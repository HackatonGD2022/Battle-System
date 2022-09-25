using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private Item item;
    private Image image;

    public void SetItem(Item item)
    {
        if(image == null)
        {
            image = GetComponentInChildren<Image>();
            Debug.Log(image);
        }
            
        this.item = item;
        image.color = item.Color;
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
}
