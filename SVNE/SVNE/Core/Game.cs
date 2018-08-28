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
    class Game {
        public RenderWindow window;

        public List<Clickable> MenuControls = new List<Clickable>();

        Sprite sprite = new Sprite(new Texture("Assets/30800208.jpg"));
        Text text = new Text("hello world", new Font("Assets/Consolas.ttf"));

        public Game(RenderWindow window) {
            this.window = window;

            //MenuControls.Add(new Button(new Texture("Assets/30800208.jpg"), new Texture("Assets/clouds.jpg"), 0, 0, 100, 100));
            //MenuControls.Add(new Button(new Texture("Assets/clouds.jpg"), new Texture("Assets/30800208.jpg"), 100, 100, 100, 100));
            //MenuControls.Add(new Button(new Texture("Assets/clouds.jpg"), new Texture("Assets/30800208.jpg"), 200, 100, 100, 100));
            //MenuControls.Add(new Button(new Texture("Assets/clouds.jpg"), new Texture("Assets/30800208.jpg"), 100, 200, 100, 100));
            //MenuControls.Add(new Button(new Texture("Assets/clouds.jpg"), new Texture("Assets/30800208.jpg"), 200, 200, 100, 100));

            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 0, 0, 100, 30));
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 200, 150, 100, 30));
            MenuControls.Add(new Button(new Texture("Assets/notPressed.png"), new Texture("Assets/pressed.png"), 0, 240, 100, 30));

            sprite.Scale = new Vector2f(1f, 1f);
            sprite.Origin = new Vector2f(-window.Size.X / 4, -window.Size.Y / 4);
            Console.WriteLine(sprite.Texture.Size);

            text.Origin = new Vector2f(0, 0);
        }

        public void Update() {
            //Draw(sprite);
            //Draw(text);

            foreach (Button button in MenuControls) {
                Draw(button);
            }

            HandleMouse();
        }

        public void HandleMouse() {
            foreach (Button control in MenuControls) {
                if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                    if (Mouse.GetPosition(window).X >= control.x &&
                    Mouse.GetPosition(window).X <= control.x + control.width &&
                    Mouse.GetPosition(window).Y >= control.y &&
                    Mouse.GetPosition(window).Y <= control.y + control.height) {

                        control.MouseDown();
                    }
                    else {
                        control.MouseUp();
                    }
                }

                if (!Mouse.IsButtonPressed(Mouse.Button.Left)) {
                    control.MouseUp();
                }
            }
        }

        public void Draw(Drawable gameObject) {
            window.Draw(gameObject);
        }
    }
}
