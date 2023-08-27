using System.Collections.Generic;
using Bespoke.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Bespoke.Items.Hull.Mounts
{
    public abstract class MountController : MonoBehaviour
    {
        [BoxGroup("DETAILS")]
        private Actor Actor => mount.actor;

        [BoxGroup("DETAILS")]
        private HullController Hull => mount.hull;

        [BoxGroup("DETAILS")]
        public BoxMount mount;

        private void Start()
        {
            if (Actor != null)
            {
                //Actor.Subscribe_ActorInput(OnActorInput);
            }
        }

        private void OnDestroy()
        {
            if (Actor != null)
            {
                //Actor.Unsubscribe_ActorInput(OnActorInput);
            }
        }

        private void OnActorInput()
        {
            //ProcessInputs(Actor.CurrentDirectionInputs, Actor.CurrentButtonInputs);
        }

        public abstract void ProcessInputs(Dictionary<Direction, float> directionInputs, Dictionary<Button, float> buttonInputs);
    }
}
