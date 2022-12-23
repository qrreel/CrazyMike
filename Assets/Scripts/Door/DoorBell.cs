using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBell : MonoBehaviour
{
    public bool isRinging = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Box")
            || collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            isRinging = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Box")
            || collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            isRinging = false;
    }
}
