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
        public static Sprite sprite = new Sprite(new Texture("Assets/character.png"));

        public List<DialogueBox> dialogue = new List<DialogueBox>();
        public int dialogueCounter = 0;

        enum States { MainMenu, Paused, Playing };
        public int gameState = (int)States.Playing;

        DialogueBox db;
        Animation.FadeIn fi;
        Animation.FadeOut fo;
        Animation.Shake shake;

        public Game(RenderWindow window) {
            this.window = window;
            this.window.Closed += Window_Closed;
        }

        public override void Startup() {
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), new Texture("Assets/pressed.png"), 0, 0, 100, 30, test));
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 200, 150, 100, 30));
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 0, 240, 100, 30));

            MenuControls.Add(new Button("Text Button", new Color(0, 0, 0), new Color(255, 255, 255), new Color(0, 255, 0), 30, new Font("Assets/Consolas.ttf"), 150, 400, test));

            dialogue.Add(new DialogueBox("???", "So, what brings you here?", 20));
            dialogue.Add(new DialogueBox("Me", "Uh...who are you again??", 20));
            dialogue.Add(new DialogueBox("???", "Me? Why, I am the great Magilou of course!!", 20));
            dialogue.Add(new DialogueBox("Magilou", "Now answer the question!", 20));
            dialogue.Add(new DialogueBox("Me", "Oh, uh, nothing really. I was just taking a look around and saw this cool mansion so I invited myself in.", 20));
            dialogue.Add(new DialogueBox("Magilou", "Isn't that trespassing though?", 20));
            dialogue.Add(new DialogueBox("Me", ".....", 20));
            dialogue.Add(new DialogueBox("Magilou", "Hmm, as I thought. Get out of here before the others get here.", 20));
            dialogue.Add(new DialogueBox("Me", "The others?", 20));
            dialogue.Add(new DialogueBox("Magilou", "Yes. The others. Now scram!!", 20));
            dialogue.Add(new DialogueBox("Me", "Sure thing boss!", 20));

            sprite.Scale = new Vector2f(0.2f, 0.2f);
            sprite.Origin = new Vector2f(-(window.Size.X + sprite.Texture.Size.X) / 2, -100);
            //sprite.Origin = new Vector2f(0, 0);
            sprite.Texture.Smooth = true;
            sprite.Color = new Color(255, 255, 255, 255);

            float size = (float)window.Size.X / (float)sprite.Texture.Size.X;
            Console.WriteLine(size);
            //background.Scale = new Vector2f(size, size);
            background.Origin = new Vector2f(0, 300);

            fi = new Animation.FadeIn(sprite, 2);
            fo = new Animation.FadeOut(sprite, 2);
            shake = new Animation.Shake(sprite, 10, 5, 1);
        }

        private void Window_Closed(object sender, EventArgs e) {
            Stop();
            window.Close();
        }

        public override void Shutdown() {
            
        }

        public override void Update() {
            HandleMouse();
            //db.Animate();

            if (gameState == (int)States.Playing) {
                try {
                    dialogue[dialogueCounter].Animate();
                } catch (Exception e) {
                    Console.WriteLine(e + " No more dialogue");
                }
            }
            else if(gameState == (int)States.MainMenu) {

            }
            //fi.Animate();
            //fo.Animate();
            //shake.Animate();
        }

        public override void Render() {
            if (gameState == (int)States.Playing) {
                Draw(background);
                Draw(sprite);

                try {
                    Draw(dialogue[dialogueCounter]);
                } catch (Exception e) {
                    Console.WriteLine(e + " No more dialogue");
                }
            }
            else if (gameState == (int)States.MainMenu) {
                foreach (Button button in MenuControls) {
                    Draw(button);
                }
            }
        }

        public void HandleMouse() {
            if (window.HasFocus()) {
                foreach (Button control in MenuControls) {
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

                if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                    mouseOnClickable = true;
                }
                else if (!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                    try {
                        if (dialogue[dialogueCounter].counter != dialogue[dialogueCounter].Dialogue.Length) {
                            dialogue[dialogueCounter].End = true;
                        }
                        else {
                            dialogueCounter++;
                        }
                    } catch (Exception e) {
                        Console.WriteLine(e + " No more dialogue to be displayed");
                    }

                    mouseOnClickable = false;
                }
                else {

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
