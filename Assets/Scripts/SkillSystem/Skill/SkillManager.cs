using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private List<ISkill> skills;
    public BuffManager BuffManager { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        skills = new List<ISkill>();
        BuffManager = GetComponent<BuffManager>();
        AddSkill(new DashSkill());
    }

    // Update is called once per frame
    void Update()
    {
        foreach(ISkill skill in skills)
        {
            skill.CoolDown(Time.deltaTime);
        }
    }

    public void AddSkill(ISkill skill)
    {
        skill.AssignManager(this);
        skills.Add(skill);
    }

    public void OnDash()
    {
        skills[0].Use();
    }
}
