using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanDemo1 : MonoBehaviour
{
    private Animator animator;
    public Rigidbody rb;
    private float movespeed = 5.0f;
    private float jumpspeed = 8.0f;
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
        transform.rotation = Quaternion.Euler(0, 90, 0);
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = rb.velocity;
        float stick = Input.GetAxis("Horizontal");
        if (GoalScript.isGameClear == false)
        {
            if (Input.GetKey(KeyCode.RightArrow) || stick > 0)
            {
                v.x = movespeed;
                transform.rotation = Quaternion.Euler(0,90,0);
                animator.SetBool("is_running", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || stick < 0)
            {
                v.x = -movespeed;
                transform.rotation = Quaternion.Euler(0, -90, 0);
                animator.SetBool("is_running", true);
            }
            else
            {
                v.x = 0f;
                animator.SetBool("is_running", false);
            }
            rb.velocity = v;
        }

    }
    void Update()
    {
        Vector3 v = rb.velocity;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Jump")) && isBlock == true)
        {
            v.y = jumpspeed;
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }
        rb.velocity = v;
        //
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);
        float distance = 0.9f;
        Ray ray = new Ray(rayPosition, Vector3.down);

        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

        isBlock = Physics.Raycast(ray, distance);

        if (isBlock == true)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance);
        }
        else
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
        }
    }
}
