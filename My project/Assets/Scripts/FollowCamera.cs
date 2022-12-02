using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector3 _cameraPos;
    private Transform player, win;

    private float cameraOffset = 4f;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Start()
    {

    }


    void Update()
    {
        if (win == null)
        {
            win = GameObject.Find("win(Clone)").GetComponent<Transform>();

        }
        if (transform.position.y > player.position.y && transform.position.y > win.position.y + cameraOffset)
        {
            _cameraPos=new Vector3(transform.position.x,player.position.y,transform.position.z);
            transform.position=new Vector3(transform.position.x,_cameraPos.y,-5);

        }
    }
}
