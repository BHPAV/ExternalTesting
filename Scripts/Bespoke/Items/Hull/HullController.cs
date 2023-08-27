using System.Collections.Generic;
using Bespoke.Items.Hull.Mounts;
using UnityEngine;

namespace Bespoke.Items.Hull
{
    public class HullController : MonoBehaviour
    {
        public List<BoxMount> boxMounts; // List of all the mounts on this hull

        protected virtual void InitializeHull()
        {
            // Initialization code goes here
        }

        protected virtual void UpdateHull()
        {
            // Update code goes here
        }

        // For each of the boxMounts in the list, set hull controller to this.
        // This is called from Hull.cs
        public void SetBoxMounts()
        {
            foreach (var boxMount in boxMounts)
            {
                boxMount.SetHullController(this);
            }
        }
    }
}


