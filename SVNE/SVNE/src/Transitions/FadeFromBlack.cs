using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

using SVNE.Animations;
using SVNE.Core;

namespace SVNE.Transitions {
    class FadeFromBlack : Transition {
        private RenderWindow window;
        private Clock clock;
        private byte counter = 255;
        private byte endAlpha = 0;
        private RectangleShape cover;
        private byte time;

        public FadeFromBlack(int speed, RenderWindow window) {
            this.window = window;

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

            var itemToRemove = TimeLine.Objects.Single(r => r.Equals(cover));
            TimeLine.Objects.Remove(itemToRemove);
        }

        public void Animate() {
            if (counter <= endAlpha) {
                clock.Dispose();
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > 0.01f) {
                    cover.FillColor = new Color(0, 0, 0, counter);
                    clock.Restart();
                    counter -= time;
                }
            }
        }

        public void StartEvent() {
            if(counter == 255) {
                cover = new RectangleShape(new Vector2f(window.DefaultView.Size.X, window.DefaultView.Size.Y));
                TimeLine.Objects.Add(cover);
                cover = (RectangleShape)TimeLine.Objects[TimeLine.Objects.FindIndex(r => r.Equals(cover))];
            }

            Animate();
        }

        public void EndEvent() {
            Default();
        }

        public bool Ended() {
            if (counter <= endAlpha) {
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
