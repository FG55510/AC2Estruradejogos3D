using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fim : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.INSTANCE.FimdeJogo.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
