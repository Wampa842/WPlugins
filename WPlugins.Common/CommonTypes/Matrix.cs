using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEPlugin.SDX;

namespace WPlugins
{
    // Necessary because PEPlugin.SDX.M is sealed for some reason
    public class Matrix
    {
        public float M11 { get; set; }
        public float M12 { get; set; }
        public float M13 { get; set; }
        public float M14 { get; set; }

        public float M21 { get; set; }
        public float M22 { get; set; }
        public float M23 { get; set; }
        public float M24 { get; set; }

        public float M31 { get; set; }
        public float M32 { get; set; }
        public float M33 { get; set; }
        public float M34 { get; set; }

        public float M41 { get; set; }
        public float M42 { get; set; }
        public float M43 { get; set; }
        public float M44 { get; set; }

        /// <summary>
        /// Access a single value by its (0-base) index.
        /// </summary>
        public float this[int x, int y]
        {
            get
            {
                switch (x)
                {
                    case 0:
                        switch (y)
                        {
                            case 0:
                                return this.M11;
                            case 1:
                                return this.M12;
                            case 2:
                                return this.M13;
                            case 3:
                                return this.M14;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                    case 1:
                        switch (y)
                        {
                            case 0:
                                return this.M21;
                            case 1:
                                return this.M22;
                            case 2:
                                return this.M23;
                            case 3:
                                return this.M24;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                    case 2:
                        switch (y)
                        {
                            case 0:
                                return this.M31;
                            case 1:
                                return this.M32;
                            case 2:
                                return this.M33;
                            case 3:
                                return this.M34;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                    case 3:
                        switch (y)
                        {
                            case 0:
                                return this.M41;
                            case 1:
                                return this.M42;
                            case 2:
                                return this.M43;
                            case 3:
                                return this.M44;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (x)
                {
                    case 0:
                        switch (y)
                        {
                            case 0:
                                this.M11 = value;
                                break;
                            case 1:
                                this.M12 = value;
                                break;
                            case 2:
                                this.M13 = value;
                                break;
                            case 3:
                                this.M14 = value;
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                        break;
                    case 1:
                        switch (y)
                        {
                            case 0:
                                this.M21 = value;
                                break;
                            case 1:
                                this.M22 = value;
                                break;
                            case 2:
                                this.M23 = value;
                                break;
                            case 3:
                                this.M24 = value;
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                        break;
                    case 2:
                        switch (y)
                        {
                            case 0:
                                this.M31 = value;
                                break;
                            case 1:
                                this.M32 = value;
                                break;
                            case 2:
                                this.M33 = value;
                                break;
                            case 3:
                                this.M34 = value;
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                        break;
                    case 3:
                        switch (y)
                        {
                            case 0:
                                this.M41 = value;
                                break;
                            case 1:
                                this.M42 = value;
                                break;
                            case 2:
                                this.M43 = value;
                                break;
                            case 3:
                                this.M44 = value;
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public static implicit operator M(Matrix m)
        {
            M o = new M
            {
                M11 = m.M11,
                M12 = m.M12,
                M13 = m.M13,
                M14 = m.M14,

                M21 = m.M21,
                M22 = m.M22,
                M23 = m.M23,
                M24 = m.M24,

                M31 = m.M31,
                M32 = m.M32,
                M33 = m.M33,
                M34 = m.M34,

                M41 = m.M41,
                M42 = m.M42,
                M43 = m.M43,
                M44 = m.M44
            };

            return o;
        }

        public static implicit operator Matrix(M m)
        {
            Matrix o = new Matrix
            {
                M11 = m.M11,
                M12 = m.M12,
                M13 = m.M13,
                M14 = m.M14,

                M21 = m.M21,
                M22 = m.M22,
                M23 = m.M23,
                M24 = m.M24,

                M31 = m.M31,
                M32 = m.M32,
                M33 = m.M33,
                M34 = m.M34,

                M41 = m.M41,
                M42 = m.M42,
                M43 = m.M43,
                M44 = m.M44
            };

            return o;
        }

        /// <summary>
        /// Multiply two matrices.
        /// </summary>
        public static Matrix operator *(Matrix left, Matrix right)
        {
            Matrix m = new Matrix();

            float l11 = left.M11;
            float l12 = left.M12;
            float l13 = left.M13;
            float l14 = left.M14;

            float l21 = left.M21;
            float l22 = left.M22;
            float l23 = left.M23;
            float l24 = left.M24;

            float l31 = left.M31;
            float l32 = left.M32;
            float l33 = left.M33;
            float l34 = left.M34;

            float l41 = left.M41;
            float l42 = left.M42;
            float l43 = left.M43;
            float l44 = left.M44;

            float r11 = right.M11;
            float r12 = right.M12;
            float r13 = right.M13;
            float r14 = right.M14;

            float r21 = right.M21;
            float r22 = right.M22;
            float r23 = right.M23;
            float r24 = right.M24;

            float r31 = right.M31;
            float r32 = right.M32;
            float r33 = right.M33;
            float r34 = right.M34;

            float r41 = right.M41;
            float r42 = right.M42;
            float r43 = right.M43;
            float r44 = right.M44;

            // First column
            m.M11 = l11 * r11 + l12 * r21 + l13 * r31 + l14 * r41;
            m.M12 = l11 * r12 + l12 * r22 + l13 * r32 + l14 * r42;
            m.M13 = l11 * r13 + l12 * r23 + l13 * r33 + l14 * r43;
            m.M14 = l11 * r14 + l12 * r24 + l13 * r34 + l14 * r44;

            // Second column
            m.M21 = l21 * r11 + l22 * r21 + l23 * r31 + l24 * r41;
            m.M22 = l21 * r12 + l22 * r22 + l23 * r32 + l24 * r42;
            m.M23 = l21 * r13 + l22 * r23 + l23 * r33 + l24 * r43;
            m.M24 = l21 * r14 + l22 * r24 + l23 * r34 + l24 * r44;

            // Third column
            m.M31 = l31 * r11 + l32 * r21 + l33 * r31 + l34 * r41;
            m.M32 = l31 * r12 + l32 * r22 + l33 * r32 + l34 * r42;
            m.M33 = l31 * r13 + l32 * r23 + l33 * r33 + l34 * r43;
            m.M34 = l31 * r14 + l32 * r24 + l33 * r34 + l34 * r44;

            // Fourth column
            m.M41 = l41 * r11 + l42 * r21 + l43 * r31 + l44 * r41;
            m.M42 = l41 * r12 + l42 * r22 + l43 * r32 + l44 * r42;
            m.M43 = l41 * r13 + l42 * r23 + l43 * r33 + l44 * r43;
            m.M44 = l41 * r14 + l42 * r24 + l43 * r34 + l44 * r44;

            return m;
        }

        public static V4 operator *(V4 v, Matrix m)
        {
            return new V4(
                m.M11 * v.X + m.M12 * v.Y + m.M13 * v.Z + m.M14 * v.W,
                m.M21 * v.X + m.M22 * v.Y + m.M23 * v.Z + m.M24 * v.W,
                m.M31 * v.X + m.M32 * v.Y + m.M33 * v.Z + m.M34 * v.W,
                m.M41 * v.X + m.M42 * v.Y + m.M43 * v.Z + m.M44 * v.W
                );
        }

        public static M Translate(float x, float y, float z)
        {
            return new M { M41 = x, M42 = y, M43 = z };
        }

        public static M Translate(V3 offset)
        {
            return Translate(offset.X, offset.Y, offset.Z);
        }

        public static M RotateZ(float angle)
        {
            float sin = Mathf.Sin(angle);
            float cos = Mathf.Cos(angle);
            return new M
            {
                M11 = cos,
                M21 = -sin,
                M12 = sin,
                M22 = cos
            };
        }

        public static M Scale(float x, float y, float z)
        {
            return new M
            {
                M11 = x,
                M22 = y,
                M33 = z
            };
        }

        public static M Scale(V3 scale)
        {
            return Scale(scale.X, scale.Y, scale.Z);
        }

        public static V4 Multiply(V4 v, M m)
        {
            return new V4(
                m.M11 * v.X + m.M12 * v.Y + m.M13 * v.Z + m.M14 * v.W,
                m.M21 * v.X + m.M22 * v.Y + m.M23 * v.Z + m.M24 * v.W,
                m.M31 * v.X + m.M32 * v.Y + m.M33 * v.Z + m.M34 * v.W,
                m.M41 * v.X + m.M42 * v.Y + m.M43 * v.Z + m.M44 * v.W
                );
        }

        public static M Multiply(M left, M right)
        {
            M m = new M();

            float l11 = left.M11;
            float l12 = left.M12;
            float l13 = left.M13;
            float l14 = left.M14;

            float l21 = left.M21;
            float l22 = left.M22;
            float l23 = left.M23;
            float l24 = left.M24;

            float l31 = left.M31;
            float l32 = left.M32;
            float l33 = left.M33;
            float l34 = left.M34;

            float l41 = left.M41;
            float l42 = left.M42;
            float l43 = left.M43;
            float l44 = left.M44;

            float r11 = right.M11;
            float r12 = right.M12;
            float r13 = right.M13;
            float r14 = right.M14;

            float r21 = right.M21;
            float r22 = right.M22;
            float r23 = right.M23;
            float r24 = right.M24;

            float r31 = right.M31;
            float r32 = right.M32;
            float r33 = right.M33;
            float r34 = right.M34;

            float r41 = right.M41;
            float r42 = right.M42;
            float r43 = right.M43;
            float r44 = right.M44;

            // First column
            m.M11 = l11 * r11 + l12 * r21 + l13 * r31 + l14 * r41;
            m.M12 = l11 * r12 + l12 * r22 + l13 * r32 + l14 * r42;
            m.M13 = l11 * r13 + l12 * r23 + l13 * r33 + l14 * r43;
            m.M14 = l11 * r14 + l12 * r24 + l13 * r34 + l14 * r44;

            // Second column
            m.M21 = l21 * r11 + l22 * r21 + l23 * r31 + l24 * r41;
            m.M22 = l21 * r12 + l22 * r22 + l23 * r32 + l24 * r42;
            m.M23 = l21 * r13 + l22 * r23 + l23 * r33 + l24 * r43;
            m.M24 = l21 * r14 + l22 * r24 + l23 * r34 + l24 * r44;

            // Third column
            m.M31 = l31 * r11 + l32 * r21 + l33 * r31 + l34 * r41;
            m.M32 = l31 * r12 + l32 * r22 + l33 * r32 + l34 * r42;
            m.M33 = l31 * r13 + l32 * r23 + l33 * r33 + l34 * r43;
            m.M34 = l31 * r14 + l32 * r24 + l33 * r34 + l34 * r44;

            // Fourth column
            m.M41 = l41 * r11 + l42 * r21 + l43 * r31 + l44 * r41;
            m.M42 = l41 * r12 + l42 * r22 + l43 * r32 + l44 * r42;
            m.M43 = l41 * r13 + l42 * r23 + l43 * r33 + l44 * r43;
            m.M44 = l41 * r14 + l42 * r24 + l43 * r34 + l44 * r44;

            return m;
        }
    }

    public static class MatrixAccessors
    {
        public static float Get(this M m, int x, int y)
        {
            switch (x)
            {
                case 0:
                    switch (y)
                    {
                        case 0:
                            return m.M11;
                        case 1:
                            return m.M12;
                        case 2:
                            return m.M13;
                        case 3:
                            return m.M14;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                case 1:
                    switch (y)
                    {
                        case 0:
                            return m.M21;
                        case 1:
                            return m.M22;
                        case 2:
                            return m.M23;
                        case 3:
                            return m.M24;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                case 2:
                    switch (y)
                    {
                        case 0:
                            return m.M31;
                        case 1:
                            return m.M32;
                        case 2:
                            return m.M33;
                        case 3:
                            return m.M34;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                case 3:
                    switch (y)
                    {
                        case 0:
                            return m.M41;
                        case 1:
                            return m.M42;
                        case 2:
                            return m.M43;
                        case 3:
                            return m.M44;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        public static void Set(this M m, int x, int y, float value)
        {
            switch (x)
            {
                case 0:
                    switch (y)
                    {
                        case 0:
                            m.M11 = value;
                            break;
                        case 1:
                            m.M12 = value;
                            break;
                        case 2:
                            m.M13 = value;
                            break;
                        case 3:
                            m.M14 = value;
                            break;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                    break;
                case 1:
                    switch (y)
                    {
                        case 0:
                            m.M21 = value;
                            break;
                        case 1:
                            m.M22 = value;
                            break;
                        case 2:
                            m.M23 = value;
                            break;
                        case 3:
                            m.M24 = value;
                            break;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                    break;
                case 2:
                    switch (y)
                    {
                        case 0:
                            m.M31 = value;
                            break;
                        case 1:
                            m.M32 = value;
                            break;
                        case 2:
                            m.M33 = value;
                            break;
                        case 3:
                            m.M34 = value;
                            break;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                    break;
                case 3:
                    switch (y)
                    {
                        case 0:
                            m.M41 = value;
                            break;
                        case 1:
                            m.M42 = value;
                            break;
                        case 2:
                            m.M43 = value;
                            break;
                        case 3:
                            m.M44 = value;
                            break;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
