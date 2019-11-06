using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Audio;
using SFML.System;

using SVNE.GUI;
using SVNE.Animations;

namespace SVNE.Core {
    //LOAD ALL OF THIS FROM FILE EVENTUALLY

    static class TimeLine {
        public static List<Event> timeLine;
        public static int timeLineCounter = 0;

        public static List<List<Clickable>> Options;
        public static List<Drawable> Objects;
        public static List<Character> Characters;

        public static uint charSize = 20;

        public static string currentBackground = "Assets/Backgrounds/background.jpg";
        public static Sprite Background;

        public static Character magilou;

        //public static Sound musicPlayer = new Sound();
        public static string currentSong = "Assets/Music/kamado_tanjiro_no_uta.wav";
        public static Music musicPlayer = new Music(currentSong);

        public static void LoadVariables() {
            magilou = new Character("Magilou", "Assets/Characters/Magilou/character.png", 0.2f, Constants.OPACITY_MIN);

            currentBackground = "Assets/Backgrounds/background.jpg";
            Background = new Sprite(new Texture(currentBackground));

            //musicPlayer = new Music(currentSong);

            Characters = new List<Character>();
            Objects = new List<Drawable>();
            Options = new List<List<Clickable>>();
            timeLine = new List<Event>();

            Characters.Add(magilou);
        }

        public static void Load() {
            Background.Scale = new Vector2f(SVNE.window.Size.X / Background.GetGlobalBounds().Width, SVNE.window.Size.Y / Background.GetGlobalBounds().Height);

            StoryOptions.Add(new List<Option>() { new Option("Scene 1", "Scene1"), new Option("Scene 2", "Scene2"), new Option("Scene 3", "Scene3") }); //0
            StoryOptions.Add(new List<Option>() { new Option("Scene 1 a", "Scene1"), new Option("Scene 2 a", "Scene2"), new Option("Scene 3 a", "Scene3") }); //1

            //TimeLine.musicPlayer.Play();

            timeLine.Add(new Scene("Scene1", timeLine.Count(), currentBackground));

            //timeLine.Add(new EventTrigger(new Function(() => GetChar("Magilou").ChangePos("center")), true));
            //timeLine.Add(new EventTrigger(new Function(() => GetChar("Magilou").ChangeColour(Constants.OPACITY_MIN)), true));

            timeLine.Add(new EventTrigger(new Transitions.FadeFromBlack(3, SVNE.window), true));
            timeLine.Add(new DialogueBox("???", "So, what brings you here?", charSize, new Animations.FadeIn(GetChar("Magilou"), 2)));
            timeLine.Add(new DialogueBox("Me", "Uh...who are you again??", charSize));

            timeLine.Add(new EventTrigger(new Function(() => StoryOptions.Display(0)), false));

            timeLine.Add(new DialogueBox("???", "Me? Why, I am the great Magilou of course!!", charSize));

            timeLine.Add(new Scene("Scene2", timeLine.Count(), currentBackground));

            timeLine.Add(new DialogueBox(GetChar("Magilou"), "Now answer the question!", charSize));
            timeLine.Add(new DialogueBox("Me", "Oh, uh, nothing really. I was just taking a look around and saw this cool mansion so I invited myself in.", charSize));
            timeLine.Add(new DialogueBox(GetChar("Magilou"), "Isn't that trespassing though?", charSize, new Animations.Shake(GetChar("Magilou"), 10, 5, 1)));
            timeLine.Add(new DialogueBox("Me", ".....", charSize));

            //currentBackground = "Assets/Backgrounds/background.jpg";
            timeLine.Add(new Scene("Scene3", timeLine.Count(), currentBackground));

            timeLine.Add(new DialogueBox(GetChar("Magilou"), "Hmm, as I thought. Get out of here before the others get here.", charSize));
            timeLine.Add(new DialogueBox("Me", "The others?", charSize));

            timeLine.Add(new EventTrigger(new Function(() => StoryOptions.Display(1)), false));

            timeLine.Add(new DialogueBox(GetChar("Magilou"), "Yes. The others. Now scram!!", charSize));
            timeLine.Add(new DialogueBox("Me", "Sure thing boss!", charSize, new Animations.FadeOut(GetChar("Magilou"), 2)));
            timeLine.Add(new EventTrigger(new Transitions.FadeToBlack(3, SVNE.window), true));
            timeLine.Add(new EventTrigger(new StateEvent((int)Game.States.MainMenu)));
        }

        public static Character GetChar(string CharName) {
            return Characters.Find(character => character.Name == CharName);
        }
    }
}
