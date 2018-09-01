using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SVNE.Core.GUI {
    class TextBox : Clickable, Drawable{
        public void MouseDown() {

        }

        public void MouseUp() {

        }

        public void Hover() {
            throw new NotImplementedException();
        }

        public void Reset() {

        }

        public void Draw(RenderTarget target, RenderStates states) {
            //target.Draw(sprite, states);
        }
    }
}
