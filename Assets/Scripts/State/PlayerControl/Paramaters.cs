using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Input;
using UnityEngine.Serialization;

namespace State.PlayerControl
{
    [CreateAssetMenu(fileName = "Paramaters", menuName = "ScriptableObject/PlayerControl/Paramaters")]
    [Serializable]
    public class Paramaters: ScriptableObject
    {
        [Header("Config")]
        //public float Gravity;
        public float JumpBufferTime;
        public float CoyoteTime;

        [Header("Input Information")]
        [ReadOnly] public float MoveX;
        [ReadOnly] public float MoveY;
        [ReadOnly] public float JumpBuffer;
        [ReadOnly] public bool IsDash;
        [ReadOnly] public bool IsHeld;
        [ReadOnly] public bool IsGrab;

        [Header("Inspector Information")]
        [ReadOnly] public bool IsFaceRight;
        [ReadOnly] public bool IsGround;
        [ReadOnly] public bool IsWall;
        [ReadOnly] public bool IsRightSideWall;
        [ReadOnly] public bool IsTopBlocked;
        [ReadOnly] public float CoyoteBuffer;
        [ReadOnly] public int CurrentJumpTimes;
        [ReadOnly] public float DashCoolBuffer;
        [ReadOnly] public Vector2 GrabTarget;
        [ReadOnly] public Vector2 PlayerPosition;
        [ReadOnly] public PlayerController Player;
        [ReadOnly] public float ChargePercent;

        [Header("Output Informtion")]
        [ReadOnly] public Vector2 Velocity;

        public void Initialize()
        {
            //Input Information
            MoveX = 0;
            MoveY = 0;
            IsDash = false;
            IsGround = false;
            IsWall = false;
            IsRightSideWall = false;
            IsHeld = false;
            IsGrab = false;

            //Inspect Information
            CurrentJumpTimes = 0;
            IsFaceRight = true;

            //Output Information
            Velocity = Vector2.zero;
        }
        public void PhysicsUpdate()
        {
            if (CoyoteBuffer > 0)
            {
                CoyoteBuffer -= Time.deltaTime;
            }
            if (JumpBuffer > 0)
            {
                JumpBuffer -= Time.deltaTime;
            }
            if (DashCoolBuffer > 0)
            {
                DashCoolBuffer -= Time.deltaTime;
            }
        }
        public void LogicUpdate()
        {
            if(Velocity.x < 0) { IsFaceRight= true; }
            else if (Velocity.x < 0) { IsFaceRight = false; }
        }
    }
}
