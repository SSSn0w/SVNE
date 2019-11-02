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
        public bool mouseDown = false;
        public bool changeCursor = true;
        public Func<int> action = () => 0;

        public Color notPressedColor;
        public Color pressedColor;
        public Color hoverColor;
        public uint charSize;
        public Font font;
        public Text text;
        public Sprite background;

        public bool hideAfterClick = false;

        public bool isDisplaying = false;

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

        public Button(string text, bool changeCursor, Color notPressedColor, Color pressedColor, Color hoverColor, uint charSize, Font font, int x, int y) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.changeCursor = changeCursor;
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

        public Button(string text, Color notPressedColor, Color pressedColor, Color hoverColor, uint charSize, Font font, int x, int y, Func<int> action, bool hideAfterClick) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.action = action;
            this.hideAfterClick = hideAfterClick;
            this.x = x;
            this.y = y;
            this.text = new Text(text, font, charSize);
            width = (int)this.text.GetGlobalBounds().Width;
            height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Color notPressedColor, Color pressedColor, Color hoverColor, uint charSize, Font font, int x, int y, bool hideAfterClick) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.hideAfterClick = hideAfterClick;
            this.x = x;
            this.y = y;
            this.text = new Text(text, font, charSize);
            width = (int)this.text.GetGlobalBounds().Width;
            height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Texture background, Color notPressedColor, Color pressedColor, Color hoverColor, uint charSize, Font font, int x, int y, Func<int> action, bool hideAfterClick) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.action = action;
            this.hideAfterClick = hideAfterClick;
            this.x = x;
            this.y = y;
            this.text = new Text(text, font, charSize);
            width = (int)this.text.GetGlobalBounds().Width;
            height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
            this.background = new Sprite(background);
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
            if (background == null) {
                if (Mouse.GetPosition(window).X >= X * Game.xRatio &&
                   Mouse.GetPosition(window).X <= X * Game.xRatio + Width * Game.xRatio &&
                   Mouse.GetPosition(window).Y >= Y * Game.yRatio &&
                   Mouse.GetPosition(window).Y <= Y * Game.yRatio + Height * Game.yRatio) {

                    if (isDisplaying && changeCursor) {
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
                    }

                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if (Mouse.GetPosition(window).X >= (x - width * 1.5f) * Game.xRatio &&
                   Mouse.GetPosition(window).X <= (x + width * 1.5f) * Game.xRatio + Width * Game.xRatio &&
                   Mouse.GetPosition(window).Y >= (y - height * 1.5f) * Game.yRatio &&
                   Mouse.GetPosition(window).Y <= (y + height * 1.5f) * Game.yRatio + Height * Game.yRatio) {

                    if (isDisplaying && changeCursor) {
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
                    }

                    return true;
                }
                else {
                    return false;
                }
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

            if (hideAfterClick) {
                IsDisplayed = false;
            }

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
            if (sprite != null) {
                sprite.Position = new Vector2f(x, y);
                target.Draw(sprite, states);
            }
            else {
                if(background != null) {
                    background.Position = new Vector2f(x - width * 1.5f, y - height * 1.5f);
                    background.Scale = new Vector2f(width * 4 / background.GetLocalBounds().Width, height * 4 / background.GetLocalBounds().Height);
                    target.Draw(background, states);
                }

                text.Position = new Vector2f(x, (y - (height / 2)));
                target.Draw(text, states);
            }
        }
    }
}
