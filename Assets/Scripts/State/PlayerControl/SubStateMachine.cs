using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    public abstract class SubStateMachine : StateMachine, IState
    {
        [field: SerializeReference, ReadOnly] private StateMachine _FatherStateMachine;

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Initialize(StateMachine father)
        {
            _FatherStateMachine = father;
            _Paramaters = _FatherStateMachine._Paramaters;
        }

    }
}
