using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private List<IBuff> buffs;
    // Start is called before the first frame update
    void Start()
    {
        buffs = new List<IBuff>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=buffs.Count-1;i>=0;i--)
        {
            buffs[i].Update(Time.deltaTime);
        }
    }

    public void AddBuff(IBuff buff)
    {
        buffs.Add(buff);
        buff.AssignManager(this);
        buff.Start();
    }

    public void RemoveBuff(IBuff buff)
    {
        buffs.Remove(buff);
    }
}
