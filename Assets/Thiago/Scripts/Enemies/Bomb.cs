using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bomb : MonoBehaviour
{
    public float splashRange;
    public GameObject mole;
    public GameObject target;
    public float Speed;

    private Vector2 playerStartPosition;
    private float targetX;
    private float moleX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    private bool canDestroyy;
    private Vector3 moveDirection;

    private float offset = 0.5f;
    public bool hasArrived = false;

    public GameObject explosionEffect;

    public float maxSpeed;
    public float minSpeed;
    public float maxDistance;

    private Poison poison;
    private void Start()
    {
        mole = GameObject.FindGameObjectWithTag("Enemies");
        target = GameObject.FindGameObjectWithTag("Player");
        poison = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<Poison>();
        playerStartPosition = target.transform.position;
        canDestroyy = false;
        hasArrived = GetComponent<Bomb>().hasArrived = false;
        StartCoroutine(canDestroy());
    }

    private void Update()
    {
        if (!hasArrived)
        {
            moleX = mole.transform.position.x;
            targetX = playerStartPosition.x;

            dist = targetX - moleX;
            nextX = Mathf.MoveTowards(transform.position.x, targetX, Speed * Time.deltaTime);
            float distToTarget = Vector3.Distance(playerStartPosition, mole.transform.position);
            Speed = Mathf.Lerp(minSpeed, maxSpeed, distToTarget / maxDistance);


            baseY = Mathf.Lerp(mole.transform.position.y, playerStartPosition.y, (nextX - moleX) / dist);
            height = 2 * (nextX - moleX) * (nextX - targetX) / (-0.25f * dist * dist);

            Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
            transform.position = movePosition;

            
        }
        
        if (Vector3.Distance(transform.position, playerStartPosition) < 0.1f)
        {
            hasArrived = GetComponent<Bomb>().hasArrived = true;
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(explosionEffect, target.transform.position, Quaternion.identity);
            poison.isPoison = true;
            Destroy(gameObject);
        }
    }

    IEnumerator canDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        canDestroyy = true;
    }

}