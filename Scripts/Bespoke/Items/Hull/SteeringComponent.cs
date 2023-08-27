using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bespoke.Items.Hull
{



    public class SteeringComponent : IHullComponent
    {
        public float TurnAngle = 30f;
        public float TurnSpeed = 10f;

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateComponent()
        {
            throw new System.NotImplementedException();
        }
    }

}
