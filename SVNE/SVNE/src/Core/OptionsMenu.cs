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
    class OptionsMenu : Menu {
        public List<Clickable> MenuControls = new List<Clickable>();

        public List<Clickable> Controls {
            get { return MenuControls; }
        }

        public OptionsMenu() {
            //LOAD ALL OF THIS FROM FILE EVENTUALLY

            /*MenuControls.Add(new Button("Volume", false, new Color(0, 0, 0), new Color(0, 0, 0), new Color(0, 0, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 100));
            MenuControls.Add(new Button("1280 x 720", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 200, Big));
            MenuControls.Add(new Button("640 x 360", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 300, Small));
            MenuControls.Add(new Button("Menu", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 600, MainMenu));
            MenuControls.Add(new Slider(new RectangleShape(new Vector2f(300, 40)), new RectangleShape(new Vector2f(20, 40)), 100, ChangeVolume));*/
        }

        public int MainMenu() {
            Game.gameState = (int)Game.States.MainMenu;

            return 0;
        }

        public int Big() {
            //SVNE.window.Size = new Vector2u(1280, 720);
            //Game.xRatio = ((float)SVNE.window.Size.X / (float)SVNE.defaultWidth);
            //Game.yRatio = ((float)SVNE.window.Size.Y / (float)SVNE.defaultHeight);

            return 0;
        }

        public int Small() {
            //SVNE.window.Size = new Vector2u(640, 360);
            //Game.xRatio = ((float)SVNE.window.Size.X / (float)SVNE.defaultWidth);
            //Game.yRatio = ((float)SVNE.window.Size.Y / (float)SVNE.defaultHeight);

            return 0;
        }

        public int ChangeVolume() {
            Slider volumeSlider = (Slider)MenuControls[4];

            TimeLine.musicPlayer.Volume = volumeSlider.GetPosition();

            return 0;
        }

        public void IsDisplaying(bool displaying) {
            foreach (Clickable control in MenuControls) {
                control.IsDisplayed = displaying;
            }
        }

        public void Draw() {
            //target.Draw(new RectangleShape(SVNE.window.DefaultView.Size), states);

            foreach (Clickable control in MenuControls) {
                if (control.IsDisplayed) {
                    //target.Draw(control, states);
                }
            }
        }
    }
}
