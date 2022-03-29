using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D thisRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(change);
        //UpdateAnimationAndMove();
        UpdateAnimation();
        MoveCharacter();
    }


    ////void UpdateAnimationAndMove()
    ////{
    //    if (change != Vector3.zero)
    //    {
    //        MoveCharacter();
    //        animator.SetFloat("moveX", change.x);
    //        animator.SetFloat("moveY", change.y);
    //        animator.SetBool("moving", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("moving", false);
    //    }
    //}

    void UpdateAnimation()
    {
        if (change != Vector3.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        if (change != Vector3.zero){
            thisRigidbody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
        }
    }

    //void MoveCharacter()
    //{
    //    thisRigidbody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    //}
}
