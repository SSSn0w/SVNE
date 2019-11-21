using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;

using SVNE.GUI;

namespace SVNE.Core {
    class OptionsMenu : Menu {
        public List<Clickable> MenuControls = new List<Clickable>();

        public List<Clickable> Controls {
            get { return MenuControls; }
        }

        public OptionsMenu() {
            //LOAD ALL OF THIS FROM FILE EVENTUALLY

            MenuControls.Add(new Button("Volume", false, Brushes.Black, Brushes.Black, Brushes.Black, new Font(Game.Fonts.Families[0], 30), 100, 100));
            MenuControls.Add(new Button("1280 x 720", Brushes.Black, Brushes.White, Brushes.Green, new Font(Game.Fonts.Families[0], 30), 100, 200, Big));
            MenuControls.Add(new Button("640 x 360", Brushes.Black, Brushes.White, Brushes.Green, new Font(Game.Fonts.Families[0], 30), 100, 300, Small));
            MenuControls.Add(new Button("Menu", Brushes.Black, Brushes.White, Brushes.Green, new Font(Game.Fonts.Families[0], 30), 100, 600, MainMenu));
            MenuControls.Add(new Slider(new Rectangle(0, 0, 300, 40), new Rectangle(0, 0, 20, 40), 100, ChangeVolume));
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

            //TimeLine.musicPlayer.Volume = volumeSlider.GetPosition();

            return 0;
        }

        public void IsDisplaying(bool displaying) {
            foreach (Clickable control in MenuControls) {
                control.IsDisplayed = displaying;
            }
        }

        public void Draw() {
            GL.ClearColor(Color.White);

            foreach (Clickable control in MenuControls) {
                if (control.IsDisplayed) {
                    control.Draw();
                }
            }
        }
    }
}
