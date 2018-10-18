using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core {
    class Character {
        public string Name;
        public string ResPath;
        public string Color;

        public Character(string Name, string ResPath, string Color) {
            this.Name = Name;
            this.ResPath = ResPath;
            this.Color = Color;
        }
    }
}
