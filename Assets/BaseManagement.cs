using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseManagement : MonoBehaviour {

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip hitBase;

    // Use this for initialization
    void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease ;
        GetComponent<AudioSource>().PlayOneShot(hitBase);
        healthText.text = health.ToString();
        if (health <= 0)
        {
            print("Base is dead!");
        }
        
    }

 
	
	// Update is called once per frame
	void Update () {
		
	}
}
