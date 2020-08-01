using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_fase2 : MonoBehaviour {

    public Image lifeBar;
    public float vida = 100;

    scr_gerenciador gerenLink;

    void Start()
    {
        gerenLink = GameObject.FindObjectOfType<scr_gerenciador>().GetComponent<scr_gerenciador>();
    }

    void Update () {
        vida -= Time.deltaTime*2.5f;
        if (vida <= 0)
        {
            gerenLink.Lose();
        }
        if (vida > 100)
        {
            vida = 100;
        }
        lifeBar.fillAmount = vida / 100;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pao")
        {
            vida += 25;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "inimigoFase2")
        {
            vida -= 15;
            Destroy(collision.gameObject);
        }
    }
}
