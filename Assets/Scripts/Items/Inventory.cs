using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    private Item selectedItem;

    [SerializeField]
    private GameObject uiInventory;

    [SerializeField]
    private TMPro.TextMeshProUGUI uiItemName;

    [SerializeField]
    private TMPro.TextMeshProUGUI uiItemDesc;

    [SerializeField]
    private Cells cells;

    public void AddItem(Item item)
    {
        items.Add(item);
        cells.AddItem(item);
    }

    public void Show()
    {
        uiInventory.SetActive(true);
        uiItemName.text = "";
        uiItemDesc.text = "";
        cells.ShowItems();
    }

    public void Hide()
    {
        uiInventory.SetActive(false);
        cells.Hide();
    }

    public bool IsActive()
    {
        return uiInventory.activeSelf;
    }

    public Item GetSelectedItem()
    {
        return selectedItem;
    }

    public void DropItem()
    {
        Destroy(selectedItem);
    }

    public void SelectItem(Item item)
    {
        selectedItem = item;
        uiItemName.text = item.GetTitle();
        uiItemDesc.text = item.GetDesc();
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
