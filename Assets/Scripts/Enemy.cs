using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    protected bool canAttack;

    

    protected bool moving = true;

    protected Transform target;
    protected Transform targetPos;

    private SpriteRenderer sr;
    protected virtual void Awake()
    {
        target = GameObject.Find("Player").transform;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    protected virtual void Update()
    {
        if (transform.position != targetPos.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, 5f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            Onhit(b.damage);
        }
    }
    public void MoveToTarget(Transform t)
    {
        targetPos = t;
    }
    void Onhit(int damage)
    {
        hp -= damage;
        sr.material.color =
           new Color(sr.material.color.r,
                     sr.material.color.g,
                     sr.material.color.b, 0.5f);
        Invoke("ReturnColor", 0.01f);
    }
    void ReturnColor()
    {

        sr.material.color =
              new Color(sr.material.color.r,
                        sr.material.color.g,
                        sr.material.color.b, 1f);
    }

}
