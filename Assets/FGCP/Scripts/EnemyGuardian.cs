using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnumEnemyState
{
    PATROL,
    IDLE,
    PURSUE
}

public class EnemyGuardian : MonoBehaviour
{
    Animator animator;
    PointPatrol patrol;
    Pursuit pursue;
    public float aggroRange = 5;
    float playerDistance;
    public Transform player;
    public EnumEnemyState state;

    private void Start()
    {
        patrol = GetComponent<PointPatrol>();
        pursue = GetComponent<Pursuit>();
        animator = GetComponent<Animator>();
        animator.SetTrigger("Patrol");
        state = EnumEnemyState.PATROL;
    }

    private void Update()
    {
        playerDistance = Vector2.Distance(transform.position, player.position);
        switch (state)
        {
            case EnumEnemyState.PATROL:
                if (playerDistance < aggroRange)
                {
                    ChangeState(EnumEnemyState.PURSUE);
                }
                break;
            case EnumEnemyState.PURSUE:
                if (playerDistance > aggroRange * 4)
                {
                    ChangeState(EnumEnemyState.PATROL);
                }
                break;
        }
    }

    void ChangeState(EnumEnemyState newState)
    {
        patrol.enabled = false;
        pursue.enabled = false;
        switch(newState)
        {
            case EnumEnemyState.PATROL:
                animator.SetBool("Patrol", true);
                patrol.enabled = true;
                break;
            case EnumEnemyState.PURSUE:
                animator.SetTrigger("Pursuit");
                pursue.enabled= true;
                break;
        }
        state = newState;
    }
}

