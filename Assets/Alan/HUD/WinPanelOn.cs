using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelOn : MonoBehaviour
{
    public GameObject WinPanel;
    public IsBlueInside isBlueInside;
    public IsGreenInside isGreenInside;
    public IsRedInside isRedInside;
    public List<GameObject> HUDPanels;

    private void Update()
    {
        if(isBlueInside.blueinside == true && isGreenInside.greeninside == true && isRedInside.redinside == true)
        {
           foreach (GameObject Panels in HUDPanels)
           {
                Panels.SetActive(false);
           }
           WinPanel.SetActive(true);
        }
    }
}
