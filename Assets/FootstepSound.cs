using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    [SerializeField] AudioSource footstep;
    [SerializeField] AudioClip[] clips = new AudioClip[3];
    //[SerializeField] GameObject posCheck;
    LayerMask layerMask;
    private void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
    }
    public void PlayFootstepSound()
    {
        RaycastHit2D floorHit = Physics2D.Raycast(transform.position, -Vector2.up, 10, layerMask);
        Debug.DrawRay(transform.position, -Vector2.up *10, Color.red);
        //Debug.Log(floorHit.collider.tag);
        if (floorHit.collider != null)
        {
            switch (floorHit.collider.tag)
            {
                case "GrassGround":
                    footstep.clip = clips[0];
                    break;
                case "WoodGround":
                    int chance = Random.Range(0, 2);
                    if (chance == 0)
                    {
                        footstep.clip = clips[1];
                    }
                    else
                    {
                        footstep.clip = clips[2];
                    }
                    break;
            }
            float randomPitch = Random.Range(0.8f, 1.5f);
            footstep.pitch = randomPitch;
            footstep.Play();
        }
    }
}
