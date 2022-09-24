using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI uiHealthText;

    [SerializeField]
    private Slider uiHealth;

    [SerializeField]
    private TMPro.TextMeshProUGUI uiMessage;

    [SerializeField]
    private GameObject fightMenu;

    private Stats stats;

    private LinkedList<Item> items = new LinkedList<Item>();

    public void AddItem(Item item)
    {
        SetMessage("Добавлено: " + item.ToString());
        items.AddLast(item);
    }

    public void ShowFightMenu()
    {
        fightMenu.SetActive(true);
    }

    public void HideFightMenu()
    {
        fightMenu.SetActive(false);
    }

    public void SetMessage(string text)
    {
        uiMessage.text = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        uiHealthText.text = stats.Health.ToString();
        uiHealth.maxValue = stats.Health;
        uiHealth.value = stats.Health;
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
        uiHealth.value = stats.Health;
        uiHealthText.text = stats.Health.ToString();
    }

    private void PrintAllItems()
    {
        foreach(Item item in items)
        {
            Debug.Log(item);
        }
    }
}
