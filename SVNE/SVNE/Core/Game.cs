using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace SVNE.Core {
    class Game : GameWindow {
        private List<int> Textures = new List<int>();
        private List<GUI.MenuControl.Button> MenuControls = new List<GUI.MenuControl.Button>();
        private float AspectRatio;
        private bool fullScreen = false;
        private KeyboardState keyboardState;
        private KeyboardState lastKeyboardState;
        private MouseState mouseState;
        private MouseState lastMouseState;

        public Game() : base(1280, 720, GraphicsMode.Default, "SVNE", GameWindowFlags.Default, DisplayDevice.Default, 4, 0, GraphicsContextFlags.ForwardCompatible) {

        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            Title = "SVNE";
            AspectRatio = (float)Width / (float)Height;

            WindowBorder = WindowBorder.Fixed;

            GL.ClearColor(new Color4(0.1f, 0.1f, 0.3f, 1.0f));
            /*GL.Enable(EnableCap.Texture2D);
            GL.Viewport(0, 0, width, height);
            GL.MatrixMode(GL_PROJECTION);
            GL.LoadIdentity();
            GL.Ortho(0, 0, width, height);
            GL.MatrixMode(GL_MODELVIEW);
            GL.LoadIdentity();*/


            //Load Textures
            Textures.Add(IO.LoadAsset.LoadImage("Assets/30800208.jpg"));
            MenuControls.Add(new GUI.MenuControl.Button(Textures.ElementAt(0), -1f, -1f, 0.25f, 0.1f));
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            AspectRatio = (float)Width / (float)Height;
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            Title = $"SVNE (Vsync: {VSync}) FPS: {1f / e.Time:0} Aspect Ratio: {AspectRatio}";

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Draw Controls
            foreach(GUI.MenuControl.Button control in MenuControls) {
                //Graphics.Draw.DrawTexture(control.texture);
                Graphics.Draw.DrawTexture(control.texture, control.x, control.y, control.width, control.height);
            }

            //Draw Textures
            foreach(int texture in Textures) {
                //Graphics.Draw.DrawTexture(texture);
                Graphics.Draw.DrawTexture(texture, -0.25f, -0.25f * AspectRatio, 0.5f, 0.5f * AspectRatio);
            }

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            HandleKeyboard();
            HandleMouse();
        }

        private void HandleKeyboard() {
            keyboardState = Keyboard.GetState();

            if (KeyPress(Key.Escape)) {
                Exit();
            } 
            else if (KeyPress(Key.F11) && fullScreen == false) {
                WindowState = WindowState.Fullscreen;
                fullScreen = true;
            }
            else if (KeyPress(Key.F11) && fullScreen == true) {
                WindowState = WindowState.Normal;
                fullScreen = false;
            }

            lastKeyboardState = keyboardState;
        }

        private new bool KeyPress(Key key) {
            return (keyboardState[key] && (keyboardState[key] != lastKeyboardState[key]));
        }

        private void HandleMouse() {
            mouseState = Mouse.GetState();
            float mouseX = PxToCoord(System.Windows.Forms.Cursor.Position.X, "Width");
            float mouseY = PxToCoord(System.Windows.Forms.Cursor.Position.Y, "Height");

            if (MousePress(MouseButton.Left)) {
                Console.WriteLine("x: " + mouseX + " y: " + mouseY);
                foreach (GUI.MenuControl.Button control in MenuControls) {
                    if (mouseX > control.x &&
                        mouseX < (control.x + control.width) &&
                        mouseY > control.y &&
                        mouseY < control.y + control.height) {
                        Console.WriteLine("yeet");
                    }
                    else {
                        Console.WriteLine("nothing");
                        Console.WriteLine(control.x + control.width);
                    }
                    
                }
            }

            lastMouseState = mouseState;
        }

        private bool MousePress(MouseButton mButton) {
            return (mouseState[mButton] && (mouseState[mButton] != lastMouseState[mButton]));
        }

        private float PxToCoord(float px, string axis) {
            float coord = 0f;

            if(axis.Equals("Width")) {
                coord = ((2 / (float)Width) * px) - 1;

                /*if (px < Width / 2) {
                    coord *= -1;
                }*/
            }
            else if(axis.Equals("Height")) {
                coord = ((2 / (float)Height) * px) - 1;
                /*if (px > Height / 2) {
                    coord *= -1;
                }*/
            }

            return coord;
        }
    }
}
