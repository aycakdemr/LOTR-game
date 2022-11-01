using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //private AudioClip clipToPlay;
    //private AudioSource audioSource;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private GameObject arogon;
    private Monster monster;
    private int playerHealthAmount = 1;
    //--------------------------------------
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    private Movement move;
    [SerializeField] private AudioClip clipToPlay;
    //private GameManager gameManager;
    /*public AudioClip GetClipToPlay
    {
        get
        {
            return clipToPlay;
        }
        set
        {
            clipToPlay = value;
        }
    }*/

    public Transform GetFireTransform
    {
        get
        {
            return fireTransform;
        }
        set
        {
            fireTransform = value;
        }
    }

    private void Awake()
    {
        monster = FindObjectOfType<Monster>();
        //audioSource = GetComponent<AudioSource>();
        //gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Arogon")
        {
            
            monster.GetAnim.SetBool("isAttack",true);
            Fire();
            AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
        }
        else
        {
            monster.GetAnim.SetBool("isAttack", false);
        }
    }
    public void Fire()
    {

        float difference = 360f - transform.eulerAngles.y;
        float targetRotation = 90f;
        print(targetRotation);
        if (difference >= 90f)
        {
            targetRotation = -90f;
        }
        else if (difference < 90f)
        {
            targetRotation = 90f;
        }
        //audioSource.PlayOneShot(clipToPlay);
         GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(-targetRotation, 0f, 0f));
         bulletClone.GetComponent<SwordEffect>().owner = gameObject;
    }



}
