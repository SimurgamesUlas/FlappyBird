using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    

    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        Destroy(gameObject,lifeTime);
    
    }
}
