﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (inRange) {
            //if (dialogBox.activeInHierarchy) {
                //dialogBox.SetActive(false);
            //}
            //else {
                //dialogText.text = dialog;
                //dialogBox.SetActive(true);
            //}
        //}
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Player")) {
            Debug.Log("Player in range");
            //inRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if(other.CompareTag("Player")) {
            Debug.Log("Player out of range");
            //inRange = false;
            //dialogBox.SetActive(false);
        }

    }
}
