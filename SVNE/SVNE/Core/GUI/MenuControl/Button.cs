using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core.GUI.MenuControl {
    class Button {
        public int texture;
        public float x;
        public float y;
        public float width;
        public float height;

        public Button(int texture, float x, float y, float width, float height) {
            this.texture = texture;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void OnClick() {
            Console.WriteLine("Button clicked");
        }
    }
}
