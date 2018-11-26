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
    class GameMenu : Drawable {
        public List<Clickable> MenuControls = new List<Clickable>();

        public GameMenu() {
            //(int)((SVNE.window.DefaultView.Size.X / 6) - (MenuControls[0].GetWidth / 2))
            MenuControls.Add(new Button("auto", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Consolas.ttf"), 350, 680));
            MenuControls.Add(new Button("skip", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Consolas.ttf"), 450, 680));
            MenuControls.Add(new Button("save", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Consolas.ttf"), 550, 680));
            MenuControls.Add(new Button("load", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Consolas.ttf"), 650, 680));
            MenuControls.Add(new Button("options", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Consolas.ttf"), 750, 680));
            MenuControls.Add(new Button("quit", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Consolas.ttf"), 880, 680, Quit));

            /*for (int i = 0; i < MenuControls.Count(); i++) {
                MenuControls[i].GetX = (int)(((((SVNE.window.DefaultView.Size.X / 2) / 6) * i) - (MenuControls[i].GetWidth / 2)) + (SVNE.window.DefaultView.Size.X / 4));
            }*/
        }

        public int Quit() {
            Game.gameState = (int)Game.States.MainMenu;

            return 0;
        }

        public void IsDisplaying(bool displaying) {
            foreach (Clickable control in MenuControls) {
                control.IsDisplayed = displaying;
            }
        }

        public void Draw(RenderTarget target, RenderStates states) {
            foreach (Clickable control in MenuControls) {
                if (control.IsDisplayed) {
                    target.Draw(control, states);
                }
            }
        }
    }
}
