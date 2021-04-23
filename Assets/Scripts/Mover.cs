using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody rb;
    Instanciador manager;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.manager = GameObject.FindObjectOfType<Instanciador>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0.01f, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0, 0, -0.01f);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(0, 0, 0.01f);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(-0.01f, 0, 0);
            }
            if (Input.GetButtonDown("Jump"))
            {
                if (this.rb && Mathf.Abs(this.rb.velocity.y) < 0.05f)
                    rb.AddForce(0, 3, 0, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("obstacule") && this.manager.Score < 3)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("point"))
        {
            Destroy(other.gameObject);
            this.manager.Score++;
        }
    }

    private void FixedUpdate()
    {
        if(this.rb)
        {
            this.rb.AddForce(Input.GetAxis("Horizontal") * 0.7f, 0, Input.GetAxis("Vertical") * 0.7f);
        }
    }

}
