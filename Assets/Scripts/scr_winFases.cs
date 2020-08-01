using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_winFases : MonoBehaviour {

    scr_player playerLink;
    scr_gerenciador gerenLink;

    void Start()
    {
        playerLink = GameObject.FindObjectOfType<scr_player>().GetComponent<scr_player>();
        gerenLink = GameObject.FindObjectOfType<scr_gerenciador>().GetComponent<scr_gerenciador>();
    }

    void Update()
    {
        if (playerLink.finalizou)
        {
            gerenLink.Win();
        }
    }
}
