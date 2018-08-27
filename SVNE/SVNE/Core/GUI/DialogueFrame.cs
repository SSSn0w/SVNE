using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;

namespace SVNE.Core.GUI {
    class DialogueFrame {
        public string Title;
        public string Dialogue;

        public Color4 TitleColor;
        public Color4 DialogueColor;

        public DialogueFrame() : base() {
            Title = "";
            Dialogue = "";
            TitleColor = new Color4(0, 0, 0, 1.0f);
            DialogueColor = new Color4(0, 0, 0, 1.0f);
        }

        public DialogueFrame(string Title, string Dialogue) {
            this.Title = Title;
            this.Dialogue = Dialogue;
            TitleColor = new Color4(0, 0, 0, 1.0f);
            DialogueColor = new Color4(0, 0, 0, 1.0f);
        }

        public DialogueFrame(string Title, string Dialogue, Color4 TitleColor, Color4 DialogueColor) {
            this.Title = Title;
            this.Dialogue = Dialogue;
            this.TitleColor = TitleColor;
            this.DialogueColor = DialogueColor;
        }
    }
}
