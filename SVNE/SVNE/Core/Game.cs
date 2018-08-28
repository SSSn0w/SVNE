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

            GL.Enable(EnableCap.Texture2D);
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();


            //Load Textures
            Textures.Add(IO.LoadAsset.LoadImage("Assets/30800208.jpg"));
            Textures.Add(IO.LoadAsset.LoadImage("Assets/clouds.jpg"));
            MenuControls.Add(new GUI.MenuControl.Button(Textures.ElementAt(0), -0.6f, -0.6f, 0.25f, 0.1f));
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

        protected override void OnMouseDown(MouseButtonEventArgs e) {
            base.OnMouseDown(e);

            //Console.WriteLine("x: " + (e.X - 15) + " y: " + (e.Y - 38));
        }

        protected override void OnMouseUp(MouseButtonEventArgs e) {
            base.OnMouseDown(e);

            Console.WriteLine("x: " + e.X + " y: " + e.Y);
            foreach (GUI.MenuControl.Button control in MenuControls) {
                float controlX = CoordToWorld(control.x, "Width");
                float controlY = CoordToWorld(control.x, "Height");
                float controlWidth = CoordToWorld(control.width, "Width");
                float controlHeight = CoordToWorld(control.height, "Height");

                Console.WriteLine(control.texture);

                if (control.texture == null) {
                    Console.WriteLine("yeet");
                    control.texture = Textures.ElementAt(1);
                }
                else {
                    Console.WriteLine("nothing");
                    Console.WriteLine(controlX);
                    Console.WriteLine(controlY);
                }
            }
        }

        private void HandleMouse() {
            mouseState = Mouse.GetState();
            float mouseX = mouseState.X;
            float mouseY = mouseState.Y;

            if (MousePress(MouseButton.Left)) {
                
            }

            lastMouseState = mouseState;
        }

        private bool MousePress(MouseButton mButton) {
            return (mouseState[mButton] && (mouseState[mButton] != lastMouseState[mButton]));
        }

        private float WorldToCoord(float px, string axis) {
            float coord = 0f;

            if(axis.Equals("Width")) {
                coord = ((2 / ((float)Width + 15)) * px) - 1;
            }
            else if(axis.Equals("Height")) {
                coord = ((2 / ((float)Height + 38)) * px) - 1;
            }

            return coord;
        }

        private float CoordToWorld(float coord, string axis) {
            float px = 0f;

            if (axis.Equals("Width")) {
                px = (coord + 1f) * (((float)Width + 15f) / 2f);
            }
            else if (axis.Equals("Height")) {
                px = (coord + 1f) * (((float)Height + 38f) / 2f);
            }

            return px;
        }
    }
}
