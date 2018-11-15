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
        public bool mouseDownBackground = false;
        public int controlCounter = 0;

        public InputHandler(RenderWindow window) {
            this.window = window;
            this.window.MouseButtonReleased += OnMousePressed;

            //mouseDown = new bool[Game.mm.MenuControls.Capacity];
            mouseDown = new bool[100];
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

                    controlCounter = 0;

                    foreach (Clickable control in Game.mm.MenuControls) {
                        if (!control.MouseInBounds(window)) {
                            mouseDown[controlCounter] = false;
                        }

                        controlCounter++;
                    }

                    controlCounter = 0;

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
                        else if (Mouse.IsButtonPressed(Mouse.Button.Left) && control is Slider) {
                            control.MouseDown(window);
                        }
                        else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseDown[controlCounter] && mouseOnClickable) {
                            control.MouseUp(window);
                            mouseDown[controlCounter] = false;
                        }
                        else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                            control.Hover(window);
                        }
                        else if (!mouseOnClickable && !(control is Slider)) {
                            control.Reset();
                        }

                        controlCounter++;
                    }
                }
                else if (Game.gameState == (int)Game.States.Playing) {
                    controlCounter = 0;

                    foreach (Clickable control in TimeLine.Options) {
                        if (control.MouseInBounds(window) && control.IsDisplayed) {
                            mouseOnClickable = true;
                        }
                        else {
                            mouseOnClickable = false;
                        }

                        if (Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                            control.MouseDown(window);
                        }
                        else if (Mouse.IsButtonPressed(Mouse.Button.Left) && control is Slider) {
                            control.MouseDown(window);
                        }
                        else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseDown[controlCounter] && mouseOnClickable) {
                            control.MouseUp(window);
                            mouseDown[controlCounter] = false;
                        }
                        else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                            control.Hover(window);
                        }
                        else if (!mouseOnClickable && !(control is Slider)) {
                            control.Reset();
                        }
                            
                        controlCounter++;
                    }

                    if (Mouse.IsButtonPressed(Mouse.Button.Left) && !mouseOnClickable) {
                        mouseDownBackground = true;
                    }
                    else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseDownBackground && !mouseOnClickable) {
                        try {
                            if (TimeLine.timeLine[TimeLine.timeLineCounter].GetEvent() is Transitions.Transition) {
                                Console.WriteLine("is non-skippable transition");
                            }
                            else {
                                Console.WriteLine("is skippable event");
                                TimeLine.timeLine[TimeLine.timeLineCounter].EndEvent();
                            }
                        } catch (Exception e) {
                            //Console.WriteLine(e + " No more dialogue to be displayed");
                        }

                        mouseDownBackground = false;
                    }
                }
            }
        }
    }
}
