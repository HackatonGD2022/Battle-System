using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{

    [SerializeField]
    private Item item;

    [SerializeField]
    private Player player;

    private bool canTake;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player.gameObject)
        {
            canTake = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canTake = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canTake && Input.GetKeyDown(KeyCode.E))
        {
            player.AddItem(item);
            gameObject.SetActive(false);
        }
    }
}
