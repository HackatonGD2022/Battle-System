using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    enum State
    {
        ATTACK,
        INVENTORY,
        MOVE,
    };

    private Queue<GameObject> moveQueue = new Queue<GameObject>();

    private State state;

    private Player player;

    private List<Enemy> enemyList;

    private Enemy selectedEnemy;

    private bool playerTurn = false;

    public void SetEnemies(List<Enemy> enemies)
    {
        enemyList = enemies;
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void StartFight()
    {
        player.GetComponent<PlayerMovement>().StopPlayer();

        player.transform.position = enemyList[0].getTeleportPoint().transform.position;

        player.ShowFightMenu();

        state = State.ATTACK;

        selectedEnemy = enemyList[0];
        selectedEnemy.GetComponent<Light>().enabled = true;

        SetQueue();
    }

    public void SetQueue()
    {
        moveQueue.Enqueue(player.gameObject);
        foreach (Enemy enemy in enemyList)
            moveQueue.Enqueue(enemy.gameObject);
        playerTurn = true;
    }

    private void Attack(Stats objOne, Stats objTwo)
    {
        objOne.ActionPoints -= 1;

        int takeDamage = Random.Range(0, 100);

        switch (Random.Range(0, 5))
        {
            // ноги, руки
            case 0:
                if (takeDamage >= 20)
                    objTwo.TakeDamage(1);
                break;

            // сердце
            case 1:
                if (takeDamage >= 95)
                    objTwo.TakeDamage(2);
                break;

            // тело
            case 2:
                if (takeDamage >= 30)
                    objTwo.TakeDamage(1);
                break;

            // голова
            case 3:
                if (takeDamage >= 50)
                    objTwo.TakeDamage(1);
                break;

            default:
                // Промах
                break;

        }

    }

    public void ClickFight()
    {
        Attack(player.GetComponent<Stats>(), selectedEnemy.GetComponent<Stats>());
    }

    public void ClickMove()
    {
        state = State.MOVE;
    }

    public void ClickInventory()
    {
        state = State.INVENTORY;
    }

    public void FinishTurn()
    {
        GameObject gameObject = moveQueue.Dequeue();

        moveQueue.Enqueue(gameObject);
        if(!playerTurn)
        {
            if (gameObject.GetComponent<Player>())
            {
                playerTurn = true;
            }
            else
            {
                selectedEnemy = gameObject.GetComponent<Enemy>();
            }
        }
        else
        {
            playerTurn = false;
            selectedEnemy = null;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (playerTurn)
        {
            switch (state)
            {
                case State.ATTACK:
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            RaycastHit hitInfo = new RaycastHit();
                            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                            if (hit)
                            {
                                foreach (Enemy enemy in enemyList)
                                {
                                    Debug.Log("Hit " + hitInfo.transform);
                                    if (enemy == hitInfo.transform.gameObject.GetComponent<Enemy>())
                                    {
                                        Debug.Log("Hit " + hitInfo.transform);
                                        selectedEnemy.GetComponent<Light>().enabled = false;
                                        selectedEnemy = enemy;
                                        selectedEnemy.GetComponent<Light>().enabled = true;
                                    }
                                }
                            }
                        }

                    }
                    break;
            }
        }
    }
    void FixedUpdate()
    {
        if(!playerTurn)
        {
            if(selectedEnemy)
            {
                Attack(selectedEnemy.GetComponent<Stats>(), player.GetComponent<Stats>());
            }
            FinishTurn();
        }
    }
}
