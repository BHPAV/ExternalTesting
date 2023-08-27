using System;

namespace Bespoke.InputSystem
{
    public interface IControlObserver
    {
        event Action ControlEvent;

        void ExecuteControl();
    }
}
