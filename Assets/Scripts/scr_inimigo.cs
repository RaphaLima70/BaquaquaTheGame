using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_inimigo : MonoBehaviour
{
    public int velocidade;
    public int morteTempo;

    void Start()
    {
        Destroy(gameObject, morteTempo);
    }

    void Update()
    {
        transform.Translate(new Vector2(-velocidade * Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "parede")
        {
            Destroy(gameObject);
        }

    }
}
