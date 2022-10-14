using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightBall : MonoBehaviour
{
    public GameObject lightBallPickUp, lightBallBoomerang;
    Rigidbody2D rd;
    public GameObject shootPoint;
    public GameObject shootPoinSide;
    public GameObject shootPointUp;
    public GameObject shootPointDown;
    bool canShootPickUp, canShootBoomerang;

    //Ball show with player
    public GameObject stand_BallPickUp, stand_BallBoomerang;


    float lightGaugeMin, lightGaugeMax;
    float fearGaugeMin, fearGaugeMax;

    int lightItemPickUpCount;

    // Start is called before the first frame update
    void Start()
    {
        //shootPointMidle.transfor = shootPoint.transform.position;
        rd = gameObject.GetComponent<Rigidbody2D>();
    }

    void shoot()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(rd.velocity.y < 0 && rd.velocity.x == 0)
        {
            shootPoint.transform.position = shootPointDown.transform.position;
            shootPoint.transform.rotation = shootPointDown.transform.rotation;

        }
        else if (rd.velocity.y > 0 && rd.velocity.x == 0)
        {
            shootPoint.transform.position = shootPointUp.transform.position;
            shootPoint.transform.rotation = shootPointUp.transform.rotation;

        }
        else if(rd.velocity.x < 0 || rd.velocity.x > 0)
        {
            shootPoint.transform.position = shootPoinSide.transform.position;
            shootPoint.transform.rotation = shootPointUp.transform.rotation;

        }


        if (lightGaugeMin <= 0 + 30)
        {
            StartCoroutine("autoPLightGauge");
        }

        if (lightGaugeMin >= lightGaugeMax - 30)
        {
            StartCoroutine("autoNLightGauge");
        }

        if(Input.GetButtonDown("Jump"))
        {
            lightLevel3();
        }
    }

    IEnumerator autoPLightGauge()
    {
        yield return new WaitForSeconds(0.5f);
        fearGaugeMin += 1;
        checkGauge();
    }

    IEnumerator autoNLightGauge()
    {
        yield return new WaitForSeconds(0.5f);
        fearGaugeMin -= 1;
        checkGauge();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Light")
        {
            //other.GetComponent<>();
        }   
    }

    void addlightGauge(int damage, bool isPositive)
    {
        if(isPositive)
        {
            lightGaugeMin += damage;
            checkGauge();
        }
        else
        {
            lightGaugeMin -= damage;
            checkGauge();
        }
    }

    void checkGauge()
    {
        if(lightGaugeMin > lightGaugeMax)
        {
            lightGaugeMin = lightGaugeMax;
        }
        if (lightGaugeMin < 0)
        {
            lightGaugeMin = 0;
        }

        if (fearGaugeMin > fearGaugeMax)
        {
            fearGaugeMin = fearGaugeMax;
        }
        if (fearGaugeMin < 0)
        {
            fearGaugeMin = 0;
        }
    }

    void lightLevel1()
    {
        
    }

    void lightLevel2()
    {

    }

    void lightLevel3()
    {
        stand_BallPickUp.SetActive(false);
        GameObject lightball = Instantiate(lightBallPickUp, shootPoint.transform.position, shootPoint.transform.rotation);
        if (lightball != null)
        {
            canShootPickUp = true;
            stand_BallPickUp.SetActive(true);
        }

    }

    void lightLevel4()
    {
        stand_BallBoomerang.SetActive(false);
        GameObject lightball = Instantiate(lightBallBoomerang, shootPoint.transform.position, shootPoint.transform.rotation);
        if(lightball != null)
        {
            canShootBoomerang = true;
            stand_BallBoomerang.SetActive(true);
        }
    }
}
