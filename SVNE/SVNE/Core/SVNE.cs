﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core {
    class SVNE {
        [STAThread]
        public static void Main() {
            new Game().Run(200, 200);
        }
    }
}