using Bespoke.Agent;
using Bespoke.Agent.Cores;
using Bespoke.Enums;
using Bespoke.InputSystem;

namespace Bespoke.Items.Hull
{
    using UnityEngine;

    public class Vehicle : MonoBehaviour
    {
        public AgentCore agentCore;

        public void RegisterInputScheme(InputScheme inputScheme)
        {
            // Subscribe to Up direction for acceleration
            inputScheme.DirectionActions[Direction.Up] += Accelerate;

            // Subscribe to Down direction for braking
            inputScheme.DirectionActions[Direction.Down] += Brake;

            // Subscribe to Left and Right directions for steering
            inputScheme.DirectionActions[Direction.Left] += value => Steering(-value);
            inputScheme.DirectionActions[Direction.Right] += value => Steering(value);

            // Subscribe to specific buttons for other actions
            inputScheme.ButtonActions[Button.One] += Fire;
            inputScheme.ButtonActions[Button.Two] += Repair;

            inputScheme.ButtonActions[Button.Zero] += Exit;
        }

        private void Accelerate(float value)
        {
            // Logic for accelerating the vehicle
            Debug.Log("Accelerating with value " + value);
        }

        private void Brake(float value)
        {
            // Logic for braking the vehicle
            Debug.Log("Braking with value " + value);
        }

        private void Steering(float value)
        {
            // Logic for steering the vehicle (negative value for left, positive for right)
            Debug.Log("Steering with value " + value);
        }

        private void Fire(float value)
        {
            // Logic for firing
            Debug.Log("Firing with value " + value);
        }

        private void Exit(float value)
        {
            // Logic for exiting the vehicle
            Debug.Log("Exiting with value " + value);
        }

        private void Repair(float value)
        {
            // Logic for repairing the vehicle
            Debug.Log("Repairing with value " + value);
        }

        // Other vehicle code...
    }

}
