using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_player : MonoBehaviour
{

    //public Animator animacao;
    public float velocidade;
    public bool andando;
    public Rigidbody2D rigidbody;
    public float movimentoHorizontal;
    public bool olhandoDireita;
    public int forcaPulo;
    public bool finalizou;
    Animator animacao;
    public bool pulando;
    public float tempoPuloIni;
    public float tempoPuloAtual;

    float velocidadeIni;

    public bool noChao;

    public bool plataforma;

    SpriteRenderer sprite;
    CapsuleCollider2D colider;
    public GameObject particula;
    public scr_gerenciador gerenLink;

    AudioSource grito;

    void Start()
    {
        gerenLink = GameObject.FindObjectOfType<scr_gerenciador>().GetComponent<scr_gerenciador>();
        sprite = GetComponent<SpriteRenderer>();
        colider = GetComponent<CapsuleCollider2D>();

        grito = GetComponent<AudioSource>();

        velocidadeIni = velocidade;

        tempoPuloAtual = tempoPuloIni;
        pulando = false;
        finalizou = false;
        animacao = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        olhandoDireita = true;
    }

    void FixedUpdate()
    {
        if (plataforma)
        {
            movimentoHorizontal = Input.GetAxis("Horizontal");

            if (movimentoHorizontal > 0 && !olhandoDireita)
            {
                //olha pra direita
                GiraPerson();
            }
            if (movimentoHorizontal < 0 && olhandoDireita)
            {
                //olha pra esquerda
                GiraPerson();
            }

            if (movimentoHorizontal != 0)
            {
                rigidbody.velocity = new Vector2(movimentoHorizontal * velocidade, rigidbody.velocity.y);
                animacao.SetInteger("estado", 1);
            }

            else if (movimentoHorizontal == 0 && noChao)
            {
                animacao.SetInteger("estado", 0);
            }

            if (!noChao)
            {
                //animacao.SetInteger("estado", 2);
            }
        }
        else
        {
            animacao.SetInteger("estado", 1);
            rigidbody.velocity = new Vector2(velocidade, rigidbody.velocity.y);

        }
        
        if (Input.GetButton("Jump") && noChao)
        {
            rigidbody.AddForce(new Vector2(0, forcaPulo));
            pulando = true;
        }
        if (Input.GetButton("Jump") && pulando)
        {
            if (tempoPuloAtual > 0){
                rigidbody.AddForce(new Vector2(0, forcaPulo));
                tempoPuloAtual -= Time.deltaTime;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            tempoPuloAtual = tempoPuloIni;
            pulando = false;
        }
    }

    public void GiraPerson()
    {
        olhandoDireita = !olhandoDireita;
        Vector2 escalaNova = transform.localScale;
        escalaNova.x *= -1;
        transform.localScale = escalaNova;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "inimigo")
        {
            StartCoroutine(Morreu());
            //SceneManager.LoadSceneAsync(Application.loadedLevelName);
        }

        if (collision.gameObject.tag == "fim")
        {
            finalizou = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "barril")
        {
            velocidade = 0;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            noChao = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            noChao = false;
        }

        if (collision.gameObject.tag == "barril")
        {
            velocidade = velocidadeIni;
        }
    }

    IEnumerator Morreu()
    {
        grito.Play();
        sprite.enabled = false;
        colider.enabled = false;
        rigidbody.Sleep();
        velocidade = 0;
        Instantiate(particula,gameObject.transform);
        yield return new WaitForSeconds(2);
        gerenLink.Lose();
    }
}
