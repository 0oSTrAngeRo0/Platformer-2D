using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "LandState", menuName = "ScriptableObject/PlayerControl/State/Land")]
    class LandState : State
    {
        [Header("Config")]
        [SerializeField] private float _StiffTime;

        [Header("State Information")]
        [SerializeField, ReadOnly] private float _StiffBuffer;

        public override void Enter()
        {
            base.Enter();
            _Paramaters.Velocity.y = 0;
            _Paramaters.CurrentJumpTimes = 0;
            if (_StiffTime <= 0)
            {
                return;
            }
            _StiffBuffer = _StiffTime;
            _Paramaters.Velocity.x = 0;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _StiffBuffer -= Time.deltaTime;
            if(_StiffBuffer <= 0)
            {
                _FatherStateMachine.SwitchState(typeof(MoveState));
            }
            if (_Paramaters.JumpBuffer > 0)
            {
                _FatherStateMachine.SwitchState(typeof(JumpState));
            }
        }


    }
}