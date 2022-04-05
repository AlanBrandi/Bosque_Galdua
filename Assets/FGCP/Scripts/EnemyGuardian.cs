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
    GameObject player;
    public EnumEnemyState state;
    bool transitionHappening = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
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
        playerDistance = Vector2.Distance(transform.position, player.transform.position);
        switch (state)
        {
            case EnumEnemyState.PATROL:
                if (playerDistance < aggroRange && PathUtilities.IsPathPossible(node1, node2) == true && transitionHappening == false)
                {
                    ChangeState(EnumEnemyState.SEEKER);
                }
                break;
            case EnumEnemyState.SEEKER:
                if (playerDistance > aggroRange * 4 && transitionHappening == false || PathUtilities.IsPathPossible(node1, node2) == false && transitionHappening == false)
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
                Invoke(nameof(TransitionDone), 1.1f);
                break;
            case EnumEnemyState.SEEKER:
                animator.SetTrigger("Pursuit");
                Invoke(nameof(TransitionDone), 1.1f);
                break;
        }
        transitionHappening = true;
        state = newState;
    }

    void TransitionDone()
    {
        if (state == EnumEnemyState.PATROL)
        {
            animator.SetTrigger("Patrol");
            patrol.enabled = true;
        }
        else if (state == EnumEnemyState.SEEKER)
        {
            animator.SetTrigger("Pursuit");
            seeker.enabled = true;
            InvokeRepeating(nameof(UpdatePath), 0, 1f);
        }
        transitionHappening = false;
    }
}

