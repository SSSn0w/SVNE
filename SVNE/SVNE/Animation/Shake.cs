using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;


namespace SVNE.Animation {
    class Shake {
        private Clock clock;
        private double counter = 0;
        private Sprite sprite;
        private double time;
        private int magnitude;
        private Vector2f origin;
        private float tick;

        public Shake(Sprite sprite, double time, int magnitude, int speed) {
            this.sprite = sprite;
            this.time = time;
            this.magnitude = magnitude;

            switch (speed) {
                //fast
                case 1:
                    tick = 0.01f;
                    break;
                //medium
                case 2:
                    tick = 0.04f;
                    break;
                //slow
                case 3:
                    tick = 0.08f;
                    break;
                default:
                    tick = 2;
                    break;
            }

            origin = sprite.Origin;
            clock = new Clock();
        }

        public void Animate() {
            if (counter >= time) {
                clock.Dispose();
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > tick) {
                    float x = new Random().Next(-magnitude, magnitude);
                    float y = new Random().Next(-magnitude, magnitude);
                    sprite.Origin = origin + new Vector2f(x, y);
                    clock.Restart();
                    counter += tick;
                }
            }
        }
    }
}
