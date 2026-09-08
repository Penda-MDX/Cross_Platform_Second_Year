using Unity.VisualScripting;
using UnityEngine;

public class BornToDie : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }


}
