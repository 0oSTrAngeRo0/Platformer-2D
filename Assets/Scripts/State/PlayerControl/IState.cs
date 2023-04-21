using System;
using UnityEngine;

namespace State.PlayerControl
{
    public interface IState
    {
        void Initialize(StateMachine father);
        void Enter();
        void Exit();
        void LogicUpdate();
        void PhysicsUpdate();
    }
}
