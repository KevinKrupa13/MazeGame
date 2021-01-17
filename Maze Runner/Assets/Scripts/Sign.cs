using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (inRage) {
            if (dialogBox.activeInHierarchy) {
                dialogBox.SetActive(false);
            }
            else {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D player) {
        
        if(player.CompareTag("Player")) {
            inRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D player) {
        
        if(player.CompareTag("Player")) {
            inRange = false;
            dialogBox.SetActive(false);
        }

    }
}
