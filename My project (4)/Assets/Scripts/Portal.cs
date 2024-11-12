using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int livrosnecessarios;
    [SerializeField] private int livrospegos;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.INSTANCE.Playerpegoulivro.AddListener(AtivarPortal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AtivarPortal(int quantidade)
    {
        livrospegos = livrospegos + quantidade;
        if (livrospegos >= livrosnecessarios)
        {
            
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.Playerpegoulivro.RemoveListener(AtivarPortal);
    }
}
