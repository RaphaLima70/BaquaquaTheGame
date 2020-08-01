using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_moeda : MonoBehaviour
{
    AudioSource som;
    scr_fase3 fase2Link;

    void Start()
    {
        som = GameObject.Find("SomMoeda").GetComponent<AudioSource>();
        fase2Link = GameObject.FindObjectOfType<scr_fase3>().GetComponent<scr_fase3>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fase2Link.moedaCount++;
            som.Play();
            Destroy(gameObject);
        }
    }
}
