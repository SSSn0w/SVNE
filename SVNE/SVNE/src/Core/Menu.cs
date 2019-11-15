using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SVNE.GUI;

namespace SVNE.Core {
    interface Menu : Drawable {
        List<Clickable> Controls { get;}
        void IsDisplaying(bool displaying);
    }
}
