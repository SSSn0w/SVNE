using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

using SVNE.Core;

namespace SVNE.Animations {
    class FadeIn : Animation {
        private Clock clock;
        private byte counter = 0;
        private byte endAlpha = 255;
        private Sprite sprite;
        private byte time;

        public FadeIn(Sprite sprite, int speed) : base() {
            this.sprite = sprite;
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

        public FadeIn(Character character, int speed) {
            sprite = character.sprite;
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
            sprite.Color = new Color(255, 255, 255, endAlpha);
        }

        public void Animate() {
            if (counter >= endAlpha) {
                clock.Dispose();
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > 0.01f) {
                    sprite.Color = new Color(255, 255, 255, counter);
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
            if(counter >= endAlpha) {
                return true;
            }
            else {
                return false;
            }
        }

        public Event GetEvent() {
            return this;
        }
    }
}
