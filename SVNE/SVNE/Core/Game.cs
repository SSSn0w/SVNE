using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

using SVNE.Core.GUI.MenuControl;

namespace SVNE.Core {
    class Game {
        public RenderWindow window;

        Sprite sprite = new Sprite(new Texture("Assets/30800208.jpg"));
        Text text = new Text("hello world", new Font("Assets/Consolas.ttf"));
        Button button = new Button(new Texture("Assets/30800208.jpg"), new Texture("Assets/clouds.jpg"), 0, 0, 100, 100);

        public Game(RenderWindow window) {
            this.window = window;

            sprite.Scale = new Vector2f(1f, 1f);
            sprite.Origin = new Vector2f(-window.Size.X / 4, -window.Size.Y / 4);
            Console.WriteLine(sprite.Texture.Size);

            text.Origin = new Vector2f(0, 0);
        }

        public void Update() {
            Draw(sprite);
            Draw(text);
            Draw(button);

            HandleMouse();
        }

        public void HandleMouse() {
            if (Mouse.IsButtonPressed(Mouse.Button.Left)) {
                if (Mouse.GetPosition(window).X >= button.x &&
                    Mouse.GetPosition(window).X <= button.x + button.width &&
                    Mouse.GetPosition(window).Y >= button.y &&
                    Mouse.GetPosition(window).Y <= button.y + button.height) {
                    button.Clicked();
                }
                else {
                    Console.WriteLine("clicked mouse");
                }
            }
        }

        public void Draw(Drawable gameObject) {
            window.Draw(gameObject);
        }
    }
}
