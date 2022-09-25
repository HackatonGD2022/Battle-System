using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private string title;
    private string decs;

    [SerializeField]
    private GameObject item;

    public Color Color
    {
        get;
        set;
    }


    public virtual void Use()
    {

    }

    void Start()
    {
        Color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
