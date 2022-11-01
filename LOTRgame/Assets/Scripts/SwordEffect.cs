using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffect : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public GameObject owner;
    [SerializeField] private AudioClip clipToPlay;
    private void Awake()
    {

    }
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "wall" || other.gameObject.tag == "Player")  //merminin temas ettiði objede target scripti yok ise
        {
            Destroy(gameObject);
        }
        if (gameObject.tag == "bullet" && other.gameObject.tag == "Enemy")
        {
            if (other.gameObject != null)
            {
                other.gameObject.GetComponent<Target>().GetHealth -= 1;
            }
        }
        else if ( gameObject.tag == "enemysbullet" && other.gameObject.tag == "Player")
        {
            if (other.gameObject != null)
            {

                other.gameObject.GetComponent<Target>().GetHealth -= 1;
                AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
            }

        }
        
    }
}
