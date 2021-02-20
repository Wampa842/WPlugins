using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;

namespace WPlugins.ProcessXml
{
    public static class Runner
    {
        private static BackgroundWorker _worker;
        private static Action<string, int> _report;
        private static Action<IPXPmx> _update;

        // This is just to make my work easier so I don't have to typecast to float and back to int
        private static int Percent(float amount, float total) => (int)Math.Round((amount / total) * 100);
        /// <summary>
        /// Global settings for scene manipulation and execution.
        /// </summary>
        private static class GlobalSettings
        {
            public enum ErrorHandling { Abort, Continue, Ask }

            public static ErrorHandling Exception { get; set; } = ErrorHandling.Ask;
            public static float Epsilon { get; set; } = 0;
            public static bool RegexCaseInsensitive { get; set; } = false;
            public static bool ColorIsFloat { get; set; } = true;

            public static RegexOptions GetRegexOptions()
            {
                RegexOptions o = RegexOptions.None;
                o |= RegexCaseInsensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
                return o;
            }
        }
        
        /// <summary>
        /// Begins execution in a background worker.
        /// </summary>
        public static async void ExecuteAsync(XmlDocument doc, IPXPmx pmx, IPXPmxBuilder builder, Action<string, int> report, Action<IPXPmx> update)
        {
            _report = report;
            _update = update;
            await Task.Run(() => _worker.RunWorkerAsync(new RunnerArgs(doc, pmx, builder)));
        }

        /// <summary>
        /// Requests cancellation on the background worker.
        /// </summary>
        public static void CancelWorker()
        {
            _worker.CancelAsync();
        }

        private static void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // If the result is a PMX object, the execution was successful and the scene can be updated.
            if (e.Result is IPXPmx)
            {
                _report("> Execution completed successfully.", 100);
                _update((IPXPmx)e.Result);
            }
            // If the result is an exception, the execution was interrupted by an error. The user is notified and the scene is NOT updated.
            else if (e.Result is Exception)
            {
                _report("> Interrupted by " + e.Result.GetType().ToString(), -1);
                _report(e.ToString(), -1);
            }
            // If the result is null, the execution was interrupted by cancellation.
            else if (e.Result == null)
            {
                _report("> Cancelled by user", -1);
            }
            // If this point is reached, something fucky is going on.
            else
            {
                _report("> I don't know how you reached this point... something weird is going on.", -1);
            }
        }

