using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Die : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color newColor = new Color(0.3f, 0.4f, 0.6f, 0.5f);

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Fade()
    {
        spriteRenderer.color = newColor;
    }

    void DestroyItem()
    {
        Destroy(gameObject);
    }
}
