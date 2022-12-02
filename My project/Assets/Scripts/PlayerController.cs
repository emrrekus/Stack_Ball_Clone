using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    bool impact;

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

    private void OnCollisionStay(Collision collision)
    {
        if (!impact)
        {

            playerRb.velocity = new Vector3(0, 50 * Time.fixedDeltaTime * 5, 0);


        }
        
    }


}
