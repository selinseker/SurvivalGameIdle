using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTop : MonoBehaviour
{
    private float MoveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(-HorizontalInput, 0f, -VerticalInput);
        rb.velocity = Movement * MoveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mermi"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

}
