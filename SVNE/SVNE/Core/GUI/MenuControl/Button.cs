using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SVNE.Core.GUI.MenuControl {
    class Button : Drawable {
        public Texture idle;
        public Texture clicked;
        public Sprite sprite;
        public int x;
        public int y;
        public int width;
        public int height;

        public Button(Texture idle, Texture clicked, int x, int y, int width, int height) {
            this.idle = idle;
            this.clicked = clicked;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            sprite = new Sprite(idle, new IntRect(x, y, width, height));
        }

        public void Clicked() {
            Console.WriteLine("Button clicked");
            sprite = new Sprite(clicked, new IntRect(x, y, width, height)); ;
        }

        public void Draw(RenderTarget target, RenderStates states) {
            target.Draw(sprite, states);
        }
    }
}
