using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private Stats stats;

    private LinkedList<Item> items = new LinkedList<Item>();

    private FightMenu fightMenu;

    public Stats Stats
    {
        get { return stats; }
    }

    public void AddItem(Item item)
    {
        items.AddLast(item);
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

    public void SetMessage(string text)
    {
        fightMenu.SetMessage(text);
    }


    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        playerMovement = GetComponent<PlayerMovement>();
        fightMenu = GetComponent<FightMenu>();
        HideFightMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PrintAllItems();
        }
    }

    private void FixedUpdate()
    {
    }

    private void PrintAllItems()
    {
        foreach(Item item in items)
        {
            Debug.Log(item);
        }
    }
}
