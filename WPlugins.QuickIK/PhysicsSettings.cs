using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEPlugin.Pmd;
using PEPlugin.Pmx;

namespace WPlugins.QuickIK
{
    public class PhysicsSettings
    {
        public enum LengthCalculationMode { Absolute, Relative, DistanceFromEnds }
        public LengthCalculationMode LengthCalculation { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public BodyMode BodyMode { get; set; }
        public BodyBoxKind Shape { get; set; }
        //public IPXBody Parent { get; set; }
        public bool AttachToParent { get; set; }
        //public static PhysicsSettings Default => new PhysicsSettings() { LengthCalculation = LengthCalculationMode.Relative, Length = 1, Width = 0.2f, Height = 0.2f, BodyMode = BodyMode.Static, Shape = BodyBoxKind.Sphere, Parent = null };
        public static PhysicsSettings Default => new PhysicsSettings() { LengthCalculation = LengthCalculationMode.Relative, Length = 1, Width = 0.2f, Height = 0.2f, BodyMode = BodyMode.Static, Shape = BodyBoxKind.Sphere, AttachToParent = false };
    }
}
