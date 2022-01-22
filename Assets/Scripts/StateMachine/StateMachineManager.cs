using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachine
{
    public class StateMachineManager : MonoBehaviour
    {
        private Dictionary<Type, BaseState> availableStates;

        [SerializeField]
        private BaseState currentState;

        public BaseState CurrentState { get => currentState; set => currentState = value; }
        public Dictionary<Type, BaseState> AvailableStates { get => availableStates; set => availableStates = value; }

        public event Action<BaseState> OnStateChanged;
        public event Action<Dictionary<Type, BaseState>> OnListOfStatesCreated;

        public void SetStates(Dictionary<Type, BaseState> states)
        {
            AvailableStates = states;
        }

        private void OnEnable()
        {
            CurrentState = AvailableStates.Values.First();
            OnListOfStatesCreated?.Invoke(AvailableStates);
        }

        private void FixedUpdate()
        {
            var nextState = CurrentState?.Tick();
            if (nextState != null &&
                nextState != CurrentState?.GetType())
            {
                SwitchToNewState(nextState);
            }
        }

        public void SwitchToNewState(Type nextState)
        {
            CurrentState = AvailableStates[nextState];
            OnStateChanged?.Invoke(CurrentState);
        }
    }
}