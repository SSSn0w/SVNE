using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

using SVNE.Core;

namespace SVNE.Animations {
    interface Animation : Event {
        void Default();
        void Animate();
    }
}
