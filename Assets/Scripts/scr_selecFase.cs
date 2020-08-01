using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_selecFase : MonoBehaviour
{

    public int faseAtual;

    public GameObject[] botoes;
    /*
     btn 0 = fase2off
     btn 1 = fase2On
     btn 2 = fase3off
     btn 3 = fase3On
     btn 4 = fase4off
     btn 5 = fase4On
     
     */

    void Start()
    {
        if (!PlayerPrefs.HasKey("faseAtual"))
        {
            PlayerPrefs.SetInt("faseAtual", 1);
            faseAtual = 1;
        }
        else
        {
            faseAtual = PlayerPrefs.GetInt("faseAtual");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            faseAtual = 4;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            faseAtual = 1;
            PlayerPrefs.SetInt("faseAtual", 1);
        }

        switch (faseAtual)
        {
            case 1:
                Limpar();
                botoes[0].SetActive(true);
                botoes[2].SetActive(true);
                botoes[4].SetActive(true);
                break;
            case 2:
                Limpar();
                botoes[1].SetActive(true);
                botoes[2].SetActive(true);
                botoes[4].SetActive(true);
                break;
            case 3:
                Limpar();
                botoes[1].SetActive(true);
                botoes[3].SetActive(true);
                botoes[4].SetActive(true);
                break;
            case 4:
                Limpar();
                botoes[1].SetActive(true);
                botoes[3].SetActive(true);
                botoes[5].SetActive(true);
                break;
        }
    }

    public void Limpar()
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            botoes[i].SetActive(false);
        }
    }
}
