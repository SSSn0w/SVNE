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
        private static RenderWindow window = new RenderWindow(new VideoMode(1200, 700), "SVNE", Styles.Default, settings);
        private static Color backgroundColor = new Color(5, 70, 55, 1);

        public static void Main() {
            window.Closed += Window_Closed;

            Game game = new Game(window);

            while (window.IsOpen) {
                window.Clear(backgroundColor);

                game.Update();                

                window.DispatchEvents();
                window.Display();

                System.Threading.Thread.Sleep(15);
            }
        }

        private static void Window_Closed(object sender, EventArgs e) {
            window.Close();
        }
    }
}
