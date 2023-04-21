using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISkill
{
    public SkillManager Manager { get; private set; }

    public ISkillState State { get; set; }

    public float CoolTime { get; protected set; }

    /// <summary>
    /// This skill will ready in ReamainTime seconds. Using the method CoolDown(float deltaTime), rather than modify RemainTime directly!
    /// </summary>
    public float RemainTime { get; set; }

    /// <summary>
    /// Cooling down the skill deltaTime seconds. Using this method, rather than decrease RemainTime directly!
    /// </summary>
    /// <param name="deltaTime">the seconds to cool down skill</param>
    public void CoolDown(float deltaTime)
    {
        State.CoolDown(this, deltaTime);
    }

    public void Use()
    {
        State.Use(this);
    }

    public void AssignManager(SkillManager manager)
    {
        if (Manager == null)
        {
            State = new ReadyState();
            Manager = manager;
        }
    }

    public abstract void OnTrigger();

    public virtual void OnReady() { }

    public virtual bool IsUsable() { return true; }

}

public abstract class ISkillState
{
    public virtual void Use(ISkill skill) { }
    public virtual void CoolDown(ISkill skill, float deltaTime) { }
}

public class ReadyState: ISkillState
{
    public override void Use(ISkill skill)
    {
        if(skill.IsUsable())
        {
            skill.State = new CoolingState();
            skill.OnTrigger();
        }
    }
}

public class CoolingState:ISkillState
{
    public override void CoolDown(ISkill skill, float deltaTime)
    {
        skill.RemainTime -= deltaTime;
        if (skill.RemainTime <= 0)
        {
            skill.RemainTime = skill.CoolTime;
            skill.State = new ReadyState();
            skill.OnReady();
        }
    }
}