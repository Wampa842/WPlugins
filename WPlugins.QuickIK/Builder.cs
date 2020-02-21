using System;
using System.Collections.Generic;
using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;

namespace WPlugins.QuickIK
{
    public static class Builder
    {
        private const int CURVE_POINT_COUNT = 200;
        private const bool DEBUG = false;

        // Generate straight bone chain
        public static IPXBone[] GenerateChain(IPXPmxBuilder builder, int count, Vector3 distance, Vector3 center, string name, string nameE)
        {
            IPXBone[] bones = new IPXBone[count];

            for (int i = 0; i < count; ++i)
            {
                IPXBone bone = builder.Bone();
                bone.Name = name.Replace("#", i.ToString()).Replace("&", (i + 1).ToString());
                bone.NameE = nameE.Replace("#", i.ToString()).Replace("&", (i + 1).ToString());
                bone.Position = center + (distance * i);
                if (i > 0)
                {
                    bone.Parent = bones[i - 1];
                    bone.Parent.ToBone = bone;
                }
                bones[i] = bone;
            }

            return bones;
        }

        // Create segmented bone chain
        public static IPXBone[] GenerateSegmentedChain(IPXPmxBuilder builder, int count, Vector3[] points, string name, string nameE)
        {
            IPXBone[] bones = new IPXBone[count];
            int segmentCount = points.Length - 1;
            float totalLength = 0;
            float[] segmentLengths = new float[segmentCount];

            // Determine the lengths of segments
            for (int i = 0; i < segmentCount; ++i)
            {
                float length = points[i].Distance(points[i + 1]);
                segmentLengths[i] = length;
                totalLength += length;
            }

            // Determine the number of links that can fit into each segment
            float avgDist = totalLength / count;
            int[] bonesPerSegment = new int[segmentCount];
            int remaining = count;
            for(int i = 0; i < segmentCount - 1; ++i)
            {
                bonesPerSegment[i] = Mathf.RoundToInt(segmentLengths[i] / avgDist);
                remaining -= bonesPerSegment[i];
            }
            // Put any remaining bones into the last segment
            bonesPerSegment[segmentCount - 1] = remaining;

            // Create the bones
            for(int i = 0; i < segmentCount; ++i)
            {
                System.Windows.Forms.MessageBox.Show($"{i}\t{segmentLengths[i]}");
            }

            return bones;
        }

        // Create uneven bone chain along spline
        public static IPXBone[] GenerateSplineChain(IPXPmxBuilder builder, int count, Vector3[] points, string name, string nameE)
        {
            IPXBone[] bones = new IPXBone[count];

            // Construct a cubic Bézier curve from the points
            // Place a link at every t = (1 / count) point
            float dt = 1.0f / count;
            for (int i = 0; i < count; ++i)
            {
                IPXBone bone = builder.Bone();
                bone.Name = name.Replace("#", i.ToString()).Replace("&", (i + 1).ToString());
                bone.NameE = nameE.Replace("#", i.ToString()).Replace("&", (i + 1).ToString());
                bone.Position = Mathf.Curve.BezierPoint(dt * i, points);
                if (i > 0)
                {
                    bone.Parent = bones[i - 1];
                    bone.Parent.ToBone = bone;
                }
                bones[i] = bone;
            }

            return bones;
        }

