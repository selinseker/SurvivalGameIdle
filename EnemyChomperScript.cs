using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChomperScript : MonoBehaviour
{
    public bool NearChomper = false;

    Animator ChomperAnim;

    Transform player;

    public float health;
    public float damage;


    void Start()
    {
        ChomperAnim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }


    void Update()
    {
        Vector3 direction = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChomperAnim.SetBool("NearChomper", true);
            player.GetComponent<PlayerEllenManager>().GetDamage(damage);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChomperAnim.SetBool("NearChomper", false);
        }
    }


}


    

