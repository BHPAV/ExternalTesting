using System;

namespace Bespoke.Agent.Tasking.Tasks
{
    public class TimeBasedTask : Task
    {
        private DateTime _startTime;
        private TimeSpan _duration;

        public TimeBasedTask(TimeSpan duration)
        {
            this._startTime = DateTime.Now;
            this._duration = duration;
        }

        public void TaskCondition()
        {
            //float time = DateTime.Now - this._startTime > this._duration;
        }
    }
}
