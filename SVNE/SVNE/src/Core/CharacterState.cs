using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core {
    [Serializable]
    class CharacterState {
        public string Name;
        public string ResPath;
        public float Scale;
        public bool Hidden;

        public CharacterState(Character character, bool hidden) {
            Name = character.Name;
            ResPath = character.ResPath;
            Scale = character.Scale;
            Hidden = hidden;
        }
    }
}
