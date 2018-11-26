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
            TimeLine.Load();
            Game.gameState = (int)Game.States.Playing;

            return 0;
        }

        public int Preferences() {
            //To-do: Add more resolutions

            SVNE.window.Size = new Vector2u(640, 360);
            Game.xRatio = ((float)SVNE.window.Size.X / (float)SVNE.defaultWidth);
            Game.yRatio = ((float)SVNE.window.Size.Y / (float)SVNE.defaultHeight);

            return 0;
        }

        public int Quit() {
            Game.gameState = (int)Game.States.Quit;
            
            return 0;
        }

        public void IsDisplaying(bool displaying) {
            foreach (Clickable control in MenuControls) {
                control.IsDisplayed = displaying;
            }
        }

        public void Draw(RenderTarget target, RenderStates states) {
            target.Draw(new RectangleShape(SVNE.window.DefaultView.Size), states);

            foreach (Clickable control in MenuControls) {
                if (control.IsDisplayed) {
                    target.Draw(control, states);
                }
            }
        }
    }
}
