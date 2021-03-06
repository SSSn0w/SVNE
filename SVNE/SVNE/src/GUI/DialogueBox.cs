﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;

using SVNE.Core;
using SVNE.Animations;

namespace SVNE.GUI {
    class DialogueBox : Event, Drawable {
        public string Title;
        public Character character;
        public char[] Dialogue;
        public string DialogueString = "";

        public int x;
        public int y;
        public int width;
        public int height;

        public Texture texture = new Texture("Assets/UI/dialogue_box.png");
        public Sprite sprite;
        public uint charSize;
        public float letterHeight;
        public Font font = new Font("Assets/Fonts/Consolas.ttf");
        public Text text;
        public Text title;
        public int marginTop = 100;
        public int marginLeft = 100;
        public int marginRight = 280;

        public Clock clock;
        public int counter = 0;
        private int charMax = 0;
        private int lineCount = 0;
        private int wordCount = 0;
        public bool End = false;

        public Animation animation;

        public Color TitleColor;
        public Color DialogueColor;

        public DialogueBox() : base() {
            Title = "";
            Dialogue = null;
            TitleColor = new Color(0, 0, 0, 255);
            DialogueColor = new Color(0, 0, 0, 255);
            width = (int)texture.Size.X;
            height = (int)texture.Size.Y;
            sprite = new Sprite(texture);

            clock = new Clock();
            text = new Text();
        }

        public DialogueBox(string Title, string Dialogue, uint charSize) {
            this.Title = Title;
            this.Dialogue = Dialogue.ToCharArray();
            this.charSize = charSize;
            //TitleColor = new Color(0, 0, 0, 255);
            TitleColor = new Color(255, 255, 255, 255);
            //DialogueColor = new Color(0, 0, 0, 255);
            DialogueColor = new Color(255, 255, 255, 255);

            width = (int)texture.Size.X;
            height = (int)texture.Size.Y;
            sprite = new Sprite(texture);

            clock = new Clock();

            string[] text = Dialogue.Split();
            this.text = new Text();

            SetTitle(Title);
        }

        public DialogueBox(string Title, string Dialogue, uint charSize, Animation animation) {
            this.Title = Title;
            this.Dialogue = Dialogue.ToCharArray();
            this.charSize = charSize;
            this.animation = animation;
            //TitleColor = new Color(0, 0, 0, 255);
            TitleColor = new Color(255, 255, 255, 255);
            //DialogueColor = new Color(0, 0, 0, 255);
            DialogueColor = new Color(255, 255, 255, 255);

            width = (int)texture.Size.X;
            height = (int)texture.Size.Y;
            sprite = new Sprite(texture);

            clock = new Clock();

            string[] text = Dialogue.Split();
            this.text = new Text();

            SetTitle(Title);
        }

        public DialogueBox(Character character, string Dialogue, uint charSize, Animation animation) {
            this.character = character;
            Title = character.Name;
            this.Dialogue = Dialogue.ToCharArray();
            this.charSize = charSize;
            this.animation = animation;
            TitleColor = new Color(255, 255, 255, 255);
            DialogueColor = new Color(255, 255, 255, 255);

            width = (int)texture.Size.X;
            height = (int)texture.Size.Y;
            sprite = new Sprite(texture);

            clock = new Clock();

            string[] text = Dialogue.Split();
            this.text = new Text();

            SetTitle(Title);
        }

        public DialogueBox(Character character, string Dialogue, uint charSize) {
            this.character = character;
            Title = character.Name;
            this.Dialogue = Dialogue.ToCharArray();
            this.charSize = charSize;
            TitleColor = new Color(255, 255, 255, 255);
            DialogueColor = new Color(255, 255, 255, 255);

            width = (int)texture.Size.X;
            height = (int)texture.Size.Y;
            sprite = new Sprite(texture);

            clock = new Clock();

            string[] text = Dialogue.Split();
            this.text = new Text();

            SetTitle(Title);
        }

        public DialogueBox(string Title, string Dialogue, Color TitleColor, Color DialogueColor) {
            this.Title = Title;
            this.Dialogue = Dialogue.ToCharArray();
            this.TitleColor = TitleColor;
            this.DialogueColor = DialogueColor;

            clock = new Clock();
            text = new Text();
        }

        public void SetTitle(string Title) {
            title = new Text(Title, font, 30);
            letterHeight = new Text(Title.ToCharArray()[0].ToString(), font, 30).GetGlobalBounds().Height;
            title.Color = TitleColor;
        }

        public void Animate() {
            if (counter >= Dialogue.Length || End) {
                while(counter < Dialogue.Length * 2) {
                    AnimateDialogue();
                }
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > 0.08f) {
                    AnimateDialogue();

                    clock.Restart();
                }
            }
        }

        public void AnimateDialogue() {
            text = new Text(DialogueString, font, charSize);
            text.Position = new Vector2f(sprite.GetGlobalBounds().Left + marginLeft, sprite.GetGlobalBounds().Top + marginTop);
            text.Color = DialogueColor;

            if (text.GetLocalBounds().Width >= sprite.GetGlobalBounds().Width - marginRight && charMax == 0) {
                charMax = DialogueString.Length;
            }

            try {
                if (charMax != 0 && DialogueString.EndsWith(" ")
                    && (DialogueString + String.Join("", Dialogue).Split(' ')[wordCount - 1]).ToString().Split('\n')[lineCount].Length >= charMax
                    /*|| charMax != 0
                    && DialogueString.Split('\n')[lineCount].Length >= charMax*/
                    || charMax != 0
                    && DialogueString.Split('\n')[lineCount].Split(' ').Last().Length >= charMax) {

                    DialogueString += "\n";
                    lineCount++;
                }
            } catch (Exception e) {
                //Console.WriteLine(e + " Out of bounds exception from DialogueBox. This is normal. Please Ignore.");
            }

            if (DialogueString.EndsWith("\n")) {
                DialogueString += Dialogue[counter].ToString().TrimStart();
            }
            else {
                DialogueString += Dialogue[counter];
            }

            wordCount = DialogueString.Count(Char.IsWhiteSpace);
            counter++;
        }

        public void StartEvent() {
            Animate();
            //SetTitle(character.Name);
            animation.StartEvent();
        }

        public void EndEvent() {
            if (counter != Dialogue.Length) {
                End = true;
                animation.EndEvent();
            }
            else {
                TimeLine.timeLineCounter++;
            }
        }

        public bool Ended() {
            if (End) {
                return true;
            }
            else {
                return false;
            }
        }

        public Event GetEvent() {
            return this;
        }

        public void Draw(RenderTarget target, RenderStates states) {
            sprite.Position = new Vector2f((1280 - width) / 2, (720 - height));
            title.Position = new Vector2f(text.Position.X, (525 - (int)letterHeight / 2));

            target.Draw(sprite, states);
            target.Draw(title, states);
            target.Draw(text, states);
        }
    }
}
