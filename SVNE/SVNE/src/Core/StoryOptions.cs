using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

using SVNE.GUI;

namespace SVNE.Core {
    class StoryOptions {
        public static List<List<Option>> OptionList = new List<List<Option>>();

        public static void Add(List<Option> options) {
            OptionList.Add(options);

            List<Clickable> list = new List<Clickable>();
            for (int i = 0; i < options.Count(); i++) {
                list.Add(new Button(options[i].Text, new Color(255, 255, 255), new Color(255, 0, 0), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 5, 100 * (i + 1), () => {
                    /*foreach (Event _event in TimeLine.timeLine) {
                        if (_event is Scene) {
                            Scene scene = (Scene) _event;
                            for (int option = 0; option < options.Count(); option++) {
                                if (options[option].JumpToScene.Equals(scene.Title)) {
                                    Console.WriteLine(scene.Title);
                                    Console.WriteLine(option);

                                    TimeLine.timeLineCounter = scene.Position;

                                    Console.WriteLine(TimeLine.timeLineCounter);
                                    return 0;
                                }
                            }
                        }
                    }*/

                    TimeLine.timeLineCounter += 2;
                    return 0;
                }, true));
            }

            TimeLine.Options.Add(list);
        }

        public static int Display(int optionIndex) {
            TimeLine.timeLineCounter--;
            InputHandler.hideControls = false;

            foreach(Clickable control in TimeLine.Options[optionIndex]) {
                control.IsDisplayed = true;
            }

            return 0;
        }
    }
}
