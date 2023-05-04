using System;
using UnityEngine;

namespace State.PlayerControl
{
    public interface IState
    {
        public bool CanEnter { get; }
        void Initialize(StateMachine father);
        void Enter();
        void Exit();
        void LogicUpdate();
        void PhysicsUpdate();
    }
}
