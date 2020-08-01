using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_inicialization : MonoBehaviour {

    public GameObject[] paineis;

    public Animator fadeAnim;

    void Start()
    {
        StartCoroutine(iniciar());
    }

    public void Limpar()
    {
        for (int i = 0; i < paineis.Length; i++)
        {
            paineis[i].SetActive(false);
        }
    }

    IEnumerator iniciar()
    {
        fadeAnim.SetBool("isFading", true);
        yield return new WaitForSeconds(1);
        Limpar();
        paineis[0].SetActive(true);
        fadeAnim.SetBool("isFading",false);
        yield return new WaitForSeconds(3);
        fadeAnim.SetBool("isFading", true);
        yield return new WaitForSeconds(2);
        Limpar();
        paineis[1].SetActive(true);
        fadeAnim.SetBool("isFading", false);
        yield return new WaitForSeconds(4);
        fadeAnim.SetBool("isFading", true);
        yield return new WaitForSeconds(2);
        Limpar();
        paineis[2].SetActive(true);
        fadeAnim.SetBool("isFading", false);
        yield return new WaitForSeconds(1);
        fadeAnim.SetBool("isFading", true);
        SceneManager.LoadSceneAsync("MainMenu");
    }

}

