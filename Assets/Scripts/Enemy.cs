using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    protected bool canAttack;

    protected bool moving = true;

    protected Transform target;
    public Transform targetPos; 

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
        if (hp <= 0)
        {
            Destroy(gameObject);
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
    void Onhit(int damage)
    {

        if (hp <= 0) return;
        if (gameObject.name == "Boss")
        {
            int ran = Random.Range(0, 9);
            if (ran == 1)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/GasItem");
                Vector2 v = new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y);
                Instantiate(prefab, v, prefab.transform.rotation);

            }
        }
        hp -= damage;
        sr.material.color =
           new Color(sr.material.color.r,
                     sr.material.color.g,
                     sr.material.color.b, 0.5f);
        Invoke("ReturnColor", 0.01f);
        if (hp <= 0)
        {
            int ran = Random.Range(0, 9);
            if (ran < 4)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/GasItem");
                Vector2 v = new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y);
                Instantiate(prefab, v, prefab.transform.rotation);
            }
            ran = Random.Range(0, 10);
            if (ran < 5)
            {
                return;
            }
            else if (ran < 7)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/FixItem");
                Vector2 v = new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y);
                Instantiate(prefab, v, prefab.transform.rotation);
            }
            else if (ran < 9) 
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/UpgradeBulletLvlItem");
                Vector2 v = new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y);
                Instantiate(prefab, v, prefab.transform.rotation);
            }
            else
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/BarriorItem");
                Vector2 v = new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y);
                Instantiate(prefab, v, prefab.transform.rotation);
            }
            Destroy(gameObject);
        }
        
    }
    void ReturnColor()
    {
        sr.material.color =
              new Color(sr.material.color.r,
                        sr.material.color.g,
                        sr.material.color.b, 1f);
    }
    

}
