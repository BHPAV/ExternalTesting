using System.Collections.Generic;
using Bespoke.Enums;
using Bespoke.Items.Hull.Mounts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Bespoke.Items.Hull
{
    public class BoxController : MountController
    {
        [BoxGroup("DETAILS")]
        public Rigidbody rb;
        [BoxGroup("DETAILS")]
        public Hull hull;

        [BoxGroup("STATS")]         public float moveSpeed = 750.0f;
        [BoxGroup("STATS")]         public float rotationSpeed = 75.0f;
        [BoxGroup("STATS")]         public float bumpPower = 75.0f;

        private void Start()
        {
            // Get the parent's rigidbody
            hull = GetComponent<Hull>();
            rb = GetComponentInParent<Rigidbody>();
            mount = GetComponent<BoxMount>();

            // Set rb's center of mass to to vector3.zero
            rb.centerOfMass = Vector3.zero;
        }

        public override void ProcessInputs(Dictionary<Direction, float> directionInputs, Dictionary<Button, float> buttonInputs)
        {
            float up = directionInputs.ContainsKey(Direction.Up) ? directionInputs[Direction.Up] : 0;
            float down = directionInputs.ContainsKey(Direction.Down) ? directionInputs[Direction.Down] : 0;
            float left = directionInputs.ContainsKey(Direction.Left) ? directionInputs[Direction.Left] : 0;
            float right = directionInputs.ContainsKey(Direction.Right) ? directionInputs[Direction.Right] : 0;

            float action_1 = buttonInputs.ContainsKey(Button.Zero) ? buttonInputs[Button.Zero] : 0;
            float action_2 = buttonInputs.ContainsKey(Button.One) ? buttonInputs[Button.One] : 0;
            float action_3 = buttonInputs.ContainsKey(Button.Two) ? buttonInputs[Button.Two] : 0;

            Accelerate(up - down);
            Rotation(right - left);
            Bump(action_2);
        }

        public void InitializeBox()
        {
            // Initialization code goes here
        }

        public void UpdateBox()
        {
            // Update code goes here
        }

        private void Accelerate(float input)
        {

            hull.transform.Translate(Vector3.forward * input * moveSpeed * Time.deltaTime);
            //rb.AddForce(Hull.transform.forward * input * moveSpeed * Time.deltaTime);
            if(input > 0.5f)
                Debug.Log("Accelerate");
        }

        private void Rotation(float input)
        {
            hull.transform.Rotate(Vector3.up * input * rotationSpeed * Time.deltaTime);
            //Debug.Log("Turn");
        }

        private void Brake(float input)
        {
            if(input < 0.5f) return;

            // Reduce the rigidbody's velocity by 25% if velocity is under 0.5, reduce to zero.
            if(rb.velocity.magnitude < 0.5f)
            {
                rb.velocity = Vector3.zero;
            }
            else
            {
                rb.velocity *= 0.75f;
            }

            //hull.transform.Rotate(Vector3.up * input * rotationSpeed * Time.deltaTime);
        }

        private void Bump(float input)
        {
            // If input is true, cast a sphere around the hull then add a force to any rigidbodies that are infront of the hull, ignoring any parent rigidbodies.
            if(input < 0.5f) return;

            // Cast a sphere in front of the hull
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, 0.25f, transform.forward, out hit, 0.25f))
            {
                // If the spherecast hits a rigidbody, add a force to it
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * bumpPower, hit.point);
                }
            }

            // Draw a sphere to show the size of the sphere


            // draw a gizmo to show the direction of the spherecast
            var transform1 = transform;
            Debug.DrawRay(transform1.position, transform1.forward * 0.25f, Color.red, 1.0f);

        }
    }

}
