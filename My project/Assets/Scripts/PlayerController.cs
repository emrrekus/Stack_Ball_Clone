using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    bool impact;
    float currenTime;
    bool invincible;

    public GameObject fireShield;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            impact = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            impact = false;
        }
        if (invincible)
        {
            currenTime -= Time.deltaTime * 0.35f;
            if (fireShield.activeInHierarchy)
            {
                fireShield.SetActive(false);
            }
        }
        else
        {
            if (fireShield.activeInHierarchy)
            {
                fireShield.SetActive(true);
            }
            if (impact)
            {
                currenTime += Time.deltaTime * 0.8f;
            }
            else
            {
                currenTime -= Time.deltaTime * 0.5f;
            }

        }

        if (currenTime >= 1)
        {
            currenTime = 1;
            invincible = true;
            Debug.Log("invicible");
        }
        else if (currenTime <= 0)
        {
            currenTime = 0;
            invincible = false;
            Debug.Log("---");
            
        }
    }
    private void FixedUpdate()
    {
        if (impact)
        {

            playerRb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 7, 0);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!impact)
        {

            playerRb.velocity = new Vector3(0, 50 * Time.fixedDeltaTime * 5, 0);


        }
        else
        {
            if (invincible)
            {
                if (collision.gameObject.tag == "enemy"&& collision.gameObject.tag =="plane")
                {
                    collision.transform.parent.gameObject.SetActive(false);
                }
                
            }
            else
            {
                if (collision.gameObject.tag == "enemy")
                {
                    collision.transform.parent.gameObject.SetActive(false);
                }
                else if (collision.gameObject.tag == "plane")
                {
                    Debug.Log("GameOver");
                }

            }
           

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!impact)
        {

            playerRb.velocity = new Vector3(0, 50 * Time.fixedDeltaTime * 5, 0);


        }

    }


}
