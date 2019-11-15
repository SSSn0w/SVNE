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
        public float Scale;
        public Color Color;

        public Sprite sprite;

        public int x;
        public int y;
        public int width;
        public int height;

        public Character(string Name, string ResPath, float Scale) : base() {
            this.Name = Name;
            this.ResPath = ResPath;
            this.Scale = Scale;
            this.Color = new Color(0, 0, 0);

            sprite = new Sprite(new Texture(ResPath));
            sprite.Scale = new Vector2f(Scale, Scale);
            ChangePos("center"); //Default
        }

        public Character(string Name, string ResPath, float Scale, Color Color) {
            this.Name = Name;
            this.ResPath = ResPath;
            this.Scale = Scale;
            this.Color = Color;

            sprite = new Sprite(new Texture(ResPath));
            sprite.Scale = new Vector2f(Scale, Scale);
            sprite.Color = Color;
            ChangePos("center"); //Default
        }

        public Character(string Name, string ResPath, Color Color) {
            this.Name = Name;
            this.ResPath = ResPath;
            this.Color = Color;

            sprite = new Sprite(new Texture(ResPath));
        }

        public Character(string Name) {
            this.Name = Name;
            sprite = null;// new Sprite();
        }

        public int ChangePos(string position) {
            if(position.Equals("center")) {
                //sprite.Position = new Vector2f(((SVNE.window.Size.X / 2) - ((sprite.GetGlobalBounds().Width * Game.xRatio) / 2)) / Game.xRatio, (SVNE.window.Size.Y - (sprite.GetGlobalBounds().Height * Game.yRatio)) / Game.xRatio);
            }
            else if(position.Equals("truecenter")) {

            }
            else if (position.Equals("top")) {

            }
            else if (position.Equals("left")) {
                //sprite.Position = new Vector2f(0, (SVNE.window.Size.Y - (sprite.GetGlobalBounds().Height * Game.yRatio)) / Game.xRatio);
            }
            else if (position.Equals("right")) {
                //sprite.Position = new Vector2f((SVNE.window.Size.X - (sprite.GetGlobalBounds().Width * Game.xRatio)) / Game.xRatio, (SVNE.window.Size.Y - (sprite.GetGlobalBounds().Height * Game.yRatio)) / Game.xRatio);
            }
            else if (position.Equals("topleft")) {

            }
            else if (position.Equals("topright")) {

            }
            else {
                
            }

            return 0;
        }

        public int ChangeName(string name) {
            Name = name;

            return 0;
        }

        public int ChangeColour(Color color) {
            Color = color;

            return 0;
        }

        public int ChangeSprite(string respath) {
            sprite.Texture = new Texture(respath);

            return 0;
        }

        public void Draw() {
            //target.Draw(sprite, states);
        }
    }
}
