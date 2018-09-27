using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace SVNE.Animation {
    class FadeOut {
        private Clock clock;
        private byte counter = 255;
        private Sprite sprite;
        private byte time;

        public FadeOut(Sprite sprite, int speed) {
            this.sprite = sprite;
            switch(speed) {
                //fast
                case 1:
                    time = 5;
                    break;
                //medium
                case 2:
                    time = 3;
                    break;
                //slow
                case 3:
                    time = 1;
                    break;
                default:
                    time = 3;
                    break;
            }
            clock = new Clock();
        }

        public int Animate() {
            if (counter <= 1) {
                clock.Dispose();
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > 0.01f) {
                    sprite.Color = new Color(255, 255, 255, counter);
                    clock.Restart();
                    counter -= time;
                }
            }

            return 0;
        }
    }
}
