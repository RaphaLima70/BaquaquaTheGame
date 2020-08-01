using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camera : MonoBehaviour
{

    public Transform playerTransform;
    private float x;
    public float suavizacao;

    public bool isFase2;

    void FixedUpdate()
    {
        x = playerTransform.position.x;

        if (playerTransform != null)
        {
            //transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, new Vector3(x+5, transform.position.y, transform.position.z), suavizacao);
        }

        if (isFase2)
        {
            if (playerTransform != null)
            {
                //transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, new Vector3(x, playerTransform.position.y+1, transform.position.z), suavizacao);
            }
        }
        else
        {
            if (playerTransform != null)
            {
                //transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, new Vector3(x + 5, transform.position.y, transform.position.z), suavizacao);
            }
        }


    }
}
