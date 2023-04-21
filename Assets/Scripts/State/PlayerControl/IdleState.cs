using System;
using UnityEngine;

namespace State.PlayerControl
{
    [Serializable]
    [CreateAssetMenu(fileName = "IdleState", menuName = "ScriptableObject/PlayerControl/State/Idle")]
    public class IdleState : State
    {
        public override void LogicUpdate()
        {
        }
    }
}
