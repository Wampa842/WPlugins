using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WPlugins.ViewSettingsStorage
{
    [Flags]
    public enum DrawObjects { None = 0, Bone = 1, Vertex = 2, SelectedVertex = 4, InvisibleBone = 8, Face = 16, Normal = 32, SelectedNormal = 64, BodyWire = 128, BodySolid = 256, Joint = 512 }
    [Flags]
    public enum SelectObjects { None = 0, Vertex = 1, Face = 2, Bone = 4, Body = 8, Joint = 16 }
    public enum FillMode { Shaded, Flat, WireColor, WireBlack, Weight }

    [Serializable]
    public class Camera
    {
        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 Up { get; set; } = new Vector3(0, 1, 0);
    }

    [Serializable]
    public class ViewSettings
    {
        // Camera
        public Camera Camera { get; set; }          // Camera angle settings
        public Vector3 RotationCenter { get; set; } // Camera orbit center
        public bool Perspective { get; set; }       // Perspective/orthographic projection

        // Lights
        public Color AmbientColor { get; set; }     // Fill light color
        public Color LightColor { get; set; }       // Key light color
        public Vector3 LightDirection { get; set; } // Light direction

        // Background
        public Color BackgroundColor { get; set; }  // Solid background color
        //public bool FloorGrid { get; set; }         // Floor grid and axes

        // Visibility
        //public DrawObjects ObjectVisibility { get; set; }   // Which objects should be displayed
        //public SelectObjects ObjectSelect { get; set; }     // Which objects should be selectable
        //public FillMode Fill { get; set; }
        //public bool Wireframe { get; set; }



        public ViewSettings()
        {
            Camera = new Camera();
            BackgroundColor = Color.White;
            AmbientColor = Color.White;
            LightColor = Color.Gray;
            LightDirection = new Vector3(0.5f, 1.0f, 0.5f);
        }
    }
}
