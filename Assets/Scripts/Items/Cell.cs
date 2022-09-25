using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    private Item item;
    private Image image;

    public void SetItem(Item item)
    {
        if(image == null)
            image = GetComponentInChildren<Image>();
            
        this.item = item;
        image.color = item.GetColor();
    }

    public bool HasItem()
    {
        return item != null;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Inventory inv = player.GetComponent<Inventory>();
        inv.SelectItem(item);
    }
}
