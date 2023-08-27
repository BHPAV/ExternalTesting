using Unity.MLAgents.Sensors;
using UnityEngine;

namespace Bespoke.Agent.Sensors
{



    public class TotalTransformSensorComponent : SensorComponent
    {

        private TotalTransformSensor _sensor;
        private StackingSensor _stackingSensor;

        [SerializeField] private string sensorName;
        [SerializeField] private int numStacks = 3;

        [SerializeField] private GameObject targetObject;
        public Vector3 TargetTransform => targetObject.transform.position;
        public Vector3 targetPos;

        private void FixedUpdate()                      => targetPos = targetObject.transform.position;
        public void SetSensorName(string sensorName)          => this.sensorName = sensorName;
        public void SetSensorTarget(GameObject target)  => targetObject = target;

        public override ISensor[] CreateSensors()
        {
            _sensor = new TotalTransformSensor(targetObject, sensorName);
            _stackingSensor = new StackingSensor(_sensor, numStacks);
            return new ISensor[] { _stackingSensor };
        }


    }

}
