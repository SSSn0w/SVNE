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

        public List<Event> TimeLine = new List<Event>();
        public static int timelineCounter = 0;

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
            /*MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), new Texture("Assets/pressed.png"), 0, 0, 100, 30, test));
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 200, 150, 100, 30));
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 0, 240, 100, 30));

            MenuControls.Add(new Button("Text Button", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 150, 400, test));*/

            fi = new Animations.FadeIn(sprite, 2);
            fo = new Animations.FadeOut(sprite, 2);
            shake = new Animations.Shake(sprite, 10, 5, 1);

            TimeLine.Add(new DialogueBox("???", "So, what brings you here?", 20, fi));
            TimeLine.Add(new EventTrigger(new Animations.Shake(sprite, 3, 20, 1), true));
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

            sprite.Scale = new Vector2f(0.2f, 0.2f);
            sprite.Origin = new Vector2f(-(window.Size.X + sprite.Texture.Size.X) / 2, -100);
            //sprite.Origin = new Vector2f(0, 0);
            sprite.Texture.Smooth = true;
            sprite.Color = new Color(255, 255, 255, 0);

            float size = (float)window.Size.X / (float)sprite.Texture.Size.X;
            //background.Scale = new Vector2f(size, size);
            background.Origin = new Vector2f(0, 300);
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
        }

        public void HandleMouse() {
            if (window.HasFocus()) {
                if (gameState == (int)States.MainMenu) {
                    foreach (Button control in mm.MenuControls) {
                        if (Mouse.GetPosition(window).X >= control.x &&
                        Mouse.GetPosition(window).X <= control.x + control.width &&
                        Mouse.GetPosition(window).Y >= control.y &&
                        Mouse.GetPosition(window).Y <= control.y + control.height) {
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;

                            if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                                control.MouseDown();
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
