using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_somInimigo : MonoBehaviour {

    AudioSource som;
    public float rate;
    public float tempoAtual;

	void Start () {
        som = GetComponent<AudioSource>();
        tempoAtual = 0;
	}
	
	// Update is called once per frame
	void Update () {
        tempoAtual += Time.deltaTime;
        if (tempoAtual > rate)
        {
            som.Play();
            tempoAtual = 0;
        }
	}
   
}
