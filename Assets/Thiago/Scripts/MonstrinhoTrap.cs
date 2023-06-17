using UnityEngine;
using System.Collections;

public class MonstrinhoTrap : MonoBehaviour
{
    public GameObject eyeCloser;
    public GameObject light1;
    public GameObject light2;
    private Animator anim;
    private Monstrinho monst;
    private Collider2D col;

    private void OnEnable()
    {
        EventManager.Instance.ActivatedMonstrinho += OnMonstrinhoActivated;
    }

    private void OnDisable()
    {
        EventManager.Instance.ActivatedMonstrinho -= OnMonstrinhoActivated;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        monst = GetComponent<Monstrinho>();
        col.enabled = false;
    }

    private void Update()
    {
        if (UserInput.instance.playerController.InGame.Debug_H.triggered)
        {
            Activate();
        }
    }

    private void Activate()
    {
        eyeCloser.SetActive(false);
        light1.SetActive(true);
        light2.SetActive(true);
        StartCoroutine(monstrinhoAttack());
    }

    private void OnMonstrinhoActivated(GameObject obj, bool activate)
    {
        // Verifique se o MonstrinhoTrap � o Monstrinho espec�fico relacionado ao inimigo ou � alavanca
        if (gameObject == obj)
        {
            if (activate)
            {
                Activate();
            }
            else
            {
                eyeCloser.SetActive(true);
                light1.SetActive(false);
                light2.SetActive(false);
                anim.enabled = false;
                monst.enabled = false;
            }
        }
    }

    IEnumerator monstrinhoAttack()
    {
        yield return new WaitForSeconds(.5f);
        col.enabled = true;
        anim.enabled = true;
        monst.enabled = true;
        
        
    }
    
}
