using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public float lifeTime;
    public float projSpeed;
    private Vector3 change;
    private Rigidbody2D myRigidBody;
    private bool active;

    // Start is called before the first frame update
    private void Start()
    {       
        GameObject go = GameObject.Find("Player");
        PlayerMove playerMove = go.GetComponent<PlayerMove>();
        change = playerMove.finalChange;

        active = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        Invoke("DestroyProjectile", lifeTime);

        
    }

    // Update is called once per frame
    private void Update()
    {
        myRigidBody.MovePosition(
            transform.position + change.normalized * projSpeed * Time.deltaTime
        );
    }

    void DestroyProjectile() {
        if (active == true) {
            Destroy(gameObject);
            active = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Border" && active == true) {
            DestroyProjectile();
            active = false;
        }

    }
}
