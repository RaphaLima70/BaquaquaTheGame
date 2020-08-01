using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_doguinho : MonoBehaviour {

    
    public int velocidade; 	
	
	void Update () {
        transform.Translate(new Vector2(-velocidade * Time.deltaTime, 0));
	}

private void OnTriggerEnter2D(Collider2D collision)
{
  if(collision.gameObject.tag == "player")
    {
        Destroy(gameObject);
    }
}
}
