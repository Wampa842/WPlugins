using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using PEPlugin.Pmx;
using PEPlugin.SDX;

namespace WPlugins.ProcessXml
{
    public static class Selector
    {
        public static class Bone
        {
            public static IEnumerable<IPXBone> Selector(XmlElement selector, IPXPmx pmx)
            {
                switch (selector.GetAttribute("method").ToLowerInvariant())
                {
                    case "index":
                        HashSet<IPXBone> bones = new HashSet<IPXBone>();
                        if (int.TryParse(selector.InnerText, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int index))
                        {
                            bones.Add(ByIndex(index, pmx));
                        }
                        return bones;
                    default:
                        return ByName(selector.InnerText, pmx);
                }
            }

            public static IEnumerable<IPXBone> ByName(string pattern, IPXPmx pmx) => pmx.Bone.Where(b => Regex.IsMatch(b.Name, pattern) || Regex.IsMatch(b.NameE, pattern));

            public static IPXBone ByIndex(int index, IPXPmx pmx) => index >= 0 && index < pmx.Bone.Count ? pmx.Bone[index] : null;
        }

        public static class Material
        {
            /// <summary>
            /// Return the materials where the names match the given regex pattern.
            /// </summary>
            public static IEnumerable<IPXMaterial> ByName(string pattern, IPXPmx pmx) => pmx.Material.Where(m => Regex.IsMatch(m.Name, pattern) || Regex.IsMatch(m.NameE, pattern));
            /// <summary>
            /// Returns the materials where the note field matches the given regex pattern.
            /// </summary>
            public static IEnumerable<IPXMaterial> ByNote(string pattern, IPXPmx pmx) => pmx.Material.Where(m => Regex.IsMatch(m.Memo, pattern));
            public static IPXMaterial ByIndex(int index, IPXPmx pmx) => index >= 0 && index < pmx.Material.Count ? pmx.Material[index] : null;
        }

        public static class Vertex
        {
            private static void Combine(HashSet<IPXVertex> dst, IEnumerable<IPXVertex> src, string mode)
            {
                switch (mode)
                {
                    case "intersect":
                    case "intersection":
                    case "and":
                        dst.IntersectWith(src);
                        break;
                    case "subtract":
                    case "sub":
                        dst.ExceptWith(src);
                        break;
                    case "replace":
                        dst.Clear();
                        dst.UnionWith(src);
                        break;
                    case "add":
                    case "union":
                    case "or":
                    default:
                        dst.UnionWith(src);
                        break;
                }
                System.Windows.Forms.MessageBox.Show(dst.Count.ToString());
            }

