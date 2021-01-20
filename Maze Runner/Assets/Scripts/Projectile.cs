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

    // Start is called before the first frame update
    private void Start()
    {       
        GameObject go = GameObject.Find("Player");
        PlayerMove playerMove = go.GetComponent<PlayerMove>();
        change = playerMove.finalChange;

        myRigidBody = GetComponent<Rigidbody2D>();
        Invoke("DestroyProjectile", lifeTime);

        
    }

    // Update is called once per frame
    private void Update()
    {
        myRigidBody.MovePosition(
            transform.position + change * projSpeed * Time.deltaTime
        );
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }
}
