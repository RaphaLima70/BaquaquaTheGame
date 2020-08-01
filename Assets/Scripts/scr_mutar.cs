using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_mutar : MonoBehaviour {
	
	void Update () {
        if (PlayerPrefs.GetString("mutado") == "mutado")
        {
            AudioListener.pause = true;
        }
        if (PlayerPrefs.GetString("mutado") == "desmutado")
        {
            AudioListener.pause = false;
        }
    }
}
