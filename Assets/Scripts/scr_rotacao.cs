using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_rotacao : MonoBehaviour {

    public Transform navio;

	// Use this for initialization
	void Start () {
        navio = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,-navio.rotation.z,transform.rotation.w);
	}
}
