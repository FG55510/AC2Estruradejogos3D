using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    void Start()
    {
     animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerSad()
    {
        animator.SetBool("Sad", true);

        animator.SetBool("Sad", false);
    }

    public void PlayerDead()
    {
        animator.SetTrigger("Death");
    }
}
