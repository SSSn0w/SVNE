using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;

using SVNE.GUI;

namespace SVNE.Core {
    class MainMenu : Menu {
        public List<Clickable> MenuControls = new List<Clickable>();

        public List<Clickable> Controls {
            get { return MenuControls; }
        }

        public MainMenu() {
            //LOAD ALL OF THIS FROM FILE EVENTUALLY

            MenuControls.Add(new Button("Start", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 100, Start));
            MenuControls.Add(new Button("Load", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 200, Load));
            MenuControls.Add(new Button("Preferences", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 300, Preferences));
            MenuControls.Add(new Button("About", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 400));
            MenuControls.Add(new Button("Help", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 500));
            MenuControls.Add(new Button("Quit", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 600, Quit));
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

        public void Draw(RenderTarget target, RenderStates states) {
            //target.Draw(new RectangleShape(SVNE.window.DefaultView.Size), states);

            foreach (Clickable control in MenuControls) {
                if (control.IsDisplayed) {
                    target.Draw(control, states);
                }
            }
        }
    }
}
