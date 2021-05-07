using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody rb;
    Instanciador manager;
    private new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.manager = GameObject.FindObjectOfType<Instanciador>();
        this.audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0)
            {
                transform.position += new Vector3(0.01f, 0, 0);
            }
            else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
            {
                transform.position += new Vector3(0, 0, -0.01f);
            }
            else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
            {
                transform.position += new Vector3(0, 0, 0.01f);
            }
            else if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") < 0)
            {
                transform.position += new Vector3(-0.01f, 0, 0);
            }
            if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                if (!this.audio.isPlaying)
                    this.audio.Play();
            }
            if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
                this.audio.Stop();
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
        {
            GameObject.FindObjectOfType<AudioManager>().PlayDeathSound();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("point"))
        {
            GameObject.FindObjectOfType<AudioManager>().PlayPointSound();
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

    public void modifyVolume(float volumen)
    {
        this.audio.volume = volumen;
    }

}
