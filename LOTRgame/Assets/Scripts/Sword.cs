using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Attack attack;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private float fireRate;
    [SerializeField] private int clipSize; //max mermi
    //[SerializeField] private AudioClip clip;
    private int currentAmmoCount;
    public int GetCurrentWeaponAmmoCount
    {
        get
        {
            return currentAmmoCount;
        }
        set
        {
            currentAmmoCount = value;
        }
    }
    private void Awake()
    {
        currentAmmoCount = clipSize;
    }
    void Start()
    {

    }
    private void OnEnable()
    {
        if (attack != null)
        {
            attack.GetFireTransform = fireTransform;
            attack.GetClipSize = clipSize;
            attack.getFireRate = fireRate;
            attack.GetAmmo = currentAmmoCount;
            //attack.GetClipToPlay = clip;
        }
    }
}
