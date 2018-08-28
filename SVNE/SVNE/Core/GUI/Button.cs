using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace SVNE.Core.GUI {
    class Button : Clickable, Drawable {
        public Sprite notPressed;
        public Sprite pressed;
        public Sprite sprite;
        public int x;
        public int y;
        public int width;
        public int height;

        public Button(Texture notPressed, Texture pressed, int x, int y, int width, int height) : base() {
            this.notPressed = new Sprite(notPressed, new IntRect(x, y, width, height));
            this.pressed = new Sprite(pressed, new IntRect(x, y, width, height));
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            this.notPressed.Texture.Repeated = true;
            this.pressed.Texture.Repeated = true;
            sprite = new Sprite(notPressed, new IntRect(x, y, width, height));
        }

        public void MouseDown() {
            Console.WriteLine("mouse down");
            sprite = pressed;
        }

        public void MouseUp() {
            Console.WriteLine("mouse up");
            sprite = notPressed;
        }

        public void Draw(RenderTarget target, RenderStates states) {
            sprite.Origin = new Vector2f(-x, -y);
            target.Draw(sprite, states);
        }
    }
}
