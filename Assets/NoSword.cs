using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSword : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim.SetBool("HasSword", false);
    }
}
