using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Stats stats;

    public Stats Stats
    {
        get { return stats; }
    }

    public virtual void OnDeath(Fight fight)
    {

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
