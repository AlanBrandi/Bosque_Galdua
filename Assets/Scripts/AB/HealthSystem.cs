using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    int life = 3;
    Transform MyGO_trns;
    public GameObject MyGO_GO;
    public GameObject head;
    public GameObject body;
    public GameObject Death_FX;
    public GameObject Death2_FX;
    public GameObject Hit_FX;

    private void Start()
    {
        MyGO_trns = GetComponent<Transform>();
        //MyGO_GO = GetComponent<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            print("atingido");
            life = life - 1;
            Instantiate(Hit_FX, new Vector3(MyGO_GO.transform.position.x + .3f , MyGO_GO.transform.position.y + 5.3f, MyGO_GO.transform.position.z), Quaternion.identity);
        }
    }
    private void Update()
    {
        if (life <= 0) 
        {
            Destroy(MyGO_GO.transform.gameObject);
            Instantiate(Death_FX, new Vector3(MyGO_GO.transform.position.x + .3f, MyGO_GO.transform.position.y + 5.3f, MyGO_GO.transform.position.z), Quaternion.identity);
            Instantiate(Death2_FX, new Vector3(MyGO_GO.transform.position.x + .3f, MyGO_GO.transform.position.y + 5.3f, MyGO_GO.transform.position.z), Quaternion.identity);
        }
    }
}
