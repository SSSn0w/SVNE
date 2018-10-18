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
        public bool mouseDown = false;

        public InputHandler(RenderWindow window) {
            this.window = window;
        }

        public void HandleMouse() {
            if (window.HasFocus()) {
                if (Game.gameState == (int)Game.States.MainMenu) {
                    foreach (Clickable control in Game.mm.MenuControls) {
                        if (control.MouseInBounds(window)) {
                            mouseOnClickable = true;
                        }
                        else {
                            mouseOnClickable = false;
                        }

                        if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                            control.MouseDown(window);
                            mouseDown = true;
                        }
                        else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && !control.MouseDown(window) && mouseDown && mouseOnClickable) {
                            control.MouseUp(window);
                            mouseDown = false;
                        }
                        else {
                            control.Hover(window);
                        }
                    }
                }
                else if (Game.gameState == (int)Game.States.Playing) {
                    if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                        mouseDown = true;
                    }
                    else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseDown) {
                        try {
                            Game.TimeLine[Game.timelineCounter].EndEvent();
                        } catch (Exception e) {
                            Console.WriteLine(e + " No more dialogue to be displayed");
                        }

                        mouseDown = false;
                    }
                    else {

                    }
                }
            }
        }
    }
}
