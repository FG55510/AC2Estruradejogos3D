using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estante : MonoBehaviour
{
    public int livrosnecessarios;
    [SerializeField] private int livrospegos;
    public GameObject transicao;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.INSTANCE.Playerpegoulivro.AddListener(Liberacaminho);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Liberacaminho(int quantidade)
    {
        livrospegos = livrospegos + quantidade;
        if(livrospegos >= livrosnecessarios)
        {
            transicao.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.Playerpegoulivro.RemoveListener(Liberacaminho);
    }

}
