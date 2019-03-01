using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public int scoreAdd = 0;
    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerScript>().score += scoreAdd;
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collider.tag == "Light1" || collider.tag == "Light2")
        {
            GetComponent<ParticleSystem>().Pause();
        }
    }
}
