using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private List<Enemy> enemies;

    [SerializeField]
    private GameObject fightMenu;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player.gameObject)
        {
            StartFight();
        }
    }

    private void StartFight()
    {
        Fight f = fightMenu.GetComponent<Fight>();

        f.SetEnemies(enemies);
        f.SetPlayer(player);

        Debug.Log(f);

        f.StartFight();

        GetComponent<BoxCollider>().enabled = false;

        enabled = false;
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