        // Create evenly spaced bone chain along spline
        public static IPXBone[] GenerateSplineChainEvenSpaced(IPXPmxBuilder builder, int count, Vector3[] points, string name, string nameE)
        {
            List<IPXBone> bones = new List<IPXBone>();

            // Identify the t values that divide the spline into a count number of equal pieces
            float deltaT = 1.0f / CURVE_POINT_COUNT;            // The density of t parameters
            Vector3[] curve = new Vector3[CURVE_POINT_COUNT];   // Calculated curve points
            float curveLength = 0;                              // The total arc length of the curve
            Vector3 previousPoint = points[0];
            for (int i = 0; i < CURVE_POINT_COUNT; ++i)
            {
                Vector3 pt = Mathf.Curve.BezierPoint(deltaT * i, points);
                curveLength += pt.Distance(previousPoint);
                previousPoint = curve[i] = pt;
            }
            float distance = curveLength / count;           // The desired arc length between links
            float[] linkT = new float[count];               // The t parameters that divide the spline into roughly equal parts; the first and last are always 0 and 1.
            linkT[0] = 0;
            linkT[count - 1] = 1;
            int linkNumber = 1;
            float distSoFar = 0;
            for (int i = 1; i < CURVE_POINT_COUNT; ++i)
            {
                distSoFar += curve[i].Distance(curve[i - 1]);
                if (distSoFar >= distance)
                {
                    linkT[linkNumber] = deltaT * i;
                    distSoFar = 0;
                    ++linkNumber;
                }
                if (linkNumber >= count)
                    break;
            }

            if (DEBUG)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder("t\tpoint\n\n");
                foreach (float t in linkT)
                    sb.AppendFormat("{0:f4}\t{1}\n", t, Mathf.Curve.BezierPoint(t, points));
                System.Windows.Forms.MessageBox.Show(sb.Append("All t values should be between 0 and 1, in incremental order.").ToString());
            }

            // Place the links at the desired t parameters
            for (int i = 0; i < count; ++i)
            {
                IPXBone bone = builder.Bone();
                bone.Name = name.Replace("#", i.ToString()).Replace("&", (i + 1).ToString());
                bone.NameE = nameE.Replace("#", i.ToString()).Replace("&", (i + 1).ToString());
                bone.Position = Mathf.Curve.BezierPoint(linkT[i], points);
                if (i > 0)
                {
                    bone.Parent = bones[i - 1];
                    bone.Parent.ToBone = bone;
                }
                bones.Add(bone);
            }

            return bones.ToArray();
        }

        // Create a physics chain that fits onto the bone chain
        public static void GeneratePhysics(IPXPmxBuilder builder, IPXBone[] bones, PhysicsSettings settings, out IPXBody[] rigidbodies, out IPXJoint[] joints)
        {
            rigidbodies = new IPXBody[bones.Length - 1];
            joints = new IPXJoint[bones.Length - 2];

            for (int i = 0; i < rigidbodies.Length; ++i)
            {
                // Basic setup
                IPXBody b = rigidbodies[i] = builder.Body();
                b.Position = Vector3.Average(bones[i].Position, bones[i + 1].Position);
                b.Bone = bones[i];
                b.Name = b.Bone.Name;
                b.NameE = b.Bone.NameE;
                b.Mode = settings.BodyMode;

                // Size
                b.BoxKind = settings.Shape;
                float w = settings.Width;
                float h = settings.Height;
                float length;
                switch (settings.LengthCalculation)
                {
                    case PhysicsSettings.LengthCalculationMode.Relative:
                        length = Vector3.Distance(bones[i].Position, bones[i + 1].Position) * settings.Length;
                        break;
                    case PhysicsSettings.LengthCalculationMode.DistanceFromEnds:
                        length = Math.Max(Vector3.Distance(bones[i].Position, bones[i + 1].Position) - settings.Length * 2, 0);
                        break;
                    default:
                        length = settings.Length;
                        break;
                }
                if (settings.Shape == PEPlugin.Pmd.BodyBoxKind.Sphere)
                {
                    b.BoxSize = new V3(length / 2.0f, 1, 1);
                }
                else
                {
                    b.BoxSize = new Vector3(w, length / 2.0f, h);
                }

                // Angle
                V3 dir = bones[i + 1].Position - bones[i].Position;
                dir.Normalize();
                float heading = Mathf.Atan2(dir.X, dir.Z);
                float theta = -heading;
                V3 elev = new V3(Mathf.Cos(theta) * dir.X + Mathf.Sin(theta) * dir.Z, dir.Y, -Mathf.Sin(theta) * dir.X + Mathf.Cos(theta) * dir.Z);
                b.Rotation = new V3(Mathf.Atan2(elev.Z, elev.Y), heading, 0);

            }

            for (int i = 0; i < joints.Length; ++i)
            {
                IPXJoint j = joints[i] = builder.Joint();
                j.Position = bones[i + 1].Position;
                j.BodyA = rigidbodies[i];
                j.BodyB = rigidbodies[i + 1];
                j.Name = j.BodyA.Name;
                j.NameE = j.BodyA.NameE;
            }
        }
    }
}
