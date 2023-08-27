using UnityEngine;

namespace Bespoke.Items.Hull.Mounts
{
    public interface IMount
    {
        void MountActor(Actor actor);
        void UnmountActor();
    }

    public interface IControlMount
    {
        void ControlMount();
    }

    public interface IDriverMount : IControlMount
    {
        void Drive();
        void Stop();
    }
}
