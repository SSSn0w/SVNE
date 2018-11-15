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

            for (int i = 0; i < options.Count(); i++) {
                TimeLine.Options.Add(new Button(options[i].Text, new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 100, 100, () => { TimeLine.timeLineCounter++; return 0; }, true));
            }
        }

        public static int Display(int optionIndex) {
            TimeLine.Options[optionIndex].IsDisplayed = true;

            return 0;
        }
    }
}
