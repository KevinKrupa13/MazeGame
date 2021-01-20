using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime;

    // Start is called before the first frame update
    private void Start()
    {       
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }
}
