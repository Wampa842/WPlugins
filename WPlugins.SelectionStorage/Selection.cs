using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.SelectionStorage
{
    public class Selection
    {
        public string Name { get; set; }
        public int[] Vertex { get; set; }
        public int[] Triangle { get; set; }
        public int[] Bone { get; set; }
        public int[] Rigidbody { get; set; }
        public int[] Joint { get; set; }

        public Selection()
        {
            Name = "";
            Vertex = new int[0];
            Triangle = new int[0];
            Bone = new int[0];
            Rigidbody = new int[0];
            Joint = new int[0];
        }

        public Selection(PEPlugin.View.IPXPmxViewConnector connector)
        {
            Name = "";
            Vertex = connector.GetSelectedVertexIndices();
            Triangle = connector.GetSelectedFaceIndices();
            Bone = connector.GetSelectedBoneIndices();
            Rigidbody = connector.GetSelectedBodyIndices();
            Joint = connector.GetSelectedJointIndices();
        }

        public Selection(PEPlugin.View.IPXPmxViewConnector connector, string name) : this(connector)
        {
            Name = name;
        }
    }
}
