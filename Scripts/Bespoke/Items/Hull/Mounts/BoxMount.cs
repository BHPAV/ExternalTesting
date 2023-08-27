using UnityEngine;

namespace Bespoke.Items.Hull.Mounts
{
    public class BoxMount : Mount
    {

        public Type type = Type.Box;
        public MountController controller;
        public HullController hull;
        public Actor actor;

        private void Awake()
        {
            CreateController();
            GetHullController();
        }

        public void SetHullController(HullController setHull)
        {
            this.hull = setHull;
        }

        public virtual void CreateController()
        {
            /*
            // If there's a controller already, destroy it/*
            switch (type)
            {
                case Type.Box:
                    controller = gameObject.AddComponent<BoxController>();
                    break;
                case Type.Driver:
                    controller = gameObject.AddComponent<DriverController>();
                    break;
                //case Mount.Type.Gunner:
                //    controller = gameObject.AddComponent<GunnerController>();
                //    break;
                // Add more cases as needed
                default:
                    Debug.LogError("Invalid mount type");
                    break;
            }
            */

        }

        protected void GetHullController()
        {
            /*
            hull = GetComponentInParent<HullController>();

            if (hull == null)
            {
                Debug.LogError("No hull controller found");
            }
            */
        }

        public void CreateController<T>() where T : MountController
        {
            /*
            // If there's a controller already, destroy it
            if (controller != null)
            {
                Destroy(controller);
            }

            // Add the specified type of controller
            controller = gameObject.AddComponent<T>();
            */
        }

        public override void MountActor(Actor mountActor)
        {
            /*
            this.actor = mountActor;
            var transform1 = mountActor.transform;

            transform1.parent = transform;
            transform1.localPosition = Vector3.zero;
            transform1.localRotation = Quaternion.identity;

            mountActor.Subscribe_ActorInput(OnActorInput);
            */
        }

        public override void UnmountActor()
        {
            /*
            actor.transform.parent = null;
            actor.Unsubscribe_ActorInput(OnActorInput);

            //actor.mounted = false;
            actor = null;
            */
        }

        public virtual void OnActorInput()
        {
            /*
            if(controller == null || actor == null)
                return;

            controller.ProcessInputs(actor.CurrentDirectionInputs, actor.CurrentButtonInputs);
            */
        }


        // Draw gizmo on selected. Draw a sphere coloured orange.
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 0.025f);
        }

    }
}
