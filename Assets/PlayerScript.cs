using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    private float movespeed = 5.0f;
    private float jumpspeed = 10.0f;
    private bool isBlock = true;
    private AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = rb.velocity;
        if (GoalScript.isGameClear == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                v.x = movespeed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                v.x = -movespeed;
            }
            else
            {
                v.x = 0f;
            }
            rb.velocity = v;
        }
    }
    void Update()
    {
        Vector3 v = rb.velocity;
        if (Input.GetKeyDown(KeyCode.Space)&&isBlock==true)
        {
            v.y = jumpspeed;
        }
        rb.velocity = v;
        //
        Vector3 rayPosition = transform.position;
        Ray ray = new Ray(rayPosition,Vector3.down);

        float distance = 0.6f;
        Debug.DrawRay(rayPosition,Vector3.down*distance,Color.red);

        isBlock = Physics.Raycast(ray,distance);

        if (isBlock == true)
        {
            Debug.DrawRay(rayPosition,Vector3.down*distance);
        }else
        {
            Debug.DrawRay(rayPosition,Vector3.down*distance,Color.yellow);
        }
    }

}
