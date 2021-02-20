using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace WPlugins
{
    /// <summary>
    /// A vector of three elements representing a position in 3D space.
    /// </summary>
    [Serializable]
    public struct Vector3 : ISerializable, PEPlugin.Pmd.IPEVector3
    {
        #region Properties
        /// <summary>
        /// Position on the horizontal axis. Positive values are on the right side.
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Position on the vertical axis. Positive values are above the ground plane.
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// Position on the depth axis. Positive values are in front of the zero plane.
        /// </summary>
        public float Z { get; set; }
        /// <summary>
        /// Represents the red value of a color. Identical to the X property.
        /// </summary>
        public float R { get { return X; } set { X = value; } }
        /// <summary>
        /// Represents the green value of a color. Identical to the Y property.
        /// </summary>
        public float G { get { return Y; } set { Y = value; } }
        /// <summary>
        /// Represents the blue value of a color. Identical to the Z property.
        /// </summary>
        public float B { get { return Z; } set { Z = value; } }
        /// <summary>
        /// Access XYZ members by index.
        /// </summary>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    case 2:
                        Z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        #endregion

        #region Overrides and interfaces
        // Serialize
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", X);
            info.AddValue("y", Y);
            info.AddValue("z", Z);
        }

        public object Clone()
        {
            return new Vector3(X, Y, Z);
        }

        public override string ToString()
        {
            return string.Format("({0:f4}, {1:f4}, {2:f4})", X, Y, Z);
        }

        public string ToString(string format)
        {
            return string.Format("({0}, {1}, {2})", X.ToString(format), Y.ToString(format), Z.ToString(format));
        }
        #endregion

        #region Constructors
        // Deserialize
        public Vector3(SerializationInfo info, StreamingContext context)
        {
            X = info.GetSingle("x");
            Y = info.GetSingle("y");
            Z = info.GetSingle("z");
        }

        // XYZ vector
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // From PEPlugin interface
        public Vector3(PEPlugin.Pmd.IPEVector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }
        #endregion

        #region Operators
        // Implicit conversion to SlimDX type
        public static implicit operator PEPlugin.SDX.V3(Vector3 v) => new PEPlugin.SDX.V3(v.X, v.Y, v.Z);

        // Type casting from SlimDX type
        public static implicit operator Vector3(PEPlugin.SDX.V3 v) => new Vector3(v.X, v.Y, v.Z);

        // Multiply by scalar
        public static Vector3 operator *(Vector3 a, float b) => new Vector3(a.X * b, a.Y * b, a.Z * b);
        public static Vector3 operator *(float a, Vector3 b) => b * a;

        // Divide by scalar
        public static Vector3 operator /(Vector3 a, float b) => a * (1 / b);

        // Add two vectors
        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        // Subtract two vectors
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        #endregion

        #region Maths
        /// <summary>
        /// The square of the vector's magnitude.
        /// </summary>
        public float Magnitude2 => X * X + Y * Y + Z * Z;
        /// <summary>
        /// The vector's magnitude.
        /// </summary>
        public float Magnitude => (float)Math.Sqrt(Magnitude2);

        /// <summary>
        /// The vector's norm (unit vector).
        /// </summary>
        public Vector3 Normalized => this / Magnitude;

        /// <summary>
        /// The square of the distance from another vector.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float Distance2(Vector3 other) => (this - other).Magnitude2;

        /// <summary>
        /// Distance from another vector.
        /// </summary>
        public float Distance(Vector3 other) => (this - other).Magnitude;
        #endregion

        #region Maths (static)
        public enum Plane { YZ = 0, XZ = 1, XY = 2 }

        /// <summary>
        /// The distance between two vectors.
        /// </summary>
        public static float Distance(Vector3 a, Vector3 b) => a.Distance(b);

        /// <summary>
        /// The square of the distance between two vectors.
        /// </summary>
        public static float Distance2(Vector3 a, Vector3 b) => a.Distance2(b);

        /// <summary>
        /// The average of two vectors.
        /// </summary>
        public static Vector3 Average(Vector3 a, Vector3 b) => (a + b) / 2;

        public static Vector3 Normalize(Vector3 v) => v.Normalized;

        /// <summary>
        /// The dot product of two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Dot(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        /// <summary>
        /// Find the angle (radians) between two vectors on a given plane.
        /// </summary>
        public static float AxisAngleBetween(Vector3 a, Vector3 b, Plane plane)
        {
            float a1, b1, a2, b2;
            switch (plane)
            {
                case Plane.YZ:
                    a1 = a.Y;
                    a2 = a.Z;
                    b1 = b.Y;
                    b2 = b.Z;
                    break;
                case Plane.XZ:
                    a1 = a.X;
                    a2 = a.Z;
                    b1 = b.X;
                    b2 = b.Z;
                    break;
                default:
                    a1 = a.X;
                    a2 = a.Y;
                    b1 = b.X;
                    b2 = b.Y;
                    break;
            }

            float dot = a1 * b1 + a2 * b2;
            float magA = (float)Math.Sqrt(a1 * a1 + a2 * a2);
            float magB = (float)Math.Sqrt(b1 * b1 + b2 * b2);
            return (float)Math.Acos(dot / (magA * magB));
        }

        /// <summary>
        /// Find the Euler angles (in radians) between two vectors.
        /// </summary>
        public static Vector3 AnglesBetween(Vector3 a, Vector3 b)
        {
            return new Vector3(AxisAngleBetween(a, b, Plane.YZ), AxisAngleBetween(a, b, Plane.XZ), AxisAngleBetween(a, b, Plane.XY));
        }
        #endregion
    }
}
