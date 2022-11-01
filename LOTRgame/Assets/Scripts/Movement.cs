using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpPower = 130f;
    [SerializeField] float turnSpeed = 15f;
    [SerializeField] private Transform[] rayStartPoints;
    private Animator anim;
    private bool isJumping;
    private bool canJump;
    private bool isgrounded;
    private int jumpCount = 0;
    private Target target;
    [SerializeField] private AudioClip clipToPlay;
    public Animator GetAnim
    {
        get
        {
            return anim;
        }
    }
    private void Awake()
    {
        target = GetComponent<Target>();
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(target.GetHealth <= 0)
        {
          //  anim.SetBool("isDying", true);
        }
        AnimGroundCheck();
        TakeInput();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isgrounded = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "cone")
        {
            target.GetHealth -= 1;
            AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.name == "Ground")
        {
            isgrounded = false;
        }
    }

    private void TakeInput()
    {
      
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, Mathf.Clamp((-speed) * 10000 * Time.deltaTime, -15f, 0f));
            //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -179.99f, 0f), turnSpeed * Time.deltaTime);
            anim.SetBool("isMoving", true);
            //anim.SetBool("isFalling", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, Mathf.Clamp((speed) * 10000 * Time.deltaTime, 0f, 15f));
            //transform.rotation = Quaternion.Euler(0f, -360f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 359.99f, 0f), turnSpeed * Time.deltaTime);
            anim.SetBool("isMoving", true);
            //anim.SetBool("isFalling", false);
        }
        else
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 0f);
            // anim.SetBool("isFalling", true);
        }
        if (jumpCount > 0 && !isgrounded)
        {
            Jump();
        }
        if (isgrounded)
        {
            Jump();        
        }   
        else
        {
            anim.SetBool("isFalling", true);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = new Vector3(0f, Mathf.Clamp((jumpPower) * 50 * Time.deltaTime, 0f, 15f), 0f);
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
            jumpCount++;
        }
    }
    private void AnimGroundCheck()
    {
        if (isgrounded)
        {
            anim.SetBool("isGrounded", true);
            anim.SetBool("isMoving", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }
    }
    //private bool OnGroundCheck()
    //{

    //    bool hit = false;
    //    for (int i = 0; i < rayStartPoints.Length; i++)
    //    {
    //        hit = Physics.Raycast(rayStartPoints[i].position, rayStartPoints[i].transform.up, 0.50f);
    //        Debug.DrawRay(rayStartPoints[i].position, -rayStartPoints[i].transform.up * 100 * 0.50f, Color.red);
    //    }

    //    if (hit)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }

    //    // return Physics.CheckSphere(rayStartPoints[0].transform.position, 0.1f);

    //}

}
