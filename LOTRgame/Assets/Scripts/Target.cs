using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealth = 15;
    //[SerializeField] private GameObject hitFx;
    [SerializeField] private AudioClip clipToPlay;
    [SerializeField] private GameObject deadFx;
    [SerializeField] private int currentHealth = 15;
    public int GetHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
    public int GetMaxHealth
    {
        get
        {
            return maxHealth;
        }
    }
    private void Awake()
    {
       // print(currentHealth);
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (currentHealth == 0)
        {
            Die();
        }
    }
    /* private void OnTriggerEnter(Collider other)
     {

         SwordEffect playerbullet = other.gameObject.GetComponent<SwordEffect>();
         //print("fsfs" + bullet.name);
         if (playerbullet)
         {
             if (playerbullet)
             {

                 currentHealth--;
                 //AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
                 if (hitFx != null && currentHealth > 0)
                 {
                     Instantiate(hitFx, transform.position, Quaternion.identity);
                 }
                 if (currentHealth == 0)
                 {
                     print("girdi");
                     Die();
                 }

                 Destroy(other.gameObject);
             }

         }

     }*/
    private void Die()
    {
        if (deadFx != null)
        {
            Instantiate(deadFx, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
