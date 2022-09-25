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

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void Show()
    {
        uiInventory.SetActive(true);
        uiItemName.text = "";
        uiItemDesc.text = "";
    }

    public void Hide()
    {
        uiInventory.SetActive(false);
    }

    public bool IsActive()
    {
        return uiInventory.activeSelf;
    }

    public void UseItem()
    {
        if(selectedItem)
            selectedItem.Use();
    }

    public void DropItem()
    {
        Destroy(selectedItem);
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
