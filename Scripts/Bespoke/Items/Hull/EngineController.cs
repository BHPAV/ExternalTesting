using UnityEngine;

namespace Bespoke.Items.Hull
{



    public class EngineController : MonoBehaviour
    {
        private WheelController wheelController;
        [SerializeField] private float engineMaxPower = 200f;
        public float currentPower = 0f;

        public void InitializeEngine()
        {
            //motorTorque = vehicleData.motorTorque;
            //maxSteerAngle = vehicleData.maxSteerAngle;
        }

        public void Initialize(WheelController wheelController)
        {
            this.wheelController = wheelController;
        }

        void Update()
        {
            //float verticalInput = Input.GetAxis("Vertical");
            //wheelController.ApplyTorque(enginePower * verticalInput);
        }

        private void FixedUpdate()
        {
            DegradePower();
        }

        public void UpdateEngine()
        {
            //float verticalInput = Input.GetAxis("Vertical");
            //wheelController.ApplyTorque(enginePower * verticalInput);
            wheelController.ApplyTorque(currentPower);
        }

        public void Accelerate(float accelerate)
        {
            if(accelerate > 0.5f || accelerate < -0.5f)
            {
                //wheelController.ApplyTorque(-enginePower * accelerate);
                currentPower += (10.0f * accelerate);
                if(currentPower > engineMaxPower || currentPower < (-engineMaxPower / 2))
                {
                    currentPower = engineMaxPower;
                }
            }
        }


        // Function that degrades currentPower over time if Accelerate is not being called for 0.5 seconds
        public void DegradePower()
        {
            if(currentPower != 0.0f)
                currentPower = Mathf.Lerp(currentPower, 0.0f, 0.1f);
        }


    }
}
