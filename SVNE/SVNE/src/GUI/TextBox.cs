using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SVNE.GUI {
    class TextBox : Clickable {
        public int x;
        public int y;
        public int width;
        public int height;

        public bool isDisplaying;
        public bool mouseDown;

        public TextBox() {

        }

        public int GetX {
            get { return x; }
            set { x = value; }
        }

        public int GetY {
            get { return y; }
            set { y = value; }
        }

        public int GetWidth {
            get { return width; }
            set { width = value; }
        }

        public int GetHeight {
            get { return height; }
            set { height = value; }
        }

        public bool IsDisplayed {
            get { return isDisplaying; }
            set { isDisplaying = value; }
        }

        public bool IsMouseDown {
            get { return mouseDown; }
            set { mouseDown = value; }
        }

        public bool MouseInBounds(RenderWindow window) {
            throw new NotImplementedException();
        }

        public bool MouseDown(RenderWindow window) {
            throw new NotImplementedException();
        }

        public bool MouseUp(RenderWindow window) {
            throw new NotImplementedException();
        }

        public bool Hover(RenderWindow window) {
            throw new NotImplementedException();
        }

        public void Reset() {

        }

        public void Draw(RenderTarget target, RenderStates states) {
            //target.Draw(sprite, states);
        }
    }
}
