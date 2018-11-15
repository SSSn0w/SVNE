﻿using System;
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

        public InputHandler inputHandler;

        public static Sprite background = new Sprite(new Texture("Assets/background.jpg"));
        //public static Sprite sprite = new Sprite(new Texture("Assets/character.png"));
        //public static Character sprite = new Character("Magilou", "Assets/character.png", 0.2f);
        public static RectangleShape sceneOverlay;

        public enum States { MainMenu, Paused, Playing, Quit };
        public static int gameState = (int)States.MainMenu;

        public static MainMenu mm = new MainMenu();

        public Game(RenderWindow window) {
            this.window = window;
            this.window.Closed += Window_Closed;
        }

        public override void Startup() {
            inputHandler = new InputHandler(window);

            xRatio = ((float)SVNE.window.Size.X / (float)SVNE.defaultWidth);
            yRatio = ((float)SVNE.window.Size.Y / (float)SVNE.defaultHeight);

            sceneOverlay = new RectangleShape(new Vector2f(window.Size.X, window.Size.Y));
            sceneOverlay.FillColor = new Color(0, 0, 0, 0);

            /*sprite.Scale = new Vector2f(0.2f, 0.2f);
            sprite.Origin = new Vector2f(-(SVNE.window.Size.X + (sprite.Texture.Size.X * sprite.Scale.X)), -(SVNE.window.Size.Y - (sprite.Texture.Size.Y * sprite.Scale.Y)) * 5);
            sprite.Texture.Smooth = true;*/

            background.Origin = new Vector2f(0, 300);

            /*SpriteList.Add("sceneOverlay", sceneOverlay);
            SpriteList.Add("background", background);
            SpriteList.Add("characters", sprite); //Needs rework to add multiple characters
            SpriteList.Add("mainMenu", mm);*/
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

            inputHandler.HandleMouse();

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
                mm.IsDisplaying(true);
                Draw(mm);
            }
            else if (gameState == (int)States.Playing) {
                mm.IsDisplaying(false);

                Draw(background);
                Draw(TimeLine.magilou);

                try {
                    if (TimeLine.timeLine[TimeLine.timeLineCounter] is Drawable) {
                        Drawable drawable = TimeLine.timeLine[TimeLine.timeLineCounter] as Drawable;
                        Draw(drawable);
                    }
                } catch (Exception e) {
                    //Console.WriteLine(e + " No more dialogue");
                }

                for (int i = 0; i < TimeLine.Objects.Count(); i++) {
                    Draw(TimeLine.Objects[i]);
                }

                foreach(Clickable control in TimeLine.Options) {
                    if(control.IsDisplayed) {
                        Draw(control);
                    }
                }

                Draw(sceneOverlay);
            }

            window.Display();
        }

        public void Draw(Drawable gameObject) {
            window.Draw(gameObject);
        }
    }
}
