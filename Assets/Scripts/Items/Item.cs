using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    protected string title;
    protected string desc;
    protected Color color;

    [SerializeField]
    private GameObject item;

    public Color GetColor()
    {
        return color;
    }

    public virtual string GetTitle()
    {
        if(title == null)
            return item.name;
        return title;
    }

    public virtual string GetDesc()
    {
        if (desc == null)
            return "";
        return desc;
    }

    public virtual void Use(GameObject entity)
    {

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
