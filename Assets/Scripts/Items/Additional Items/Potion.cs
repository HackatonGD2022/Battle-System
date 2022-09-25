using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    public override void Use(GameObject entity)
    {
        Player player = entity.GetComponent<Player>();
        if (player.Stats.Health <= 6)
            player.Stats.Health += 4;
        else
            player.Stats.Health = 10;

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        title = "Ведьмено зелье";
        desc = "Обычное зелье, как и в любом рпг";
        color = Color.magenta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
