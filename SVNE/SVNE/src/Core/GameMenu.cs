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
            MenuControls.Add(new Button("auto", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Fonts/Consolas.ttf"), 0, 680));
            MenuControls.Add(new Button("skip", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Fonts/Consolas.ttf"), 0, 680));
            MenuControls.Add(new Button("save", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Fonts/Consolas.ttf"), 0, 680));
            MenuControls.Add(new Button("load", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Fonts/Consolas.ttf"), 0, 680));
            MenuControls.Add(new Button("options", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Fonts/Consolas.ttf"), 0, 680));
            MenuControls.Add(new Button("quit", new Color(255, 255, 255), new Color(0, 0, 0), new Color(0, 255, 0), 20, new Font("Assets/Fonts/Consolas.ttf"), 0, 680, Quit));

            int totalWidth = 0;

            for (int i = 0; i < MenuControls.Count(); i++) {
                if(i == 0) {
                    MenuControls[i].X = 0;
                    totalWidth += MenuControls[i].Width;
                }
                else {
                    MenuControls[i].X = MenuControls[i - 1].X + 50 + MenuControls[i - 1].Width;
                    totalWidth += 50 + MenuControls[i].Width;
                }
            }



            foreach (Clickable control in MenuControls) {
                control.X += (int)((SVNE.window.DefaultView.Size.X / 2) - (totalWidth / 2));
            }
        }

        public int Quit() {
            Game.gameState = (int)Game.States.MainMenu;
            TimeLine.musicPlayer.Stop();

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
