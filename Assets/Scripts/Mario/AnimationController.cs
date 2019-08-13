using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //Components
    Animator anim;
    MovementController Player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Player = GetComponent<MovementController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Horizontal", Mathf.Abs(Player.horizontalMove));
        anim.SetFloat("Run", Player.run);
        anim.SetBool("IsGrounded", Player.IsGrounded());
        if (Input.GetButtonDown("Attack"))
        {
            anim.SetTrigger("Fire");
        }
    }
    
}
