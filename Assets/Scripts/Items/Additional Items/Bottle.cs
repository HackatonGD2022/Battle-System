using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : Item
{


    public override void Use(GameObject entity) 
    {
        Enemy en = entity.GetComponent<Enemy>();
        en.Stats.TakeDamage(2);
    }
    // Start is called before the first frame update
    void Start()
    {
        title = "Бутыль с маслом";
        desc = "Можно бросить, чтобы поджечь врага";
        color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
