using System.Xml;
using System.Linq;
using PEPlugin.SDX;

#pragma warning disable IDE0018
// TODO: fix "#pragma warning disable IDE0018", use GetAttributeCI in the getter methods

namespace WPlugins.ProcessXml
{
    /// <summary>
    /// Extension methods to easily read float and float-vector values from an XML node.
    /// </summary>
    internal static class XmlExtensions
    {
        /*
        internal static V2 GetV2(this XmlNode node)
        {
            float x = 0;
            float.TryParse(node["x"].InnerText, out x);
            float y = 0;
            float.TryParse(node["y"].InnerText, out y);
            return new V2(x, y);
        }

        internal static V3 GetV3(this XmlNode node)
        {
            float x = 0;
            float.TryParse(node["x"].InnerText, out x);
            float y = 0;
            float.TryParse(node["y"].InnerText, out y);
            float z = 0;
            float.TryParse(node["z"].InnerText, out z);
            return new V3(x, y, z);
        }

        internal static V4 GetV4(this XmlNode node)
        {
            float x = 0;
            float.TryParse(node["x"].InnerText, out x);
            float y = 0;
            float.TryParse(node["y"].InnerText, out y);
            float z = 0;
            float.TryParse(node["z"].InnerText, out z);
            float w = 0;
            float.TryParse(node["w"].InnerText, out w);
            return new V4(x, y, z, w);
        }

        internal static float GetSingle(this XmlNode node)
        {
            float x = 0;
            float.TryParse(node["x"].InnerText, out x);
            return x;
        }*/

        /// <summary>
        /// Reads a <see cref="V4"/> value from an XML element's x, y, z, w attributes.
        /// </summary>
        internal static V4 GetV4(this XmlElement node)
        {
            System.Globalization.NumberStyles s = System.Globalization.NumberStyles.Float;
            System.IFormatProvider f = System.Globalization.NumberFormatInfo.InvariantInfo;
            float x = 0;
            if (!(float.TryParse(node.GetAttribute("x"), s, f, out x) || float.TryParse(node.GetAttribute("X"), s, f, out x) || float.TryParse(node.GetAttribute("u"), s, f, out x) || float.TryParse(node.GetAttribute("U"), s, f, out x)))
            { }
            float y = 0;
            if (!(float.TryParse(node.GetAttribute("y"), s, f, out y) || float.TryParse(node.GetAttribute("Y"), s, f, out y) || float.TryParse(node.GetAttribute("v"), s, f, out y) || float.TryParse(node.GetAttribute("V"), s, f, out y)))
            { }
            float z = 0;
            if (!float.TryParse(node.GetAttribute("z"), s, f, out z))
                float.TryParse(node.GetAttribute("Z"), s, f, out z);
            float w = 0;
            if (!float.TryParse(node.GetAttribute("w"), s, f, out w))
                float.TryParse(node.GetAttribute("W"), s, f, out w);

            return new V4(x, y, z, w);
        }

        /// <summary>
        /// Reads a <see cref="V3"/> value from an XML element's x, y, z attributes.
        /// </summary>
        internal static V3 GetV3(this XmlElement node)
        {
            System.Globalization.NumberStyles s = System.Globalization.NumberStyles.Float;
            System.IFormatProvider f = System.Globalization.NumberFormatInfo.InvariantInfo;
            float x = 0;
            if (!(float.TryParse(node.GetAttribute("x"), s, f, out x) || float.TryParse(node.GetAttribute("X"), s, f, out x) || float.TryParse(node.GetAttribute("u"), s, f, out x) || float.TryParse(node.GetAttribute("U"), s, f, out x)))
            { }
            float y = 0;
            if (!(float.TryParse(node.GetAttribute("y"), s, f, out y) || float.TryParse(node.GetAttribute("Y"), s, f, out y) || float.TryParse(node.GetAttribute("v"), s, f, out y) || float.TryParse(node.GetAttribute("V"), s, f, out y)))
            { }
            float z = 0;
            if (!float.TryParse(node.GetAttribute("z"), out z))
                float.TryParse(node.GetAttribute("Z"), out z);

            return new V3(x, y, z);
        }

        /// <summary>
        /// Reads a <see cref="V2"/> value from an XML element's x, y or u, v attributes.
        /// </summary>
        internal static V2 GetV2(this XmlElement node)
        {
            System.Globalization.NumberStyles s = System.Globalization.NumberStyles.Float;
            System.IFormatProvider f = System.Globalization.NumberFormatInfo.InvariantInfo;
            float x = 0;
            if (!(float.TryParse(node.GetAttribute("x"), s, f, out x) || float.TryParse(node.GetAttribute("X"), s, f, out x) || float.TryParse(node.GetAttribute("u"), s, f, out x) || float.TryParse(node.GetAttribute("U"), s, f, out x)))
            { }
            float y = 0;
            if (!(float.TryParse(node.GetAttribute("y"), s, f, out y) || float.TryParse(node.GetAttribute("Y"), s, f, out y) || float.TryParse(node.GetAttribute("v"), s, f, out y) || float.TryParse(node.GetAttribute("V"), s, f, out y)))
            { }

            return new V2(x, y);
        }

        /// <summary>
        /// Reads a <see cref="System.Single"/> value from an XML element's inner text.
        /// </summary>
        internal static float GetSingle(this XmlElement node)
        {
            System.Globalization.NumberStyles s = System.Globalization.NumberStyles.Float;
            System.IFormatProvider f = System.Globalization.NumberFormatInfo.InvariantInfo;
            float x = 0;
            float.TryParse(node.InnerText, s, f, out x);
            return x;
        }

        /// <summary>
        /// Reads a <see cref="System.Single"/> value from an XML element's attribute specified by its name.
        /// </summary>
        internal static float GetSingle(this XmlElement node, string attribute)
        {
            System.Globalization.NumberStyles s = System.Globalization.NumberStyles.Float;
            System.IFormatProvider f = System.Globalization.NumberFormatInfo.InvariantInfo;
            float x = 0;
            float.TryParse(node.GetAttribute(attribute), s, f, out x);
            return x;
        }

        /// <summary>
        /// Returns the value of an XmlElement's attribute of the given name. Case-insensitive.
        /// </summary>
        internal static string GetAttributeCI(this XmlElement node, string name)
        {
            if (!node.HasAttributes)
                return string.Empty;

            string lowerCaseName = name.ToLowerInvariant();
            XmlAttribute attribute = node.Attributes.OfType<XmlAttribute>().Where(a => a.Name.ToLowerInvariant() == lowerCaseName).FirstOrDefault();

            if (attribute == null)
                return string.Empty;
            return attribute.InnerText;
        }

        /// <summary>
        /// Returns the node's child node of the given name. Case-insensitive.
        /// </summary>
        internal static XmlNode GetChildCI(this XmlNode node, string name)
        {
            if (!node.HasChildNodes)
                return null;

            string lowerCaseName = name.ToLowerInvariant();
            return node.ChildNodes.OfType<XmlNode>().Where(a => a.Name.ToLowerInvariant() == lowerCaseName).FirstOrDefault();
        }

        /// <summary>
        /// Returns the node's child element of the given name. Case-insensitive.
        /// </summary>
        internal static XmlElement GetChildElementCI(this XmlNode node, string name)
        {
            if (!node.HasChildNodes)
                return null;

            string lowerCaseName = name.ToLowerInvariant();
            return node.ChildNodes.OfType<XmlElement>().Where(a => a.Name.ToLowerInvariant() == lowerCaseName).FirstOrDefault();
        }
    }
}
