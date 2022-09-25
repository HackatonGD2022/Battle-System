using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightObject : Enemy
{
    public override void OnDeath(Fight fight)
    {
        fight.KillAll();
    }

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
