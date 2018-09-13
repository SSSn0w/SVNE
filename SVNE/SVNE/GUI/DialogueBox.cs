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
        public string DialogueString = "";

        public int x;
        public int y;
        public int width;
        public int height;

        public Texture texture = new Texture("Assets/dialogue_box.png");
        public Sprite sprite;
        public uint charSize;
        public Font font = new Font("Assets/Consolas.ttf");
        public Text text;
        public int marginTop = 100;
        public int marginLeft = 100;
        public int marginRight = 260;

        public Clock clock;
        private int counter = 0;
        private int charMax = 0;
        private int lineCount = 0;
        private int wordCount = 0;

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
            Game.Dialogue.Add(new Text());
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
            Game.Dialogue.Add(new Text());
        }

        public DialogueBox(string Title, string Dialogue, Color TitleColor, Color DialogueColor) {
            this.Title = Title;
            this.Dialogue = Dialogue.ToCharArray();
            this.TitleColor = TitleColor;
            this.DialogueColor = DialogueColor;

            clock = new Clock();
            Game.Dialogue.Add(new Text());
        }

        public void Animate() {
            if (counter >= Dialogue.Length) {
                clock.Dispose();
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > 0.08f) {
                    Game.Dialogue[0] = new Text(DialogueString, font, charSize);
                    Game.Dialogue[0].Origin = new Vector2f(-sprite.GetGlobalBounds().Left - marginLeft, -sprite.GetGlobalBounds().Top - marginTop);

                    if (Game.Dialogue[0].GetLocalBounds().Width >= sprite.GetGlobalBounds().Width - marginRight && charMax == 0) {
                        charMax = DialogueString.Length;
                    }

                    try {
                        if (charMax != 0 && DialogueString.EndsWith(" ") && (DialogueString + String.Join("", Dialogue).Split(' ')[wordCount - 1]).ToString().Split('\n')[lineCount].Length >= charMax) {
                            DialogueString += "\n";
                            lineCount++;
                        }
                    } catch(Exception e) {
                        Console.WriteLine("Out of bounds exception from DialogueBox. This is normal. Continuing...");
                    }

                    if (DialogueString.EndsWith("\n")) {
                        DialogueString += Dialogue[counter].ToString().TrimStart();
                    }
                    else {
                        DialogueString += Dialogue[counter];
                    }

                    wordCount = DialogueString.Count(Char.IsWhiteSpace);
                    counter++;

                    clock.Restart();
                }
            }
        }

        public void Draw(RenderTarget target, RenderStates states) {
            sprite.Origin = new Vector2f(-(1280 - width) / 2, -(720 - height));
            target.Draw(sprite, states);
        }
    }
}
