using UnityEngine;

public class EnemyGFX : MonoBehaviour
{
    PointPatrol pointPatrol;
    AudioSource audioSource;
    float pointPosition;
    public bool facingRight = true;
    Transform player;
    EnemyGuardian enemy;

    private void Start()
    {
        pointPatrol = GetComponentInParent<PointPatrol>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponentInParent<EnemyGuardian>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (enemy.state == EnumEnemyState.SEEKER)
        {
            Flip('s');
        }
    }

    void PlaySound(float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.Play();
    }

    public void Flip(char mode)
    {
        if (mode == 's')
        {
            pointPosition = player.position.x - transform.position.x;
            if (pointPosition < 0 && facingRight == true || pointPosition > 0 && facingRight == false)
            {
                Flip('n');
            }
        }
        else if (mode == 'p')
        {
            pointPosition = pointPatrol.targetPosition.x - transform.position.x;
            if (pointPosition < 0 && facingRight)
            {
                Flip('n');
            }
            else if (pointPosition > 0 && !facingRight)
            {
                Flip('n');
            }
        }
        else if (facingRight == true)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }
        else if (facingRight == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
    }
}
