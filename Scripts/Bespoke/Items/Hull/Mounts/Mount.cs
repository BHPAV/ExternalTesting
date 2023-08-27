using UnityEngine;

namespace Bespoke.Items.Hull.Mounts
{
    public abstract class Mount : MonoBehaviour
    {
        public enum Type
        {
            Box,
            Driver,
            Gunner,
            Passenger,
            Cargo
        }

        public abstract void MountActor(Actor mountActor);
        public abstract void UnmountActor();
    }
}
