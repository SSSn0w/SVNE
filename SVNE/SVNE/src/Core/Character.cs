using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SVNE.Core {
    class Character {
        public string Name;
        public string ResPath;
        public string Color;

        public Sprite sprite;

        public int x;
        public int y;
        public int width;
        public int height;

        public Character(string Name, string ResPath, string Color) {
            this.Name = Name;
            this.ResPath = ResPath;
            this.Color = Color;

            sprite = new Sprite(new Texture(ResPath));
        }
    }
}
