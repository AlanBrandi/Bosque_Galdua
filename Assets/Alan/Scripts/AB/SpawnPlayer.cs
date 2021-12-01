using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject Player;
    private void Awake()
    {
        Instantiate(Player, this.transform.position, Quaternion.identity);
    }
}
