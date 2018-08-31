using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core.GUI {
    interface Clickable {
        void MouseDown();
        void MouseUp();
        void Reset();
    }
}
