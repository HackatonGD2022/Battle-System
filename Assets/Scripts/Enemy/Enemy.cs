using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private GameObject teleportPoint;

    private Stats stats;

    public Stats Stats
    {
        get { return stats; }
    }

    public GameObject getTeleportPoint()
    {
        return teleportPoint;
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
