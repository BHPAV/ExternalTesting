using System;
using UnityEngine;

namespace Bespoke.Agent.Cognition
{
    public class AgentStatsSystem : AgentSubSystem, IAgentSystem
    {
        // Event declarations
        public event Action<float> OnHealthChanged;
        public event Action<float> OnEnergyChanged;
        public event Action<float> OnExperienceGained;
        public event Action OnHealthBelowThreshold;
        public event Action OnEnergyDepleted;

        private float _health;
        public float Health
        {
            get { return _health; }
            private set
            {
                _health = Mathf.Clamp(value, 0, 100);
                OnHealthChanged?.Invoke(_health);
                if (_health < HealthThreshold) OnHealthBelowThreshold?.Invoke();
            }
        }

        private float _energy;
        public float Energy
        {
            get { return _energy; }
            private set
            {
                _energy = Mathf.Clamp(value, 0, 100);
                OnEnergyChanged?.Invoke(_energy);
                if (_energy <= 0) OnEnergyDepleted?.Invoke();
            }
        }

        private float _experience;
        public float Experience
        {
            get { return _experience; }
            private set
            {
                _experience = value;
                OnExperienceGained?.Invoke(_experience);
            }
        }

        // Threshold or constants
        private const float HealthThreshold = 50.0f;

        // Methods for modifying stats and checking conditions
        // ...

        public void IncreaseHealth(float amount)
        {
            Health += amount;
        }

        public void DecreaseHealth(float amount)
        {
            Health -= amount;
        }

        public void ModifyEnergy(float amount)
        {
            Energy += amount;
        }

        public void AddExperience(float amount)
        {
            Experience += amount;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }

        public override void Update()
        {
            //throw new NotImplementedException();
        }
    }

}
