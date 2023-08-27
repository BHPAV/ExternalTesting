using Bespoke.Agent;
using Bespoke.Enums;
using Bespoke.InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bespoke.Items.Hull
{
    public class MountComponent : MonoBehaviour, IHullComponent
    {
        public Transform mountPoint;
        [SerializeField] private Actor actorMounted;

        public float rotationSpeed = 100f;
        public float acceleration = 10f;


        public void Initialize()
        {
            // Initialization code for the mounts
        }

        public void UpdateComponent()
        {
            // Update code for managing mounts, such as placing characters at mount points
        }

        public void MountActor(Actor actor)
        {
            actorMounted = actor;

            // Mount the actor to the mount point
            var transform1 = actor.transform;
            transform1.position = mountPoint.position;
            transform1.rotation = mountPoint.rotation;
            actor.transform.SetParent(mountPoint);

            // Subscribe to the actor's input scheme
            RegisterInputScheme(actor.InputScheme);
        }

        public void DismountActor(Actor actor)
        {
            // Dismount the actor from the mount point
            actor.transform.SetParent(null);

            // Unsubscribe from the actor's input scheme
            DeregisterInputScheme(actorMounted.InputScheme);

            actorMounted = null;
        }

        private void RegisterInputScheme(InputScheme inputScheme)
        {
            // Subscribe to Up direction for acceleration
            inputScheme.DirectionActions[Direction.Up] += Accelerate;

            // Subscribe to Down direction for braking
            inputScheme.DirectionActions[Direction.Down] += Reverse;

            // Subscribe to Left and Right directions for steering
            inputScheme.DirectionActions[Direction.Left] += value => Turn(-value);
            inputScheme.DirectionActions[Direction.Right] += value => Turn(value);
        }

        private void DeregisterInputScheme(InputScheme inputScheme)
        {
            // Subscribe to Up direction for acceleration
            inputScheme.DirectionActions[Direction.Up] -= Accelerate;

            // Subscribe to Down direction for braking
            inputScheme.DirectionActions[Direction.Down] -= Reverse;

            // Subscribe to Left and Right directions for steering
            inputScheme.DirectionActions[Direction.Left] -= value => Turn(-value);
            inputScheme.DirectionActions[Direction.Right] -= value => Turn(value);
        }

        private void Accelerate(float value)
        {
            // Logic for accelerating the vehicle
            //Debug.Log("Accelerating with value " + value);

            transform.Translate(Vector3.forward * value * acceleration * Time.deltaTime);
        }

        private void Reverse(float value)
        {
            // Logic for accelerating the vehicle
            //Debug.Log("Accelerating with value " + value);

            transform.Translate(-Vector3.forward * value * (acceleration/2) * Time.deltaTime);
        }

        private void Turn(float value)
        {
            // Logic for steering the vehicle (negative value for left, positive for right)
            //Debug.Log("Steering with value " + value);

            transform.Rotate(Vector3.up * value * rotationSpeed * Time.deltaTime);
        }
    }
}

