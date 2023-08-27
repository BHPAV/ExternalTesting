using Sirenix.OdinInspector;
using UnityEngine;

namespace Bespoke.Items.Hull.Wheels
{

    public class WheelControl : MonoBehaviour
    {

        // Model game object
        [Title("Model")]
        [Tooltip("The visual representation of the wheel.")]
        [SerializeField] private GameObject model;

        // Wheel collider component
        [Title("Wheel Collider")]
        [Tooltip("The collider component for the wheel.")]
        [SerializeField] private WheelCollider wheelCollider;
        [SerializeField] private Quaternion wheelRotation ;

        // Steering capability
        [Title("Steering")]
        [Tooltip("Indicates whether the wheel can steer.")]
        public bool canSteer;

        [Title("Steering")]
        [Tooltip("Indicates maximum turning angle of wheel.")]
        public float maxSteerAngle;

        // Power capability
        [Title("Power")]
        [Tooltip("Indicates whether the wheel can apply power.")]
        public bool canPower;



        //Particles
        public TrailRenderer skidTrail;
        public ParticleSystem smoke;

        // Constants
        [SerializeField] private float SkidThreshold = 0.8f;
        [SerializeField] private float RPMThreshold = 5.0f;

        public bool Skidding;
        public bool Grounded;

        [SerializeField] private float steerAngle = 0.0f;
        private EngineController engine;
        public float currentPower = 0.0f;





        private void Start()
        {
            // Check if the wheel collider is null
            if (wheelCollider == null)
            {
                GetWheelCollider();
                GetWheelModel();
                //GetEffects();
            }

            engine = GetComponentInParent<EngineController>();
        }

        private void Update()
        {

            // Check if the model game object is null
            //if (model == null)
            //{
            //    Debug.LogError("Model is not assigned.");
            //    return;
            //}
        }

        private void RotateWheelModel()
        {
            //Rotating The Wheels Meshes so they have the same position and rotation as the wheel colliders
            var pos = Vector3.zero; //position value (temporary)
            var rot = Quaternion.identity; //rotation value (temporary)

            wheelCollider.GetWorldPose(out pos, out rot); //get the world rotation & position of the wheel colliders
            model.transform.position = pos; //Set the wheel transform positions to the wheel collider positions
            model.transform.rotation = rot * Quaternion.Euler(Vector3.zero); //Rotate the wheel transforms to the rotation of the wheel collider(s) and the rotation offset
        }

        void FixedUpdate()
        {
            // Rotate the visual model based on the position of the wheel collider
            //model.transform.rotation = wheelCollider.transform.rotation;
            //model.transform.localPosition = wheelCollider.transform.position;


            //TESTING UPDATES
            //Grounded = IsGrounded();
            //Skidding = IsSkidding();

            //EffectCheck();

            //wheelRotation = wheelCollider.transform.rotation;
            ApplyTorque(engine.currentPower);

            RotateWheelModel();

            // lerp steering angle back to 0
            steerAngle = Mathf.Lerp(steerAngle, 0.0f, 0.1f);
        }

        private void GetEffects()
        {
            Transform fxTransform = transform.Find("FX");
            if (fxTransform != null)
            {
                skidTrail = fxTransform.GetComponent<TrailRenderer>();
                smoke = fxTransform.GetComponent<ParticleSystem>();
            }
        }

        private void GetWheelCollider()
        {
            Transform colliderTransform = transform.Find("Collider");
            if (colliderTransform != null)
            {
                wheelCollider = colliderTransform.GetComponent<WheelCollider>();
                if (wheelCollider == null)
                {
                    Debug.LogError("Child object named 'Collider' does not have a WheelCollider component attached.");
                }
            }
            else
            {
                Debug.LogError("Child object named 'Collider' not found.");
            }
        }


        private void GetWheelModel()
        {
            Transform modelTransform = transform.Find("Model");
            if (modelTransform != null)
            {
                model = modelTransform.gameObject;
            }
            else
            {
                Debug.LogError("Child object named 'Model' not found.");
            }
        }






        [Title("Torque")]
        public void ApplyTorque(float torque)
        {
            currentPower = torque;

            // Apply the specified torque to the wheel collider if the wheel can apply power
            if (!canPower) return;

            wheelCollider.motorTorque = torque;
            currentPower = wheelCollider.motorTorque;
        }


        [Title("Steering")]
        public void ApplySteering(float steering)
        {
            // Check if the wheel collider is null
            if (wheelCollider == null)
            {
                Debug.LogError("Wheel collider is not assigned.");
                return;
            }

            // Apply the specified torque to the wheel collider if the wheel can apply power
            if (canSteer)
            {
                steerAngle += (steering * 5);
                wheelCollider.steerAngle = Mathf.Clamp(steerAngle, -maxSteerAngle, maxSteerAngle);
                steerAngle = wheelCollider.steerAngle;
            }
        }



        [Title("Grounded")]
        public bool IsGrounded()
        {
            // Check if the wheel collider is null
            if (wheelCollider == null)
            {
                Debug.LogError("Wheel collider is not assigned.");
                return false;
            }

            // Check if the wheel is touching the ground
            WheelHit hit;
            return wheelCollider.GetGroundHit(out hit);
        }



        [Title("Skidding")]
        public bool IsSkidding()
        {
            // Check if the wheel collider is null
            if (wheelCollider == null)
            {
                Debug.LogError("Wheel collider is not assigned.");
                return false;
            }

            // Check if the wheel is skidding
            WheelHit hit;
            wheelCollider.GetGroundHit(out hit);
            return Mathf.Abs(hit.sidewaysSlip) >= SkidThreshold || (Mathf.Abs(hit.forwardSlip) >= SkidThreshold && wheelCollider.rpm > RPMThreshold);
        }


        [Title("Smoking")]
        public bool IsSmoking()
        {
            // Check if the wheel collider is null
            if (wheelCollider == null)
            {
                Debug.LogError("Wheel collider is not assigned.");
                return false;
            }

            // Check if the wheel is skidding
            WheelHit hit;
            wheelCollider.GetGroundHit(out hit);
            return Mathf.Abs(hit.sidewaysSlip) >= SkidThreshold || (Mathf.Abs(hit.forwardSlip) >= SkidThreshold && wheelCollider.rpm > RPMThreshold);
        }



        private void EffectCheck()
        {
            if(IsSkidding() && IsGrounded())
                skidTrail.emitting = true;
            else
                skidTrail.emitting = false;
        }

        public void SetColliderPosition(Vector3 _position)
        {
            //wheelCollider.transform.localPosition = _position;
            GameObject colliderObject = this.transform.GetChild(0).gameObject;
            colliderObject.transform.localPosition = _position;
        }



        private void WheelRotation()
        {
            Vector3 position;
            Quaternion rotation;
            wheelCollider.GetWorldPose(out position, out rotation);
            model.transform.localPosition = position;
            model.transform.rotation = rotation;
        }

        public WheelCollider GetCollider()
        {
        return wheelCollider;
        }

        public GameObject GetModel()
        {
            return model;
        }





    }

}
