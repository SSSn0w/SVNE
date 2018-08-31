using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;

namespace SVNE.Core.GUI {
    class DialogueFrame : Clickable, Drawable {
        public string Title;
        public string Dialogue;

        public Color TitleColor;
        public Color DialogueColor;

        public DialogueFrame() : base() {
            Title = "";
            Dialogue = "";
            TitleColor = new Color(0, 0, 0, 1);
            DialogueColor = new Color(0, 0, 0, 1);
        }

        public DialogueFrame(string Title, string Dialogue) {
            this.Title = Title;
            this.Dialogue = Dialogue;
            TitleColor = new Color(0, 0, 0, 1);
            DialogueColor = new Color(0, 0, 0, 1);
        }

        public DialogueFrame(string Title, string Dialogue, Color TitleColor, Color DialogueColor) {
            this.Title = Title;
            this.Dialogue = Dialogue;
            this.TitleColor = TitleColor;
            this.DialogueColor = DialogueColor;
        }

        public void MouseDown() {

        }

        public void MouseUp() {

        }

        public void Reset() {

        }

        public void Draw(RenderTarget target, RenderStates states) {
            //target.Draw(sprite, states);
        }
    }
}
