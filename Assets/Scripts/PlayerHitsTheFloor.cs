﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerHitsTheFloor : MonoBehaviour
{
    public GameObject player;
    public GameObject ship;

    public GameObject Lives3;
    public GameObject Lives2;
    public GameObject Lives1;

    private float curHealth;
    private GameObject healthbar;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            ship.GetComponent<Transform>().position = new Vector2(-5.27f, -4.27f);
            var rotationVector = player.transform.rotation.eulerAngles;
            rotationVector.z = 12.107f;
            player.transform.rotation = Quaternion.Euler(rotationVector);
            player.GetComponent<Transform>().position = new Vector3(-5.594f, -3.958f);
            Debug.Log("Player killed himself");
            HealthLose();
        }
    }
    void HealthLose()
    {
        healthbar = GameObject.Find("Player").GetComponent<HealthBar>().healthbar;
        Vector3 Coords = new Vector3(1f, healthbar.transform.localScale.y, healthbar.transform.localScale.z);

        if (Lives3.activeSelf)
        {
            GameObject.Find("Player").GetComponent<HealthBar>().curHealth = 100f;
            healthbar.transform.localScale = Coords;
            Lives3.SetActive(false);
            Lives2.SetActive(true);
        }
        else if (Lives2.activeSelf)
        {
            GameObject.Find("Player").GetComponent<HealthBar>().curHealth = 100f;
            healthbar.transform.localScale = Coords;
            Lives2.SetActive(false);
            Lives1.SetActive(true);
        }
        else if (Lives1.activeSelf)
        {
            GameObject.Find("Player").GetComponent<HealthBar>().curHealth = 100f;
            healthbar.transform.localScale = Coords;
            Lives1.SetActive(false);
        }
        else if (Lives1.activeSelf == false)
        {
            Debug.Log("Game Over");
        }
    }
}
