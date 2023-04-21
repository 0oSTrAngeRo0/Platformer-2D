using System;
using System.Collections.Generic;
using UnityEngine;

namespace State.PlayerControl
{
    [CreateAssetMenu(fileName = "StateMachine", menuName = "ScriptableObject/PlayerControl/StateMachine")]
    public class StateMachine : ScriptableObject
    {
        [field: Header("Config")]
        [SerializeField] private List<State> states;
        [field: SerializeReference] public Paramaters _Paramaters { get; protected set; }

        [field: Header("Information")]
        [field: SerializeField, ReadOnly] public State _CurrentState { get; protected set; }
        [field: SerializeField, ReadOnly] public State _LastState { get; protected set; }

        protected Dictionary<Type, State> _States;

        public void SwitchState(Type stateType)
        {
            //可注释
            //if (!_States.ContainsKey(stateType))
            //{
            //    return;
            //}

            _CurrentState.Exit();
            _LastState = _CurrentState;
            _CurrentState = _States[stateType];
            _CurrentState.Enter();
        }
        public void PopState()
        {
            _CurrentState = _LastState;
            _CurrentState.PopEnter();
        }
        public virtual void Initialize()
        {
            _States = new();
            _States.Clear();
            foreach(State state in states)
            {
                _States.Add(state.GetType(), state);
                state.Initialize(this);
            }
            _CurrentState = states[0];
            _CurrentState.Enter();
        }
        public void SwitchState(State state)
        {
            _CurrentState.Exit();
            _CurrentState = state;
            _CurrentState.Enter();
        }
        public virtual void LogicUpdate()
        {
            _CurrentState.LogicUpdate();
        }
        public virtual void PhysicsUpdate()
        {
            _CurrentState.PhysicsUpdate();
        }
    }


}
