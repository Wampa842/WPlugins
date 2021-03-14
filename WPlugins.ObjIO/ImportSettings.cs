using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace WPlugins.ObjIO
{
    [Serializable]
    public class ImportSettings
    {
        public enum CreateBoneMode { None = 0, Origin = 1, Average = 2 };
        public enum MaterialNamingMode { Numbered = 0, GroupName = 1, BitmapName = 2 }

        public bool UseMetricUnits { get; set; } = false;
        public bool FlipFaces { get; set; } = false;
        public bool SwapYZ { get; set; } = false;
        public bool TurnQuads { get; set; } = false;
        public bool SaveTrianglePairs { get; set; } = false;
        public bool WhiteMaterialIfTextured { get; set; } = true;

        public bool UniformScale { get; set; } = true;
        public bool UniformUVScale { get; set; } = true;
        public float ScaleX { get; set; } = 1.0f;
        public float ScaleY { get; set; } = 1.0f;
        public float ScaleZ { get; set; } = 1.0f;
        public float ScaleU { get; set; } = 1.0f;
        public float ScaleV { get; set; } = 1.0f;
        public CreateBoneMode CreateBone { get; set; } = CreateBoneMode.None;
        public MaterialNamingMode MaterialNaming { get; set; } = MaterialNamingMode.GroupName;

        internal static string FilePath => Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "WPlugins.ObjIO.ImportSettings.xml");

        internal static void Save(ImportSettings data)
        {
            Export(FilePath, data);
        }

        internal static ImportSettings Load()
        {
            return Import(FilePath);
        }

        internal static void Export(string path, ImportSettings data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSettings));
            XmlWriter writer = null;

            try
            {
                writer = XmlWriter.Create(new FileStream(path, FileMode.Create));
                serializer.Serialize(writer, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        internal static ImportSettings Import(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSettings));
            XmlReader reader = null;

            try
            {
                reader = XmlReader.Create(new FileStream(path, FileMode.Open));
                return (ImportSettings)serializer.Deserialize(reader);
            }
            catch (FileNotFoundException)
            {
                return new ImportSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return new ImportSettings();
        }
    }
}
