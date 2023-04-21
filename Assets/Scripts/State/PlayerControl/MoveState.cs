using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "MoveState", menuName = "ScriptableObject/PlayerControl/State/Move")]
    public class MoveState : State
    {
        [Header("Config")]
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _AccelerateTime;
        [SerializeField] private float _DecelerateTime;

        [Header("Information")]
        [SerializeField, ReadOnly] private float _MoveSpeed;
        [SerializeField, ReadOnly] private float _AccelerateSpeed;
        [SerializeField, ReadOnly] private float _DecelerateSpeed;

        public override void Initialize(StateMachine father)
        {
            base.Initialize(father);
            _AccelerateSpeed = _MaxSpeed / _AccelerateTime;
            _DecelerateSpeed = _MaxSpeed / _DecelerateTime;
        }
        public override void Enter()
        {
            base.Enter();
            _MoveSpeed = _Paramaters.Velocity.x;
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (_Paramaters.MoveX==0)
            {
                _MoveSpeed = Mathf.MoveTowards(_MoveSpeed, 0, Time.deltaTime * _DecelerateSpeed);
            }
            else
            {
                _MoveSpeed += _Paramaters.MoveX * _AccelerateSpeed * Time.deltaTime;
                _MoveSpeed = Mathf.Clamp(_MoveSpeed, -_MaxSpeed, _MaxSpeed);
            }
            _Paramaters.Velocity.x = _MoveSpeed;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(_Paramaters.MoveY<0 && _Paramaters.IsGround)
            {
                _FatherStateMachine.SwitchState(typeof(CrouchState));
            }
            else if (_Paramaters.JumpBuffer > 0)
            {
                _FatherStateMachine.SwitchState(typeof(JumpState));
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
            else if (_Paramaters.IsGrab)
            {
                _FatherStateMachine.SwitchState(typeof(GrabDashState));
            }
        }
    }
}
