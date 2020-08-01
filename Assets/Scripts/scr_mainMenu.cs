using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_mainMenu : MonoBehaviour
{

    public GameObject[] paineis;

    public Animator fadeAnim;

    public GameObject gira;

    public bool histOn = false;
    [SerializeField]
    private int contaPag;

    public AudioSource musicaMenu;
    public AudioSource musicaHist;
    public AudioSource somBtn;
    public AudioSource somPag;



    public GameObject muteSpr;
    public GameObject unMuteSpr;

    public bool mutado;

    /*
     1- abertura
     2- main menu
     3- creditos
     4- referencias
     5- h1
     6- h2
     7- h3
     8- h4
     9- h5
     10- h6
     11- load
     12- selecFase
         */

    private void Start()
    {
        Time.timeScale = 1;
        Limpar();
        StartCoroutine(fadar(1));
        contaPag = 4;
    }

    private void Update()
    {
        gira.transform.Rotate(0, 0, -10);

        if (paineis[4].activeInHierarchy)
        {
            histOn = true;
        }

        if (histOn)
        {
            musicaMenu.Stop();
            if (!musicaHist.isPlaying)
            {
                musicaHist.Play();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (contaPag != 4)
                {
                    contaPag--;
                    abrirMenu(contaPag);
                    somPag.Play();
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (contaPag != 9)
                {
                    contaPag++;
                    abrirMenu(contaPag);
                    somPag.Play();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                histOn = false;
                abrirMenu(1);
                contaPag = 4;
            }
        }
        else
        {
            if (!musicaMenu.isPlaying)
            {
                musicaMenu.Play();
            }
            musicaHist.Stop();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Mutar();
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

    public void abrirMenu(int num)
    {
        StartCoroutine(fadar(num));
        somBtn.Play();
    }

    public void abrirFase(string nome)
    {
        StartCoroutine(carregaFase(nome));
        somBtn.Play();
    }

    public void Limpar()
    {
        for (int i = 0; i < paineis.Length; i++)
        {
            paineis[i].SetActive(false);
        }
    }

    IEnumerator fadar(int num)
    {
        fadeAnim.gameObject.SetActive(true);
        fadeAnim.SetBool("isFading", true);
        yield return new WaitForSeconds(2);
        Limpar();
        paineis[num].SetActive(true);
        fadeAnim.SetBool("isFading", false);
        yield return new WaitForSeconds(1.3f);
        fadeAnim.gameObject.SetActive(false);
    }

    IEnumerator carregaFase(string nome)
    {
        fadeAnim.gameObject.SetActive(true);
        fadeAnim.SetBool("isFading", true);
        yield return new WaitForSeconds(2);
        Limpar();
        paineis[10].SetActive(true);
        fadeAnim.SetBool("isFading", false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(nome);
    }


    public void QuitGame()
    {
        Application.Quit();
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

}

