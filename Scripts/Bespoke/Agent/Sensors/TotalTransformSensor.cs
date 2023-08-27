using Unity.MLAgents.Sensors;
using UnityEngine;

namespace Bespoke.Agent.Sensors
{

    public class TotalTransformSensor : ISensor
    {
        private readonly GameObject _targetObject;
        private readonly string _name;

        private const int ObservationSize = 7;

        public TotalTransformSensor(GameObject targetObject, string name)
        {
            this._targetObject = targetObject;
            this._name = name;
        }

        public int[] GetObservationShape()
        {
            return new[] { ObservationSize };
        }

        public string GetName()
        {
            return _name;
        }

        public byte[] GetCompressedObservation()
        {
            return null;
        }

        public void Update()
        {
        }

        public void Reset()
        {
        }

        public int Write(ObservationWriter writer)
        {
            var position = _targetObject.transform.position;
            writer[0] = position.x;
            writer[1] = position.y;
            writer[2] = position.z;

            var rotation = _targetObject.transform.rotation;
            writer[3] = rotation.x;
            writer[4] = rotation.y;
            writer[5] = rotation.z;
            writer[6] = rotation.w;
            return 7; // Number of values written
        }

        public ObservationSpec GetObservationSpec()
        {
            return ObservationSpec.Vector(ObservationSize);
        }

        public CompressionSpec GetCompressionSpec()
        {
            return CompressionSpec.Default();
        }
    }

}
