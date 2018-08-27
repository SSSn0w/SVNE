using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;

namespace SVNE.Core {
    class Character {
        public string Name;
        public string ResPath;
        public Color4 Color;

        public Character(string Name, string ResPath, Color4 Color) {
            this.Name = Name;
            this.ResPath = ResPath;
            this.Color = Color;
        }
    }
}
