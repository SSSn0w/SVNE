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
        public static bool mouseDownBackground = false;
        public static bool hideControls = false;

        public static void OnMousePressed(object sender, MouseButtonEventArgs e) {
            if (e.Button == Mouse.Button.Left) {
                if (Game.gameState == (int)Game.States.MainMenu) {
                    foreach (Clickable control in Game.mainMenu.MenuControls) {
                        if (control.MouseInBounds(SVNE.window)) {
                            control.IsMouseDown = true;
                        }
                    }
                }
            }
        }

        public static void HandleMouse(RenderWindow window) {
            if (window.HasFocus()) {
                if (Game.gameState == (int)Game.States.MainMenu || Game.gameState == (int)Game.States.OptionsMenu || Game.gameState == (int)Game.States.LoadMenu || Game.gameState == (int)Game.States.SaveMenu || Game.gameState == (int)Game.States.Paused) {
                    foreach (Menu menu in Game.Menus) {
                        foreach (Clickable control in menu.Controls) {
                            if (!control.MouseInBounds(window)) {
                                control.IsMouseDown = false;
                            }
                        }

                        foreach (Clickable control in menu.Controls.ToList()) {
                            if (control.MouseInBounds(window) && control.IsDisplayed) {
                                mouseOnClickable = true;
                            }
                            else {
                                mouseOnClickable = false;
                                control.IsMouseDown = false;
                            }

                            if (Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                control.MouseDown(window);
                                control.IsMouseDown = true;
                            }
                            else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && control.IsMouseDown && mouseOnClickable) {
                                control.MouseUp(window);
                                control.IsMouseDown = false;
                            }
                            else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                control.Hover(window);
                            }
                            else if (!mouseOnClickable && !(control is Slider)) {
                                control.Reset();
                            }

                            if (!Mouse.IsButtonPressed(Mouse.Button.Left)) {
                                if (control is Slider) {
                                    Slider slider = (Slider)control;
                                    slider.grabbed = false;
                                }
                            }
                        }
                    }
                }
                else if (Game.gameState == (int)Game.States.Playing) {
                    bool lockBackground = false;

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
                                    control.IsMouseDown = false;
                                }

                                if (Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                    control.MouseDown(window);
                                    control.IsMouseDown = true;
                                }
                                else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && control.IsMouseDown && mouseOnClickable) {
                                    control.MouseUp(window);
                                    hideControls = true;
                                    lockBackground = false;
                                    mouseOnClickable = false;
                                    control.IsMouseDown = false;
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
                        }

                        listCount++;
                    }

                    //In-Game Menu Options
                    foreach (Clickable control in Game.gameMenu.MenuControls) {
                        if (control.IsDisplayed) {
                            if (control.MouseInBounds(window) && control.IsDisplayed) {
                                mouseOnClickable = true;
                                lockBackground = true;
                            }
                            else {
                                mouseOnClickable = false;
                                control.IsMouseDown = false;
                            }

                            if (Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                control.MouseDown(window);
                                control.IsMouseDown = true;
                            }
                            else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && control.IsMouseDown && mouseOnClickable) {
                                control.MouseUp(window);
                                mouseOnClickable = false;
                                control.IsMouseDown = false;
                                lockBackground = false;
                            }
                            else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                control.Hover(window);
                            }
                            else if (!mouseOnClickable && !(control is Slider)) {
                                control.Reset();
                            }

                            if (!Mouse.IsButtonPressed(Mouse.Button.Left)) {
                                if (control is Slider) {
                                    Slider slider = (Slider)control;
                                    slider.grabbed = false;
                                }
                            }
                        }
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
