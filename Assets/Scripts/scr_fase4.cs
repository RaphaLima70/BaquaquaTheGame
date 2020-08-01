using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_fase4 : MonoBehaviour
{

    public float tempoDePartida;
    public Text cronometroTxt;

    scr_player playerLink;
    scr_gerenciador gerenLink;

    void Start()
    {
        playerLink = GameObject.FindObjectOfType<scr_player>().GetComponent<scr_player>();
        gerenLink = GameObject.FindObjectOfType<scr_gerenciador>().GetComponent<scr_gerenciador>();
        tempoDePartida = 60;
    }

    void Update()
    {
        cronometroTxt.text = tempoDePartida.ToString("0");
        if (gerenLink.iniciou)
        {
            tempoDePartida -= Time.deltaTime;
        }
        if (playerLink.finalizou)
        {
            gerenLink.Win();
        }
        if (tempoDePartida <= 0)
        {
            gerenLink.Lose();
        }
    }
}
