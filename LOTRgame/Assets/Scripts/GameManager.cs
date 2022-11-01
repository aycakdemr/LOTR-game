using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelFinishedParent;
    private bool levelFinished = false;
    private Target playerHealth;
    public bool GetLeEvelFinish
    {
        get
        {
            return levelFinished;
        }

    }
    private void Awake()
    {
        levelFinishedParent.SetActive(false);
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Target>();
    }
    void Update()
    {
        if (playerHealth.GetHealth <= 0)
        {
            levelFinishedParent.SetActive(true);
            levelFinished = true;
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            levelFinishedParent.SetActive(true);
            levelFinished = true;
            Destroy(other.gameObject);
        }
        else
        {
            levelFinishedParent.SetActive(false);
            levelFinished = false;
        }
    }
}
