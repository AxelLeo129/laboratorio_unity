using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical : MonoBehaviour

{
    [SerializeField] private float amplitud = 3;
    [SerializeField] private float velocidad = 2;
    [SerializeField] private bool direccion = true;
    private Vector3 posicion;

    // Start is called before the first frame update
    void Start()
    {
        this.posicion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.direccion)
            transform.position = this.posicion + new Vector3(this.amplitud * Mathf.Sin(Time.time * velocidad), 0, 0);
        else
            transform.position = this.posicion + new Vector3(-(this.amplitud * Mathf.Sin(Time.time * velocidad)), 0, 0);
    }
}
