using UnityEngine;

public class DisableEnemyfollow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Creature"))
        {
            Enemyfollow enemyfollow = other.GetComponent<Enemyfollow>();
            if (enemyfollow != null)
            {
                enemyfollow.enabled = false;
            }
        }
    }
}