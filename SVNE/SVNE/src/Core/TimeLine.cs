using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Audio;

using SVNE.GUI;
using SVNE.Animations;

namespace SVNE.Core {
    //LOAD ALL OF THIS FROM FILE EVENTUALLY

    static class TimeLine {
        public static List<Event> timeLine;
        public static int timeLineCounter = 0;

        public static List<Drawable> Objects;
        public static List<List<Clickable>> Options;

        public static uint charSize = 20;

        public static Sprite Background = new Sprite(new Texture("Assets/Backgrounds/background.jpg"));

        public static Character mystery = new Character("???");
        public static Character magilou = new Character("Magilou", "Assets/Characters/Magilou/character.png", 0.2f);

        //public static Sound musicPlayer = new Sound();
        public static Music musicPlayer;

        public static void Load() {
            timeLine = new List<Event>();
            Objects = new List<Drawable>();
            Options = new List<List<Clickable>>();

            magilou.sprite.Color = new Color(255, 255, 255, 0);
            magilou.ChangePos("center");
            Objects.Add(magilou);
            //timeLine.Add(new EventTrigger(new Function(() => magilou.ChangePos("right")), true));

            timeLine.Add(new Scene("Scene1", timeLine.Count(), "Assets/Backgrounds/background.jpg"));

            timeLine.Add(new EventTrigger(new Transitions.FadeFromBlack(3, SVNE.window), true));
            timeLine.Add(new DialogueBox(mystery, "So, what brings you here?", charSize, new Animations.FadeIn(magilou, 2)));
            timeLine.Add(new DialogueBox("Me", "Uh...who are you again??", charSize));

            StoryOptions.Add(new List<Option>() { new Option("Scene 1", "Scene1"), new Option("Scene 2", "Scene2"), new Option("Scene 3", "Scene3") });
            timeLine.Add(new EventTrigger(new Function(() => StoryOptions.Display(0)), false));

            timeLine.Add(new DialogueBox(mystery, "Me? Why, I am the great Magilou of course!!", charSize));

            timeLine.Add(new Scene("Scene2", timeLine.Count(), "Assets/Backgrounds/background.jpg"));

            timeLine.Add(new DialogueBox(magilou, "Now answer the question!", charSize));
            timeLine.Add(new DialogueBox("Me", "Oh, uh, nothing really. I was just taking a look around and saw this cool mansion so I invited myself in.", charSize));
            timeLine.Add(new DialogueBox(magilou, "Isn't that trespassing though?", charSize, new Animations.Shake(magilou, 10, 5, 1)));
            timeLine.Add(new DialogueBox("Me", ".....", charSize));

            timeLine.Add(new Scene("Scene3", timeLine.Count(), "Assets/Backgrounds/background.jpg"));

            timeLine.Add(new DialogueBox(magilou, "Hmm, as I thought. Get out of here before the others get here.", charSize));
            timeLine.Add(new DialogueBox("Me", "The others?", charSize));
            timeLine.Add(new DialogueBox(magilou, "Yes. The others. Now scram!!", charSize));
            timeLine.Add(new DialogueBox("Me", "Sure thing boss!", charSize, new Animations.FadeOut(magilou, 2)));
            timeLine.Add(new EventTrigger(new Transitions.FadeToBlack(3, SVNE.window), true));
            timeLine.Add(new EventTrigger(new StateEvent((int)Game.States.MainMenu)));
        }
    }
}
