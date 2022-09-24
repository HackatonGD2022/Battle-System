using UnityEngine;

public class PlayerDetector : Collider
{
    public bool isAvailable = false;

    void OnCollisionEnter(Collision collision)
    {
        // TODO if collison.collider Player
        isAvailable = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isAvailable = false;
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
