using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core {
    class StateEvent : Event {
        public int gameState;

        public StateEvent(int gameState) {
            this.gameState = gameState;
        }

        public void StartEvent() {
            if (gameState == (int)Game.States.MainMenu) {
                Game.gameState = gameState;
            }

            EndEvent();
        }

        public void EndEvent() {
            if (gameState == (int)Game.States.MainMenu) {
                TimeLine.timeLineCounter = 0;
            }
        }

        public bool Ended() {
            return true;
        }

        public Event GetEvent() {
            return this;
        }
    }
}
