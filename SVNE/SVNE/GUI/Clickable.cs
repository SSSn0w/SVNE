using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SVNE.GUI {
    interface Clickable : Drawable {
        int GetX { get; set; }
        int GetY { get; set; }
        int GetWidth { get; set; }
        int GetHeight { get; set; }
        void MouseDown(RenderWindow window);
        void MouseUp();
        void Hover();
        void Reset();
    }
}
