﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

using SVNE.Core;


namespace SVNE.Animations {
    class Shake : Animation {
        private Clock clock;
        private double counter = 0;
        private Sprite sprite;
        private double time;
        private int magnitude;
        private Vector2f position;
        private float tick;

        public Shake(Sprite sprite, double time, int magnitude, int speed) : base() {
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

            clock = new Clock();
        }

        public Shake(Character character, double time, int magnitude, int speed) {
            sprite = character.sprite;
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

            clock = new Clock();
        }

        public void Default() {
            sprite.Position = position;
        }

        public void Animate() {
            if (counter >= time) {
               
            }
            else {
                if (clock.ElapsedTime.AsSeconds() > tick) {
                    if(counter == 0) {
                        position = sprite.Position;
                    }

                    float x = new Random().Next(-magnitude, magnitude);
                    float y = new Random().Next(-magnitude, magnitude);
                    sprite.Position = position + new Vector2f(x, y);
                    clock.Restart();
                    counter += tick;
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
            if (counter >= time) {
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
