using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace SVNE.Core.GUI {
    class DialogueBox : Drawable {
        public string Title;
        public string Dialogue;

        public int x;
        public int y;
        public int width;
        public int height;

        public Texture texture = new Texture("Assets/dialogue_box.png");
        public Sprite sprite;
        public uint charSize;
        public Font font;
        public Text text;

        public Color TitleColor;
        public Color DialogueColor;

        public DialogueBox() : base() {
            Title = "";
            Dialogue = "";
            TitleColor = new Color(0, 0, 0, 1);
            DialogueColor = new Color(0, 0, 0, 1);
            width = (int)texture.Size.X;
            height = (int)texture.Size.Y;
            sprite = new Sprite(texture);
        }

        public DialogueBox(string Title, string Dialogue) {
            this.Title = Title;
            this.Dialogue = Dialogue;
            TitleColor = new Color(0, 0, 0, 1);
            DialogueColor = new Color(0, 0, 0, 1);
        }

        public DialogueBox(string Title, string Dialogue, Color TitleColor, Color DialogueColor) {
            this.Title = Title;
            this.Dialogue = Dialogue;
            this.TitleColor = TitleColor;
            this.DialogueColor = DialogueColor;
        }

        public void Draw(RenderTarget target, RenderStates states) {
            sprite.Origin = new Vector2f(-(1280 - width) / 2, -(720 - height));
            target.Draw(sprite, states);
        }
    }
}
