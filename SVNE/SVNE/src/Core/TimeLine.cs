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
    static class TimeLine {
        public static List<Event> timeLine;
        public static int timeLineCounter = 0;

        public static List<Drawable> Objects;
        public static List<List<Clickable>> Options;

        public static Sprite Background = new Sprite(new Texture("Assets/background.jpg"));

        public static Character mystery = new Character("???");
        public static Character magilou = new Character("Magilou", "Assets/character.png", 0.2f);

        public static Sound musicPlayer = new Sound();
        public static SoundBuffer preloadedSound;
        //public static Music musicPlayer;

        public static void Load() {
            timeLine = new List<Event>();
            Objects = new List<Drawable>();
            Options = new List<List<Clickable>>();

            timeLineCounter = 0;

            //musicPlayer = new Music("Assets/guitar-on-the-water.wav");
            musicPlayer.Loop = true;
            //preloadedSound = new SoundBuffer("Assets/guitar-on-the-water.wav");
            //preloadedSound = Game.Sounds[0];
            preloadedSound = new SoundBuffer("Assets/badtime.wav");
            musicPlayer.SoundBuffer = preloadedSound;

            magilou.sprite.Color = new Color(255, 255, 255, 0);
            //timeLine.Add(new EventTrigger(new Function(() => magilou.ChangePos("right")), true));

            timeLine.Add(new Scene("Scene1", timeLine.Count(), "Assets/background.jpg"));

            timeLine.Add(new EventTrigger(new Transitions.FadeFromBlack(3, SVNE.window), true));
            timeLine.Add(new DialogueBox(mystery, "So, what brings you here?", 20, new Animations.FadeIn(magilou, 2)));
            timeLine.Add(new DialogueBox("Me", "Uh...who are you again??", 20));

            StoryOptions.Add(new List<Option>() { new Option("Scene 1", "Scene1"), new Option("Scene 2", "Scene2"), new Option("Scene 3", "Scene3") });
            timeLine.Add(new EventTrigger(new Function(() => StoryOptions.Display(0)), false));

            timeLine.Add(new DialogueBox(mystery, "Me? Why, I am the great Magilou of course!!", 20));

            timeLine.Add(new Scene("Scene2", timeLine.Count(), "Assets/background.jpg"));

            timeLine.Add(new DialogueBox(magilou, "Now answer the question!", 20));
            timeLine.Add(new DialogueBox("Me", "Oh, uh, nothing really. I was just taking a look around and saw this cool mansion so I invited myself in.", 20));
            timeLine.Add(new DialogueBox(magilou, "Isn't that trespassing though?", 20, new Animations.Shake(magilou, 10, 5, 1)));
            timeLine.Add(new DialogueBox("Me", ".....", 20));

            timeLine.Add(new Scene("Scene3", timeLine.Count(), "Assets/background.jpg"));

            timeLine.Add(new DialogueBox(magilou, "Hmm, as I thought. Get out of here before the others get here.", 20));
            timeLine.Add(new DialogueBox("Me", "The others?", 20));
            timeLine.Add(new DialogueBox(magilou, "Yes. The others. Now scram!!", 20));
            timeLine.Add(new DialogueBox("Me", "Sure thing boss!", 20, new Animations.FadeOut(magilou, 2)));
            timeLine.Add(new EventTrigger(new Transitions.FadeToBlack(3, SVNE.window), true));
            timeLine.Add(new EventTrigger(new StateEvent((int)Game.States.MainMenu)));
        }
    }
}
