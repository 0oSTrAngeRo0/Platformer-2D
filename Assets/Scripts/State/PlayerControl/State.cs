using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    public abstract class State : ScriptableObject, IState
    {
        [Header("State Information")]
        [field: SerializeReference, ReadOnly] protected StateMachine _FatherStateMachine;
        [field: SerializeReference, ReadOnly] protected Paramaters _Paramaters;

        [Header("State Config")]
        //Debug Information
        [field: SerializeReference] public string _StateName;
        [field: SerializeReference] public Color _DebugColor;

        public virtual bool CanEnter => true;
        public virtual void Enter() { }

        public virtual void PopEnter() { }

        public virtual void Exit() { }

        public virtual void Initialize(StateMachine father)
        {
            _FatherStateMachine = father;
            _Paramaters = _FatherStateMachine._Paramaters;
        }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() { }
    }
}
