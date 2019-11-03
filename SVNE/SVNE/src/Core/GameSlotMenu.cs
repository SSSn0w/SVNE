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

namespace SVNE.Core {
    class GameSlotMenu : Menu {
        public List<Clickable> MenuControls = new List<Clickable>();
        public int[,] SlotTexture = new int[,] { { 0, 1, 0, 1 }, { 1, 0, 1, 0 } };
        //public int[,] SlotTexture = new int[,] { { 1, 0, 1, 0 }, { 1, 0, 1, 0 }, { 1, 0, 1, 0 } };
        public Texture defaultTexture = new Texture("Assets/UI/default_slot.png");
        public Texture otherTexture = new Texture("Assets/UI/default_slot2.png"); //temp

        private static int tileWidth = (int)SVNE.window.Size.X / 3;
        private static int tileHeight = (int)SVNE.window.Size.Y / 5;
        private static int tileGap = tileWidth / 16;

        public static int VERTICAL = 0;
        public static int HORIZONTAL = 1;

        public int Layout = VERTICAL;

        public List<Clickable> Controls {
            get { return MenuControls; }
        }

        public GameSlotMenu() {
            int xPos;
            int yPos;

            if (Layout == VERTICAL) {
                for (int i = 0; i < SlotTexture.GetLength(0); i++) {
                    xPos = tileWidth * i + (tileGap * i);
                    xPos += ((int)SVNE.window.Size.X - (tileWidth * SlotTexture.GetLength(0) + (tileGap * (SlotTexture.GetLength(0) - 1)))) / 2;

                    for (int j = 0; j < SlotTexture.GetLength(1); j++) {
                        yPos = tileHeight * j + (tileGap * j);
                        yPos += ((int)SVNE.window.Size.Y - (tileHeight * SlotTexture.GetLength(1) + (tileGap * (SlotTexture.GetLength(1) - 1)))) / 2;

                        if (SlotTexture[i, j] == 0) {
                            MenuControls.Add(new Button(defaultTexture, otherTexture, xPos, yPos, tileWidth, tileHeight, SlotAction));
                        }
                        else if (SlotTexture[i, j] == 1) {
                            //Change texture to game snapshot
                            MenuControls.Add(new Button(otherTexture, defaultTexture, xPos, yPos, tileWidth, tileHeight, SlotAction));
                        }
                    }
                }
            }
            else if (Layout == HORIZONTAL) {
                for (int i = 0; i < SlotTexture.GetLength(0); i++) {
                    yPos = tileHeight * i + (tileGap * i);
                    yPos += ((int)SVNE.window.Size.Y - (tileHeight * SlotTexture.GetLength(0) + (tileGap * (SlotTexture.GetLength(0) - 1)))) / 2;

                    for (int j = 0; j < SlotTexture.GetLength(1); j++) {
                        xPos = tileWidth * j + (tileGap * j);
                        xPos += ((int)SVNE.window.Size.X - (tileWidth * SlotTexture.GetLength(1) + (tileGap * (SlotTexture.GetLength(1) - 1)))) / 2;

                        if (SlotTexture[i, j] == 0) {
                            MenuControls.Add(new Button(defaultTexture, otherTexture, xPos, yPos, tileWidth, tileHeight, SlotAction));
                        }
                        else if (SlotTexture[i, j] == 1) {
                            //Change texture to game snapshot
                            MenuControls.Add(new Button(otherTexture, defaultTexture, xPos, yPos, tileWidth, tileHeight, SlotAction));
                        }
                    }
                }
            }

            MenuControls.Add(new Button("Back", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Fonts/Consolas.ttf"), 100, 600, Back));
        }

        public int SlotAction() {
            if (Game.gameState == (int)Game.States.LoadMenu) {
                Console.WriteLine("loading game in slot...");
            }

            if (Game.gameState == (int)Game.States.SaveMenu) {
                Console.WriteLine("saving game in slot...");
            }

            return 0;
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
                    target.Draw(control, states);
                }
            }
        }
    }
}
