using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace SVNE.Core {
    class SVNE {
        private static ContextSettings settings = new ContextSettings();
        private static RenderWindow window = new RenderWindow(new VideoMode(1280, 720), "SVNE", Styles.Titlebar | Styles.Close, settings);

        public static void Main() {
            Game game = new Game(window);

            while (window.IsOpen) {
                game.Run(window, 1f / 60f);
            }
        }
    }
}
