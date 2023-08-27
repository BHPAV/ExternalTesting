using System;
using System.Collections.Generic;
using UnityEngine;
using Bespoke.Enums;
using Unity.MLAgents.Actuators;

namespace Bespoke.InputSystem
{
    public class InputAction
    {
        public Direction? Direction { get; set; }
        public Button? Button { get; set; }
        public float Value { get; set; }
    }

    [System.Serializable]
    public class InputScheme
    {
        [SerializeField] private List<Direction> directions = new List<Direction>();
        [SerializeField] private List<Button> buttons = new List<Button>();

        public Dictionary<Direction, Action<float>> DirectionActions { get; } = new Dictionary<Direction, Action<float>>();
        public Dictionary<Button, Action<float>> ButtonActions { get; } = new Dictionary<Button, Action<float>>();

        public InputScheme()
        {
            InitializeActions(directions.Count, buttons.Count);
        }

        public InputScheme(int numDirections, int numButtons)
        {
            InitializeActions(numDirections, numButtons);
        }

        private void InitializeActions(int numDirections, int numButtons)
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                DirectionActions[direction] = null;
            }

            foreach (Button button in Enum.GetValues(typeof(Button)))
            {
                ButtonActions[button] = null;
            }
        }

        public void InputDiscreteActions(ActionSegment<int> discreteActions)
        {
            int expectedLength = directions.Count + buttons.Count;
            if (discreteActions.Length != expectedLength)
            {
                Debug.LogWarning($"Expected {expectedLength} discrete actions but received {discreteActions.Length}.");
                return;
            }

            // Process directions
            for (int i = 0; i < directions.Count; i++)
            {
                Direction direction = directions[i];
                float value = discreteActions[i];
                DirectionActions[direction]?.Invoke(value);
            }

            // Process buttons
            for (int i = 0; i < buttons.Count; i++)
            {
                Button button = buttons[i];
                float value = discreteActions[directions.Count + i];
                ButtonActions[button]?.Invoke(value);
            }
        }

        public float[] GetWASDValues()
        {
            return new float[]
            {
                Input.GetKey(KeyCode.W) ? 1f : 0f,
                Input.GetKey(KeyCode.S) ? 1f : 0f,
                Input.GetKey(KeyCode.A) ? 1f : 0f,
                Input.GetKey(KeyCode.D) ? 1f : 0f
            };
        }

        public void ProcessWASDInput()
        {
            if (Input.GetKey(KeyCode.W))
                DirectionActions[Direction.Up]?.Invoke(1f);
            if (Input.GetKey(KeyCode.S))
                DirectionActions[Direction.Down]?.Invoke(1f);
            if (Input.GetKey(KeyCode.A))
                DirectionActions[Direction.Left]?.Invoke(1f);
            if (Input.GetKey(KeyCode.D))
                DirectionActions[Direction.Right]?.Invoke(1f);
        }
    }
}
// Compare this snippet from Assets\Scripts\Bespoke\InputSystem\InputScheme.cs:
