using UnityEngine;

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
    }
}
