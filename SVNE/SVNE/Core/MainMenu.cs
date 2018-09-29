using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

using SVNE.GUI;

namespace SVNE.Core {
    class MainMenu : Drawable {
        public List<Clickable> MenuControls = new List<Clickable>();

        public MainMenu() {
            MenuControls.Add(new Button("Start", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 100, Start));
            MenuControls.Add(new Button("Load", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 200));
            MenuControls.Add(new Button("Preferences", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 300));
            MenuControls.Add(new Button("About", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 400));
            MenuControls.Add(new Button("Help", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 500));
            MenuControls.Add(new Button("Quit", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 600, Quit));
        }

        public int Start() {
            Game.gameState = (int)Game.States.Playing;

            return 0;
        }

        public int Quit() {
            Game.gameState = (int)Game.States.Quit;

            return 0;
        }

        public void Draw(RenderTarget target, RenderStates states) {
            target.Draw(new RectangleShape(new Vector2f(1280, 720)), states);

            foreach (Button button in MenuControls) {
                target.Draw(button, states);
            }
        }
    }
}
