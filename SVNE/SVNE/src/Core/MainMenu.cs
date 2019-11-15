using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;

using SVNE.GUI;

namespace SVNE.Core {
    class MainMenu : Menu {
        public List<Clickable> MenuControls = new List<Clickable>();

        public List<Clickable> Controls {
            get { return MenuControls; }
        }

        public MainMenu() {
            //LOAD ALL OF THIS FROM FILE EVENTUALLY

            MenuControls.Add(new Button("Start", Brushes.Black, Brushes.White, Brushes.Green, new Font("Assets/Fonts/Consolas.ttf", 30), 100, 100, Start));
            MenuControls.Add(new Button("Load", Brushes.Black, Brushes.White, Brushes.Green, new Font("Assets/Fonts/Consolas.ttf", 30), 100, 200, Load));
            MenuControls.Add(new Button("Preferences", Brushes.Black, Brushes.White, Brushes.Green, new Font("Assets/Fonts/Consolas.ttf", 30), 100, 300, Preferences));
            MenuControls.Add(new Button("About", Brushes.Black, Brushes.White, Brushes.Green, new Font("Assets/Fonts/Consolas.ttf", 30), 100, 400));
            MenuControls.Add(new Button("Help", Brushes.Black, Brushes.White, Brushes.Green, new Font("Assets/Fonts/Consolas.ttf", 30), 100, 500));
            MenuControls.Add(new Button("Quit", Brushes.Black, Brushes.White, Brushes.Green, new Font("Assets/Fonts/Consolas.ttf", 30), 100, 600, Quit));
        }

        public int Start() {
            TimeLine.timeLineCounter = 0;
            TimeLine.LoadVariables();
            TimeLine.Load();
            Game.gameState = (int)Game.States.Playing;
            TimeLine.musicPlayer.Loop = true;
            //TimeLine.musicPlayer.SoundBuffer = Game.Sounds[0];
            //TimeLine.musicPlayer.Play();

            return 0;
        }

        public int Load() {
            Game.gameState = (int)Game.States.LoadMenu;

            return 0;
        }

        public int Preferences() {
            Game.gameState = (int)Game.States.OptionsMenu;

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

        public void Draw() {
            GL.ClearColor(Color.White);

            foreach (Clickable control in MenuControls) {
                if (true) {//control.IsDisplayed) {
                    control.Draw();
                }
            }
        }
    }
}
