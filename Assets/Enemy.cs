using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    protected bool canAttack;

    protected Transform target;
    protected virtual void Awake()
    {
        target = GameObject.Find("Player").transform;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            Onhit(b.damage);
        }
    }
    void Onhit(int damage)
    {
        hp -= damage;
    }

}
