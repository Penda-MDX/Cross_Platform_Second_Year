using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float damagePerFrame;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("I hit a " + collision.gameObject.name);
        collision.gameObject.SendMessage("Damage", damagePerFrame, SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I hit a " + collision.gameObject.name);
        collision.gameObject.SendMessage("Damage", damagePerFrame, SendMessageOptions.DontRequireReceiver);
    }
}
