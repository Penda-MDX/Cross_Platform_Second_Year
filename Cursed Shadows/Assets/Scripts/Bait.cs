using UnityEngine;

public class Bait : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Creature"))
        {
            LureCreature(other.GetComponent<Creature>());
            Destroy(gameObject); // Destroy the bait after luring
        }
    }

    private void LureCreature(Creature creature)
    {
        Debug.Log("Creature lured to Bait!");
        // Add lure behavior here (e.g., make the creature move towards the bait)
    }
}
