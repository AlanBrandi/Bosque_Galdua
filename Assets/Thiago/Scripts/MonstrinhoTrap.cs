using UnityEngine;

public class MonstrinhoTrap : MonoBehaviour
{
    public GameObject eyeCloser;
    public GameObject light1;
    public GameObject light2;
    private Animator anim;
    private Monstrinho monst;

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
        monst = GetComponent<Monstrinho>();
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
        anim.enabled = true;
        monst.enabled = true;
    }

    private void OnMonstrinhoActivated(GameObject obj, bool activate)
    {
        // Verifique se o MonstrinhoTrap é o Monstrinho específico relacionado ao inimigo ou à alavanca
        if (gameObject == obj)
        {
            if (activate)
            {
                Activate();
            }
            else
            {
                // Desativar o MonstrinhoTrap
                eyeCloser.SetActive(true);
                light1.SetActive(false);
                light2.SetActive(false);
                anim.enabled = false;
                monst.enabled = false;
            }
        }
    }
}
