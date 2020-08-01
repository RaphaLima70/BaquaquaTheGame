using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_fase3 : MonoBehaviour {

    public int moedaCount;

    scr_player playerLink;
    scr_gerenciador gerenLink;

    void Start()
    {
        playerLink = GameObject.FindObjectOfType<scr_player>().GetComponent<scr_player>();
        gerenLink = GameObject.FindObjectOfType<scr_gerenciador>().GetComponent<scr_gerenciador>();
    }

    void Update () {
		if(moedaCount > 15 && playerLink.finalizou)
        {
            gerenLink.Win();
        }
        else if(moedaCount < 15 && playerLink.finalizou)
        {
            gerenLink.Lose();
        }
	}
}
