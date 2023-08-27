using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform bileşeni

    public Vector3 offset = new Vector3(0f, 5f, -10f); // Kamera ile oyuncu arasındaki mesafe

    public float smoothSpeed = 0.5f; // Kamera takip hızı

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(player);
    }
    

   
}
