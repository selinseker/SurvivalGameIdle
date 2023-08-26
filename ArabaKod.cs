using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArabaKod : MonoBehaviour
{
    private Vector3 initialPosition;
    public float MoveSpeed = 5f;
    public float MoveDistance = 10f;
    private bool MovingRight = true;
    
    void Start()
    {
        initialPosition = transform.position;
    }

    
    void Update()
    {
        if (MovingRight)
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);

        }

        if (Vector3.Distance(transform.position, initialPosition) >= MoveDistance)
        {
            MovingRight = !MovingRight;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }



}
