using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "GrabDashState", menuName = "ScriptableObject/PlayerControl/State/GrabDash")]
    public class GrabDashState : State
    {
        [Header("Config")]
        [SerializeField] private float _Speed;

        [Header("Information")]
        [SerializeField] private float _Duration;
        public override void Enter()
        {
            base.Enter();
            _Paramaters.IsGrab = false;
            
            _Paramaters.Velocity = (_Paramaters.GrabTarget - _Paramaters.PlayerPosition).normalized * _Speed;
            _Duration = Vector2.Distance(_Paramaters.GrabTarget, _Paramaters.PlayerPosition) / _Speed;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_Duration < 0)
            {
                //Modify Position


                //Switch State
                if (_Paramaters.JumpBuffer > 0)
                {
                    _FatherStateMachine.SwitchState(typeof(AirJumpState));
                }
                else if (!_Paramaters.IsGround)
                {
                    _FatherStateMachine.SwitchState(typeof(FallState));
                }
                else if (_Paramaters.IsDash)
                {
                    _FatherStateMachine.SwitchState(typeof(DashState));
                }
                else if (!_Paramaters.IsGrab)
                {
                    _FatherStateMachine.SwitchState(typeof(GrabDashState));
                }

                return;
            }
            _Duration -= Time.deltaTime;
        }
        public override void Exit()
        {
            base.Exit();
            _Paramaters.Velocity.Set(0, 0);
        }
    }
}
