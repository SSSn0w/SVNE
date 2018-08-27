using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;

namespace SVNE.Core {
    class Game : GameWindow {
        public Game() : base(1280, 720, GraphicsMode.Default, "SVNE", GameWindowFlags.Default, DisplayDevice.Default, 4, 0, GraphicsContextFlags.ForwardCompatible) {

        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            Title = "SVNE";

            GL.ClearColor(new Color4(0.1f, 0.1f, 0.3f, 1.0f));
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            Title = $"SVNE (Vsync: {VSync}) FPS: {1f / e.Time:0}";

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            HandleKeyboard();
        }

        private void HandleKeyboard() {
            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Key.Escape)) {
                Exit();
            }
        }
    }
}
