using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core {
    class Function : Event {
        public Func<int> function;

        public Function(Func<int> function) {
            this.function = function;
        }

        public void StartEvent() {
            EndEvent();
        }

        public void EndEvent() {
            function();
        }

        public bool Ended() {
            return true;
        }

        public Event GetEvent() {
            return this;
        }
    }
}
