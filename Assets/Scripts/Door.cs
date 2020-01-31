using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D closeCollider, openCollider;
    public bool isFirstChange = false;
    public bool isOpen = false;

    public void SetOpen()
    {
        isFirstChange = true;
        isOpen = !isOpen;
        anim.SetBool("isOpen", isOpen);
        anim.SetBool("isFirstChange", isFirstChange);
        closeCollider.enabled = !isOpen;
        openCollider.enabled = isOpen;
    }


    private void OnMouseDown()
    {
        SetOpen();
    }
}
