using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject ammo;
    private Transform fireTransform;
    private float fireRate = 0.5f;
    private int ammoCount = 30;
    private float currentFireRate = 0f;
    private int maxAmmo = 30;
    private Movement move;
    [SerializeField] private AudioClip clipToPlay;
    private Target target;
    [SerializeField] private bool isPlayer = false;
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
    public float GetCurrentFireRate
    {
        get
        {
            return currentFireRate;
        }
        set
        {
            currentFireRate = value;
        }
    }
    public int GetAmmo
    {
        get
        {
            return ammoCount;
        }
        set
        {
            ammoCount = value;
            if (ammoCount > maxAmmo)
            {
                ammoCount = maxAmmo;
            }
        }
    }
    public int GetClipSize
    {
        get
        {
            return maxAmmo;
        }
        set
        {
            maxAmmo = value;
        }
    }
    public float getFireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }
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
    // Start is called before the first frame update
    private void Awake()
    {
        target = FindObjectOfType<Target>();
        move = GetComponent<Movement>();
        //audioSource = GetComponent<AudioSource>();
        //gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireRate > 0f)
        {
            currentFireRate -= Time.deltaTime;
        }
        PlayerInput();

    }

    private void PlayerInput()
    {
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentFireRate <= 0f && ammoCount > 0)
                {
                    move.GetAnim.SetBool("isAttack", true);
                    Fire();
                    //FindObjectOfType<Target>().GetHealth -= 1;
                }
            }
            else
            {
                move.GetAnim.SetBool("isAttack", false);
            }

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
        ammoCount--;
        currentFireRate = fireRate;
        AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
        GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(targetRotation, 0f, 0f));
        bulletClone.GetComponent<SwordEffect>().owner = gameObject;
    }
}
