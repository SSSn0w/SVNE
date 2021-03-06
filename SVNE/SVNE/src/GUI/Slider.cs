﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

using SVNE.Core;

namespace SVNE.GUI
{
    class Slider : Clickable {
        public RectangleShape bar;
        public RectangleShape handle;

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

        public Slider(RectangleShape bar, RectangleShape handle) : base() {
            this.bar = bar;
            this.handle = handle;

            this.bar.Position = new Vector2f(300, 100);
            this.handle.Position = new Vector2f(300, 100 - ((handle.Size.Y - bar.Size.Y) / 2));
            this.bar.FillColor = new Color(103, 163, 225, 255);
            this.handle.FillColor = new Color(0, 102, 203, 255);

            x = (int)handle.Position.X;
            y = (int)handle.Position.Y;
            width = (int)handle.Size.X;
            height = (int)handle.Size.Y;
        }

        public Slider(RectangleShape bar, RectangleShape handle, Func<int> action) : base() {
            this.bar = bar;
            this.handle = handle;

            this.bar.Position = new Vector2f(300, 100);
            this.handle.Position = new Vector2f(300, 100 - ((handle.Size.Y - bar.Size.Y) / 2));
            this.bar.FillColor = new Color(103, 163, 225, 255);
            this.handle.FillColor = new Color(0, 102, 203, 255);

            this.action = action;

            x = (int)handle.Position.X;
            y = (int)handle.Position.Y;
            width = (int)handle.Size.X;
            height = (int)handle.Size.Y;
        }

        public Slider(RectangleShape bar, RectangleShape handle, int defaultPos, Func<int> action) : base() {
            this.bar = bar;
            this.handle = handle;

            this.defaultPos = defaultPos;

            this.bar.Position = new Vector2f(300, 100);
            this.handle.Position = new Vector2f(300 + ((bar.Size.X / 100) * defaultPos), 100 - ((handle.Size.Y - bar.Size.Y) / 2));
            this.bar.FillColor = new Color(103, 163, 225, 255);
            this.handle.FillColor = new Color(0, 102, 203, 255);

            this.action = action;

            x = (int)handle.Position.X;
            y = (int)handle.Position.Y;
            width = (int)handle.Size.X;
            height = (int)handle.Size.Y;
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

        public bool MouseInBounds(RenderWindow window) {
            if (Mouse.GetPosition(window).X >= X * Game.xRatio &&
               Mouse.GetPosition(window).X <= X * Game.xRatio + Width * Game.xRatio &&
               Mouse.GetPosition(window).Y >= Y * Game.yRatio &&
               Mouse.GetPosition(window).Y <= Y * Game.yRatio + Height * Game.yRatio ||
               Mouse.GetPosition(window).X >= bar.Position.X * Game.xRatio &&
               Mouse.GetPosition(window).X <= bar.Position.X * Game.xRatio + bar.Size.X * Game.xRatio &&
               Mouse.GetPosition(window).Y >= bar.Position.Y * Game.yRatio &&
               Mouse.GetPosition(window).Y <= bar.Position.Y * Game.yRatio + bar.Size.Y * Game.yRatio) {

                if (isDisplaying) {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
                }

                return true;
            }
            else {
                return false;
            }
        }

        public bool Hover(RenderWindow window) {
            grabbed = false;

            return false;
        }

        public bool MouseDown(RenderWindow window) {
            if (MouseInBounds(window) && Mouse.IsButtonPressed(Mouse.Button.Left)) {
                grabbed = true;
            }

            if(grabbed) {
                float mouseX = Mouse.GetPosition(window).X / Game.xRatio;
                float mouseY = Mouse.GetPosition(window).Y / Game.yRatio;

                x = (int)(mouseX - (handle.Size.X / 2));
                handle.Position = new Vector2f(mouseX - (handle.Size.X / 2), handle.Position.Y);

                if (handle.Position.X <= bar.Position.X) {
                    x = (int)(bar.Position.X);
                    handle.Position = new Vector2f(bar.Position.X, handle.Position.Y);
                }

                if (handle.Position.X >= (bar.Position.X + bar.Size.X) - handle.Size.X) {
                    x = (int)((bar.Position.X + bar.Size.X) - handle.Size.X);
                    handle.Position = new Vector2f((bar.Position.X + bar.Size.X) - handle.Size.X, handle.Position.Y);
                }

                action();

                return true;
            }
            else {
                Reset();

                return false;
            }
        }

        public bool MouseUp(RenderWindow window) {
            grabbed = false;

            return true;
        }

        public void Reset() {

        }

        public int GetPosition() {
            handlePos = (int)((handle.Position.X - bar.Position.X) / ((bar.Size.X - handle.Size.X) / 100));

            return (int)((handle.Position.X - bar.Position.X) / (bar.Size.X / 100));
        }

        public void Draw(RenderTarget target, RenderStates states) {
            if (grabbed && Mouse.IsButtonPressed(Mouse.Button.Left)) {
                float mouseX = Mouse.GetPosition(Core.SVNE.window).X / Game.xRatio;
                float mouseY = Mouse.GetPosition(Core.SVNE.window).Y / Game.yRatio;

                x = (int)(mouseX - (handle.Size.X / 2));
                handle.Position = new Vector2f(mouseX - (handle.Size.X / 2), handle.Position.Y);

                if (handle.Position.X <= bar.Position.X) {
                    x = (int)(bar.Position.X);
                    handle.Position = new Vector2f(bar.Position.X, handle.Position.Y);
                }

                if (handle.Position.X >= (bar.Position.X + bar.Size.X) - handle.Size.X) {
                    x = (int)((bar.Position.X + bar.Size.X) - handle.Size.X);
                    handle.Position = new Vector2f((bar.Position.X + bar.Size.X) - handle.Size.X, handle.Position.Y);
                }

                GetPosition();
            }
            else {
                Reset();
            }

            target.Draw(bar, states);
            target.Draw(handle, states);
        }
    }
}
