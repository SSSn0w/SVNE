using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;

using SVNE.Core;

namespace SVNE.GUI {
    class DialogueBox : Drawable {
        public string Title;
        public char[] Dialogue;

        public int x;
        public int y;
        public int width;
        public int height;

        public Texture texture = new Texture("Assets/dialogue_box.png");
        public Sprite sprite;
        public uint charSize;
        public Font font = new Font("Assets/Consolas.ttf");
        public Text text;

        public Clock clock;
        private int counter = 0;

        public Color TitleColor;
        public Color DialogueColor;

        public DialogueBox() : base() {
            Title = "";
            Dialogue = null;
            TitleColor = new Color(0, 0, 0, 1);
            DialogueColor = new Color(0, 0, 0, 1);
            width = (int)texture.Size.X;
            height = (int)texture.Size.Y;
            sprite = new Sprite(texture);

            clock = new Clock();
        }

        public DialogueBox(string Title, string Dialogue, uint charSize) {
            this.Title = Title;
            this.Dialogue = Dialogue.ToCharArray();
            this.charSize = charSize;
            TitleColor = new Color(0, 0, 0, 1);
            DialogueColor = new Color(0, 0, 0, 1);

            width = (int)texture.Size.X;
            height = (int)texture.Size.Y;
            sprite = new Sprite(texture);

            clock = new Clock();
            string[] text = Dialogue.Split();
        }

        public DialogueBox(string Title, string Dialogue, Color TitleColor, Color DialogueColor) {
            this.Title = Title;
            this.Dialogue = Dialogue.ToCharArray();
            this.TitleColor = TitleColor;
            this.DialogueColor = DialogueColor;

            clock = new Clock();
        }

        public void AnimateText() {
            if (counter >= Dialogue.Length) {
                clock.Dispose();
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > 0.08f) {
                    Game.Dialogue.Add(new Text(Dialogue[counter].ToString(), font, charSize));
                    Game.Dialogue.ElementAt(counter).Origin = new Vector2f(-340 - counter * (charSize / 2), -560);

                    clock.Restart();
                    counter++;
                }
            }
        }

        public void Draw(RenderTarget target, RenderStates states) {
            sprite.Origin = new Vector2f(-(1280 - width) / 2, -(720 - height));
            target.Draw(sprite, states);
        }
    }
}
