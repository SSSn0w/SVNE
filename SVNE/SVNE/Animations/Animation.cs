﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SVNE.Animations {
    interface Animation {
        void Default();
        void Animate();
    }
}
