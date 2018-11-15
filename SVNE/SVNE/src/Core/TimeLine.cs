using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

using SVNE.GUI;
using SVNE.Animations;

namespace SVNE.Core {
    static class TimeLine {
        public static List<Event> timeLine;
        public static int timeLineCounter = 0;

        public static List<Drawable> Objects;
        public static List<Clickable> Options;

        public static Character mystery = new Character("???");
        public static Character magilou = new Character("Magilou", "Assets/character.png", 0.2f);

        public static void Load() {
            timeLine = new List<Event>();
            Objects = new List<Drawable>();
            Options = new List<Clickable>();

            //StoryOptions.Add(new List<Option>() { new Option("test 1"), new Option("test 2"), new Option("test 3") });
            StoryOptions.Add(new List<Option>() { new Option("test 1") });

            magilou.sprite.Color = new Color(255, 255, 255, 0);
            //timeLine.Add(new EventTrigger(new Function(() => magilou.ChangePos("right")), true));

            timeLine.Add(new EventTrigger(new Transitions.FadeFromBlack(Game.sceneOverlay, 3, SVNE.window), true));
            timeLine.Add(new DialogueBox(mystery, "So, what brings you here?", 20, new Animations.FadeIn(magilou, 2)));
            timeLine.Add(new DialogueBox("Me", "Uh...who are you again??", 20));

            timeLine.Add(new EventTrigger(new Function(() => StoryOptions.Display(0)), false));

            timeLine.Add(new DialogueBox(mystery, "Me? Why, I am the great Magilou of course!!", 20));
            timeLine.Add(new DialogueBox(magilou, "Now answer the question!", 20));
            timeLine.Add(new DialogueBox("Me", "Oh, uh, nothing really. I was just taking a look around and saw this cool mansion so I invited myself in.", 20));
            timeLine.Add(new DialogueBox(magilou, "Isn't that trespassing though?", 20, new Animations.Shake(magilou, 10, 5, 1)));
            timeLine.Add(new DialogueBox("Me", ".....", 20));
            timeLine.Add(new DialogueBox(magilou, "Hmm, as I thought. Get out of here before the others get here.", 20));
            timeLine.Add(new DialogueBox("Me", "The others?", 20));
            timeLine.Add(new DialogueBox(magilou, "Yes. The others. Now scram!!", 20));
            timeLine.Add(new DialogueBox("Me", "Sure thing boss!", 20, new Animations.FadeOut(magilou, 2)));
            timeLine.Add(new EventTrigger(new Transitions.FadeToBlack(Game.sceneOverlay, 3, SVNE.window), true));
            timeLine.Add(new EventTrigger(new StateEvent((int)Game.States.MainMenu)));
        }
    }
}
