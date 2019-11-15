using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using ManagedBass;

using SVNE.GUI;
using SVNE.IO;

namespace SVNE.Core {
    class Game : GameWindow {
       // public RenderWindow window;
        public static float xRatio;
        public static float yRatio;

        int VertexBufferObject;

        public enum States { MainMenu, OptionsMenu, SaveMenu, LoadMenu, Paused, Playing, Quit };
        public static int gameState = (int)States.MainMenu;

        public static List<Menu> Menus = new List<Menu>();

        public static MainMenu mainMenu;
        public static GameMenu gameMenu;
        public static OptionsMenu optionsMenu;
        public static GameSlotMenu gameSlotMenu;

        //public static List<SoundBuffer> Sounds = new List<SoundBuffer>();

        public static bool storyOptionsOpen = false;

        int texture;

        TextRenderer renderer;
        Font consolas = new Font("Assets/Fonts/Consolas.ttf", 50);

        public Game(int width, int height, string title) : base(width, height, new GraphicsMode(32, 24, 0, 16), title) { //FSAA 16
            /*this.window = window;
            this.window.Closed += Window_Closed;
            this.window.MouseButtonReleased += InputHandler.OnMousePressed;*/
        }

        protected override void OnLoad(EventArgs e) {
            /*xRatio = ((float)SVNE.window.Size.X / (float)SVNE.defaultWidth);
            yRatio = ((float)SVNE.window.Size.Y / (float)SVNE.defaultHeight);*/

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Multisample);

            VertexBufferObject = GL.GenBuffer();
            GL.ClearColor(Color.CornflowerBlue);

            /*mainMenu = new MainMenu();
            gameMenu = new GameMenu();
            optionsMenu = new OptionsMenu();
            gameSlotMenu = new GameSlotMenu();

            Menus.Add(mainMenu);
            Menus.Add(gameMenu);
            Menus.Add(optionsMenu);
            Menus.Add(gameSlotMenu);*/

            LoadSounds();

            texture = LoadAsset.LoadTexture("Assets/Characters/Magilou/character.png");

            renderer = new TextRenderer(Width, Height);
            PointF position = PointF.Empty;

            renderer.Clear(Color.Empty);
            renderer.DrawString("The quick brown fox jumps over the lazy dog", consolas, Brushes.White, position);
            position.Y += consolas.Height;

            base.OnLoad(e);
        }

        protected override void OnUnload(EventArgs e) {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(VertexBufferObject);

            renderer.Dispose();

            base.OnUnload(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            /*KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape)) {
                Exit();
            }

            base.OnUpdateFrame(e);*/

            InputHandler.HandleMouse();

            if (gameState == (int)States.Playing) {
                /*try {
                    TimeLine.timeLine[TimeLine.timeLineCounter].StartEvent();
                } catch (Exception ex) {
                    //Console.WriteLine(e + "Can't start event");
                }*/
            }
            else if(gameState == (int)States.MainMenu) {
                //TimeLine.musicPlayer.Stop();
            }
            else if (gameState == (int)States.LoadMenu) {
                
            }
            else if (gameState == (int)States.SaveMenu) {

            }
            else if(gameState == (int)States.Quit) {
                //Shutdown();
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            /*if (gameState == (int)States.MainMenu) {
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

            window.Display();*/

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Functions.Draw(texture, 0, 0, 400, 600);
            Functions.DrawText(renderer.Texture);

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e) {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        /*public void Draw(Drawable gameObject) {
            window.Draw(gameObject);
        }*/

        public void StopDisplaying() {
           /* mainMenu.IsDisplaying(false);
            gameMenu.IsDisplaying(false);
            optionsMenu.IsDisplaying(false);
            gameSlotMenu.IsDisplaying(false);*/
        }

        public void LoadSounds() {
            //LOAD ALL OF THIS FROM FILE EVENTUALLY
            //Sounds.Add(new SoundBuffer("Assets/kamado_tanjiro_no_uta.wav"));
        }
    }
}
