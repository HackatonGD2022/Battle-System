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
        USE
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
        player.StopWalk();

        player.ShowFightMenu();

        state = State.ATTACK;

        selectedEnemy = enemyList[0];
        selectedEnemy.GetComponent<Light>().enabled = true;

        SetQueue();
        player.SetMessage("����� ��������");
        player.Stats.ResetPoints();
    }

    public void SetQueue()
    {
        moveQueue.Enqueue(player.gameObject);
        foreach (Enemy enemy in enemyList)
        {
            if (enemy.GetType() == typeof(FightObject))
                continue;
            moveQueue.Enqueue(enemy.gameObject);
        }    
        playerTurn = true;
    }

    private void Attack(Stats objOne, Stats objTwo)
    {
        if (objOne.ActionPoints < 1)
            return;

        objOne.ActionPoints -= 1;

        int takeDamage = Random.Range(0, 100);

        switch (Random.Range(0, 5))
        {
            // ����, ����
            case 0:
                if (takeDamage >= 20)
                {
                    objTwo.TakeDamage(1);
                    player.SetMessage("��������� �� �����������");
                } else
                {
                    player.SetMessage("������ �� �����������");
                }
                break;

            // ������
            case 1:
                if (takeDamage >= 95)
                {
                    objTwo.TakeDamage(1);
                    player.SetMessage("��������� � ������");
                } else {
                    player.SetMessage("������ �� ������");
                }
                break;

            // ����
            case 2:
                if (takeDamage >= 30)
                {
                    objTwo.TakeDamage(1);
                    player.SetMessage("��������� � ��������");
                } else
                {
                    player.SetMessage("������ �� ��������");
                }
                break;

            // ������
            case 3:
                if (takeDamage >= 50)
                {
                    objTwo.TakeDamage(1);
                    player.SetMessage("��������� �� ������");
                } else
                {
                    player.SetMessage("������ �� ������");
                }
                break;

            default:
                player.SetMessage("������");
                break;

        }

    }

    private bool ChangeState(State newState)
    {
        switch(state)
        {
            case State.ATTACK:
                if (newState == State.ATTACK)
                    return false;
                // TODO: clear selection;
                break;

            case State.MOVE:
                if (newState == State.MOVE)
                    return false;
                player.MoveCircle.SetActive(false);
                break;

            case State.INVENTORY:
                player.HideInventory();
                if (newState == State.INVENTORY)
                {
                    state = State.ATTACK;
                    return false;
                }
                break;

            case State.USE:
                if (newState == State.USE)
                    return false;
                player.HideConfirmButton();
                break;
        }

        switch (newState)
        {
            case State.ATTACK:
                state = State.ATTACK;
                break;

            case State.MOVE:
                state = State.MOVE;
                player.MoveCircle.SetActive(true);
                break;

            case State.INVENTORY:
                state = State.INVENTORY;
                player.ShowInventory();
                break;

            case State.USE:
                state = State.USE;
                player.HideInventory();
                player.ShowConfirmButton();
                break;
        }

        return true;
    }

    public void KillAll()
    {
        foreach(Enemy enemy in enemyList)
        {
            enemy.OnDeath(this);
            Destroy(enemy.gameObject);
        }
        enemyList.Clear();
    }

    public void ClickUse()
    {
        ChangeState(State.USE);
    }

    public void ConfirmUse()
    {
        if (player.Stats.ActionPoints >= 2)
        {
            player.Stats.ActionPoints -= 2;
            Item item = player.GetSelectedItem();

            if(item.GetType() == typeof(Potion))
            {
                item.Use(player.gameObject);
                return;
            }

            item.Use(selectedEnemy.gameObject);

            if (selectedEnemy.Stats.IsDied())
            {
                enemyList.Remove(selectedEnemy);
                selectedEnemy.OnDeath(this);
                Destroy(selectedEnemy.gameObject);
            }
        }
        else
            player.SetMessage("������������ ����� ��������");

    }

    public void ClickFight()
    {
        if (ChangeState(State.ATTACK))
            return;

        if(player.Stats.ActionPoints < 1)
        {
            player.SetMessage("������������ ����� ��������");
            return;
        }

        Attack(player.Stats, selectedEnemy.Stats);

        if(selectedEnemy.Stats.IsDied())
        {
            enemyList.Remove(selectedEnemy);
            selectedEnemy.OnDeath(this);
            Destroy(selectedEnemy.gameObject);
        }
    }

    public void ClickMove()
    {
        ChangeState(State.MOVE);
    }

    public void ClickInventory()
    {
        ChangeState(State.INVENTORY);
    }

    public void FinishTurn()
    {
        GameObject gameObject = moveQueue.Dequeue();

        if (gameObject == null)
            return;

        moveQueue.Enqueue(gameObject);
        if(!playerTurn)
        {
            if (gameObject.GetComponent<Player>())
            {
                playerTurn = true;
                player.Stats.ResetPoints();
            }
            else
            {
                selectedEnemy = gameObject.GetComponent<Enemy>();
                //selectedEnemy.GetComponent<Light>().enabled = true;
                selectedEnemy.Stats.ResetPoints();
            }
        }
        else
        {
            playerTurn = false;
            ChangeState(State.ATTACK);
            // Disable selection light of enemy.
            selectedEnemy.GetComponent<Light>().enabled = false;
            selectedEnemy = null;
        }
    }

    private bool HasAliveEnemy()
    {
        var isSomeoneAlive = false;
        foreach (Enemy enemy in enemyList)
        {
            if (enemy.GetType() == typeof(FightObject))
                continue;
            isSomeoneAlive = true;
        }
        return isSomeoneAlive;
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
                case State.USE:
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
                                        if(selectedEnemy)
                                            selectedEnemy.GetComponent<Light>().enabled = false;
                                        selectedEnemy = enemy;
                                        selectedEnemy.GetComponent<Light>().enabled = true;
                                    }
                                }
                            }
                        }

                    }
                    break;

                case State.MOVE:
                    if (Input.GetMouseButtonDown(0))
                    {
                        RaycastHit hitInfo = new RaycastHit();
                        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                        if (hit)
                        {
                            if (hitInfo.transform.gameObject == player.MoveCircle)
                            {
                                if (player.Stats.ActionPoints > 1)
                                {
                                    player.Stats.ActionPoints -= 1;
                                    player.Move(hitInfo.point);
                                }
                                else
                                    player.SetMessage("������������ ����� ��������");
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
                //selectedEnemy.GetComponent<Light>().enabled = true;
                Attack(selectedEnemy.GetComponent<Stats>(), player.GetComponent<Stats>());
                if(player.Stats.IsDied())
                    player.SetMessage("������� ��������");

                //selectedEnemy.GetComponent<Light>().enabled = false;
            }
            FinishTurn();
        }

        if (!HasAliveEnemy())
        {
            player.SetMessage("����� �������");
            StopFight();
        }
    }

    private void StopFight()
    {
        ChangeState(State.ATTACK);
        player.StartWalk();
        player.HideFightMenu();
    }
}
