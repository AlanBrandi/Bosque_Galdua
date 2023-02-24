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

    //-------------------------------

    [SerializeField] GameObject redGen;
    [SerializeField] GameObject greenGen;
    [SerializeField] GameObject blueGen;
    [SerializeField] GameObject normalGate;
    [SerializeField] GameObject openingGate;
    [SerializeField] GameObject triggerGate;
    [SerializeField] PlayerPass playerPass;

    private void Start()
    {
        normalGate.SetActive(true);
    }
    private void Update()
    {
        if(isRedInside.redinside)
        {
            redGen.SetActive(true);
            //ativar sprite + fx com vermelho + sound
        }
        if (isGreenInside.greeninside)
        {
            greenGen.SetActive(true);
            //ativar sprite + fx com verde + sound
        }
        if (isBlueInside.blueinside)
        {
            blueGen.SetActive(true);
            //ativar sprite + fx com blue + sound
        }

        if (isBlueInside.blueinside == true && isGreenInside.greeninside == true && isRedInside.redinside == true)
        {
            normalGate.SetActive(false);
            if (playerPass.playerPassed)
            {
                PlayerPass();
            }
        }
    }

    void PlayerPass()
    {
        openingGate.SetActive(true);
        Invoke("ExitOn", 3);
    }
    void ExitOn()
    {
        triggerGate.SetActive(true);
    }
}
