using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject pipePrefab;
    public float minY;
    public float maxY;
    public float x;
    public float interval;
    void Start()
    {
        InvokeRepeating("Spawn",interval,interval);    
    }

    private void Spawn(){
        GameObject instance = Instantiate(pipePrefab);
        instance.transform.position = new Vector2(x,Random.Range(minY,maxY));
        instance.transform.SetParent(transform);
        
    }
}
