using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal : MonoBehaviour
{
    private Vector3 posicion;
    
    // Start is called before the first frame update
    void Start()
    {
        this.posicion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = this.posicion + new Vector3(0, 0, 2.5f * Mathf.Sin(Time.time * 2));
    }
}
