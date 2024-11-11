using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager INSTANCE;
    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
    }
    #endregion


   public UnityEvent<int> Playerpegoulivro;

    public UnityEvent PlayerResetou;

    public UnityEvent PlayerDeath;

    public UnityEvent PlayerPegouCristal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
