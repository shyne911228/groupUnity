using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator an;
    private Collider2D co;
    public Transform left,right;
    private bool face=true;
    public float Speed,jumpforce;
    public LayerMask ground;
    public float leftf,rightf;
 



    void Start()
    {
        an=GetComponent<Animator>();
        //base.Start();
        rb=GetComponent<Rigidbody2D>();
        co=GetComponent<Collider2D>();
        leftf=left.position.x; //防止左標點及右標點跟隨目標移動
        rightf=right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
        /*
        transform.DetachChildren();
      
        */       
    }
    
    
    void Update()
    {
        swichan();
    }
    
    void move()
    {
        if(face)
        {
            if(co.IsTouchingLayers(ground))
            {
                rb.velocity=new Vector2(-Speed,jumpforce);
                an.SetBool("jump",true);
            }
            
            if(transform.position.x<leftf)//轉向
            {
                transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,1);
                face=false;
            }
        }
        else
        {
            if(co.IsTouchingLayers(ground))
            {
                rb.velocity=new Vector2(Speed,jumpforce);
                an.SetBool("jump",true);
            }
            
            if(transform.position.x>rightf)//轉向
            {
                transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,1);
                face=true;
            }
        }
    }

    
    void swichan()
    {
        if(an.GetBool("jump"))
        {
            if(rb.velocity.y<0.1)
            {
                an.SetBool("jump",false);
                an.SetBool("down",true);
            }
        }
        if(co.IsTouchingLayers(ground) && an.GetBool("down"))
        {
            an.SetBool("down",false);
        }
    }
    
    
}
