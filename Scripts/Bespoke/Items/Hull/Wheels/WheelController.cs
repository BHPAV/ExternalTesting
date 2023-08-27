using Bespoke.Items.Hull;
using Bespoke.Items.Hull.Wheels;
using UnityEngine;

namespace Bespoke
{
    


    public class WheelController : MonoBehaviour
    {

        public WheelControl[] wheels;
        public float motorTorque;
        public float maxSteerAngle;

        public void InitializeWheels()
        {

        }

        public void UpdateWheels()
        {

        }

        public void Initialize(HullData hullData, GameObject vehicleModel)
        {
            //Update the Torque and Steering
            motorTorque = hullData.motorTorque;
            maxSteerAngle = hullData.maxSteerAngle;

            int numWheels = hullData.wheelPositions.Length;
            wheels = new WheelControl[numWheels];

            GameObject wheelGroup = new GameObject("Wheels");
            wheelGroup.transform.SetParent(vehicleModel.transform);
            wheelGroup.transform.localPosition = Vector3.zero;
            
            
            for (int i = 0; i < numWheels; i++)
            {
                wheels[i] = InstantiateWheel(hullData, vehicleModel, wheelGroup, hullData.wheelPositions[i]);
            }

            foreach (HullData.SteerableWheel steerableWheel in hullData.steerableWheels)
            {
                WheelControl wheel = wheels[steerableWheel.wheelIndex];
                wheel.canSteer = true;
                wheel.maxSteerAngle = steerableWheel.maxSteerAngle;
            }

            foreach (HullData.PoweredWheel poweredWheel in hullData.poweredWheels)
            {
                WheelControl wheel = wheels[poweredWheel.wheelIndex];
                wheel.canPower = true;
            }
        }


        private WheelControl InstantiateWheel(HullData hullData, GameObject vehicleModel, GameObject wheelGroup, Vector3 position)
        {
            //GameObject wheel = Instantiate(vehicleData.wheelPrefab, vehicleModel.transform.TransformPoint(position), Quaternion.identity, vehicleModel.transform);
            GameObject wheel = Instantiate(hullData.wheelPrefab, vehicleModel.transform.TransformPoint(position), Quaternion.identity, wheelGroup.transform);
            WheelControl wheelControl = wheel.GetComponent<WheelControl>();
            wheelControl.SetColliderPosition(wheelControl.transform.localPosition);
            wheelControl.transform.localPosition = Vector3.zero;

            //Add new components
            //wheel.AddComponent<SteerableWheelComponent>();
            //wheel.AddComponent<PoweredWheelComponent>();
            
            return wheelControl;
        }


        public void ApplySteering(float steering)
        {
            foreach (WheelControl wheel in wheels)
            {
                //ApplyWheelSteering(wheel, steering);
                wheel.ApplySteering(steering);
            }
        }

        private void ApplyWheelSteering(WheelControl wheelCollider, float steering)
        {
            /*
            if (steerableWheelComponent)
            {
                wheelCollider.steerAngle = Mathf.Clamp(steering, -steerableWheelComponent.maxSteerAngle, steerableWheelComponent.maxSteerAngle);
            }
            */
            
        }

        public void ApplyTorque(float torque)
        {
            foreach (WheelControl wheel in wheels)
            {
                //ApplyWheelTorque(wheel, torque);
                wheel.ApplyTorque(torque);
            }
        }

        private void ApplyWheelTorque(WheelCollider wheelCollider, float torque)
        {
            /*
            PoweredWheelComponent poweredWheelComponent = wheelCollider.GetComponent<PoweredWheelComponent>();
            if (poweredWheelComponent && poweredWheelComponent.isPowered)
            {
                wheelCollider.motorTorque = torque;
            }
            */
        }

        private void UpdateWheelModels()
        {
            /*
            foreach (WheelCollider wheel in wheels)
            {
                //UpdateWheelModel(wheel);
            }
            */
        }

        private void UpdateWheelModel(WheelControl wheelControl)
        {
            /*
            Transform wheelModelTransform = wheelControl.transform.GetChild(0);
            Vector3 position;
            Quaternion rotation;
            wheelCollider.GetWorldPose(out position, out rotation);
            wheelModelTransform.position = position;
            wheelModelTransform.rotation = rotation;
            */
        }

        void Update()
        {
            // Read user input
            //float verticalInput = Input.GetAxis("Vertical");
            //float horizontalInput = Input.GetAxis("Horizontal");

            // Calculate torque and steering values
            //float steering = horizontalInput * maxSteerAngle;
            //float torque = verticalInput * motorTorque;

            // Apply steering and torque to the wheels
            //ApplySteering(steering);
            //ApplyTorque(torque);

            // Update the wheel models to rotate based on their attached wheel colliders
            UpdateWheelModels();
        }

        [System.Serializable]
        public class WheelPair
        {
            public WheelControl leftWheel;
            public WheelControl rightWheel;

            public WheelPair(WheelControl leftWheel, WheelControl rightWheel)
            {
                this.leftWheel = leftWheel;
                this.rightWheel = rightWheel;
            }

            public void ApplyTorque(float torque)
            {
                //leftWheel.motorTorque = torque;
                //rightWheel.motorTorque = torque;
            }

            public void UpdateModelRotation()
            {
                UpdateWheelModel(leftWheel);
                UpdateWheelModel(rightWheel);
            }

            private void UpdateWheelModel(WheelControl wheelControl)
            {
                /*
                WheelCollider wheelCollider = wheelControl.GetCollider();
                
                Transform wheelModel = wheelControl.GetModel();
                Vector3 position;
                Quaternion rotation;
                wheelCollider.GetWorldPose(out position, out rotation);
                wheelModel.position = position;
                wheelModel.rotation = rotation;
                */
            }

            public void SetMaxSteerAngle(float maxSteerAngle)
            {
                /*
                SteerableWheelComponent leftSteerableWheelComponent = leftWheel.GetComponent<SteerableWheelComponent>();
                SteerableWheelComponent rightSteerableWheelComponent = rightWheel.GetComponent<SteerableWheelComponent>();

                leftSteerableWheelComponent.maxSteerAngle = maxSteerAngle;
                rightSteerableWheelComponent.maxSteerAngle = maxSteerAngle;
                */
            }

            public void ApplySteering(float steering)
            {
                //foreach (WheelCollider wheel in wheels)
                //{
                //    ApplyWheelSteering(wheel, steering);
                //}
            }

            private void ApplyWheelSteering(WheelCollider wheelCollider, float steering)
            {
                /*
                SteerableWheelComponent steerableWheelComponent = wheelCollider.GetComponent<SteerableWheelComponent>();
                if (steerableWheelComponent)
                {
                    wheelCollider.steerAngle = Mathf.Clamp(steering, -steerableWheelComponent.maxSteerAngle, steerableWheelComponent.maxSteerAngle);
                }
                */
            }

            public WheelControl GetWheel(int index)
            {
                return index == 0 ? leftWheel : rightWheel;
            }

            
        }
    }
}