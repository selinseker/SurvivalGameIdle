using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTop : MonoBehaviour
{
    public float MoveSpeed = 2f;
    private Rigidbody rb;

    Animator playerAnimator;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {

      
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-horizontalInput, 0.0f, -verticalInput);

        rb.velocity = movement;

        if (movement != Vector3.zero)
        {
            
            Quaternion newRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.15f);

           
            playerAnimator.SetBool("PlayerSpeed", true);
        }
        else
        {
            playerAnimator.SetBool("PlayerSpeed", false);
        }

       
        transform.Translate(movement, Space.World);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mermi"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        
    }



}
