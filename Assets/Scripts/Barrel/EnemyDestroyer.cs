using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField]
    private EnemyDetector detector;

    public void Bang()
    {
        foreach (GameObject enemy in detector.enemyList)
        {
            Destroy(enemy);
        }
        Destroy(gameObject);
    }
}
