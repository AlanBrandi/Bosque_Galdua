using UnityEngine;

public class InteractibleItens : MonoBehaviour
{

    private bool playerIsNear = false;

    [HideInInspector] public Animator anim;

    public bool isAnchor;

    public bool isSail;

    public bool isRudder;

    [HideInInspector] public bool stopPlayer = false;

  

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}
