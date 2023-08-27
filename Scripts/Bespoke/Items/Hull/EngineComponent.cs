using UnityEngine;

namespace Bespoke.Items.Hull
{
    public class EngineComponent : IHullComponent
    {
        public float Power = 100f;
        public float Fuel = 100f;

        public void Initialize()
        {
            // Initialization code for the engine
        }

        public void UpdateComponent()
        {
            // Update code for managing engine behavior
            // Example: Consume fuel based on power usage
            Fuel -= Power * Time.deltaTime * 0.01f;
        }
    }

}
