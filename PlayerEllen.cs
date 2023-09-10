using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTop : MonoBehaviour
{
    public float ileriHiz =11.0f; 
    public float yanHiz = 9.0f;   
    
    private Rigidbody rb;
    public float damage = 10f;

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

        Vector3 movement = new Vector3(-horizontalInput * yanHiz, 0.0f, -ileriHiz);

        rb.velocity = movement;

        if ( movement!= Vector3.zero)
        {
            playerAnimator.SetBool("PlayerSpeed", true);
        }
        else
        {
            playerAnimator.SetBool("PlayerSpeed", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mermi"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameObject.GetComponent<PlayerEllenManager>().GetDamage(damage);
        }

    }

}
