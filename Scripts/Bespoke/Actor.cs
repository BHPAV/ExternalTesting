
using System;
using System.Collections.Generic;
using Bespoke.Agent;
using Bespoke.Agent.Cores;
using Bespoke.Agent.Events;
using Bespoke.Enums;
using Bespoke.InputSystem;
using Bespoke.Items.Hull;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Bespoke
{
    public class Actor : MonoBehaviour
    {
        [FoldoutGroup("MONITORING", expanded: false)]
        public InputScheme inputScheme = new InputScheme(4, 3);

        [FoldoutGroup("MONITORING")]
        public Dictionary<Direction, float> CurrentDirectionInputs = new Dictionary<Direction, float>();

        [FoldoutGroup("MONITORING")] public Dictionary<Button, float> CurrentButtonInputs = new Dictionary<Button, float>();

        [SerializeField] private AgentCore agent;
        
        

        
        public InputScheme InputScheme => GetInputScheme();

        private InputScheme GetInputScheme()
        {
            return agent != null ? agent.inputScheme : inputScheme;
        }

        public void Start()
        {
            Mount();
        }

        // Find a MountComponent in the scene, if one is found Mount the Actor to it.
        public void Mount()
        {
            var mount = FindObjectOfType<MountComponent>();
            if (mount != null)
            {
                mount.MountActor(this);
            }
        }
    }
}

