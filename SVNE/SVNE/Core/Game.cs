using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

using SVNE.Core.GUI;

namespace SVNE.Core {
    class Game : GameLoop {
        public RenderWindow window;

        public List<Clickable> MenuControls = new List<Clickable>();
        public bool mouseOnClickable = false;

        Sprite sprite = new Sprite(new Texture("Assets/30800208.jpg"));
        Text text = new Text("hello world", new Font("Assets/Consolas.ttf"));

        public Game(RenderWindow window) {
            this.window = window;
            this.window.Closed += Window_Closed;
        }

        public override void Startup() {
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 0, 0, 100, 30, test));
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 200, 150, 100, 30));
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 0, 240, 100, 30));

            sprite.Scale = new Vector2f(1f, 1f);
            sprite.Origin = new Vector2f(-window.Size.X / 4, -window.Size.Y / 4);
            Console.WriteLine(sprite.Texture.Size);

            text.Origin = new Vector2f(-window.Size.X / 1.5f, -window.Size.Y / 1.5f);
        }

        private void Window_Closed(object sender, EventArgs e) {
            Stop();
            window.Close();
        }

        public override void Shutdown() {
            
        }

        public override void Update() {
            HandleMouse();
        }

        public override void Render() {
            Draw(sprite);
            Draw(text);

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
                    if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                        control.MouseDown();
                        mouseOnClickable = true;
                    }
                    else if(!Mouse.IsButtonPressed(Mouse.Button.Left) && mouseOnClickable) {
                        control.MouseUp();
                        mouseOnClickable = false;
                    }
                    else {
                        control.Reset();
                    }
                }
                else {
                    control.Reset();
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
