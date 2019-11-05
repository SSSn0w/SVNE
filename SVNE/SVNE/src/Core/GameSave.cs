using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;

namespace SVNE.Core {

    [Serializable]
    class GameSave {
        public int timeLinePos;
        public string background;
        public List<CharacterState> characters;
        public string currentSong;

        public GameSave(int timeLinePos, string background, List<CharacterState> characters, string currentSong) {
            this.timeLinePos = timeLinePos;
            this.background = background;
            this.characters = characters;
            this.currentSong = currentSong;
        }
    }
}
