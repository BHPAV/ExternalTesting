using Sirenix.OdinInspector;
using UnityEngine;

namespace Bespoke.Items.Hull
{
    [CreateAssetMenu(fileName = "Hull Data", menuName = "BESPOKE/Hull Data", order = 1)]
    public class HullData : ScriptableObject
    {

        public enum Type
        {
            BotBody,
            BoxManipulator,
            TankHull,
            GolfCart,
            Board,
            ForkLift
        }

        [BoxGroup("Vehicle Info")]                  [LabelText("Hull Type")]                public Type type;
        [BoxGroup("Vehicle Info")]                  [LabelText("Type Name")]                public string typeName;
        [BoxGroup("Vehicle Info")]                  [LabelText("Hull ID")]                  public string id;

        [BoxGroup("Vehicle Components")]            [LabelText("Body")]                     public GameObject prefab;


        [FoldoutGroup("Vehicle Components/Wheels")] [LabelText("Prefab")]                   public GameObject wheelPrefab;
        [FoldoutGroup("Vehicle Components/Wheels")] [LabelText("Wheel")]                    public Vector3[] wheelPositions;
        [FoldoutGroup("Vehicle Components/Wheels")] [LabelText("Steering")]                 public SteerableWheel[] steerableWheels;
        [FoldoutGroup("Vehicle Components/Wheels")] [LabelText("Powered")]                  public PoweredWheel[] poweredWheels;

        //[FoldoutGroup("Vehicle Components/Mounts")] [LabelText("Mounting Components")]      [SerializeReference]
        //public List<Mount> mounts;

        [FoldoutGroup("Vehicle Physics")]           [LabelText("Center of Gravity")]        public Vector3 centerOfMass;

        //[BoxGroup("Vehicle Info")]
        //[LabelText("Wheel Positions")]
        //public List<Vector3> wheelPositions;
        [FoldoutGroup("Vehicle Physics")]           [LabelText("Mass (kg)")]                public float mass;
        [FoldoutGroup("Vehicle Physics")]           [LabelText("Motor Torque (Nm)")]        public float motorTorque;
        [FoldoutGroup("Vehicle Physics")]           [LabelText("Max Steer Angle (deg)")]    public float maxSteerAngle;
        [FoldoutGroup("Vehicle Physics")]           [LabelText("Brake Force (N)")]          public float brakeForce;
        [FoldoutGroup("Vehicle Physics")]           [LabelText("Maximum Speed (km/h)")]     public float maximumSpeed;
        [FoldoutGroup("Vehicle Attachments")]       [LabelText("Prefab to Attach")]         public GameObject attachmentPrefab;





        [System.Serializable]
        public struct SteerableWheel
        {
            public int wheelIndex;
            public float maxSteerAngle;
        }

        [System.Serializable]
        public struct PoweredWheel
        {
            public int wheelIndex;
        }



        // Self-Reference Creator____________________________________________________________


    }
}
