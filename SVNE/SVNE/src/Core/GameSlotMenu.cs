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

        public Texture defaultTexture = new Texture("Assets/UI/default_slot.png");
        public Texture otherTexture = new Texture("Assets/UI/default_slot2.png"); //temp

        public Image screenShot;
        private int slot = 1;
        public int selectedSlot = 0;

        private static int columns = 2;
        private static int rows = 4;
        private static int tileWidth = (int)SVNE.window.Size.X / 3;
        private static int tileHeight = (int)SVNE.window.Size.Y / 5;
        private static int tileGap = tileWidth / 16;

        public static int VERTICAL = 0;
        public static int HORIZONTAL = 1;

        public int Layout = HORIZONTAL;

        public List<Clickable> Controls {
            get { return MenuControls; }
        }

        public GameSlotMenu() {
            InitControls();
        }

        public void InitControls() {
            int xPos;
            int yPos;

            if (Layout == VERTICAL) {
                for (int i = 0; i < rows; i++) {
                    xPos = tileWidth * i + (tileGap * i);
                    xPos += ((int)SVNE.window.Size.X - (tileWidth * rows + (tileGap * (rows - 1)))) / 2;

                    for (int j = 0; j < columns; j++) {
                        yPos = tileHeight * j + (tileGap * j);
                        yPos += ((int)SVNE.window.Size.Y - (tileHeight * columns + (tileGap * (columns - 1)))) / 2;

                        Texture slotTex;

                        try {
                            slotTex = new Texture("Data/" + slot + ".png");
                        }
                        catch (Exception e) {
                            Console.WriteLine("Save thumbnail not found...");
                            slotTex = slotTex = new Texture("Data/no-image.jpg");
                        }

                        MenuControls.Add(new Button(slotTex, otherTexture, xPos, yPos, tileWidth, tileHeight, SlotAction));

                        slot++;
                    }
                }
            }
            else if (Layout == HORIZONTAL) {
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
                            slotTex = slotTex = new Texture("Data/no-image.jpg");
                        }

                        MenuControls.Add(new Button(slotTex, otherTexture, xPos, yPos, tileWidth, tileHeight, SlotAction));

                        slot++;
                    }
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
            }

            if (Game.gameState == (int)Game.States.SaveMenu) {
                Console.WriteLine("saving game in slot...");
                screenShot.SaveToFile("Data/" + (selectedSlot + 1) + ".png");
                RefreshControls();
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
                    if(control.IsMouseDown) {
                        selectedSlot = MenuControls.IndexOf(control);
                    }
                    target.Draw(control, states);
                }
            }
        }
    }
}
