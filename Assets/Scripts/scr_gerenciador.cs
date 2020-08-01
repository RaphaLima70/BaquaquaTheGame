using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_gerenciador : MonoBehaviour
{

    public GameObject painelPause;

    public GameObject muteSpr;
    public GameObject unMuteSpr;

    public GameObject winPanel;
    public GameObject losePanel;

    public GameObject load;

    public GameObject PreGamePanel;

    public string proxFaseNome;

    public bool mutado;

    public bool pausado;

    public bool iniciou;

    public int faseAtual;

    private void Start()
    {
        iniciou = false;
        load.SetActive(false);
        Time.timeScale = 0;
        PreGamePanel.SetActive(true);
        painelPause.SetActive(false);
        muteSpr.SetActive(true);
        unMuteSpr.SetActive(false);
        pausado = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Mutar();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pausado)
            {
                Despausar();
            }
            else
            {
                Pausar();
            }
        }

        if (PlayerPrefs.GetString("mutado") == "mutado")
        {
            mutado = true;
            muteSpr.SetActive(false);
            unMuteSpr.SetActive(true);
        }
        else if (PlayerPrefs.GetString("mutado") == "desmutado")
        {
            mutado = false;
            muteSpr.SetActive(true);
            unMuteSpr.SetActive(false);
        }
    }

    public void Mutar()
    {
        mutado = !mutado;

        if (mutado)
        {
            PlayerPrefs.SetString("mutado", "mutado");
        }
        else
        {
            PlayerPrefs.SetString("mutado", "desmutado");
        }
    }

    public void Pausar()
    {
        pausado = true;
        Time.timeScale = 0;
        painelPause.SetActive(true);
    }

    public void Despausar()
    {
        pausado = false;
        Time.timeScale = 1;
        painelPause.SetActive(false);
    }

    public void Recomecar()
    {
        load.SetActive(true);
        SceneManager.LoadSceneAsync(Application.loadedLevel);
    }

    public void MainMenu()
    {
        load.SetActive(true);
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Win()
    {
        if (faseAtual !=4 && PlayerPrefs.GetInt("faseAtual") <= faseAtual)
        {
            PlayerPrefs.SetInt("faseAtual", faseAtual + 1);
        }
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    public void Lose()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void ProxFase()
    {
        load.SetActive(true);
        SceneManager.LoadSceneAsync(proxFaseNome);

    }

    public void Iniciar()
    {
        PreGamePanel.SetActive(false);
        Time.timeScale = 1;
        iniciou = true;
    }
}
