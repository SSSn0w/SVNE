using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;

using SVNE.Core;
using System.Drawing;

namespace SVNE.GUI
{
    class Slider : Clickable {
        public Rectangle bar;
        public Rectangle handle;

        public int x;
        public int y;
        public int width;
        public int height;

        public bool grabbed = false;
        public bool isDisplaying;
        public bool mouseDown = false;

        public int defaultPos = 0;
        public int handlePos = 0;

        public Func<int> action = () => 0;

        public Slider(Rectangle bar, Rectangle handle) : base() {
            this.bar = bar;
            this.handle = handle;

            this.bar.X = 300;
            this.bar.Y = 100;
            this.handle.X = 300;
            this.handle.Y = 100 - ((handle.Height - bar.Height) / 2);
            //this.bar.FillColor = new Color(103, 163, 225, 255);
            //this.handle.FillColor = new Color(0, 102, 203, 255);

            x = handle.X;
            y = handle.Y;
            width = handle.Width;
            height = handle.Height;
        }

        public Slider(Rectangle bar, Rectangle handle, Func<int> action) : base() {
            this.bar = bar;
            this.handle = handle;

            this.bar.X = 300;
            this.bar.Y = 100;
            this.handle.X = 300;
            this.handle.Y = 100 - ((handle.Height - bar.Height) / 2);
            //this.bar.FillColor = new Color(103, 163, 225, 255);
            //this.handle.FillColor = new Color(0, 102, 203, 255);

            x = handle.X;
            y = handle.Y;
            width = handle.Width;
            height = handle.Height;

            this.action = action;
        }

        public Slider(Rectangle bar, Rectangle handle, int defaultPos, Func<int> action) : base() {
            this.bar = bar;
            this.handle = handle;

            this.defaultPos = defaultPos;

            this.bar.X = 300;
            this.bar.Y = 100;
            this.handle.X = 300;
            this.handle.Y = 100 - ((handle.Height - bar.Height) / 2);
            //this.bar.FillColor = new Color(103, 163, 225, 255);
            //this.handle.FillColor = new Color(0, 102, 203, 255);

            x = handle.X;
            y = handle.Y;
            width = handle.Width;
            height = handle.Height;

            this.action = action;
        }

        public int X {
            get { return x; }
            set { x = value; }
        }

        public int Y {
            get { return y; }
            set { y = value; }
        }

        public int Width {
            get { return width; }
            set { width = value; }
        }

        public int Height {
            get { return height; }
            set { height = value; }
        }

        public bool IsDisplayed {
            get { return isDisplaying; }
            set { isDisplaying = value; }
        }

        public bool IsMouseDown {
            get { return mouseDown; }
            set { mouseDown = value; }
        }

        public bool MouseInBounds() {
            Point mState = Game.mousePos;

            if (mState.X >= handle.X * Game.xRatio &&
               mState.X <= handle.X * Game.xRatio + handle.Width * Game.xRatio &&
               mState.Y >= handle.Y * Game.yRatio &&
               mState.Y <= handle.Y * Game.yRatio + handle.Height * Game.yRatio ||
               mState.X >= bar.X * Game.xRatio &&
               mState.X <= bar.X * Game.xRatio + bar.Width * Game.xRatio &&
               mState.Y >= bar.Y * Game.yRatio &&
               mState.Y <= bar.Y * Game.yRatio + bar.Height * Game.yRatio) {

                if (isDisplaying) {
                    //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
                }

                return true;
            }
            else {
                return false;
            }
        }

        public bool Hover() {
            grabbed = false;

            return false;
        }

        public bool MouseDown() {
            Point mState = Game.mousePos;

            if (MouseInBounds() && Mouse.GetState().IsButtonDown(MouseButton.Left)) {
                grabbed = true;
            }

            if(grabbed) {
                int mouseX = mState.X;
                int mouseY = mState.Y;

                x = (int)(mouseX - (handle.Width / 2));
                handle.X = mouseX - (handle.Width / 2);
                handle.Y = handle.Y;

                if (handle.X <= bar.X) {
                    x = (int)(bar.X);
                    handle.X = bar.X;
                    handle.Y = handle.Y;
                }

                if (handle.X >= (bar.X + bar.Width) - handle.Width) {
                    x = (int)((bar.X + bar.Width) - handle.Width);
                    handle.X = (bar.X + bar.Width) - handle.X;
                    handle.Y = handle.Y;
                }

                action();

                return true;
            }
            else {
                Reset();

                return false;
            }
        }

        public bool MouseUp() {
            grabbed = false;

            return true;
        }

        public void Reset() {

        }

        public int GetPosition() {
            handlePos = (int)((handle.X - bar.X) / ((bar.Width - handle.Width) / 100));

            return (int)((handle.X - bar.X) / (bar.Width / 100));
        }

        public void Draw() {
            Point mState = Game.mousePos;

            if (grabbed && Mouse.GetState().IsButtonDown(MouseButton.Left)) {
                //float mouseX = Mouse.GetPosition(Core.SVNE.window).X / Game.xRatio;
                //float mouseY = Mouse.GetPosition(Core.SVNE.window).Y / Game.yRatio;
                float mouseX = mState.X;
                float mouseY = mState.Y;

                x = (int)(mouseX - (handle.X / 2));
                handle.X = (int)mouseX - (handle.Width / 2);
                handle.Y = handle.Y;

                if (handle.X <= bar.X) {
                    x = (int)(bar.X);
                    handle.X = bar.X;
                    handle.Y = handle.Y;
                }

                if (handle.X >= (bar.X + bar.Width) - handle.Width) {
                    x = (int)((bar.X + bar.Width) - handle.Width);
                    handle.X = (bar.X + bar.Width) - handle.Width;
                    handle.Y = handle.Y;
                }

                GetPosition();
            }
            else {
                Reset();
            }

            //target.Draw(bar, states);
            //target.Draw(handle, states);

            Game.gfxRenderer.Clear(System.Drawing.Color.Empty);

            Game.gfxRenderer.DrawRect(Brushes.Cyan, bar.X, bar.Y, bar.Width, bar.Height);
            Game.gfxRenderer.DrawRect(Brushes.DarkCyan, handle.X, handle.Y, handle.Width, handle.Height);

            Functions.DrawGFX(Game.gfxRenderer.Texture);
        }
    }
}
