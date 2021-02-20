using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPlugins
{
    /// <summary>
    /// A collection of mathematical methods that operate on floating-point types. To hell with Microsoft's obsession with quadruple precision.
    /// </summary>
    public static class Mathf
    {
        /// <summary>
        /// Provides methods for parametric curve calculations.
        /// </summary>
        public static class Curve
        {
            /// <summary>
            /// Determine a point on an Nth order Bézier curve using De Casteljau's algorithm.
            /// </summary>
            /// <param name="t">The parameter of the curve's function.</param>
            /// <param name="points">The array of vectors that define the curve's control points.</param>
            public static Vector3 BezierPoint(float t, Vector3[] points)
            {
                if (points.Length <= 0)
                    return new Vector3();
                int n = points.Length - 1;
                Vector3[] q = (Vector3[])points.Clone();
                for (int i = 0; i <= n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        q[j] = (1 - t) * q[j] + t * q[j + 1];
                    }
                }
                return q[0];
            }

            private static float CatmullRomGetT(float t, Vector3 t0, Vector3 t1, float alpha = 0.5f)
            {
                float a = Mathf.Pow(t1.X - t0.X, 2) + Mathf.Pow(t1.Y - t0.Y, 2) + Mathf.Pow(t1.Z - t0.Z, 2);
                float b = Mathf.Sqrt(a);
                float c = Mathf.Pow(b, alpha);
                return c + t;
            }
        }

        public const float PI = 3.14159265358979323846264338327950288419716939937510f;
        public static float Sin(double x) => (float)Math.Sin(x);
        public static float Cos(double x) => (float)Math.Cos(x);
        public static float Atan2(double x, double y) => (float)Math.Atan2(x, y);
        public static int RoundToInt(double x) => (int)Math.Round(x);
        public static int FloorToInt(double x) => (int)Math.Floor(x);
        public static int CeilingToInt(double x) => (int)Math.Ceiling(x);
        public static float Pow(double a, double exponent) => (float)Math.Pow(a, exponent);
        public static float Sqrt(double a) => (float)Math.Sqrt(a);
        public static float Rad(this double deg) => (float)(deg * (PI / 180));
        public static float Deg(this double rad) => (float)(rad * (180 / PI));
    }
}
