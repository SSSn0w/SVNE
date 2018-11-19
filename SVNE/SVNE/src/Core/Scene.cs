using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace SVNE.Core {
    class Scene : Event {
        public string Title;
        public int Position;
        public Sprite Background;

        public Scene(string Title, int Position) : base() {
            this.Title = Title;
            this.Position = Position;
            this.Background = TimeLine.Background;
        }

        public Scene(string Title, int Position, string Background) {
            this.Title = Title;
            this.Position = Position;
            this.Background = new Sprite(new Texture(Background));
        }

        public void StartEvent() {
            Background.Origin = new Vector2f(0, 300);
            TimeLine.Background = Background;

            EndEvent();
        }

        public void EndEvent() {
            TimeLine.timeLineCounter++;
        }

        public bool Ended() {
            return true;
        }

        public Event GetEvent() {
            return this;
        }
    }
}
