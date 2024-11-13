using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject todestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            NPC npc = other.GetComponent<NPC>();
            if (npc.final == true)
            {
                npc.Attack();
                Destroy(todestroy);
            }

            
        }
    }
}
