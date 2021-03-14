using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;
#pragma warning disable IDE0018 // Inline variable declaration

namespace WPlugins.ObjIO
{
    public static class Importer
    {
        /// <summary>
        /// Splits the vertex assignment triple into its component indices.
        /// </summary>
        private static void GetVertexElements(string s, out int v, out int vt, out int vn)
        {
            v = vt = vn = -1;
            string[] split = s.Trim().Split(new char[] { '/' }, StringSplitOptions.None);

            int.TryParse(split[0], out v);
            --v;
            int.TryParse(split[1], out vt);
            --vt;
            int.TryParse(split[2], out vn);
            --vn;
        }

        /// <summary>
        /// Determines if the vertex assignment triple represents a new unique vertex, and returns its index as the out parameter.
        /// </summary>
        private static bool GetUniqueVertex(int v, int vt, int vn, Dictionary<Tuple<int, int, int>, int> dict, int vertexCount, out int index)
        {
            Tuple<int, int, int> key = new Tuple<int, int, int>(v, vt, vn);
            if (dict.ContainsKey(key))
            {
                index = dict[key];
                return false;
            }
            else
            {
                index = vertexCount;
                dict.Add(new Tuple<int, int, int>(v, vt, vn), index);
                return true;
            }
        }

        /// <summary>
        /// Parses the Material Template Library at the provided path and returns a list of materials.
        /// </summary>
        private static Dictionary<string, IPXMaterial> ImportMaterials(string path, IPXPmxBuilder builder, ImportSettings settings, IOProgress progress)
        {
            // Cancel the process if needed
            if (progress.CancellationToken.IsCancellationRequested)
                progress.CancellationToken.ThrowIfCancellationRequested();

            StreamReader reader = null;
            System.Globalization.NumberFormatInfo fi = System.Globalization.NumberFormatInfo.InvariantInfo;
            System.Globalization.NumberStyles ns = System.Globalization.NumberStyles.Float;

            Dictionary<string, IPXMaterial> materials = new Dictionary<string, IPXMaterial>();
            IPXMaterial current = null;
            int lineNumber = 0;
            char[] separator = { ' ' };

            try
            {
                reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    // Cancel the process if needed
                    if (progress.CancellationToken.IsCancellationRequested)
                        progress.CancellationToken.ThrowIfCancellationRequested();

                    string line = reader.ReadLine().Trim();
                    ++lineNumber;
                    if (string.IsNullOrWhiteSpace(line) || line[0] == '#') continue;
                    string[] split = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    switch (split[0])
                    {
                        // Diffuse color and opacity
                        case "Kd":
                            if (current != null)
                            {
                                float r = 0, g = 0, b = 0, a = 1;
                                float.TryParse(split[1], ns, fi, out r);
                                float.TryParse(split[2], ns, fi, out g);
                                float.TryParse(split[3], ns, fi, out b);
                                if (split.Length > 4)
                                {
                                    float.TryParse(split[4], ns, fi, out a);
                                }

                                current.Diffuse = new V4(r, g, b, a);
                            }
                            break;
                        // Ambient - used as emissive
                        case "Ka":
                            if (current != null)
                            {
                                float r = 0, g = 0, b = 0;
                                float.TryParse(split[1], ns, fi, out r);
                                float.TryParse(split[2], ns, fi, out g);
                                float.TryParse(split[3], ns, fi, out b);
                                current.Ambient = new V3(r, g, b);
                            }
                            break;
                        // Specular color
                        case "Ks":
                            if (current != null)
                            {
                                float r = 0, g = 0, b = 0;
                                float.TryParse(split[1], ns, fi, out r);
                                float.TryParse(split[2], ns, fi, out g);
                                float.TryParse(split[3], ns, fi, out b);
                                current.Specular = new V3(r, g, b);
                            }
                            break;
                        // Emissive
                        case "Ke":
                            if (current != null)
                            {
                                float r = 0, g = 0, b = 0;
                                float.TryParse(split[1], ns, fi, out r);
                                float.TryParse(split[2], ns, fi, out g);
                                float.TryParse(split[3], ns, fi, out b);
                                current.Ambient = new V3(r, g, b);
                            }
                            break;
                        // Opacity (1 is fully opaque)
                        case "d":
                            if (current != null)
                            {
                                if (float.TryParse(split[1], ns, fi, out float a))
                                {
                                    current.Diffuse.A = a;
                                }
                            }
                            break;
                        // Transparency (1 is fully transparent)
                        case "Tr":
                            if (current != null)
                            {
                                if (float.TryParse(split[1], ns, fi, out float a))
                                {
                                    current.Diffuse.A = 1.0f - a;
                                }
                            }
                            break;
                        // Specular exponent
                        case "Ns":
                            if (current != null)
                            {
                                if (float.TryParse(split[1], ns, fi, out float a))
                                {
                                    current.Power = a;
                                }
                            }
                            break;
                        // Illumination mode (unused)
                        case "illum":
                            break;
                        // Diffuse map
                        case "map_Kd":
                            if (current != null)
                            {
                                current.Tex = line.Substring(7);
                                if (settings.WhiteMaterialIfTextured)
                                {
                                    current.Diffuse = new V4(1, 1, 1, current.Diffuse.A);
                                    current.Ambient = new V3(0.5f, 0.5f, 0.5f);
                                }
                            }
                            break;
                        // Specular map
                        case "map_Ks":
                            break;
                        // Ambient map
                        case "map_Ka":
                            break;
                        // Begin a new material
                        case "newmtl":
                            current = builder.Material();
                            current.Name = current.NameE = line.Substring(7);
                            current.Diffuse = new V4(1, 1, 1, 1);
                            current.Ambient = new V3(0.5f, 0.5f, 0.5f);
                            current.Specular = new V3(0, 0, 0);
                            current.Power = 20;
                            current.SelfShadow = true;
                            current.SelfShadowMap = true;
                            current.Shadow = true;
                            current.BothDraw = false;

                            if (materials.ContainsKey(current.Name))
                            {
                                progress.ReportWarning(string.Format("[MTL {1}] Duplicate material found: \"{0}\".", current.Name, lineNumber));
                            }
                            else
                            {
                                materials.Add(current.Name, current);
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (OperationCanceledException) { throw; }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
            }

            return materials;
        }

        /// <summary>
        /// Parses the Wavefront Object file at the provided path and returns the operation's result.
        /// </summary>
        public static ImportResult Import(string path, IPXPmxBuilder builder, ImportSettings settings, IOProgress progress)
        {
            // Cancel the process if needed
            if (progress.CancellationToken.IsCancellationRequested)
                progress.CancellationToken.ThrowIfCancellationRequested();

            IPXPmx pmx = builder.Pmx();
            pmx.Clear();
            pmx.ModelInfo.ModelName = pmx.ModelInfo.ModelNameE = Path.GetFileNameWithoutExtension(path);
            pmx.ModelInfo.Comment = pmx.ModelInfo.CommentE = "(Imported from OBJ by WPlugins.ObjIO)";
            StreamReader reader = null;
            System.Globalization.NumberFormatInfo fi = System.Globalization.NumberFormatInfo.InvariantInfo;
            System.Globalization.NumberStyles ns = System.Globalization.NumberStyles.Float;

            // Model elements
            List<V3> vList = new List<V3>();
            List<V2> vtList = new List<V2>();
            List<V3> vnList = new List<V3>();
            Dictionary<Tuple<int, int, int>, int> vertexDictionary = new Dictionary<Tuple<int, int, int>, int>();
            Dictionary<string, IPXMaterial> materials = new Dictionary<string, IPXMaterial>();
            IPXMaterial currentMaterial = null;

            // Values derived from settings
            V3 positionScale = new V3(settings.ScaleX, settings.ScaleY, settings.ScaleZ) * (settings.UseMetricUnits ? 0.254f : 0.1f);

            // Statistics
            int lineNumber = 0;

            try
            {
                reader = new StreamReader(path);
                char[] separator = { ' ' };
                while (!reader.EndOfStream)
                {
                    System.Threading.Thread.Sleep(2);

                    // Cancel the process if needed
                    if (progress.CancellationToken.IsCancellationRequested)
                        progress.CancellationToken.ThrowIfCancellationRequested();

                    string line = reader.ReadLine().Trim();
                    ++lineNumber;
                    ++progress.LineNumber;
                    progress.Report(IOProgress.Percent(reader.BaseStream.Position, reader.BaseStream.Length));

                    // Skip empty lines and comments
                    if (string.IsNullOrWhiteSpace(line) || line[0] == '#') continue;

                    string[] split = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    switch (split[0])
                    {
                        // Vertex position
                        case "v":
                            try
                            {
                                float x = float.Parse(split[1], ns, fi);
                                float y = float.Parse(split[2], ns, fi);
                                float z = float.Parse(split[3], ns, fi);
                                vList.Add(new V3(x, y, -z));
                            }
                            catch (FormatException ex)
                            {
                                if (progress.ReportError(string.Format("A format exception has occured: {0}", line)))
                                {
                                    return ImportResult.Fail(ex, progress.WarningCount, progress.ErrorCount);
                                }
                                vList.Add(new V3());
                            }
                            break;
                        // Vertex texture coordinates
                        case "vt":
                            try
                            {
                                // Technically this can be a V3 or any vector, but PMX only uses the first two elements for the main UV channel.
                                float x = float.Parse(split[1], ns, fi);
                                float y = float.Parse(split[2], ns, fi);
                                vtList.Add(new V2(x, -y));
                            }
                            catch (FormatException ex)
                            {
                                if (progress.ReportError(string.Format("A format exception has occured: {0}", line)))
                                {
                                    return ImportResult.Fail(ex, progress.WarningCount, progress.ErrorCount);
                                }
                                vtList.Add(new V2());
                            }
                            break;
                        // Vertex normal
                        case "vn":
                            try
                            {
                                float x = float.Parse(split[1], ns, fi);
                                float y = float.Parse(split[2], ns, fi);
                                float z = float.Parse(split[3], ns, fi);
                                vnList.Add(new V3(x, y, -z));
                            }
                            catch (FormatException ex)
                            {
                                if (progress.ReportError(string.Format("A format exception has occured: {0}", line)))
                                {
                                    return ImportResult.Fail(ex, progress.WarningCount, progress.ErrorCount);
                                }
                                vnList.Add(new V3());
                            }
                            break;
                        // Face definition
                        case "f":
                            if (currentMaterial == null)
                            {
                                progress.ReportWarning(string.Format("Encountered a face record when no active group was set.", lineNumber));
                                currentMaterial = builder.Material();
                            }

                            // Triangle
                            if (split.Length == 4)
                            {
                                int v = 0;
                                int vt = 0;
                                int vn = 0;
                                bool newVertex;

                                try
                                {
                                    // Split each vertex assignment triple into its respective v/vt/vn indices.
                                    GetVertexElements(split[1], out v, out vt, out vn);
                                    // Based on the indices, determine if the vertex assignment is unique or already exists. A vertex is considered unique if one or more index is different, regardless of the vectors they represent.
                                    newVertex = GetUniqueVertex(v, vt, vn, vertexDictionary, pmx.Vertex.Count, out int index1);
                                    if (newVertex)
                                    {
                                        IPXVertex vert = builder.Vertex();
                                        pmx.Vertex.Add(vert);   // The new vertex is added to the end of the list, making its index equal to the list's count before the addition.
                                        if (v >= 0)
                                            vert.Position = vList[v] * positionScale;
                                        if (vt >= 0)
                                            vert.UV = vtList[vt];
                                        if (vn >= 0)
                                            vert.Normal = vnList[vn];
                                    }
                                    IPXVertex vertex1 = pmx.Vertex[index1];

                                    // Repeat the same process for the rest of the vertex triples.
                                    GetVertexElements(split[2], out v, out vt, out vn);
                                    newVertex = GetUniqueVertex(v, vt, vn, vertexDictionary, pmx.Vertex.Count, out int index2);
                                    if (newVertex)
                                    {
                                        IPXVertex vert = builder.Vertex();
                                        pmx.Vertex.Add(vert);
                                        if (v >= 0)
                                            vert.Position = vList[v] * positionScale;
                                        if (vt >= 0)
                                            vert.UV = vtList[vt];
                                        if (vn >= 0)
                                            vert.Normal = vnList[vn];
                                    }
                                    IPXVertex vertex2 = pmx.Vertex[index2];

                                    GetVertexElements(split[3], out v, out vt, out vn);
                                    newVertex = GetUniqueVertex(v, vt, vn, vertexDictionary, pmx.Vertex.Count, out int index3);
                                    if (newVertex)
                                    {
                                        IPXVertex vert = builder.Vertex();
                                        pmx.Vertex.Add(vert);
                                        if (v >= 0)
                                            vert.Position = vList[v] * positionScale;
                                        if (vt >= 0)
                                            vert.UV = vtList[vt];
                                        if (vn >= 0)
                                            vert.Normal = vnList[vn];
                                    }
                                    IPXVertex vertex3 = pmx.Vertex[index3];

                                    // Build the triangle and assign the vertices; use reverse order and negative normal vectors if the triangles are reversed.
                                    IPXFace face = builder.Face();
                                    if (settings.FlipFaces)
                                    {
                                        vertex1.Normal *= -1;
                                        vertex2.Normal *= -1;
                                        vertex3.Normal *= -1;
                                        face.Vertex1 = vertex1;
                                        face.Vertex2 = vertex2;
                                        face.Vertex3 = vertex3;
                                    }
                                    else
                                    {
                                        face.Vertex1 = vertex3;
                                        face.Vertex2 = vertex2;
                                        face.Vertex3 = vertex1;
                                    }
                                    currentMaterial.Faces.Add(face);
                                }
                                catch (Exception ex)
                                {
                                    if (progress.ReportError(ex.ToString()))
                                    {
                                        return ImportResult.Fail(ex, progress.WarningCount, progress.ErrorCount);
                                    }
                                }
                            }
                            // Quad
                            else if (split.Length == 5)
                            {
                                int v = 0;
                                int vt = 0;
                                int vn = 0;
                                bool newVertex;
                                try
                                {
                                    GetVertexElements(split[1], out v, out vt, out vn);
                                    newVertex = GetUniqueVertex(v, vt, vn, vertexDictionary, pmx.Vertex.Count, out int index1);
                                    if (newVertex)
                                    {
                                        IPXVertex vert = builder.Vertex();
                                        pmx.Vertex.Add(vert);
                                        if (v >= 0)
                                            vert.Position = vList[v] * positionScale;
                                        if (vt >= 0)
                                            vert.UV = vtList[vt];
                                        if (vn >= 0)
                                            vert.Normal = vnList[vn];
                                    }
                                    IPXVertex vertex1 = pmx.Vertex[index1];

                                    GetVertexElements(split[2], out v, out vt, out vn);
                                    newVertex = GetUniqueVertex(v, vt, vn, vertexDictionary, pmx.Vertex.Count, out int index2);
                                    if (newVertex)
                                    {
                                        IPXVertex vert = builder.Vertex();
                                        pmx.Vertex.Add(vert);
                                        if (v >= 0)
                                            vert.Position = vList[v] * positionScale;
                                        if (vt >= 0)
                                            vert.UV = vtList[vt];
                                        if (vn >= 0)
                                            vert.Normal = vnList[vn];
                                    }
                                    IPXVertex vertex2 = pmx.Vertex[index2];

                                    GetVertexElements(split[3], out v, out vt, out vn);
                                    newVertex = GetUniqueVertex(v, vt, vn, vertexDictionary, pmx.Vertex.Count, out int index3);
                                    if (newVertex)
                                    {
                                        IPXVertex vert = builder.Vertex();
                                        pmx.Vertex.Add(vert);
                                        if (v >= 0)
                                            vert.Position = vList[v] * positionScale;
                                        if (vt >= 0)
                                            vert.UV = vtList[vt];
                                        if (vn >= 0)
                                            vert.Normal = vnList[vn];
                                    }
                                    IPXVertex vertex3 = pmx.Vertex[index3];

                                    GetVertexElements(split[4], out v, out vt, out vn);
                                    newVertex = GetUniqueVertex(v, vt, vn, vertexDictionary, pmx.Vertex.Count, out int index4);
                                    if (newVertex)
                                    {
                                        IPXVertex vert = builder.Vertex();
                                        pmx.Vertex.Add(vert);
                                        if (v >= 0)
                                            vert.Position = vList[v] * positionScale;
                                        if (vt >= 0)
                                            vert.UV = vtList[vt];
                                        if (vn >= 0)
                                            vert.Normal = vnList[vn];
                                    }
                                    IPXVertex vertex4 = pmx.Vertex[index4];

                                    int faceIndex1 = 0, faceIndex2 = 0;
                                    IPXFace face = builder.Face();
                                    if (settings.FlipFaces)
                                    {
                                        face.Vertex3 = settings.TurnQuads ? vertex3 : vertex4;
                                        face.Vertex2 = vertex2;
                                        face.Vertex1 = vertex1;
                                        currentMaterial.Faces.Add(face);
                                        faceIndex1 = currentMaterial.Faces.Count - 1;

                                        face = builder.Face();
                                        face.Vertex1 = settings.TurnQuads ? vertex1 : vertex2;
                                        face.Vertex2 = vertex3;
                                        face.Vertex3 = vertex4;
                                        currentMaterial.Faces.Add(face);
                                        faceIndex2 = currentMaterial.Faces.Count - 1;
                                    }
                                    else
                                    {
                                        face.Vertex1 = settings.TurnQuads ? vertex3 : vertex4;
                                        face.Vertex2 = vertex2;
                                        face.Vertex3 = vertex1;
                                        currentMaterial.Faces.Add(face);
                                        faceIndex1 = currentMaterial.Faces.Count - 1;

                                        face = builder.Face();
                                        face.Vertex3 = settings.TurnQuads ? vertex1 : vertex2;
                                        face.Vertex2 = vertex3;
                                        face.Vertex1 = vertex4;
                                        currentMaterial.Faces.Add(face);
                                        faceIndex2 = currentMaterial.Faces.Count - 1;
                                    }

                                    if (settings.SaveTrianglePairs)
                                    {
                                        currentMaterial.Memo += string.Format("({0},{1})", faceIndex1, faceIndex2);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (progress.ReportError(ex.ToString()))
                                    {
                                        return ImportResult.Fail(ex, progress.WarningCount, progress.ErrorCount);
                                    }
                                }
                            }
                            else
                            {
                                if (progress.ReportError(string.Format("The OBJ file contains a polygon with an invalid number of vertices. Currently only triangles and quads are supported. Line content: {0}", line)))
                                {
                                    return ImportResult.Fail(new InvalidOperationException("Invalid polygon"), progress.WarningCount, progress.ErrorCount);
                                }
                            }
                            break;
                        // Group assignment defines which PMX object (IPXMaterial instance) the subsequent faces belong to.
                        case "g":
                            currentMaterial = builder.Material();
                            currentMaterial.Name = currentMaterial.NameE = line.Trim().Substring(2);
                            progress.Report("New object: " + currentMaterial.Name);
                            pmx.Material.Add(currentMaterial);
                            // Set default properties
                            currentMaterial.Diffuse = new V4(1, 1, 1, 1);
                            currentMaterial.Ambient = new V3(0.5f, 0.5f, 0.5f);
                            break;
                        // Material assignment defines which material template should be applied to the currently active PMX object. Any number of PMX objects can refer to a single material template.
                        case "usemtl":
                            if (currentMaterial == null)
                            {
                                progress.ReportWarning(string.Format("Encountered a material template reference when no active group was set.", lineNumber));
                                currentMaterial = builder.Material();
                            }
                            {
                                string name = line.Trim().Substring(7);
                                IPXMaterial m = currentMaterial;    // Active material
                                IPXMaterial t = materials[name];    // Template material
                                m.Diffuse = t.Diffuse;
                                m.Specular = t.Specular;
                                m.Power = t.Power;
                                m.Ambient = t.Ambient;
                                m.Diffuse = t.Diffuse;
                                m.SelfShadow = t.SelfShadow;
                                m.SelfShadowMap = t.SelfShadowMap;
                                m.Shadow = t.Shadow;
                                m.Tex = t.Tex;
                                m.EdgeSize = t.EdgeSize;
                                m.EdgeColor = t.EdgeColor;
                                m.Edge = t.Edge;
                            }
                            break;
                        // Material library, may occur multiple times in a model.
                        case "mtllib":
                            string materialLibraryName = line.Substring(7);
                            progress.Report("Importing materials from " + materialLibraryName);
                            // Try relative path
                            string materialLibraryPath = Path.Combine(Path.GetDirectoryName(path), materialLibraryName);
                            if (!File.Exists(materialLibraryPath))
                            {
                                // Try absolute path
                                materialLibraryPath = materialLibraryName;
                                if (!File.Exists(materialLibraryPath))
                                {
                                    progress.ReportError(string.Format("Material library not found ({0}).", materialLibraryName));
                                    break;
                                }
                            }
                            Dictionary<string, IPXMaterial> tempDict = ImportMaterials(materialLibraryPath, builder, settings, progress);
                            foreach (KeyValuePair<string, IPXMaterial> kvp in tempDict)
                            {
                                if (materials.ContainsKey(kvp.Key))
                                {
                                    progress.ReportWarning(string.Format("Duplicate material {0} imported from {1} has been discarded.", kvp.Key, materialLibraryName));
                                }
                                else
                                {
                                    materials.Add(kvp.Key, kvp.Value);
                                }
                            }
                            progress.Report(string.Format("Imported {0} materials from {1}.", tempDict.Count, materialLibraryName));
                            break;
                        // Smoothing group assignment (unused)
                        case "s":
                            break;
                        default:
                            break;
                    }
                }

                // Second pass for bone weights and transformations because I'm lazy
                IPXBone bone = null;
                if (settings.CreateBone != ImportSettings.CreateBoneMode.None)
                {
                    bone = builder.Bone();
                    bone.Name = bone.NameE = pmx.ModelInfo.ModelName.Replace(' ', '_');
                }
                foreach (IPXVertex vertex in pmx.Vertex)
                {
                    // Bone
                    if (settings.CreateBone == ImportSettings.CreateBoneMode.Average)
                    {
                        bone.Position += vertex.Position;
                    }
                    vertex.Bone1 = settings.CreateBone != ImportSettings.CreateBoneMode.None ? bone : null;
                    vertex.Weight1 = 1.0f;
                    vertex.Bone2 = vertex.Bone3 = vertex.Bone4 = null;
                    vertex.Weight2 = vertex.Weight3 = vertex.Weight4 = 0;

                    // Axis swap
                    if (settings.SwapYZ)
                    {
                        float temp = vertex.Position.Y;
                        vertex.Position.Y = vertex.Position.Z;
                        vertex.Position.Z = temp;
                        temp = vertex.Normal.Y;
                        vertex.Normal.Y = vertex.Normal.Z;
                        vertex.Normal.Z = temp;
                    }
                }
                if (settings.CreateBone == ImportSettings.CreateBoneMode.Average)
                {
                    bone.Position /= pmx.Vertex.Count;
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                if (progress.ReportError(ex.ToString()))
                {
                    return ImportResult.Fail(ex, progress.WarningCount, progress.ErrorCount);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
            }

            return ImportResult.Success(pmx, progress.WarningCount, progress.ErrorCount);
        }
    }
}
