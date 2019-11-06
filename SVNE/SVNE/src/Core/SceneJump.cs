using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNE.Core {
    class SceneJump {
        List<Option> options;
        int i;

        public SceneJump(List<Option> options, int i) {
            this.options = options;
            this.i = i;
        }

        public void Jump() {
            Game.storyOptionsOpen = false;

            foreach (Event _event in TimeLine.timeLine.ToList()) {
                if (_event is Scene) {
                    Scene scene = (Scene)_event;
                    if (options[i].JumpToScene.Equals(scene.Title)) {

                        if(scene.Position <= TimeLine.timeLineCounter) {
                            TimeLine.LoadVariables();
                            TimeLine.Load();
                        }

                        TimeLine.timeLineCounter = scene.Position;
                    }
                }
            }
        }
    }
}