            /// <summary>
            /// Selects vertices based on a list of XML nodes.
            /// </summary>
            [System.Obsolete("Use SelectorNode instead.")]
            public static IEnumerable<IPXVertex> SelectorList(XmlNodeList list, IPXPmx pmx)
            {
                HashSet<IPXVertex> vertices = new HashSet<IPXVertex>();
                foreach (XmlElement selector in list.OfType<XmlElement>())
                {
                    switch (selector.Name.ToLowerInvariant())
                    {
                        case "material":
                        case "object":
                            switch (selector.GetAttribute("method").ToLowerInvariant())
                            {
                                case "index":
                                    if (int.TryParse(selector.InnerText, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int index))
                                    {
                                        vertices.UnionWith(Vertex.FromMaterial(Material.ByIndex(index, pmx)));
                                    }
                                    break;
                                case "note":
                                    vertices.UnionWith(Vertex.ByMaterialNote(selector.InnerText, pmx));
                                    break;
                                default:
                                    vertices.UnionWith(Vertex.ByMaterialName(selector.InnerText, pmx));
                                    break;
                            }
                            break;
                        case "bone":
                        case "weight":
                            switch (selector.GetAttribute("method").ToLowerInvariant())
                            {
                                case "index":
                                    if (int.TryParse(selector.InnerText, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int index))
                                    {
                                        vertices.UnionWith(Vertex.FromBoneWeight(Bone.ByIndex(index, pmx), pmx));
                                    }
                                    break;
                                default:
                                    vertices.UnionWith(Vertex.FromBoneWeight(Bone.ByName(selector.InnerText, pmx).FirstOrDefault(), pmx));
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
                return vertices;
            }

            public static IEnumerable<IPXVertex> SelectorNode(XmlElement selectorNode, IPXPmx pmx)
            {
                HashSet<IPXVertex> vertices = new HashSet<IPXVertex>();
                // <select type="material" method="name">MatName</select>
                foreach (XmlElement selector in selectorNode.ChildNodes.OfType<XmlElement>())
                {
                    string type = selector.GetAttributeCI("type").ToLowerInvariant();
                    string method = selector.GetAttributeCI("method").ToLowerInvariant();
                    string combine = selector.GetAttributeCI("combine").ToLowerInvariant();

                    switch (type)
                    {
                        // Find by material properties
                        case "material":
                        case "object":
                            switch (method)
                            {
                                case "note":
                                    //vertices.UnionWith(Vertex.ByMaterialNote(selector.InnerText, pmx));
                                    Combine(vertices, Vertex.ByMaterialNote(selector.InnerText, pmx), combine);
                                    break;
                                case "index":
                                    if (int.TryParse(selector.InnerText, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int index))
                                    {
                                        Combine(vertices, Vertex.FromMaterial(Material.ByIndex(index, pmx)), combine);
                                    }
                                    break;
                                default:
                                    Combine(vertices, Vertex.ByMaterialName(selector.InnerText, pmx), combine);
                                    break;
                            }
                            break;
                        // Find by bone weights
                        case "bone":
                        case "weight":
                            switch (method)
                            {
                                case "index":
                                    if (int.TryParse(selector.InnerText, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int index))
                                    {
                                        Combine(vertices, Vertex.FromBoneWeight(Bone.ByIndex(index, pmx), pmx), combine);
                                    }
                                    break;
                                default:
                                    Combine(vertices, Vertex.FromBoneWeight(Bone.ByName(selector.InnerText, pmx).FirstOrDefault(), pmx), combine);
                                    break;
                            }
                            break;
                        // Find by position inside box
                        case "box":
                            switch (method)
                            {
                                // Box is defined by a center position, and a size vector.
                                case "center":
                                    XmlElement centerElement = selector.GetChildElementCI("center");
                                    XmlElement sizeElement = selector.GetChildElementCI("size");
                                    if (centerElement != null && sizeElement != null)
                                    {
                                        V3 center = centerElement.GetV3();
                                        V3 size = sizeElement.GetV3();

                                        V3 a = new V3(center.X - size.X / 2, center.Y - size.Y / 2, center.Z - size.Z / 2);
                                        V3 b = new V3(center.X + size.X / 2, center.Y + size.Y / 2, center.Z + size.Z / 2);
                                        Combine(vertices, Vertex.InsideCube(a, b, pmx), combine);
                                    }
                                    break;
                                // Box is defined by its two opposite corners.
                                default:
                                    Combine(vertices, Vertex.InsideCube(selector.GetChildElementCI("a").GetV3(), selector.GetChildElementCI("b").GetV3(), pmx), combine);
                                    break;
                            }
                            break;
                        // Find by position inside sphere
                        case "sphere":
                            break;
                        // Find by position inside cylinder
                        case "cylinder":
                            break;
                        default:
                            break;
                    }
                }
                return vertices;
            }

            /// <summary>
            /// Returns the vertices of the specified material.
            /// </summary>
            public static IEnumerable<IPXVertex> FromMaterial(IPXMaterial material)
            {
                HashSet<IPXVertex> vertices = new HashSet<IPXVertex>();
                foreach (IPXFace face in material.Faces)
                {
                    vertices.Add(face.Vertex1);
                    vertices.Add(face.Vertex2);
                    vertices.Add(face.Vertex3);
                }
                return vertices;
            }

            /// <summary>
            /// Returns the vertices that belong to the given materials.
            /// </summary>
            public static IEnumerable<IPXVertex> FromMaterials(IEnumerable<IPXMaterial> materials)
            {
                HashSet<IPXVertex> vertices = new HashSet<IPXVertex>();
                foreach (IPXMaterial mat in materials)
                {
                    foreach (IPXFace face in mat.Faces)
                    {
                        vertices.Add(face.Vertex1);
                        vertices.Add(face.Vertex2);
                        vertices.Add(face.Vertex3);
                    }
                }
                return vertices;
            }

            public static IEnumerable<IPXVertex> FromBoneWeight(IPXBone bone, IPXPmx pmx) => pmx.Vertex.Where(v => v.Bone1 == bone || v.Bone2 == bone || v.Bone3 == bone || v.Bone4 == bone);

            /// <summary>
            /// Returns the vertices that belong to the materials that match the regex pattern.
            /// </summary>
            public static IEnumerable<IPXVertex> ByMaterialName(string pattern, IPXPmx pmx) => FromMaterials(Material.ByName(pattern, pmx));

            public static IEnumerable<IPXVertex> ByMaterialNote(string pattern, IPXPmx pmx) => FromMaterials(Material.ByNote(pattern, pmx));

            /// <summary>
            /// Returns the vertices that are within the specified <paramref name="radius"/> from the given <paramref name="center"/>.
            /// </summary>
            public static IEnumerable<IPXVertex> InsideSphere(V3 center, float radius, IPXPmx pmx)
            {
                float squared = radius * radius;
                return pmx.Vertex.Where(v => (v.Position - center).LengthSq() <= squared);
            }

            /// <summary>
            /// Returns the vertices that are inside the cube defined by its two opposing points.
            /// </summary>
            public static IEnumerable<IPXVertex> InsideCube(V3 a, V3 b, IPXPmx pmx)
            {
                float xmin = Math.Min(a.X, b.X);
                float xmax = Math.Max(a.X, b.X);
                float ymin = Math.Min(a.Y, b.Y);
                float ymax = Math.Max(a.Y, b.Y);
                float zmin = Math.Min(a.Z, b.Z);
                float zmax = Math.Max(a.Z, b.Z);

                return pmx.Vertex.Where(v =>
                {
                    float x = v.Position.X;
                    float y = v.Position.Y;
                    float z = v.Position.Z;

                    if (x < xmin || x > xmax) return false;
                    if (y < ymin || y > ymax) return false;
                    if (z < zmin || z > zmax) return false;
                    return true;
                });
            }
        }
    }
}
