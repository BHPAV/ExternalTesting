using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Bespoke.Items.Hull
{
    public class Hull : MonoBehaviour
    {
        [Serialize] private List<IHullComponent> _components = new List<IHullComponent>();

        // Add a component to the vehicle
        public void AddComponent(IHullComponent component)
        {
            _components.Add(component);
            component.Initialize();
        }

        // Remove a component from the vehicle
        public void RemoveComponent(IHullComponent component)
        {
            _components.Remove(component);
        }

        // Update all components
        private void Update()
        {
            foreach (var component in _components)
            {
                component.UpdateComponent();
            }
        }
    }
}
