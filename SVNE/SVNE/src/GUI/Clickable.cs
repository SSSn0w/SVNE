using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SVNE.GUI {
    interface Clickable : Drawable {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        bool IsDisplayed { get; set; }
        bool IsMouseDown { get; set; }
        bool MouseInBounds(RenderWindow window);
        bool MouseDown(RenderWindow window);
        bool MouseUp(RenderWindow window);
        bool Hover(RenderWindow window);
        void Reset();
    }
}
