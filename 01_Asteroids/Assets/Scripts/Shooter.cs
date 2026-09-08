using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{

    [SerializeField] private Transform projectilePrefab;


    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Vector3 newPosition = transform.position;
            Instantiate(projectilePrefab, newPosition, transform.rotation);
        }
    }

}
