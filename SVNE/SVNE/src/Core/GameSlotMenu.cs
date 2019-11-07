using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;

using SVNE.GUI;
using System.IO;

namespace SVNE.Core {
    class GameSlotMenu : Menu {
        public List<Clickable> MenuControls = new List<Clickable>();

        public Texture defaultTexture = new Texture("Assets/UI/default_slot.png");
        public Texture otherTexture = new Texture("Assets/UI/default_slot2.png"); //temp

        public Image screenShot;
        private int slot = 1;
        public int selectedSlot = 0;

        private static int columns = 3;
        private static int rows = 2;
        private static int tileWidth = (int)(SVNE.window.Size.X / 3.5);
        private static int tileHeight = (int)(SVNE.window.Size.Y / 3.5);
        private static int tileGap = tileWidth / 16;

        public List<Clickable> Controls {
            get { return MenuControls; }
        }

        public GameSlotMenu() {
            InitControls();
        }

        public void InitControls() {
            int xPos;
            int yPos;

            for (int i = 0; i < rows; i++) {
                yPos = tileHeight * i + (tileGap * i);
                yPos += ((int)SVNE.window.Size.Y - (tileHeight * rows + (tileGap * (rows - 1)))) / 2;

                for (int j = 0; j < columns; j++) {
                    xPos = tileWidth * j + (tileGap * j);
                    xPos += ((int)SVNE.window.Size.X - (tileWidth * columns + (tileGap * (columns - 1)))) / 2;

                    Texture slotTex;

                    try {
                        slotTex = new Texture("Data/" + slot + ".png");
                    }
                    catch (Exception e) {
                        Console.WriteLine("Save thumbnail not found...");
                        slotTex = new Texture("Assets/UI/no-image.jpg");
                    }

                    MenuControls.Add(new Button(new Sprite(slotTex), new Sprite(slotTex), xPos, yPos, tileWidth, tileHeight, SlotAction));

                    Sprite slotSpriteIdle = MenuControls.Cast<Button>().Last().notPressed;
                    slotSpriteIdle.Scale = new Vector2f((float)tileWidth / slotSpriteIdle.Texture.Size.X, (float)tileHeight / slotSpriteIdle.Texture.Size.Y);

                    Sprite slotSpritePressed = MenuControls.Cast<Button>().Last().pressed;
                    slotSpritePressed.Scale = new Vector2f((float)tileWidth / slotSpritePressed.Texture.Size.X, (float)tileHeight / slotSpritePressed.Texture.Size.Y);
                    slotSpritePressed.Color = new Color(100, 100, 100);

                    slot++;
                }
            }

            MenuControls.Add(new Button("Back", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 600, Back));
        }

        public void RefreshControls() {
            MenuControls.Clear();
            slot = 1;
            InitControls();
        }

        public int SlotAction() {
            if (Game.gameState == (int)Game.States.LoadMenu) {
                Console.WriteLine("loading game in slot...");

                try {
                    TimeLine.LoadVariables();

                    GameSave gameSave = ReadFromBinaryFile<GameSave>("Data/" + (selectedSlot + 1) + ".save");
                    TimeLine.timeLineCounter = gameSave.timeLinePos;

                    TimeLine.currentBackground = gameSave.background;
                    TimeLine.Background = new Sprite(new Texture(gameSave.background));

                    List<Character> characters = new List<Character>();
                    foreach (CharacterState character in gameSave.characters) {
                        if (character.Hidden) {
                            characters.Add(new Character(character.Name, character.ResPath, character.Scale, new Color(255, 255, 255, 0)));
                        }
                        else {
                            characters.Add(new Character(character.Name, character.ResPath, character.Scale, new Color(255, 255, 255, 255)));
                        }
                    }
                    TimeLine.Characters = characters;

                    TimeLine.currentSong = gameSave.currentSong;
                    TimeLine.musicPlayer = new Music(gameSave.currentSong);

                    for (int i = 0; i < TimeLine.timeLineCounter; i++) {
                        try {
                            if (Game.storyOptionsOpen) {
                                Game.storyOptionsOpen = false;
                                for (int j = 0; j < TimeLine.Options.Count(); j++) {
                                    foreach (Clickable control in TimeLine.Options[j]) {
                                        control.IsDisplayed = false;
                                    }
                                }
                            }
                        }
                        catch (Exception e) {
                            //Console.WriteLine(e + " No more dialogue to be displayed");
                        }
                    }

                    TimeLine.Load();

                    Game.gameState = (int)Game.States.Playing;
                    TimeLine.musicPlayer.Loop = true;
                    //TimeLine.musicPlayer.SoundBuffer = Game.Sounds[0];
                    //TimeLine.musicPlayer.Play();
                }
                catch (Exception e) {
                    
                }
            }

            if (Game.gameState == (int)Game.States.SaveMenu) {
                Console.WriteLine("saving game in slot...");

                screenShot.SaveToFile("Data/" + (selectedSlot + 1) + ".png");

                List<CharacterState> characters = new List<CharacterState>();
                foreach (Character character in TimeLine.Characters) {
                    bool hidden = false;

                    if(character.sprite.Color.A == 0) {
                        hidden = true;
                    }
                    else {
                        hidden = false;
                    }

                    characters.Add(new CharacterState(character, hidden));
                }

                GameSave gameSave = new GameSave(TimeLine.timeLineCounter, TimeLine.currentBackground, characters, TimeLine.currentSong);
                WriteToBinaryFile<GameSave>("Data/" + (selectedSlot + 1) + ".save", gameSave);

                RefreshControls();
            }

            return 0;
        }

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false) {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create)) {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public static T ReadFromBinaryFile<T>(string filePath) {
            using (Stream stream = File.Open(filePath, FileMode.Open)) {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public int Back() {
            if (Game.gameState == (int)Game.States.LoadMenu) {
                Game.gameState = (int)Game.States.MainMenu;
            }

            if (Game.gameState == (int)Game.States.SaveMenu) {
                Game.gameState = (int)Game.States.Playing;
            }

            return 0;
        }

        public void IsDisplaying(bool displaying) {
            foreach (Clickable control in MenuControls) {
                control.IsDisplayed = displaying;
            }
        }

        public void Draw(RenderTarget target, RenderStates states) {
            target.Draw(new RectangleShape(SVNE.window.DefaultView.Size), states);

            foreach (Clickable control in MenuControls) {
                if (control.IsDisplayed) {
                    if(control.IsMouseDown) {
                        selectedSlot = MenuControls.IndexOf(control);
                    }
                    target.Draw(control, states);
                }
            }
        }
    }
}
