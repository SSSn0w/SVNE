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
        bool IsDisplayed { get; set; }
        bool MouseInBounds(RenderWindow window);
        bool MouseDown(RenderWindow window);
        bool MouseUp(RenderWindow window);
        bool Hover(RenderWindow window);
        void Reset();
    }
}
