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
        private int counter = 0;
        private Sprite sprite;
        private double time;

        public FadeIn(Sprite sprite, double time) {
            this.sprite = sprite;
            this.time = time;
            clock = new Clock();
        }

        public void Start() {
            if (counter < 0) {
                clock.Dispose();
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > 1f) {
                    Core.Game.sprite.Color = new Color(255, 255, 255, 255 - 100);
                    clock.Restart();
                    counter++;
                }
            }
        }
    }
}
