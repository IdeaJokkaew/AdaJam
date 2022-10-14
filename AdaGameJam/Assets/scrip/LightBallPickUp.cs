using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBallPickUp : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    LightBall LightBall;
    public int speed;
    public float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        LightBall = FindObjectOfType<LightBall>();
        Rigidbody2D.AddForce(LightBall.shootPoint.transform.up * speed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
