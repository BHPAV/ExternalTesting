using System.Collections.Generic;
using Bespoke.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Bespoke.Items.Hull.Mounts
{
    public class DriverController : MountController
    {
        [BoxGroup("DETAILS")]
        public Rigidbody rb;
        [BoxGroup("DETAILS")]
        public EngineController engine;
        [BoxGroup("DETAILS")]
        public WheelController wheels;

        [BoxGroup("STATS")]
        public float moveSpeed = 100.0f;
        [BoxGroup("STATS")]
        public float rotationSpeed = 50.0f;

        private void Start()
        {
            rb = GetComponentInParent<Rigidbody>();
            mount = GetComponent<BoxMount>();

            HullController hull = GetComponent<HullController>();
            //moveSpeed = hull.moveSpeed;
            //rotationSpeed = hull.rotationSpeed;
            //engine = hull.engineController;
            //wheels = hull.wheelController;
        }

        public override void ProcessInputs(Dictionary<Direction, float> directionInputs, Dictionary<Button, float> buttonInputs)
        {
            //Debug.Log("Input Received for Drive Controller");

            float up = directionInputs.ContainsKey(Direction.Up) ? directionInputs[Direction.Up] : 0;
            float down = directionInputs.ContainsKey(Direction.Down) ? directionInputs[Direction.Down] : 0;
            float left = directionInputs.ContainsKey(Direction.Left) ? directionInputs[Direction.Left] : 0;
            float right = directionInputs.ContainsKey(Direction.Right) ? directionInputs[Direction.Right] : 0;

            float action_1 = buttonInputs.ContainsKey(Button.Zero) ? buttonInputs[Button.Zero] : 0;
            float action_2 = buttonInputs.ContainsKey(Button.One) ? buttonInputs[Button.One] : 0;
            float action_3 = buttonInputs.ContainsKey(Button.Two) ? buttonInputs[Button.Two] : 0;

            Accelerate(up - down);
            Rotation(right - left);
            Brake(action_1);
        }

        private void Accelerate(float input)
        {
            transform.Translate(Vector3.forward * input * moveSpeed * Time.deltaTime);
            //Debug.Log("Accelerate");
        }

        private void Rotation(float input)
        {
            transform.Rotate(Vector3.up * input * rotationSpeed * Time.deltaTime);
            //Debug.Log("Turn");
        }

        private void Brake(float input)
        {
            transform.Rotate(Vector3.up * input * rotationSpeed * Time.deltaTime);
        }
    }
}

