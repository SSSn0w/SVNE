using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

using SVNE.GUI;

namespace SVNE.Core {
    class Game : GameLoop {
        public RenderWindow window;

        public List<Clickable> MenuControls = new List<Clickable>();
        public bool mouseOnClickable = false;

        public Sprite background = new Sprite(new Texture("Assets/background.jpg"));
        public Sprite sprite = new Sprite(new Texture("Assets/character.png"));
        public RectangleShape sceneOverlay;

        public List<Event> TimeLine = new List<Event>();
        public static int timelineCounter = 0;

        //public static IDictionary<string, Drawable> SpriteList = new Dictionary<string, Drawable>();

        public enum States { MainMenu, Paused, Playing, Quit };
        public static int gameState = (int)States.MainMenu;

        MainMenu mm = new MainMenu();

        Animations.FadeIn fi;
        Animations.FadeOut fo;
        Animations.Shake shake;

        public Game(RenderWindow window) {
            this.window = window;
            this.window.Closed += Window_Closed;
        }

        public override void Startup() {
            sceneOverlay = new RectangleShape(new Vector2f(window.Size.X, window.Size.Y));
            sceneOverlay.FillColor = new Color(0, 0, 0, 0);

            sprite.Scale = new Vector2f(0.2f, 0.2f);
            sprite.Origin = new Vector2f(-(window.Size.X + sprite.Texture.Size.X) / 2, -100);
            sprite.Texture.Smooth = true;
            sprite.Color = new Color(255, 255, 255, 0);

            background.Origin = new Vector2f(0, 300);

            /*SpriteList.Add("sceneOverlay", sceneOverlay);
            SpriteList.Add("background", background);
            SpriteList.Add("characters", sprite); //Needs rework to add multiple characters
            SpriteList.Add("mainMenu", mm);*/

            fi = new Animations.FadeIn(sprite, 2);
            fo = new Animations.FadeOut(sprite, 2);
            shake = new Animations.Shake(sprite, 10, 5, 1);

            TimeLine.Add(new EventTrigger(new Transitions.FadeFromBlack(sceneOverlay, 3, window), true));
            TimeLine.Add(new DialogueBox("???", "So, what brings you here?", 20, fi));
            TimeLine.Add(new DialogueBox("Me", "Uh...who are you again??", 20));
            TimeLine.Add(new DialogueBox("???", "Me? Why, I am the great Magilou of course!!", 20));
            TimeLine.Add(new DialogueBox("Magilou", "Now answer the question!", 20));
            TimeLine.Add(new DialogueBox("Me", "Oh, uh, nothing really. I was just taking a look around and saw this cool mansion so I invited myself in.", 20));
            TimeLine.Add(new DialogueBox("Magilou", "Isn't that trespassing though?", 20, new Animations.Shake(sprite, 10, 10, 1)));
            TimeLine.Add(new DialogueBox("Me", ".....", 20));
            TimeLine.Add(new DialogueBox("Magilou", "Hmm, as I thought. Get out of here before the others get here.", 20));
            TimeLine.Add(new DialogueBox("Me", "The others?", 20));
            TimeLine.Add(new DialogueBox("Magilou", "Yes. The others. Now scram!!", 20));
            TimeLine.Add(new DialogueBox("Me", "Sure thing boss!", 20, fo));
            TimeLine.Add(new EventTrigger(new Transitions.FadeToBlack(sceneOverlay, 3, window), true));
        }

        private void Window_Closed(object sender, EventArgs e) {
            Shutdown();
        }

        public override void Shutdown() {
            Stop();
            window.Close();
        }

        public override void Update() {
            HandleMouse();

            if (gameState == (int)States.Playing) {
                try {
                    TimeLine[timelineCounter].StartEvent();
                } catch (Exception e) {
                    Console.WriteLine(e + " No more dialogue");
                }
            }
            else if(gameState == (int)States.MainMenu) {
                
            }
            else if(gameState == (int)States.Quit) {
                Shutdown();
            }
        }

        public override void Render() {
            if (gameState == (int)States.Playing) {
                Draw(background);
                Draw(sprite);

                try {
                    if (TimeLine[timelineCounter] is Drawable) {
                        Drawable drawable = TimeLine[timelineCounter] as Drawable;
                        Draw(drawable);
                    }
                } catch (Exception e) {
                    Console.WriteLine(e + " No more dialogue");
                }
            }
            else if (gameState == (int)States.MainMenu) {
                Draw(mm);
            }

            Draw(sceneOverlay);
        }

        public void HandleMouse() {
            if (window.HasFocus()) {
                if (gameState == (int)States.MainMenu) {
                    foreach (Clickable control in mm.MenuControls) {
                        if (Mouse.GetPosition(window).X >= control.GetX &&
                        Mouse.GetPosition(window).X <= control.GetX + control.GetWidth &&
                        Mouse.GetPosition(window).Y >= control.GetY &&
                        Mouse.GetPosition(window).Y <= control.GetY + control.GetHeight) {
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;

                            if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                                control.MouseDown(window);
                                mouseOnClickable = true;
                            }
                            else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                                control.MouseUp();
                                mouseOnClickable = false;
                            }
                            else {
                                control.Hover();
                            }
                        }
                        else {
                            control.Reset();
                        }
                    }
                }
                else if (gameState == (int)States.Playing) {
                    if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                        mouseOnClickable = true;
                    }
                    else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                        try {
                            TimeLine[timelineCounter].EndEvent();
                        } catch (Exception e) {
                            Console.WriteLine(e + " No more dialogue to be displayed");
                        }

                        mouseOnClickable = false;
                    }
                    else {

                    }
                }
            }
        }

        public void Draw(Drawable gameObject) {
            window.Draw(gameObject);
        }

        public int test() {
            System.Windows.Forms.MessageBox.Show("haHAA");

            return 0;
        }
    }
}
