using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item
{

    public override void Use(GameObject entity)
    {
        Enemy en = entity.GetComponent<Enemy>();
        en.Stats.TakeDamage(2);
    }

    // Start is called before the first frame update
    void Start()
    {
        title = "Топор";
        desc = "Просто топор :)";
        color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
