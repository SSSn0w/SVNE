using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using SFML.Graphics;
using SFML.System;

using OpenTK;
using OpenTK.Input;

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

        public Brush notPressedColor;
        public Brush pressedColor;
        public Brush hoverColor;
        public uint charSize;
        public System.Drawing.Font font;
        public string text;
        public Brush defaultColor;
        public Brush textColor;
        public int background;

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

        public Button(Sprite notPressed, Sprite pressed, int x, int y, int width, int height, Func<int> action) {
            this.notPressed = notPressed;
            this.pressed = pressed;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.action = action;
            this.notPressed.Texture.Repeated = true;
            this.pressed.Texture.Repeated = true;
            sprite = notPressed;
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

        public Button(Sprite notPressed, Sprite pressed, Sprite hover, int x, int y, int width, int height, Func<int> action) {
            this.notPressed = notPressed;
            this.pressed = pressed;
            this.hover = hover;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.action = action;
            this.notPressed.Texture.Repeated = true;
            this.pressed.Texture.Repeated = true;
            sprite = notPressed;
        }

        public Button(string text, Brush notPressedColor, Brush pressedColor, uint charSize, System.Drawing.Font font, int x, int y) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.charSize = charSize;
            this.font = font;
            this.x = x;
            this.y = y;
            //this.text = new Text(text, font, charSize);
            //width = (int)this.text.GetGlobalBounds().Width;
            //height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Brush notPressedColor, Brush pressedColor, uint charSize, System.Drawing.Font font, int x, int y, Func<int> action) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.charSize = charSize;
            this.font = font;
            this.action = action;
            this.x = x;
            this.y = y;
            //this.text = new Text(text, font, charSize);
            //width = (int)this.text.GetGlobalBounds().Width;
            //height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Brush notPressedColor, Brush pressedColor, Brush hoverColor, uint charSize, System.Drawing.Font font, int x, int y) {
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.x = x;
            this.y = y;
            //this.text = new Text(text, font, charSize);
            //width = (int)this.text.GetGlobalBounds().Width;
            //height = (int)this.text.GetGlobalBounds().Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Brush notPressedColor, Brush pressedColor, Brush hoverColor, System.Drawing.Font font, int x, int y) {
            this.text = text;
            this.defaultColor = notPressedColor;
            this.textColor = notPressedColor;
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.font = font;
            this.x = x;
            this.y = y;
            //this.text = new Text(text, font, charSize);
            width = (int)Game.textRenderer.MeasureString(text, font).Width;
            height = (int)Game.textRenderer.MeasureString(text, font).Height;
            this.y = this.y + height / 2;
        }

        //====================================================================================================================================================================
        //====================================================================================================================================================================
        //====================================================================================================================================================================

        public Button(string text, Brush notPressedColor, Brush pressedColor, Brush hoverColor, System.Drawing.Font font, int x, int y, Func<int> action) {
            this.text = text;
            this.defaultColor = notPressedColor;
            this.textColor = notPressedColor;
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.font = font;
            this.action = action;
            this.x = x;
            this.y = y;
            //this.text = new Text(text, font, charSize);
            width = (int)Game.textRenderer.MeasureString(text, font).Width;
            height = (int)Game.textRenderer.MeasureString(text, font).Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Brush notPressedColor, Brush pressedColor, Brush hoverColor, uint charSize, System.Drawing.Font font, int x, int y, Func<int> action, bool hideAfterClick) {
            this.text = text;
            this.defaultColor = notPressedColor;
            this.textColor = notPressedColor;
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.action = action;
            this.hideAfterClick = hideAfterClick;
            this.x = x;
            this.y = y;
            //this.text = new Text(text, font, charSize);
            width = (int)Game.textRenderer.MeasureString(text, font).Width;
            height = (int)Game.textRenderer.MeasureString(text, font).Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, Brush notPressedColor, Brush pressedColor, Brush hoverColor, uint charSize, System.Drawing.Font font, int x, int y, bool hideAfterClick) {
            this.text = text;
            this.defaultColor = notPressedColor;
            this.textColor = notPressedColor;
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.hideAfterClick = hideAfterClick;
            this.x = x;
            this.y = y;
            //this.text = new Text(text, font, charSize);
            width = (int)Game.textRenderer.MeasureString(text, font).Width;
            height = (int)Game.textRenderer.MeasureString(text, font).Height;
            this.y = this.y + height / 2;
        }

        public Button(string text, int background, Brush notPressedColor, Brush pressedColor, Brush hoverColor, uint charSize, System.Drawing.Font font, int x, int y, Func<int> action, bool hideAfterClick) {
            this.text = text;
            this.defaultColor = notPressedColor;
            this.textColor = notPressedColor;
            this.notPressedColor = notPressedColor;
            this.pressedColor = pressedColor;
            this.hoverColor = hoverColor;
            this.charSize = charSize;
            this.font = font;
            this.action = action;
            this.hideAfterClick = hideAfterClick;
            this.x = x;
            this.y = y;
            //this.text = new Text(text, font, charSize);
            width = (int)Game.textRenderer.MeasureString(text, font).Width;
            height = (int)Game.textRenderer.MeasureString(text, font).Height;
            this.y = this.y + height / 2;
            this.background = background;
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

            if (background == 0) {
                if (mState.X >= X * Game.xRatio &&
                   mState.X <= X * Game.xRatio + Width * Game.xRatio &&
                   mState.Y >= Y - (height / 2) * Game.yRatio &&
                   mState.Y <= Y - (height / 2) * Game.yRatio + Height * Game.yRatio) {

                    if (isDisplaying && changeCursor) {
                        //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
                    }
                    
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if (mState.X >= (x - width) * Game.xRatio &&
                   mState.X <= (x + width) * Game.xRatio + Width * Game.xRatio &&
                   mState.Y >= (y - height) * Game.yRatio &&
                   mState.Y <= (y + height) * Game.yRatio + Height * Game.yRatio) {

                    Console.WriteLine(mState.X + ", " + mState.Y);

                    if (isDisplaying && changeCursor) {
                        //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
                    }

                    return true;
                }
                else {
                    return false;
                }
            }
        }

        public bool MouseDown() {
            MouseState mState = Mouse.GetCursorState();

            if (MouseInBounds() && mState.IsButtonDown(MouseButton.Left)) {
                if (sprite != null) {
                    sprite = pressed;
                }
                else {
                    textColor = pressedColor;
                }

                return true;
            }
            else {
                Reset();

                return false;
            }
        }

        public bool MouseUp() {
            MouseState mState = Mouse.GetCursorState();

            if (sprite != null) {
                sprite = notPressed;
            }
            else {
                textColor = notPressedColor;
            }

            action();

            if (hideAfterClick) {
                IsDisplayed = false;
            }

            return true;
        }

        public bool Hover() {
            if (MouseInBounds()) {
                if (hover != null) {
                    sprite = hover;
                    return true;
                }

                if (hoverColor != defaultColor) {
                    textColor = hoverColor;
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
                textColor = notPressedColor;
            }
        }

        public void Draw() {
            /*if (sprite != null) {
                sprite.Position = new Vector2f(x, y);
                //Draw(sprite);
            }
            else {
                if(background != null) {
                    background.Position = new Vector2f(x - width * 1.5f, y - height * 1.5f);
                    background.Scale = new Vector2f(width * 4 / background.GetLocalBounds().Width, height * 4 / background.GetLocalBounds().Height);
                    target.Draw(background, states);
                }

                //text.Position = new Vector2f(x, (y - (height / 2)));
            }*/

            Game.textRenderer.Clear(System.Drawing.Color.Empty);

            PointF position = new PointF(x, (y - (height / 2)));
            Game.textRenderer.DrawString(text, font, textColor, position);

            Functions.DrawText(Game.textRenderer.Texture);
        }
    }
}
