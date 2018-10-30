using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

using SVNE.GUI;

namespace SVNE.Core {
    class MainMenu : Drawable {
        public List<Clickable> MenuControls = new List<Clickable>();

        public MainMenu() {
            MenuControls.Add(new Button("Start", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 100, Start));
            MenuControls.Add(new Button("Load", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 200));
            MenuControls.Add(new Button("Preferences", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 300, Preferences));
            MenuControls.Add(new Button("About", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 400));
            MenuControls.Add(new Button("Help", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 500));
            MenuControls.Add(new Button("Quit", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 600, Quit));
            //MenuControls.Add(new Slider(new RectangleShape(new Vector2f(300, 10)), new RectangleShape(new Vector2f(20, 20))));
            MenuControls.Add(new Slider(new RectangleShape(new Vector2f(300, 40)), new RectangleShape(new Vector2f(20, 40))));
        }

        public int Start() {
            Game.gameState = (int)Game.States.Playing;

            return 0;
        }

        public int Preferences() {
            //To-do: Add more resolutions and make sure to multiply all drawables have their size multiplied by the new resolution ratio

            SVNE.window.Close();
            SVNE.window = new RenderWindow(VideoMode.FullscreenModes[0], "SVNE", Styles.Fullscreen, SVNE.window.Settings);
            SVNE.game = new Game(SVNE.window);
            SVNE.game.Run(SVNE.window, 1f / 60f);

            return 0;
        }

        public int Quit() {
            Game.gameState = (int)Game.States.Quit;
            
            return 0;
        }

        public void Draw(RenderTarget target, RenderStates states) {
            target.Draw(new RectangleShape(new Vector2f(1280, 720)), states);

            foreach (Clickable button in MenuControls) {
                target.Draw(button, states);
            }
        }
    }
}
