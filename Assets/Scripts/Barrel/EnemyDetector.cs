using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public List<GameObject> enemyList;

    private void OnTriggerStay(Collider other)
    {
        if (!enemyList.Contains(other.gameObject))
        {
            enemyList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemyList.Remove(other.gameObject);
    }
}