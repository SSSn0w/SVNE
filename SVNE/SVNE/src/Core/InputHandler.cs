using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

using SVNE.GUI;

namespace SVNE.Core {
    class InputHandler {
        private RenderWindow window;

        public bool mouseOnClickable = false;
        public bool[] mouseDown;

        public InputHandler(RenderWindow window) {
            this.window = window;
            this.window.MouseButtonReleased += OnMousePressed;

            mouseDown = new bool[Game.mm.MenuControls.Capacity];
        }

        public void OnMousePressed(object sender, MouseButtonEventArgs e) {
            if (e.Button == Mouse.Button.Left) {
                int i = 0;

                if (Game.gameState == (int)Game.States.MainMenu) {
                    foreach (Clickable control in Game.mm.MenuControls) {
                        if (control.MouseInBounds(window)) {
                            mouseDown[i] = true;
                        }

                        i++;
                    }
                }
                else if(Game.gameState == (int)Game.States.Playing) {
                    mouseDown[0] = true;
                }
            }
        }

        public void HandleMouse() {
            if (window.HasFocus()) {
                if (Game.gameState == (int)Game.States.MainMenu) {
                    int i = 0;

                    foreach (Clickable control in Game.mm.MenuControls) {
                        if (!control.MouseInBounds(window)) {
                            mouseDown[i] = false;
                        }

                        i++;
                    }

                    i = 0;

                    foreach (Clickable control in Game.mm.MenuControls) {
                        if (control.MouseInBounds(window)) {
                            mouseOnClickable = true;
                        }
                        else {
                            mouseOnClickable = false;
                        }

                        if (Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                            control.MouseDown(window);
                        }
                        else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseDown[i] && mouseOnClickable) {
                            Console.WriteLine("doot");
                            control.MouseUp(window);
                            mouseDown[i] = false;
                        }
                        else if(!Mouse.IsButtonPressed(Mouse.Button.Left)) {
                            control.Hover(window);
                            //mouseDown = false;
                        }

                        i++;
                    }
                }
                else if (Game.gameState == (int)Game.States.Playing) {
                    if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                        mouseDown[0] = true;
                    }
                    else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseDown[0]) {
                        try {
                            //if(Game.TimeLine[Game.timelineCounter].GetType !== Transition)
                            Game.TimeLine[Game.timelineCounter].EndEvent();
                        } catch (Exception e) {
                            //Console.WriteLine(e + " No more dialogue to be displayed");
                        }

                        mouseDown[0] = false;
                    }
                    else {

                    }
                }
            }
        }
    }
}
