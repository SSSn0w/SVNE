using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

using SVNE.Animations;

namespace SVNE.Transitions {
    class FadeToBlack : Animation {
        private Clock clock;
        private byte counter = 0;
        private byte endAlpha = 255;
        private RectangleShape cover;
        private byte time;

        public FadeToBlack(RectangleShape cover, int speed, RenderWindow window) {
            this.cover = cover;

            switch (speed) {
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

        public void Default() {
            clock.Dispose();
            cover.FillColor = new Color(0, 0, 0, endAlpha);
        }

        public void Animate() {
            if (counter >= endAlpha) {
                clock.Dispose();
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > 0.01f) {
                    cover.FillColor = new Color(0, 0, 0, counter);
                    clock.Restart();
                    counter += time;
                }
            }
        }

        public void StartEvent() {
            Animate();
        }

        public void EndEvent() {
            Default();
        }

        public bool Ended() {
            if (counter >= endAlpha) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
