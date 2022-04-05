using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public enum EnumEnemyState
{
    PATROL,
    SEEKER,
}

public class EnemyGuardian : MonoBehaviour
{
    AIDestinationSetter aiDS;
    Animator animator;
    PointPatrol patrol;
    AIPath seeker;
    public float aggroRange = 5;
    float playerDistance;
    public Transform player;
    public EnumEnemyState state;
    bool animIsDone = false;

    private void Start()
    {
        aiDS = GetComponent<AIDestinationSetter>();
        patrol = GetComponent<PointPatrol>();
        seeker = GetComponent<AIPath>();
        animator = GetComponentInChildren<Animator>();
        state = EnumEnemyState.PATROL;
    }

    private void Update()
    {
        GraphNode node1 = AstarPath.active.GetNearest(this.transform.position).node;
        GraphNode node2 = AstarPath.active.GetNearest(aiDS.target.position, NNConstraint.Default).node;
        playerDistance = Vector2.Distance(transform.position, player.position);
        switch (state)
        {
            case EnumEnemyState.PATROL:
                if (playerDistance < aggroRange && PathUtilities.IsPathPossible(node1, node2) == true)
                {
                    ChangeState(EnumEnemyState.SEEKER);
                }
                break;
            case EnumEnemyState.SEEKER:
                if (playerDistance > aggroRange * 4 || PathUtilities.IsPathPossible(node1, node2) == false)
                {
                    ChangeState(EnumEnemyState.PATROL);
                }
                break;
        }
    }

    void UpdatePath()
    {
        AstarPath.active.Scan();
    }

    void ChangeState(EnumEnemyState newState)
    {
        CancelInvoke(nameof(UpdatePath));
        patrol.enabled = false;
        seeker.enabled = false;
        switch(newState)
        {
            case EnumEnemyState.PATROL:
                animator.SetTrigger("Patrol");
                Invoke(nameof(TransitionDone), 1f);
                break;
            case EnumEnemyState.SEEKER:
                animator.SetTrigger("Pursuit");
                Invoke(nameof(TransitionDone), 1f);
                break;
        }
        state = newState;
    }

    void TransitionDone()
    {
        if (state == EnumEnemyState.PATROL)
        {
            patrol.enabled = true;
            animator.SetTrigger("Patrol");
        }
        else if (state == EnumEnemyState.SEEKER)
        {
            seeker.enabled = true;
            animator.SetTrigger("Pursuit");
            InvokeRepeating(nameof(UpdatePath), 0, 1f);
        }
    }
}

