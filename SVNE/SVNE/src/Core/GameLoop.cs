using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVNE.Core {
    public abstract class GameLoop {
        private bool runFlag = false;

        /**
         * Begin the game loop
         * @param delta time between logic updates (in seconds)
         */
        public void Run(RenderWindow window, double delta) {
            runFlag = true;

            Startup();
            // convert the time to seconds
            double nextTime = NanoTime();
            double maxTimeDiff = 0.5;
            int skippedFrames = 1;
            int maxSkippedFrames = 5;

            while (runFlag) {
                // convert the time to seconds
                double currTime = NanoTime();
                if ((currTime - nextTime) > maxTimeDiff) nextTime = currTime;
                if (currTime >= nextTime) {
                    // assign the time for the next update
                    nextTime += delta;
                    window.DispatchEvents();
                    Update();
                    if ((currTime < nextTime) || (skippedFrames > maxSkippedFrames)) {
                        Render();
                        window.Display();
                        skippedFrames = 1;
                    }
                    else {
                        skippedFrames++;
                    }
                }
                else {
                    // calculate the time to sleep
                    int sleepTime = (int)(1000.0 * (nextTime - currTime));
                    // sanity check
                    if (sleepTime > 0) {
                        // sleep until the next update
                        try {
                            Thread.Sleep(sleepTime);
                        } catch (Exception e) {
                            // do nothing
                        }
                    }
                }
            }
            Shutdown();
        }

        public void Stop() {
            runFlag = false;
        }

        private static long NanoTime() {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }

        public abstract void Startup();
        public abstract void Shutdown();
        public abstract void Update();
        public abstract void Render();
    }
}
