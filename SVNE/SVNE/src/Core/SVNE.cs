using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics;

namespace SVNE.Core {
    class SVNE {
        public static int defaultWidth = 1280;
        public static int defaultHeight = 720;

        public static Game game;

        public static void Main() {
            using (game = new Game(defaultWidth, defaultHeight, "SVNE")) {
                game.Run();// 60.0);
            }
        }
    }
}
