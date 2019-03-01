using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    public Transform player;
    public int dist;
    public Transform lava;
    public float speedRotation;
    public float speedMove;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) < dist)
        {
            Vector3 Rotation = player.position - lava.position;
            lava.rotation = Quaternion.Slerp(lava.rotation, Quaternion.LookRotation(Rotation), speedRotation * Time.deltaTime);
            lava.transform.position += lava.forward * speedMove * Time.deltaTime;
        }
	}
}
