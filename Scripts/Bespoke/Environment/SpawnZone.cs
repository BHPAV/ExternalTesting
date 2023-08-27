using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bespoke.Environment
{
    [System.Serializable]
    public class SpawnZone
    {
        public Transform spawnPoint; // The position to spawn the agent
        public bool isActive; // Determines if the spawn zone is active or not
        public int spawnWeight; // Weight to determine the probability of selecting this spawn zone

        // Additional variables and methods as needed
    }
}
