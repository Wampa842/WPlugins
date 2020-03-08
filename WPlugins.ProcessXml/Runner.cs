using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ProcessXml
{
    public static class Runner
    {
        /// <summary>
        /// Determines what should happen if a name collision occurs.
        /// </summary>
        public enum CollisionAction { Keep, Replace, New }

        public static bool ValidateXml(XmlDocument doc, Action<string> log)
        {
            bool valid = true;

            //XmlElement root = doc.DocumentElement;
            //foreach(XmlElement node in root)
            //{
            //    switch(node.Name.ToLowerInvariant())
            //    {
            //        case "create":

            //            break;
            //        default:    // Unknown nodes are ignored
            //            break;
            //    }
            //}

            return valid;
        }

        public static void Execute(XmlDocument doc, IPXPmx pmx, IPXPmxBuilder builder, Action<string> log)
        {
            XmlElement root = doc.DocumentElement;
            foreach(XmlElement node in root)
            {
                switch(node.Name.ToLowerInvariant())
                {
                    case "create":
                        switch(node["type"].InnerText.ToLowerInvariant())
                        {
                            case "bone":
                                {
                                    string name = "";
                                    IPXBone bone = null;
                                    if (node["name"] != null)
                                    {
                                        name = node["name"].InnerText;
                                        if(pmx.Bone.Any(b => b.Name.ToLowerInvariant() == name))
                                        {
                                            // If a collision occurs, refer to the "collision" attribute to decide
                                            XmlNode coll = node["name"].Attributes["collision"];
                                            if (coll == null || coll.InnerText == "keep")
                                            {
                                                // Keep the old bone and skip the command
                                                break;
                                            }
                                            else if(coll.InnerText == "replace")
                                            {
                                                // Modify the old bone
                                                bone = pmx.Bone.Where(b => b.Name.ToLowerInvariant() == name).FirstOrDefault();
                                            }
                                            else
                                            {
                                                // Create a new bone
                                                bone = builder.Bone();
                                                name += bone.GetHashCode().ToString();
                                            }
                                        }
                                        else
                                        {
                                            // If there's no collision, create a new bone
                                            bone = builder.Bone();
                                        }
                                    }

                                    bone = builder.Bone();
                                    bone.Name = bone.NameE = name;

                                    if (node["position"] != null)
                                    {
                                        XmlElement pos = node["position"];
                                        float x = 0;
                                        float.TryParse(pos["x"].InnerText, out x);
                                        float y = 0;
                                        float.TryParse(pos["y"].InnerText, out y);
                                        float z = 0;
                                        float.TryParse(pos["z"].InnerText, out z);
                                        bone.Position = new PEPlugin.SDX.V3(x, y, z);
                                    }
                                    if(node["translation"] != null)
                                    {
                                        bone.IsTranslation = bool.TryParse(node["translation"].InnerText, out bool translation) ? translation : false;
                                    }
                                    pmx.Bone.Add(bone);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "mbox":
                    case "messagebox":
                        System.Windows.Forms.MessageBox.Show(node.InnerText);
                        break;
                    case "echo":
                    case "print":
                        log.Invoke(node.InnerText);
                        break;
                    case "weightobject":
                        {// Get the names
                            string boneName = "";
                            List<string> objNames = new List<string>();
                            List<string> objTags = new List<string>();

                            foreach (XmlElement e in node)
                            {
                                switch(e.Name.ToLowerInvariant())
                                {
                                    case "object":
                                        objNames.Add(e.InnerText);
                                        break;
                                    case "tag":
                                        objTags.Add(e.InnerText);
                                        break;
                                    case "bone":
                                        boneName = e.InnerText;
                                        break;

                                }
                            }

                            // Find the actual objects
                            List<IPXVertex> vertices = new List<IPXVertex>();
                            IPXBone bone = pmx.Bone.Where(b => Regex.IsMatch(b.Name, boneName)).FirstOrDefault();
                            if (bone == null)
                            {
                                log.Invoke(string.Format("[weightobject] Bone not found: {0}", boneName));
                                break;
                            }

                            IEnumerable<IPXMaterial> materials =
                                from m in pmx.Material
                                where objNames.Any(name => Regex.IsMatch(m.Name, name))
                                || objTags.Any(tag => m.Memo.Contains(tag))
                                select m;

                            // Set vertex weights
                            foreach (IPXMaterial material in materials)
                            {
                                foreach (IPXFace face in material.Faces)
                                {
                                    face.Vertex1.Bone1 = bone;
                                    face.Vertex1.Weight1 = 1;
                                    face.Vertex2.Bone1 = bone;
                                    face.Vertex2.Weight1 = 1;
                                    face.Vertex3.Bone1 = bone;
                                    face.Vertex3.Weight1 = 1;
                                }
                            }

                            log.Invoke(string.Format("[weightobject] Weighted {0} objects to {1}", materials.Count(), boneName));
                        }
                        break;
                    default:    // ignore unknown nodes
                        break;
                }
            }

            
        }
    }
}
