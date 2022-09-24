using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private int movePoints;

    [SerializeField]
    private int actionPoints;

    [SerializeField]
    private int attack;

    [SerializeField]
    private int block;

    [SerializeField]
    private float evasion;

    [SerializeField]
    private float counterattack;

    private bool died = false;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int MovePoints
    {
        get { return MovePoints; }
        set { movePoints = value; }
    }

    public int ActionPoints
    {
        get { return actionPoints; }
        set { actionPoints = value; }
    }

    public bool IsDied()
    {
        return died;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
            died = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
