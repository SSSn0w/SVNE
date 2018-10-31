using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

using SVNE.Core;

namespace SVNE.GUI {
    class Button : Clickable {
        public Sprite notPressed;
        public Sprite pressed;
        public Sprite hover;
        public Sprite sprite;
        public int x;
        public int y;
        public int width;
        public int height;
        public Func<int> action = () => 0;

        public Color notPressedColor;
        public Color pressedColor;
        public Color hoverColor;
        public uint charSize;
        public Font font;
        public Text text;

        public Button(Texture notPressed, Texture pressed, int x, int y, int width, int height) : base() {
            this.notPressed = new Sprite(notPressed, new IntRect(x, y, width, height));
            this.pressed = new Sprite(pressed, new IntRect(x, y, width, height));
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.notPressed.Texture.Repeated = true;
            this.pressed.Texture.Repeated = true;
            sprite = new Sprite(notPressed, new IntRect(x, y, width, height));
        }

        public Button(Texture notPressed, Texture pressed, int x, int y, int width, int height, Func<int> action) {
            this.notPressed = new Sprite(notPressed, new IntRect(x, y, width, height));
            this.pressed = new Sprite(pressed, new IntRect(x, y, width, height));
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.action = action;
            this.notPressed.Texture.Repeated = true;
            this.pressed.Texture.Repeated = true;
            sprite = new Sprite(notPressed, new IntRect(x, y, width, height));
        }

        public Button(Texture notPressed, Texture pressed, Texture hover, int x, int y, int width, int height) {
            this.notPressed = new Sprite(notPressed, new IntRect(x, y, width, height));
            this.pressed = new Sprite(pressed, new IntRect(x, y, width, height));
            this.hover = new Sprite(hover, new IntRect(x, y, width, height));
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.notPressed.Texture.Repeated = true;
            this.pressed.Texture.Repeated = true;
            sprite = new Sprite(notPressed, new IntRect(x, y, width, height));
        }

        public Button(Texture notPressed, Texture pressed, Texture hover, int x, int y, int width, int height, Func<int> action) {
            this.notPressed = new Sprite(notPressed, new IntRect(x, y, width, height));
            this.pressed = new Sprite(pressed, new IntRect(x, y, width, height));
            this.hover = new Sprite(hover, new IntRect(x, y, width, height));
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.action = action;
            this.notPressed.Texture.Repeated = true;
            this.pressed.Texture.Repeated = true;
            sprite = new Sprite(notPressed, new IntRect(x, y, width, height));
        }

        public Button(string text, Color notPressedColor, Color pressedColor, uint charSize, Font font, int x, int y) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.charSize = charSize;
            this.font = font;
            this.x = x;
            this.y = y;
            this.text = new Text(text, font, charSize);
            width = (int)this.text.GetGlobalBounds().Width;
            height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Color notPressedColor, Color pressedColor, uint charSize, Font font, int x, int y, Func<int> action) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.charSize = charSize;
            this.font = font;
            this.action = action;
            this.x = x;
            this.y = y;
            this.text = new Text(text, font, charSize);
            width = (int)this.text.GetGlobalBounds().Width;
            height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Color notPressedColor, Color pressedColor, Color hoverColor, uint charSize, Font font, int x, int y) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.x = x;
            this.y = y;
            this.text = new Text(text, font, charSize);
            width = (int)this.text.GetGlobalBounds().Width;
            height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Color notPressedColor, Color pressedColor, Color hoverColor, uint charSize, Font font, int x, int y, Func<int> action) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.action = action;
            this.x = x;
            this.y = y;
            this.text = new Text(text, font, charSize);
            width = (int)this.text.GetGlobalBounds().Width;
            height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
        }

        public int GetX {
            get { return x; }
            set { x = value; }
        }

        public int GetY {
            get { return y; }
            set { y = value; }
        }

        public int GetWidth {
            get { return width; }
            set { width = value; }
        }

        public int GetHeight {
            get { return height; }
            set { height = value; }
        }

        public bool MouseInBounds(RenderWindow window) {
            if(Mouse.GetPosition(window).X >= GetX * Game.xRatio &&
               Mouse.GetPosition(window).X <= GetX * Game.xRatio + GetWidth * Game.xRatio &&
               Mouse.GetPosition(window).Y >= GetY * Game.yRatio &&
               Mouse.GetPosition(window).Y <= GetY * Game.yRatio + GetHeight * Game.yRatio) {

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
                return true;
            }
            else {
                return false;
            }
        }

        public bool MouseDown(RenderWindow window) {
            if (MouseInBounds(window) && Mouse.IsButtonPressed(Mouse.Button.Left)) {
                if (sprite != null) {
                    sprite = pressed;
                }
                else {
                    text.Color = pressedColor;
                }

                return true;
            }
            else {
                Reset();

                return false;
            }
        }

        public bool MouseUp(RenderWindow window) {
            if (sprite != null) {
                sprite = notPressed;
            }
            else {
                text.Color = notPressedColor;
            }

            action();

            return true;
        }

        public bool Hover(RenderWindow window) {
            if (MouseInBounds(window)) {
                if (hover != null) {
                    sprite = hover;
                    return true;
                }

                if (hoverColor != default(Color)) {
                    text.Color = hoverColor;
                    return true;
                }

                return false;
            }
            else {
                Reset();

                return false;
            }
        }

        public void Reset() {
            if (sprite != null) {
                sprite = notPressed;
            }
            else {
                text.Color = notPressedColor;
            }
        }

        public void Draw(RenderTarget target, RenderStates states) {
            float x = -this.x;
            float y = -this.y;

            if (sprite != null) {

                sprite.Origin = new Vector2f(x, y);
                target.Draw(sprite, states);
            }
            else {
                text.Origin = new Vector2f(x, (y - -(height / 2)));
                target.Draw(text, states);
            }
        }
    }
}
