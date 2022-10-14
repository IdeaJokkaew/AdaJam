using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class charactermovement : MonoBehaviour
{

    public int moveSpeed;
    Rigidbody2D Rigidbody2D;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //Movement
        float inputX = Input.GetAxis("Horizontal")* moveSpeed * Time.fixedDeltaTime;
        float inputy = Input.GetAxis("Vertical")* moveSpeed * Time.fixedDeltaTime;

        Rigidbody2D.velocity = new Vector2 (inputX, inputy);

        float magSpeed = Mathf.Clamp01(Rigidbody2D.velocity.magnitude);

        animator.SetFloat("speed", magSpeed);
        Debug.Log(magSpeed);


        //Flip Character
        if(Rigidbody2D.velocity.x > 0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else if(Rigidbody2D.velocity.x < 0)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
    }
}
