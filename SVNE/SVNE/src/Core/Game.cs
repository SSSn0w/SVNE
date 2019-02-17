using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

using SVNE.GUI;

namespace SVNE.Core {
    class Game : GameLoop {
        public RenderWindow window;
        public static float xRatio;
        public static float yRatio;

        public enum States { MainMenu, OptionsMenu, Paused, Playing, Quit };
        public static int gameState = (int)States.MainMenu;

        public static MainMenu mainMenu;
        public static GameMenu gameMenu;
        public static OptionsMenu optionsMenu;

        public static List<SoundBuffer> Sounds;

        public Game(RenderWindow window) {
            this.window = window;
            this.window.Closed += Window_Closed;
            this.window.MouseButtonReleased += InputHandler.OnMousePressed;
        }

        public override void Startup() {
            xRatio = ((float)SVNE.window.Size.X / (float)SVNE.defaultWidth);
            yRatio = ((float)SVNE.window.Size.Y / (float)SVNE.defaultHeight);

            mainMenu = new MainMenu();
            gameMenu = new GameMenu();
            optionsMenu = new OptionsMenu();

            LoadSounds();
    }

        private void Window_Closed(object sender, EventArgs e) {
            Shutdown();
        }

        public override void Shutdown() {
            Stop();
            window.Close();
        }

        public override void Update() {
            window.DispatchEvents();

            InputHandler.HandleMouse(window);

            if (gameState == (int)States.Playing) {
                try {
                    TimeLine.timeLine[TimeLine.timeLineCounter].StartEvent();
                } catch (Exception e) {
                    //Console.WriteLine(e + " No more dialogue");
                }
            }
            else if(gameState == (int)States.MainMenu) {
                
            }
            else if(gameState == (int)States.Quit) {
                Shutdown();
            }
        }

        public override void Render() {
            if (gameState == (int)States.MainMenu) {
                mainMenu.IsDisplaying(true);
                gameMenu.IsDisplaying(false);
                optionsMenu.IsDisplaying(false);
                Draw(mainMenu);
            }
            else if (gameState == (int)States.OptionsMenu) {
                mainMenu.IsDisplaying(false);
                gameMenu.IsDisplaying(false);
                optionsMenu.IsDisplaying(true);
                Draw(optionsMenu);
            }
            else if (gameState == (int)States.Playing) {
                mainMenu.IsDisplaying(false);
                gameMenu.IsDisplaying(true);
                optionsMenu.IsDisplaying(false);

                Draw(TimeLine.Background);

                Draw(TimeLine.magilou);

                try {
                    if (TimeLine.timeLine[TimeLine.timeLineCounter] is Drawable) {
                        Drawable drawable = TimeLine.timeLine[TimeLine.timeLineCounter] as Drawable;
                        Draw(drawable);
                    }
                } catch (Exception e) {
                    //Console.WriteLine(e + " No more dialogue");
                }

                int listCount = 0;
                foreach(List<Clickable> list in TimeLine.Options) {
                    foreach (Clickable control in TimeLine.Options[listCount]) {
                        if (control.IsDisplayed) {
                            Draw(control);
                        }
                    }

                    listCount++;
                }

                for (int i = 0; i < TimeLine.Objects.Count(); i++) {
                    Draw(TimeLine.Objects[i]);
                }

                Draw(gameMenu);
            }

            window.Display();
        }

        public void Draw(Drawable gameObject) {
            window.Draw(gameObject);
        }

        public void LoadSounds() {
            //Sounds.Add(new SoundBuffer("Assets/Be Happy.wav"));
        }
    }
}
