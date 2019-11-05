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
                SceneJump sceneJump = new SceneJump(options, i);

                list.Add(new Button(options[i].Text, new Texture("Assets/UI/game_option_background.png"),new Color(255, 255, 255), new Color(255, 0, 0), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 0, 100 * (i + 1), () => {
                    sceneJump.Jump();
                    return 0;
                }, true));

                list[i].X = (int)SVNE.window.Size.X / 2 - list[i].Width / 2;
                //list[i].background.Position = new Vector2f(x - width * 1.5f, y - height * 1.5f);
            }

            TimeLine.Options.Add(list);
        }

        public static int Display(int optionIndex) {
            Game.storyOptionsOpen = true;

            TimeLine.timeLineCounter--;
            InputHandler.hideControls = false;

            foreach(Clickable control in TimeLine.Options[optionIndex]) {
                control.IsDisplayed = true;
            }

            return 0;
        }
    }
}
