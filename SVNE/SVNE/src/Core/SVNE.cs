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
        public static uint defaultWidth = 1280;
        public static uint defaultHeight = 720;

        private static ContextSettings settings = new ContextSettings(0, 0, 16);

        public static RenderWindow window = new RenderWindow(new VideoMode(defaultWidth, defaultHeight), "SVNE", Styles.Titlebar | Styles.Close, settings);
        public static View view = window.GetView();

        public static Game game;

        public static void Main() {
            game = new Game(window);

            while (window.IsOpen) {
                game.Run(window, 1f / 60f);
            }
        }
    }
}
