using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace SVNE.Core {
    class Character : Drawable {
        public string Name;
        public string ResPath;
        public string Color;

        public Sprite sprite;
        public Vector2f position;

        public int x;
        public int y;
        public int width;
        public int height;

        public Character(string Name, string ResPath, float scale) : base() {
            this.Name = Name;
            this.ResPath = ResPath;
            this.Color = "black";

            sprite = new Sprite(new Texture(ResPath));
            sprite.Scale = new Vector2f(scale, scale);
            ChangePos("center"); //Default
        }

        public Character(string Name, string ResPath, string Color) {
            this.Name = Name;
            this.ResPath = ResPath;
            this.Color = Color;

            sprite = new Sprite(new Texture(ResPath));
        }

        public int ChangePos(string position) {
            if(position.Equals("center")) {
                sprite.Position = new Vector2f(((SVNE.window.Size.X / 2) - ((sprite.GetGlobalBounds().Width * Game.xRatio) / 2)) / Game.xRatio, (SVNE.window.Size.Y - (sprite.GetGlobalBounds().Height * Game.yRatio)) / Game.xRatio);
            }
            else if(position.Equals("truecenter")) {

            }
            else if (position.Equals("top")) {

            }
            else if (position.Equals("left")) {
                sprite.Position = new Vector2f(0, (SVNE.window.Size.Y - (sprite.GetGlobalBounds().Height * Game.yRatio)) / Game.xRatio);
            }
            else if (position.Equals("right")) {
                sprite.Position = new Vector2f((SVNE.window.Size.X - (sprite.GetGlobalBounds().Width * Game.xRatio)) / Game.xRatio, (SVNE.window.Size.Y - (sprite.GetGlobalBounds().Height * Game.yRatio)) / Game.xRatio);
            }
            else if (position.Equals("topleft")) {

            }
            else if (position.Equals("topright")) {

            }
            else {
                
            }

            return 0;
        }

        public void Draw(RenderTarget target, RenderStates states) {
            target.Draw(sprite, states);
        }
    }
}
