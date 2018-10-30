using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SVNE.Core;

namespace SVNE.Transitions {
    interface Transition : Event {
        void Default();
        void Animate();
    }
}
