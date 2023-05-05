using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "CrouchChargeState", menuName = "ScriptableObject/PlayerControl/State/CrouchChargeState")]
    public class CrouchChargeState : State
    {
        [Header("Config")]
        [SerializeField] private float _HoldTimeLimitation;

        [Header("Information")]
        [SerializeField, ReadOnly] private float _HoldTime;

        public float HoldTime => _HoldTime;
        public float HoldTimeLimitation => _HoldTimeLimitation;
        
        public override void Enter()
        {
            base.Enter();
            _Paramaters.Player.IsCrouch = true;
            _Paramaters.Velocity = Vector2.zero;
            _HoldTime = 0;
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _HoldTime = Mathf.Clamp(_HoldTime + Time.deltaTime, 0, _HoldTimeLimitation);
            if(_Paramaters.IsTopBlocked)
            {
                return;
            }

            if (Mathf.Abs(_Paramaters.MoveX) > Mathf.Epsilon)
            {
                _FatherStateMachine.SwitchState(typeof(CrouchState));
            }
            else if (_Paramaters.MoveY>=0 && _Paramaters.IsGround)
            {
                _FatherStateMachine.SwitchState(typeof(MoveState));
            }
            else if (_Paramaters.JumpBuffer > 0)
            {
                _FatherStateMachine.SwitchState(typeof(ChargeJumpState));
            }
            else if (_Paramaters.Velocity.y <= 0 && !_Paramaters.IsGround)
            {
                _FatherStateMachine.SwitchState(typeof(FallState));
            }
            else if (_Paramaters.IsDash)
            {
                _FatherStateMachine.SwitchState(typeof(DashState));
            }
            else if (_Paramaters.IsWall && _Paramaters.IsHeld)
            {
                _FatherStateMachine.SwitchState(typeof(ClimbWallState));
            }
        }
        public override void Exit()
        {
            base.Exit();
            _Paramaters.Player.IsCrouch = false;
            _Paramaters.ChargePercent = _HoldTime / HoldTimeLimitation;
            _HoldTime = 0;
        }
    }
}