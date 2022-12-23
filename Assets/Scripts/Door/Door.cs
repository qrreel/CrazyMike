using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Animator animator;
    static readonly int IsOpen = Animator.StringToHash("isOpen");

    public bool isOpen = false;

    DoorBell DoorBell;
    Pigs Pigs;

    void Awake()
    {
        DoorBell = FindObjectOfType<DoorBell>();
        Pigs = FindObjectOfType<Pigs>();
    }

    void Update()
    {
        animator.SetBool(IsOpen, isOpen);

        if (DoorBell.isRinging && Pigs.Enemies == 0) isOpen = true;
        else isOpen = false;
    }
}
