using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SVNE.GUI;
using SVNE.Animations;

namespace SVNE.Core {
    static class TimeLine {
        public static List<Event> timeLine;
        public static int timeLineCounter = 0;

        public static void Load() {
            timeLine = new List<Event>();

            timeLine.Add(new EventTrigger(new Transitions.FadeFromBlack(Game.sceneOverlay, 3, SVNE.window), true));
            timeLine.Add(new DialogueBox("???", "So, what brings you here?", 20, new Animations.FadeIn(Game.sprite, 2)));
            timeLine.Add(new DialogueBox("Me", "Uh...who are you again??", 20));
            timeLine.Add(new DialogueBox("???", "Me? Why, I am the great Magilou of course!!", 20));
            timeLine.Add(new DialogueBox("Magilou", "Now answer the question!", 20));
            timeLine.Add(new DialogueBox("Me", "Oh, uh, nothing really. I was just taking a look around and saw this cool mansion so I invited myself in.", 20));
            timeLine.Add(new DialogueBox("Magilou", "Isn't that trespassing though?", 20, new Animations.Shake(Game.sprite, 10, 10, 1)));
            timeLine.Add(new DialogueBox("Me", ".....", 20));
            timeLine.Add(new DialogueBox("Magilou", "Hmm, as I thought. Get out of here before the others get here.", 20));
            timeLine.Add(new DialogueBox("Me", "The others?", 20));
            timeLine.Add(new DialogueBox("Magilou", "Yes. The others. Now scram!!", 20));
            timeLine.Add(new DialogueBox("Me", "Sure thing boss!", 20, new Animations.FadeOut(Game.sprite, 2)));
            timeLine.Add(new EventTrigger(new Transitions.FadeToBlack(Game.sceneOverlay, 3, SVNE.window), true));
            timeLine.Add(new EventTrigger(new StateEvent((int)Game.States.MainMenu)));
        }
    }
}
