using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren<Image>();
        Debug.Log(image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
