using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.GUI {
    interface Clickable {
        void MouseDown();
        void MouseUp();
        void Hover();
        void Reset();
    }
}
