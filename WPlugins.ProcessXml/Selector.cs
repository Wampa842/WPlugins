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

                    switch (type)
                    {
                        case "material":
                        case "object":
                            switch (method)
                            {
                                case "note":
                                    vertices.UnionWith(Vertex.ByMaterialNote(selector.InnerText, pmx));
                                    break;
                                case "index":
                                    if (int.TryParse(selector.InnerText, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int index))
                                    {
                                        vertices.UnionWith(Vertex.FromMaterial(Material.ByIndex(index, pmx)));
                                    }
                                    break;
                                default:
                                    vertices.UnionWith(Vertex.ByMaterialName(selector.InnerText, pmx));
                                    break;
                            }
                            break;
                        case "bone":
                        case "weight":
                            switch (method)
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
                HashSet<IPXVertex> vertices = new HashSet<IPXVertex>();
                float squared = radius * radius;
                foreach (IPXVertex v in pmx.Vertex)
                {
                    V3 dist = v.Position - center;
                    if (dist.LengthSq() <= squared)
                    {
                        vertices.Add(v);
                    }
                }
                return vertices;
            }
        }
    }
}
