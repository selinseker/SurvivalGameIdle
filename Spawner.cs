using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    public GameObject MermiPrefab;
    public float SpawnInterval = 1f ;
    public float MermiSpeed = 15f ;

    private float TimeSinceLastSpawn = 0f;

    void Start()
    {
        
    }

    
    private void Update()
    {

        TimeSinceLastSpawn += Time.deltaTime;

        if (TimeSinceLastSpawn >= SpawnInterval)
        {

            SpawnMermi();
            Destroy(GameObject.FindGameObjectWithTag("Mermi"), 1.2f);

            TimeSinceLastSpawn = 0;
        }
       
    }

    private void SpawnMermi()
    {
        float randomAngle = Random.Range(-90f, 90f);
        Quaternion rotation = Quaternion.Euler(0f, randomAngle, 0f);
        Vector3 spawnDirection = rotation * transform.forward;


        GameObject Mermi = Instantiate(MermiPrefab, transform.position, rotation, transform);
        Rigidbody MermiRigidbody = Mermi.GetComponent<Rigidbody>();
        MermiRigidbody.velocity = spawnDirection * MermiSpeed;

    }
   

}
