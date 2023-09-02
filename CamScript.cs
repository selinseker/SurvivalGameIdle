using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Transform player; 

    private Vector3 offset = new Vector3(0f, 4.5f, 8f); 
 

    void Start()
    {

    }

   
    void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = desiredPosition;
        transform.LookAt(player);
    }

}
