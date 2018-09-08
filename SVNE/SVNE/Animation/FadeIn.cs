using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace SVNE.Animation {
    class FadeIn {
        private Clock clock;
        private byte counter = 0;
        private Sprite sprite;
        private byte time;

        public FadeIn(Sprite sprite, int speed) {
            this.sprite = sprite;
            switch (speed) {
                //fast
                case 1:
                    time = 3;
                    break;
                //medium
                case 2:
                    time = 2;
                    break;
                //slow
                case 3:
                    time = 1;
                    break;
                default:
                    time = 2;
                    break;
            }
            clock = new Clock();
        }

        public void Animate() {
            if (counter >= 255) {
                clock.Dispose();
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > 0.02f) {
                    sprite.Color = new Color(255, 255, 255, counter);
                    clock.Restart();
                    counter += time;
                }
            }
        }
    }
}
