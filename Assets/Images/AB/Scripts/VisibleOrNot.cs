using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleOrNot : MonoBehaviour
{
    public VisibleOrNot myGO;
    //SpriteRenderer MySprite;
    void Start()
    {
       // MySprite = this.GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            myGO.enabled = false;
        }
    }
}
