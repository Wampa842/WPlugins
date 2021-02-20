using System;
using System.Xml;
using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ProcessXml
{
    /// <summary>
    /// Holds the references to be passed to the BackgroundWorker.
    /// </summary>
    public class RunnerArgs
    {
        public XmlDocument Document { get; private set; }
        public IPXPmx Pmx { get; private set; }
        public IPXPmxBuilder Builder { get; private set; }

        public RunnerArgs(XmlDocument document, IPXPmx pmx, IPXPmxBuilder builder)
        {
            Document = document;
            Pmx = pmx;
            Builder = builder;
        }
    }
}
