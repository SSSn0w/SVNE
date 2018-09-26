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

        public static Sprite sprite = new Sprite(new Texture("Assets/30800208.jpg"));

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

            dialogue.Add(new DialogueBox("Test", "This is some test text to see if the animation is working! TEXT WRAP WOoooOOOooOOOOOOOOoOooooooOOOOOooooooooooooooooooooooooooOOOO It works hahahaha naisu!!!", 20));
            dialogue.Add(new DialogueBox("Test", "1sdfsdf", 20));
            dialogue.Add(new DialogueBox("Test", "2sfdsf", 20));
            dialogue.Add(new DialogueBox("Test", "3sdfsdfs", 20));
            dialogue.Add(new DialogueBox("Test", "4sdfsdf", 20));
            dialogue.Add(new DialogueBox("Test", "5sdfsdf", 20));
            dialogue.Add(new DialogueBox("Test", "6sdfdsf", 20));
            dialogue.Add(new DialogueBox("Test", "7sdfdsf", 20));
            dialogue.Add(new DialogueBox("Test", "8sdfsdf", 20));
            dialogue.Add(new DialogueBox("Test", "9sdfsdf", 20));
            dialogue.Add(new DialogueBox("Test", "10sddfdsfds", 20));

            sprite.Scale = new Vector2f(1f, 1f);
            sprite.Origin = new Vector2f(-(window.Size.X - sprite.Texture.Size.X) / 2, -150);
            sprite.Color = new Color(255, 255, 255, 255);

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
            //fi.Animate();
            //fo.Animate();
            //shake.Animate();
        }

        public override void Render() {
            if (gameState == (int)States.Playing) {
                Draw(sprite);

                try {
                    Draw(dialogue[dialogueCounter]);
                } catch (Exception e) {
                    Console.WriteLine(e + " No more dialogue");
                }
            }

            foreach (Button button in MenuControls) {
                Draw(button);
            }
        }

        public void HandleMouse() {
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
                    else if(!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
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
                } catch(Exception e) {
                    Console.WriteLine(e + " No more dialogue to be displayed");
                }

                mouseOnClickable = false;
            }
            else {
                
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
