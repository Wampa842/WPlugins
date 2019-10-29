using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.SelectionStorage
{
    /// <summary>
    /// Holds the indices of selected items in a PMX View instance.
    /// </summary>
    public class Selection : ICloneable
    {
        /// <summary>
        /// The displayed name of the selection
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Indices of selected vertices
        /// </summary>
        public int[] Vertex { get; set; }
        /// <summary>
        /// Indices of selected triangles
        /// </summary>
        public int[] Triangle { get; set; }
        /// <summary>
        /// Indices of selected bones
        /// </summary>
        public int[] Bone { get; set; }
        /// <summary>
        /// Indices of selected rigid bodies
        /// </summary>
        public int[] Rigidbody { get; set; }
        /// <summary>
        /// Indices of selected joints
        /// </summary>
        public int[] Joint { get; set; }

        /// <summary>
        /// Initializes a new instance of a Selection class.
        /// </summary>
        public Selection()
        {
            Name = "";
            Vertex = new int[0];
            Triangle = new int[0];
            Bone = new int[0];
            Rigidbody = new int[0];
            Joint = new int[0];
        }

        /// <summary>
        /// Initializes a new instance of a Selection class with the given indices.
        /// </summary>
        public Selection(string name, int[] vertex, int[] triangle, int[] bone, int[] rigidbody, int[] joint)
        {
            Name = name;
            Vertex = vertex;
            Triangle = triangle;
            Bone = bone;
            Rigidbody = rigidbody;
            Joint = joint;
        }

        /// <summary>
        /// Initializes a new instance of a Selection class from the given <see cref="PEPlugin.View.IPXPmxViewConnector"/> reference.
        /// </summary>
        public Selection(PEPlugin.View.IPXPmxViewConnector connector)
        {
            Name = "";
            Vertex = connector.GetSelectedVertexIndices();
            Triangle = connector.GetSelectedFaceIndices();
            Bone = connector.GetSelectedBoneIndices();
            Rigidbody = connector.GetSelectedBodyIndices();
            Joint = connector.GetSelectedJointIndices();
        }

        /// <summary>
        /// Initializes a new instance of a Selection class with the given name and <see cref="PEPlugin.View.IPXPmxViewConnector"/> reference.
        /// </summary>
        public Selection(PEPlugin.View.IPXPmxViewConnector connector, string name) : this(connector)
        {
            Name = name;
        }

        /// <summary>
        /// Creates a new Selection instance where items are the elements of any of the operands.
        /// </summary>
        /// <returns>The union of operands.</returns>
        public static Selection Union(params Selection[] operands)
        {
            // Given the sets A, B, C, D
            // returns ((A u B) u C) u D
            if (operands.Length <= 0) return new Selection();
            Selection result = (Selection)operands[0].Clone();
            for (int i = 1; i < operands.Length; ++i)
            {
                result.Vertex = result.Vertex.Union(operands[i].Vertex).ToArray();
                result.Triangle = result.Triangle.Union(operands[i].Triangle).ToArray();
                result.Bone = result.Bone.Union(operands[i].Bone).ToArray();
                result.Rigidbody = result.Rigidbody.Union(operands[i].Rigidbody).ToArray();
                result.Joint = result.Joint.Union(operands[i].Joint).ToArray();
            }
            return result;
        }

        /// <summary>
        /// Creates a new Selection instance where items must be elements of all operands.
        /// </summary>
        /// <returns>The intersect of all operands.</returns>
        public static Selection Intersect(params Selection[] operands)
        {
            // Given the sets A, B, C, D
            // returns ((A n B) n C) n D
            if (operands.Length <= 0) return new Selection();
            Selection result = (Selection)operands[0].Clone();
            for (int i = 1; i < operands.Length; ++i)
            {
                result.Vertex = result.Vertex.Intersect(operands[i].Vertex).ToArray();
                result.Triangle = result.Triangle.Intersect(operands[i].Triangle).ToArray();
                result.Bone = result.Bone.Intersect(operands[i].Bone).ToArray();
                result.Rigidbody = result.Rigidbody.Intersect(operands[i].Rigidbody).ToArray();
                result.Joint = result.Joint.Intersect(operands[i].Joint).ToArray();
            }
            return result;
        }

        /// <summary>
        /// Creates a new Selection instance where items are elements of the first operand, but not elements of subsequent operands.
        /// </summary>
        /// <returns>The relative complement of the first operand with the union of all subsequent operands.</returns>
        public static Selection Except(params Selection[] operands)
        {
            // Given the sets A, B, C, D
            // returns A \ (B u C u D)
            if (operands.Length <= 0) return new Selection();
            Selection result = (Selection)operands[0].Clone();
            for (int i = 1; i < operands.Length; ++i)
            {
                result.Vertex = result.Vertex.Except(operands[i].Vertex).ToArray();
                result.Triangle = result.Triangle.Except(operands[i].Triangle).ToArray();
                result.Bone = result.Bone.Except(operands[i].Bone).ToArray();
                result.Rigidbody = result.Rigidbody.Except(operands[i].Rigidbody).ToArray();
                result.Joint = result.Joint.Except(operands[i].Joint).ToArray();
            }
            return result;
        }

        public object Clone()
        {
            Selection clone = new Selection();
            clone.Name = this.Name;
            clone.Vertex = (int[])this.Vertex.Clone();
            clone.Triangle = (int[])this.Triangle.Clone();
            clone.Bone = (int[])this.Bone.Clone();
            clone.Rigidbody = (int[])this.Rigidbody.Clone();
            clone.Joint = (int[])this.Joint.Clone();
            return clone;
        }
    }
}
