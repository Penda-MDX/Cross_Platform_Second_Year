using UnityEngine;

public class ActivateWoodenCage : MonoBehaviour
{
    public GameObject woodenCage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            woodenCage.SetActive(true);
        }
    }
}
