using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core {
    interface Event {
        void StartEvent();
        void EndEvent();
        bool Ended();
        Event GetEvent();
    }
}
