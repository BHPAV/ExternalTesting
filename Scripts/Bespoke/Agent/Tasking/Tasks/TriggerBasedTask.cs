namespace Bespoke.Agent.Tasking.Tasks
{
    public class TriggerBasedTask : Task
    {
        private bool _triggerCondition;

        public TriggerBasedTask(bool triggerCondition)
        {
            this._triggerCondition = triggerCondition;
        }

        
    }
}
