using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core {
    class Option : Event {
        public string Text;

        public Option(string Text) {
            this.Text = Text;
        }

        public void StartEvent() {
            throw new NotImplementedException();
        }

        public void EndEvent() {
            throw new NotImplementedException();
        }

        public bool Ended() {
            throw new NotImplementedException();
        }

        public Event GetEvent() {
            throw new NotImplementedException();
        }
    }
}
