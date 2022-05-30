using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetOff : MonoBehaviour
{
    public List<GameObject> listGame;
    private void Start()
    {
        foreach (GameObject game in listGame)
        {
            game.SetActive(false);
        }
    }
}