        private static void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _report((string)e.UserState, e.ProgressPercentage);
        }

        private static void WorkerDoWork(object sender, DoWorkEventArgs eventArgs)
        {
            // Get some more convenient references
            BackgroundWorker worker = (BackgroundWorker)sender;
            RunnerArgs args = (RunnerArgs)eventArgs.Argument;
            XmlElement root = args.Document.DocumentElement;
            IPXPmx pmx = args.Pmx;
            IPXPmxBuilder builder = args.Builder;

            worker.ReportProgress(0, "> Execution started.");

            // Begin processing
            // Only the first level of elements are interpreted as commands.
            XmlElement[] commands = root.ChildNodes.OfType<XmlElement>().ToArray();
            for (int i = 0; i < commands.Length; ++i)
            {
                try
                {
                    XmlElement node = commands[i];

                    // The meaningful content of each case constitutes a separate block to avoid mixing variables. Might be unnecessary, but right now I'm not feeling too hot and my output WILL be sloppy.
                    // Should review this code later.
                    switch (node.Name.ToLowerInvariant())
                    {
                        // Creates a new bone with the provided properties.
                        case "bone":
                            {
                                string name = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();
                                IPXBone bone = null;

                                // Get name and check for collision
                                if (node["name"] != null)
                                {
                                    name = node["name"].InnerText;

                                    IPXBone existing = pmx.Bone.Where(b => b.Name == name).FirstOrDefault();
                                    if (existing != null)
                                    {
                                        // If there is a collision, refer to the collision attribute
                                        switch (node["name"].GetAttribute("collision"))
                                        {
                                            // If the attribute is "update" or "replace", refer to the existing bone for the rest of the command.
                                            case "replace":
                                            case "update":
                                                bone = existing;
                                                break;
                                            // If the attribute is "skip", don't do anything with the bone and skip the command.
                                            case "skip":
                                                continue;
                                            // If the attribute is not valid, create a new bone and ignore the old one.
                                            default:
                                                bone = builder.Bone();
                                                bone.Name = bone.NameE = name;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        bone = builder.Bone();
                                        bone.Name = bone.NameE = name;
                                    }
                                }
                                else
                                {
                                    bone = builder.Bone();
                                    bone.Name = bone.NameE = name;
                                }

                                if (node["position"] != null)
                                {
                                    bone.Position = node["position"].GetV3();
                                }
                                if (node["translation"] != null)
                                {
                                    bone.IsTranslation = bool.TryParse(node["translation"].InnerText, out bool translation) ? translation : false;
                                }
                                if (node["parent"] != null)
                                {
                                    bone.Parent = Selector.Bone.Selector(node["parent"], pmx).FirstOrDefault();
                                }
                                if (node["axis"] != null)
                                {
                                    V3 v = node["axis"].GetV3();
                                    v.Normalize();
                                    bone.IsFixAxis = true;
                                    bone.FixAxis = v;
                                }
                                if (node["weight"] != null)
                                {
                                    //IEnumerable<IPXVertex> vertices = Selector.Vertex.SelectorList(node["weight"].ChildNodes, pmx);
                                    IEnumerable<IPXVertex> vertices = Selector.Vertex.SelectorNode(node["weight"], pmx);
                                    foreach (IPXVertex v in vertices)
                                    {
                                        v.Bone1 = bone;
                                        v.Weight1 = 1;
                                        v.Bone2 = v.Bone3 = v.Bone4 = null;
                                        v.Weight2 = v.Weight3 = v.Weight4 = 0;
                                    }
                                }
                                pmx.Bone.Add(bone);
                                worker.ReportProgress(Percent(i + 1, commands.Length), string.Format("[bone] Added new bone {0}.", bone.Name));
                            }
                            break;
                        // Assigns the selected vertices to the selected bone using BDEF1.
                        case "weight":
                            {
                                IPXBone bone = null;
                                if (node["target"] != null)
                                {
                                    bone = Selector.Bone.Selector(node["target"], pmx).FirstOrDefault();
                                    if (bone == null)
                                    {
                                        worker.ReportProgress(Percent(i + 1, commands.Length), string.Format("[weight] Bone was not found.", node["target"].InnerText));
                                        break;
                                    }
                                }
                                else
                                {
                                    worker.ReportProgress(Percent(i + 1, commands.Length), "[weight] Bone selector was not specified.");
                                    break;
                                }

                                // Set vertex weights
                                if (node["select"] == null)
                                {
                                    worker.ReportProgress(Percent(i + 1, commands.Length), "[weight] No vertices were selected.");
                                    break;
                                }
                                IEnumerable<IPXVertex> vertices = Selector.Vertex.SelectorNode(node["select"], pmx);
                                foreach (IPXVertex v in vertices)
                                {
                                    v.Bone1 = bone;
                                    v.Weight1 = 1;
                                    v.Bone2 = v.Bone3 = v.Bone4 = null;
                                    v.Weight2 = v.Weight3 = v.Weight4 = 0;
                                }

                                worker.ReportProgress(Percent(i + 1, commands.Length), string.Format("[weight] Weighted {0} vertices to {1} ({2}).", vertices.Count(), bone.Name, bone.NameE));
                            }
                            break;
                        // Creates a new UV morph.
                        case "uvmorph":
                            {
                                // The morph's properties are defined in attributes.
                                IPXMorph morph = builder.Morph();
                                morph.Kind = MorphKind.UV;

                                // Set the UV channel
                                if (int.TryParse(node.GetAttribute("channel"), out int ch))
                                {
                                    switch (ch)
                                    {
                                        case 1:
                                            morph.Kind = MorphKind.UVA1;
                                            break;
                                        case 2:
                                            morph.Kind = MorphKind.UVA2;
                                            break;
                                        case 3:
                                            morph.Kind = MorphKind.UVA3;
                                            break;
                                        case 4:
                                            morph.Kind = MorphKind.UVA4;
                                            break;
                                        default:
                                            morph.Kind = MorphKind.UV;
                                            break;
                                    }
                                }

                                // Set the group panel
                                if (int.TryParse(node.GetAttribute("group"), out int group) && group <= 4 && group >= 0)
                                {
                                    morph.Panel = group;
                                }
                                else
                                {
                                    switch (node.GetAttribute("group").ToLowerInvariant())
                                    {
                                        case "hidden":
                                        case "hide":
                                        case "none":
                                        case "0":
                                            morph.Panel = 0;
                                            break;
                                        case "eyebrow":
                                        case "eyebrows":
                                        case "1":
                                            morph.Panel = 1;
                                            break;
                                        case "eye":
                                        case "eyes":
                                        case "2":
                                            morph.Panel = 2;
                                            break;
                                        case "mouth":
                                        case "3":
                                            morph.Panel = 3;
                                            break;
                                        default:
                                            morph.Panel = 4;
                                            break;
                                    }
                                }

                                // Set the name, ignore collisions
                                if (node.HasAttribute("name"))
                                {
                                    morph.Name = morph.NameE = node.GetAttribute("name");
                                }
                                else
                                {
                                    morph.Name = morph.NameE = morph.GetHashCode().ToString();
                                }

                                // Each morph contains one or more steps. Each step has its own selectors and transforms, which are applied independently.
                                foreach (XmlElement step in node.ChildNodes.OfType<XmlElement>().Where(el => el.Name.ToLowerInvariant() == "step"))
                                {
                                    // Skip steps that have no selectors
                                    if (step["select"] == null)
                                        continue;
                                    // Select vertices
                                    IEnumerable<IPXVertex> vertices = Selector.Vertex.SelectorNode(step["select"], pmx);
                                    foreach (XmlElement e in step)
                                    {
                                        switch (e.Name.ToLowerInvariant())
                                        {
                                            case "pan":
                                            case "translate":
                                                {
                                                    V2 v = e.GetV2();
                                                    foreach (IPXVertex vertex in vertices)
                                                    {
                                                        IPXUVMorphOffset offset = builder.UVMorphOffset();
                                                        offset.Vertex = vertex;
                                                        offset.Offset = new V4(v.X, v.Y, 0, 0);
                                                        morph.Offsets.Add(offset);
                                                    }
                                                }
                                                break;
                                            case "rotate":  // TODO: UV morph rotation
                                            case "scale":   // TODO: UV morph scaling
                                            default:
                                                break;
                                        }
                                    }
                                }

                                pmx.Morph.Add(morph);
                                worker.ReportProgress(Percent(i + 1, commands.Length), string.Format("[uvmorph] Created UV morph {0} with {1} offsets.", morph.Name, morph.Offsets.Count));
                            }
                            break;
                        // No particular functionality, testing only.
                        case "test":
                            {
                                //foreach (IPXMorph morph in pmx.Morph.Where(m => m.Kind == MorphKind.UV))
                                //{
                                //    foreach (IPXUVMorphOffset o in morph.Offsets)
                                //    {
                                //        _report(string.Format("{0:f2}, {1:f2}, {2:f2}, {3:f2}", o.Offset.X, o.Offset.Y, o.Offset.Z, o.Offset.W), -1);
                                //    }
                                //}
                            }
                            break;
                        // Sets up the selected vertices for use with AutoLuminous.
                        case "autoluminous":
                            {
                                if (node["select"] == null)
                                {
                                    worker.ReportProgress(Percent(i + 1, commands.Length), "[weight] No vertices were selected.");
                                    break;
                                }
                                IEnumerable<IPXVertex> vertices = Selector.Vertex.SelectorNode(node["select"], pmx);

                                // Set required values.
                                pmx.Header.UVACount = Math.Max(pmx.Header.UVACount, 3);

                                // UV1
                                int texture = 0;
                                int hsv = 0;
                                float flashFrequency = 0;
                                // UV2
                                V4 baseColor = new V4(0, 0, 0, 0);
                                // UV3
                                float texSubtract = 0;
                                float flashBias = 0;
                                float push = 0;

                                // Base emissive color
                                if (node["color"] != null)
                                {
                                    baseColor = node["color"].GetV4();
                                }

                                // Base emissive power
                                if (node["power"] != null)
                                {
                                    baseColor.W = node["power"].GetSingle();
                                }

                                if (node["texture"] != null)
                                {
                                    int.TryParse(node["texture"].InnerText, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out texture);
                                }

                                if (node["colormode"] != null)
                                {
                                    switch (node["colormode"].InnerText.ToLowerInvariant())
                                    {
                                        case "hsv":
                                            hsv = 10;
                                            break;
                                        default:
                                            hsv = 0;
                                            break;
                                    }
                                }

                                if (node["flash"] != null)
                                {
                                    float.TryParse(node["flash"].GetAttribute("bias"), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out flashBias);
                                    flashFrequency = node["flash"].GetSingle();
                                }

                                if (node["subtract"] != null)
                                {
                                    texSubtract = node["subtract"].GetSingle();
                                }

                                if (node["push"] != null)
                                {
                                    push = node["push"].GetSingle();
                                }

                                foreach (IPXVertex v in vertices)
                                {
                                    v.UVA1.X = 0.2f;    // Required value
                                    v.UVA1.Y = 0.7f;    // Required value
                                    v.UVA1.Z = flashFrequency;
                                    v.UVA1.W = texture + hsv;

                                    v.UVA2 = baseColor;

                                    v.UVA3.X = texSubtract;
                                    v.UVA3.Y = flashBias;
                                    v.UVA3.Z = push;
                                }
                            }
                            break;
                        // Creates a vertex morph for AutoLuminous properties.
                        case "almorph":
                            {
                                if (node["select"] == null)
                                {
                                    worker.ReportProgress(Percent(i + 1, commands.Length), "[weight] No vertices were selected.");
                                    break;
                                }
                                HashSet<IPXVertex> vertices = new HashSet<IPXVertex>(Selector.Vertex.SelectorNode(node["select"], pmx));

                                V4 color = new V4();

                                if (node["color"] != null)
                                {
                                    color = node["color"].GetV4();
                                }

                                // TODO: Implement the rest of the AL properties in ALMorph

                                IPXMorph morph = builder.Morph();
                                morph.Kind = MorphKind.UVA2;
                                if (node.HasAttribute("name"))
                                {
                                    morph.Name = morph.NameE = node.GetAttribute("name");
                                }
                                else
                                {
                                    morph.Name = morph.NameE = morph.GetHashCode().ToString();
                                }

                                foreach (IPXVertex v in vertices)
                                {
                                    // Set required values in case the vertex isn't already AL-enabled
                                    v.UVA1.X = 0.2f;
                                    v.UVA1.Y = 0.7f;
                                    // Create the offset
                                    morph.Offsets.Add(builder.UVMorphOffset(v, color));
                                }
                            }
                            break;
                        // Sets environment variables.
                        case "settings":
                            {
                                foreach(XmlElement child in node.ChildNodes.OfType<XmlElement>())
                                {
                                    switch (child.Name.ToLowerInvariant())
                                    {
                                        case "exception":
                                            break;
                                        case "regex":
                                            bool regexCI = GlobalSettings.RegexCaseInsensitive;
                                            bool.TryParse(child.GetAttributeCI("caseinsensitive"), out regexCI);
                                            break;
                                        case "colortype":
                                            GlobalSettings.ColorIsFloat = child.InnerText.ToLowerInvariant() == "float";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            break;
                        // Displays a MessageBox with the provided content. Optionally perform certain actions based on user input.
                        case "mbox":
                        case "messagebox":
                        case "prompt":
                            {
                                if (int.TryParse(node.GetAttributeCI("skip"), out int skipNumber) && skipNumber > 0)
                                {
                                    StringBuilder sb = new StringBuilder(string.Format("Would you like to skip the following {0} command(s)?\n", skipNumber));
                                    for(int j = 1; j <= skipNumber; ++j)
                                    {
                                        sb.Append(commands[i + j].Name);
                                    }
                                    MessageBox.Show(sb.ToString(), "Prompt: skip", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                }
                                else
                                {
                                    MessageBox.Show(node.InnerText, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            break;
                        // Prints a line in the console.
                        case "echo":
                        case "print":
                            worker.ReportProgress(Percent(i + 1, commands.Length), node.InnerText);
                            break;
                        default:
                            worker.ReportProgress(Percent(i + 1, commands.Length), "Skipping unknown command " + node.Name);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (GlobalSettings.Exception == GlobalSettings.ErrorHandling.Ask)
                    {
                        if (System.Windows.Forms.MessageBox.Show(string.Format("The following exception has occured:\n\n{0}\n\nWould you like to continue execution?", ex.ToString()), "Exception", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.No)
                        {
                            eventArgs.Result = ex;
                            return;
                        }
                    }
                    else if (GlobalSettings.Exception == GlobalSettings.ErrorHandling.Abort)
                    {
                        eventArgs.Result = ex;
                        return;
                    }
                }
            }

            // If control has reached this point, the execution is considered successful and e.Result can be set.
            eventArgs.Result = pmx;
        }

        static Runner()
        {
            // Initialize the BackgroundWorker
#pragma warning disable IDE0017 // Simplify object initialization
            _worker = new BackgroundWorker();
#pragma warning restore IDE0017 // Simplify object initialization
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += WorkerDoWork;
            _worker.ProgressChanged += WorkerProgressChanged;
            _worker.RunWorkerCompleted += WorkerCompleted;
        }
    }
}
