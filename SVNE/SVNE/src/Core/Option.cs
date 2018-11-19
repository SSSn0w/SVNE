using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core {
    class Option : Event {
        public string Text;
        public string JumpToScene;

        public Option(string Text) : base() {
            this.Text = Text;
            this.JumpToScene = "";
        }

        public Option(string Text, string JumpToScene) {
            this.Text = Text;
            this.JumpToScene = JumpToScene;
        }

        public void StartEvent() {
            EndEvent();
        }

        public void EndEvent() {
            
        }

        public bool Ended() {
            return true;
        }

        public Event GetEvent() {
            return this;
        }
    }
}
