using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : MonoBehaviour
{
    [SerializeField] private Transform[] movePoint;
    [SerializeField] private float speed = 5f;
    private Animator anim;
    [SerializeField] private GameObject arogon;
    private bool canMoveRight = false;
    public Animator GetAnim
    {
        get
        {
            return anim;
        }
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        ChechkCanMoveRight();
        MoveToward();
    }
    private void MoveToward()
    {
        if (!canMoveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoint[0].position.x, transform.position.y, movePoint[0].position.z), speed * Time.deltaTime);
            transform.DORotate(new Vector3(transform.rotation.x, 0f, transform.rotation.z), 1f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoint[1].position.x, transform.position.y, movePoint[1].position.z),
                speed * Time.deltaTime);
            transform.DORotate(new Vector3(transform.rotation.x, 180f, transform.rotation.z), 1f);
        }
    }
    private void ChechkCanMoveRight()
    {

        if (Vector3.Distance(transform.position, new Vector3(movePoint[0].position.x, transform.position.y, movePoint[0].position.z)) <= 0.1f)  //aradaki mesafe 0.1den küçükse enemynin konumu ile hareket noktasý
        {
            canMoveRight = true;
        }
        else if (Vector3.Distance(transform.position, new Vector3(movePoint[1].position.x, transform.position.y, movePoint[1].position.z)) <= 0.1f)
        {
            canMoveRight = false;
        }
    }
}
