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

        public enum States { MainMenu, OptionsMenu, SaveMenu, LoadMenu, Paused, Playing, Quit };
        public static int gameState = (int)States.MainMenu;

        public static List<Menu> Menus = new List<Menu>();

        public static MainMenu mainMenu;
        public static GameMenu gameMenu;
        public static OptionsMenu optionsMenu;
        public static GameSlotMenu gameSlotMenu;

        public static List<SoundBuffer> Sounds = new List<SoundBuffer>();

        public static bool storyOptionsOpen = false;

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
            gameSlotMenu = new GameSlotMenu();

            Menus.Add(mainMenu);
            Menus.Add(gameMenu);
            Menus.Add(optionsMenu);
            Menus.Add(gameSlotMenu);

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
                    //Console.WriteLine(e + "Can't start event");
                }
            }
            else if(gameState == (int)States.MainMenu) {
                TimeLine.musicPlayer.Stop();
            }
            else if (gameState == (int)States.LoadMenu) {
                
            }
            else if (gameState == (int)States.SaveMenu) {

            }
            else if(gameState == (int)States.Quit) {
                Shutdown();
            }
        }

        public override void Render() {
            if (gameState == (int)States.MainMenu) {
                StopDisplaying();
                mainMenu.IsDisplaying(true);

                Draw(mainMenu);
            }
            else if (gameState == (int)States.OptionsMenu) {
                StopDisplaying();
                optionsMenu.IsDisplaying(true);

                Draw(optionsMenu);
            }
            else if (gameState == (int)States.LoadMenu) {
                StopDisplaying();
                gameSlotMenu.IsDisplaying(true);

                Draw(gameSlotMenu);
            }
            else if (gameState == (int)States.SaveMenu) {
                StopDisplaying();
                gameSlotMenu.IsDisplaying(true);
                gameMenu.IsDisplaying(true);

                Draw(gameSlotMenu);
            }
            else if (gameState == (int)States.Playing) {
                StopDisplaying();
                gameMenu.IsDisplaying(true);

                Draw(TimeLine.Background);

                for (int i = 0; i < TimeLine.Objects.Count(); i++) {
                    Draw(TimeLine.Objects[i]);
                }

                for (int i = 0; i < TimeLine.Characters.Count(); i++) {
                    Draw(TimeLine.Characters[0]);
                }

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

                Draw(gameMenu);
            }

            window.Display();
        }

        public void Draw(Drawable gameObject) {
            window.Draw(gameObject);
        }

        public void StopDisplaying() {
            mainMenu.IsDisplaying(false);
            gameMenu.IsDisplaying(false);
            optionsMenu.IsDisplaying(false);
            gameSlotMenu.IsDisplaying(false);
        }

        public void LoadSounds() {
            //LOAD ALL OF THIS FROM FILE EVENTUALLY
            //Sounds.Add(new SoundBuffer("Assets/kamado_tanjiro_no_uta.wav"));
        }
    }
}
