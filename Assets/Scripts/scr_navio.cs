using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_navio : MonoBehaviour
{

    public float minRate;
    public float maxRate;
    public float tempoAtual = 0;

    public bool giraDir = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        tempoAtual -= Time.deltaTime;

        if (tempoAtual <= 0)
        {
            if (giraDir)
            {
                if (transform.rotation.z <= 4)
                {
                    transform.Rotate(0, 0, Time.deltaTime);
                }
                else
                {
                    giraDir = false;
                    tempoAtual = Random.Range(minRate, maxRate);
                }
            }
            else
            {
                if (transform.rotation.z >= -4)
                {
                    transform.Rotate(0, 0, -Time.deltaTime);
                }
                else
                {
                    giraDir = true;
                    tempoAtual = Random.Range(minRate, maxRate);
                }
            }            
        }
    }
}
