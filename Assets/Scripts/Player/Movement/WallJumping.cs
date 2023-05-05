using System.Collections;
using UnityEngine;

public class WallJumping : MonoBehaviour
{
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform frontCheck;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float wallSlidingSpeed;
    [SerializeField] private Vector2 wallJumpDirection;
    [SerializeField] private float wallJumpForce;

    private Rigidbody2D rb;
    private GameObject player;
    private Moving moveScript;

    private bool IsGrounded;
    private bool isTouchingFront;


    [HideInInspector] public bool wallSliding;
    public GameObject playerAxis;

    private void Start()
    {
        frontCheck = GameObject.Find("FrontCheck").transform;
        feetPos = GameObject.Find("FeetPos").transform;
        rb = GetComponentInChildren<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        groundLayer = LayerMask.GetMask("Ground");
        moveScript = GetComponent<Moving>();
    }


    void Update()
    {

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, wallLayer);

        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);

        if (isTouchingFront && !IsGrounded && rb.velocity.y < 0)
        {
            wallSliding = true;
            player.GetComponent<Animator>().SetBool("IsSliding", true);
        }
        else
        {
            wallSliding = false;
            player.GetComponent<Animator>().SetBool("IsSliding", false);
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));


        }

        if ((UserInput.instance.playerController.InGame.Jump.triggered) && wallSliding)
        {
            if (moveScript.canMove)
            {
                float forceX = playerAxis.transform.rotation.y == 0 ? -wallJumpForce * wallJumpDirection.x : wallJumpForce * wallJumpDirection.x;
                Vector2 force = new Vector2(forceX, wallJumpForce * wallJumpDirection.y);


                rb.velocity = Vector2.zero;

                rb.AddForce(force, ForceMode2D.Impulse);

                StartCoroutine("stopMove");
            }
        }
    }
    IEnumerator stopMove()
    {
        moveScript.canMove = false;

        Quaternion back = player.transform.rotation;

        if (playerAxis.transform.rotation.y == 0)
        {
            player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (playerAxis.transform.rotation.y == 1 || playerAxis.transform.rotation.y == -1)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        yield return new WaitForSeconds(0.3f);

        moveScript.canMove = true;
    }
}
