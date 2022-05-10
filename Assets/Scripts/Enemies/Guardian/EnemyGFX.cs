using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public PointPatrol pointPatrol;
    AudioSource audioSource;
    public float PointPosition;
    public bool facingRight = true;
    public Transform Player;
    public Transform EnemyGfxGO;
    public EnemyGuardian enemy;

    private void Start()
    {        
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (enemy.state == EnumEnemyState.SEEKER)
        {
            FlipsTowardsPoint();
        }
    }


    void PlaySound(float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.Play();
    }

    void Flip()
    {
        if (facingRight == true)
        {
            if (transform.rotation.y == 180)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            
            facingRight = false;
            pointPatrol.facingRight = false;

        }
        else if (facingRight == false)
        {
            if(transform.rotation.y == 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            
            facingRight = true;
            pointPatrol.facingRight = true;
        }

    }
    void FlipsTowardsPoint()
    {
        
        PointPosition = Player.position.x - EnemyGfxGO.position.x;
        if (PointPosition < 0 && facingRight == true)
        {
            Flip();
        }
        else if (PointPosition > 0 && facingRight == false)
        {
            Flip();
        }
    }
}
