using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidSpawn : MonoBehaviour
{
    public GameObject acidPrefab;
    public float respawnTime;
    public float min;
    public float max;
    Boss boss;
    public bool acidgo = true;
    float nextAcid = 0f;
    public float acidRate;
    public float waveRate;
    



    public void acidWave()
{
        var wanted = Random.Range(min, max);
        var position = new Vector3(wanted, transform.position.y);
        
            nextAcid = Time.time + acidRate;
            GameObject go = Instantiate(acidPrefab, position, Quaternion.identity);
        
        




        
    }

}
