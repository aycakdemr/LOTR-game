using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health Settings")]
    public bool healthPowerUp = false;
    public int healthAmount = 1;
    [Header("Ammo Settings")]
    public bool ammoPowerUp = false;
    public int ammoAmount = 5;
    [Header("Transform Settings")]
    [SerializeField] private float turnSpeed = -1f;
    [Header("Scale Settings")]
    [SerializeField] private float period = 2f;
    [SerializeField] Vector3 scaleVector;
    private Vector3 startScale;
    private float scaleFactor;
    [SerializeField] private AudioClip clipToPlay;
    // Start is called before the first frame update
    private void Awake()
    {
        startScale = transform.localScale;
    }
    void Start()
    {

        if (healthPowerUp && ammoPowerUp)
        {
            healthPowerUp = false;
            ammoPowerUp = false;
        }
        else if (healthPowerUp)
        {
            ammoPowerUp = false;
        }
        else if (ammoPowerUp)
        {
            healthPowerUp = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0f, turnSpeed, 0f);
        SinusWawe();
    }

    private void SinusWawe()
    {
        if (period <= 0f)
        {
            period = 0.1f;
        }
        float cycles = Time.timeSinceLevelLoad / period; //iki dalga arasýndaki mesafe
        const float piX2 = Mathf.PI * 2;
        float sinusWawe = Mathf.Sin(cycles * piX2);
        scaleFactor = sinusWawe / 2 + 0.5f;

        Vector3 offset = scaleFactor * scaleVector;

        transform.localScale = startScale + offset;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
            if (healthPowerUp)
            {
                other.gameObject.GetComponent<Target>().GetHealth += healthAmount;
                print(other.gameObject.GetComponent<Target>().GetHealth);
            }

            else if (ammoPowerUp)
            {
                other.gameObject.GetComponent<Attack>().GetAmmo += ammoAmount;
                print(other.gameObject.GetComponent<Attack>().GetAmmo);
            }
        }
        Destroy(gameObject);

    }
}
