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
    class Slider : Clickable
    {
        public RectangleShape bar;
        public RectangleShape handle;

        public int x;
        public int y;
        public int width;
        public int height;

        public bool grabbed = false;

        public Slider(RectangleShape bar, RectangleShape handle) : base()
        {
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

        public int GetX
        {
            get { return x; }
            set { x = value; }
        }

        public int GetY
        {
            get { return y; }
            set { y = value; }
        }

        public int GetWidth
        {
            get { return width; }
            set { width = value; }
        }

        public int GetHeight
        {
            get { return height; }
            set { height = value; }
        }

        public bool MouseInBounds(RenderWindow window) {
            if (Mouse.GetPosition(window).X >= GetX &&
               Mouse.GetPosition(window).X <= GetX + GetWidth &&
               Mouse.GetPosition(window).Y >= GetY &&
               Mouse.GetPosition(window).Y <= GetY + GetHeight ||
               Mouse.GetPosition(window).X >= bar.Position.X &&
               Mouse.GetPosition(window).X <= bar.Position.X + bar.Size.X &&
               Mouse.GetPosition(window).Y >= bar.Position.Y &&
               Mouse.GetPosition(window).Y <= bar.Position.Y + bar.Size.Y) {

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
                return true;
            }
            else {
                return false;
            }
        }

        public bool Hover(RenderWindow window)
        {
            grabbed = false;

            return false;
        }

        public bool MouseDown(RenderWindow window)
        {
            if (MouseInBounds(window) && Mouse.IsButtonPressed(Mouse.Button.Left)) {
                grabbed = true;
            }

            if(grabbed) {
                int mouseX = Mouse.GetPosition(window).X;
                int mouseY = Mouse.GetPosition(window).Y;

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

                return true;
            }
            else {
                Reset();

                return false;
            }
        }

        public bool MouseUp(RenderWindow window)
        {
            grabbed = false;

            return true;
        }

        public void Reset()
        {

        }

        public void GetPosition() {
            Console.WriteLine((handle.Position.X - bar.Position.X) / (bar.Size.X / 100));
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(bar, states);
            target.Draw(handle, states);
        }
    }
}