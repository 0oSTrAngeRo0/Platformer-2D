using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "DashState", menuName = "ScriptableObject/PlayerControl/State/Dash")]
    public class DashState : State
    {
        [Header("Config")]
        [SerializeField] private float _Duration;
        [SerializeField] private float _Distance;
        [SerializeField] public float _CoolTime;
        [SerializeField] private float _InvincibleStartTime;
        [SerializeField] private float _InvincibleEndTime;

        [Header("Information")]
        [SerializeField, ReadOnly] private float _Speed;
        [SerializeField, ReadOnly] private float _DurationBuffer;
        
        public override bool CanEnter => Mathf.Abs(_Paramaters.Velocity.x) > Mathf.Epsilon && _Paramaters.DashCoolBuffer < 0;

        public override void Initialize(StateMachine father)
        {
            base.Initialize(father);
            _Speed = _Distance / _Duration;
        }
        public override void Enter()
        {
            base.Enter();
            _Paramaters.Player.IsDash = true;
            _Paramaters.IsDash = false;
            _Speed = _Distance / _Duration; //可注释，便于调试
            _DurationBuffer = 0;
            _Paramaters.Velocity.x = _Paramaters.MoveX * _Speed;
            _Paramaters.Velocity.y = 0;
            _Paramaters.DashCoolBuffer = _CoolTime;
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            _DurationBuffer += Time.deltaTime;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_DurationBuffer > _Duration)
            {
                if (_Paramaters.IsGround)
                {
                    _FatherStateMachine.SwitchState(typeof(MoveState));
                }
                else
                {
                    _FatherStateMachine.SwitchState(typeof(FallState));
                }
            }
            else if (_Paramaters.JumpBuffer > 0)
            {
                if (_Paramaters.IsGround)
                {
                    _FatherStateMachine.SwitchState(typeof(AirJumpState));
                }
                else
                {
                    _FatherStateMachine.SwitchState(typeof(JumpState));
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
            _Paramaters.Player.IsDash = false;
        }
    }
}
