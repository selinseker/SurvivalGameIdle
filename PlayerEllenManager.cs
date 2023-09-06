using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEllenManager : MonoBehaviour
{

    public float health;
    public float TotalCoin;
    public float coinValue;

    Quaternion rotation = Quaternion.Euler(0f, 180f, 0f);

    public Transform floatingText;

    bool dead = false;

    public Slider slider;
    public Slider sliderCoin;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;

        sliderCoin.maxValue = 100f;
        sliderCoin.value = TotalCoin; 
    }

    
    void Update()
    {
        
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();

    }

    void AmIDead()
    {
        if (health <= 0)
        {
            dead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Coin"))
        {
            Instantiate(floatingText, transform.position, rotation).GetComponent<TextMesh>().text = "+" + coinValue.ToString();
            TotalCoin += coinValue;
        }
        sliderCoin.value = TotalCoin;
    }

}
