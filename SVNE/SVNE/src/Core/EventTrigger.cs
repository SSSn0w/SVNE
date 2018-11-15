using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SVNE.Animations;

namespace SVNE.Core {
    class EventTrigger : Event {
        public Event _event;
        private bool advanceTimeline = false;

        public EventTrigger(Event _event) : base() {
            this._event = _event;
        }

        public EventTrigger(Event _event, bool advanceTimeline) {
            this._event = _event;
            this.advanceTimeline = advanceTimeline;
        }

        public void StartEvent() {
            _event.StartEvent();

            if (_event.Ended() && advanceTimeline) {
                EndEvent();
            }
        }

        public void EndEvent() {
            _event.EndEvent();
            TimeLine.timeLineCounter++;
        }

        public bool Ended() {
            return true;
        }

        public Event GetEvent() {
            return _event;
        }
    }
}
