using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

using SVNE.GUI;

namespace SVNE.Core {
    static class InputHandler {
        public static bool mouseOnClickable = false;
        public static bool[] mouseDown = new bool[100];
        public static bool mouseDownBackground = false;
        public static int controlCounter = 0;
        public static bool hideControls = false;

        public static void OnMousePressed(object sender, MouseButtonEventArgs e) {
            if (e.Button == Mouse.Button.Left) {
                int i = 0;

                if (Game.gameState == (int)Game.States.MainMenu) {
                    foreach (Clickable control in Game.mainMenu.MenuControls) {
                        if (control.MouseInBounds(SVNE.window)) {
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

        public static void HandleMouse(RenderWindow window) {
            if (window.HasFocus()) {
                if (Game.gameState == (int)Game.States.MainMenu) {
                    controlCounter = 0;

                    foreach (Clickable control in Game.mainMenu.MenuControls) {
                        if (!control.MouseInBounds(window)) {
                            mouseDown[controlCounter] = false;
                        }

                        controlCounter++;
                    }

                    controlCounter = 0;

                    foreach (Clickable control in Game.mainMenu.MenuControls) {
                        if (control.MouseInBounds(window) && control.IsDisplayed) {
                            mouseOnClickable = true;
                        }
                        else {
                            mouseOnClickable = false;
                            mouseDown[controlCounter] = false;
                        }

                        if (Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                            control.MouseDown(window);
                            mouseDown[controlCounter] = true;
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
                else if (Game.gameState == (int)Game.States.OptionsMenu) {
                    controlCounter = 0;

                    foreach (Clickable control in Game.optionsMenu.MenuControls) {
                        if (!control.MouseInBounds(window)) {
                            mouseDown[controlCounter] = false;
                        }

                        controlCounter++;
                    }

                    controlCounter = 0;

                    foreach (Clickable control in Game.optionsMenu.MenuControls) {
                        if (control.MouseInBounds(window) && control.IsDisplayed) {
                            mouseOnClickable = true;
                        }
                        else {
                            mouseOnClickable = false;
                            mouseDown[controlCounter] = false;
                        }

                        if (Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                            control.MouseDown(window);
                            mouseDown[controlCounter] = true;
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
                    bool lockBackground = false;

                    controlCounter = 0;

                    //Story Pathway Option Buttons
                    int listCount = 0;
                    foreach (List<Clickable> list in TimeLine.Options) {
                        foreach (Clickable control in TimeLine.Options[listCount]) {
                            if (hideControls) {
                                control.IsDisplayed = false;
                                lockBackground = false;
                            }
                            else if (control.IsDisplayed) {
                                lockBackground = true;

                                if (control.MouseInBounds(window) && control.IsDisplayed) {
                                    mouseOnClickable = true;
                                }
                                else {
                                    mouseOnClickable = false;
                                    mouseDown[controlCounter] = false;
                                }

                                if (Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                    control.MouseDown(window);
                                    mouseDown[controlCounter] = true;
                                }
                                else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseDown[controlCounter] && mouseOnClickable) {
                                    control.MouseUp(window);
                                    hideControls = true;
                                    lockBackground = false;
                                    mouseOnClickable = false;
                                    mouseDown[controlCounter] = false;
                                }
                                else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                    control.Hover(window);
                                }
                                else if (!mouseOnClickable && !(control is Slider)) {
                                    control.Reset();
                                }
                            }
                            else {
                                
                            }

                            controlCounter++;
                        }

                        listCount++;
                    }

                    //Game Menu Options
                    controlCounter = 50; //Maybe change later

                    foreach (Clickable control in Game.gameMenu.MenuControls) {
                        if (control.IsDisplayed) {
                            if (control.MouseInBounds(window) && control.IsDisplayed) {
                                mouseOnClickable = true;
                                lockBackground = true;
                            }
                            else {
                                mouseOnClickable = false;
                                mouseDown[controlCounter] = false;
                            }

                            if (Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                control.MouseDown(window);
                                mouseDown[controlCounter] = true;
                            }
                            else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseDown[controlCounter] && mouseOnClickable) {
                                control.MouseUp(window);
                                mouseOnClickable = false;
                                mouseDown[controlCounter] = false;
                                lockBackground = false;
                            }
                            else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                control.Hover(window);
                            }
                            else if (!mouseOnClickable && !(control is Slider)) {
                                control.Reset();
                            }
                        }

                        controlCounter++;
                    }

                    //Move TimeLine forward on screen click if no options are up
                    if (Mouse.IsButtonPressed(Mouse.Button.Left) && !mouseOnClickable && !lockBackground) {
                        mouseDownBackground = true;
                    }
                    else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseDownBackground) {
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

                    lockBackground = false;
                }
            }
        }
    }
}
