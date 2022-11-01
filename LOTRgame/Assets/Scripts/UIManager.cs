using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image HealthFill;
    public Image AmmoFill;

    private Attack playerAmmo;
    private Target playerHealth;

    private void Awake()
    {
        playerAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        playerHealth = playerAmmo.GetComponent<Target>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthFill();
        UpdateAmmoFill();
    }

    private void UpdateAmmoFill()
    {
        AmmoFill.fillAmount = (float)playerAmmo.GetAmmo / playerAmmo.GetClipSize;
    }

    private void UpdateHealthFill()
    {
        HealthFill.fillAmount = (float)playerHealth.GetHealth / playerHealth.GetMaxHealth;
    }
}
