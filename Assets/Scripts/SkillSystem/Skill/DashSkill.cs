using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : ISkill
{
    public DashSkill()
    {
        CoolTime = 0.75f;
    }
    public override void OnTrigger()
    {
        //Manager.BuffManager.AddBuff(new DashBuff());
    }

    public override bool IsUsable()
    {
        //if(Manager.GetComponent<PlayerController>().move==0)
        //{
        //    return false;
        //}
        //else
        //{
        //    return true;
        //}
        return true;
    }
}
