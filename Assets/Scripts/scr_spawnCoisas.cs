using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_spawnCoisas : MonoBehaviour {

    public GameObject[] objetos;
    public float tempoMin;
    public float tempoMax;
    public float spawnRate;

    Vector3 pos;

	void Start () {
        spawnRate = Random.Range(tempoMin, tempoMax);
    }
	
	// Update is called once per frame
	void Update () {

        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        spawnRate -= Time.deltaTime;
        if (spawnRate <= 0)
        {
            spawnRate = Random.Range(tempoMin, tempoMax);
            Instantiate(objetos[Random.Range(0, objetos.Length)],pos, Quaternion.identity);
        }

	}
}
