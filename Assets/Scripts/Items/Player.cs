using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private Stats stats;

    private Inventory inventory;

    private FightMenu fightMenu;

    [SerializeField]
    private GameObject moveCircle;

    public Stats Stats
    {
        get { return stats; }
    }

    public GameObject MoveCircle
    {
        get { return moveCircle; }
    }

    public void AddItem(Item item)
    {
        inventory.AddItem(item);
        fightMenu.SetMessage("Добавлено: " + item.ToString());
    }

    public void StopWalk()
    {
        playerMovement.StopWalk();
    }

    public void StartWalk()
    {
        playerMovement.StartWalk();
    }

    public void ShowFightMenu()
    {
        fightMenu.ShowFightMenu();
    }

    public void HideFightMenu()
    {
        fightMenu.HideFightMenu();
    }

    public void ShowInventory()
    {
        inventory.Show();
    }

    public void HideInventory()
    {
        inventory.Hide();
    }

    public void SetMessage(string text)
    {
        fightMenu.SetMessage(text);
    }

    public void Move(Vector3 point)
    {
        playerMovement.MovePlayer(point);
    }

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        playerMovement = GetComponent<PlayerMovement>();
        fightMenu = GetComponent<FightMenu>();
        inventory = GetComponent<Inventory>();
        HideFightMenu();
        HideInventory();
        MoveCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(!inventory.IsActive())
            {
                StopWalk();
                ShowInventory();
            }
            else
            {
                StartWalk();
                HideInventory();
            }
        }
    }

    private void FixedUpdate()
    {
    }
}
