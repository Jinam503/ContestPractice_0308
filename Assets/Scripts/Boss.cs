using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject bullet_1;
    public GameObject bullet_2;
    public GameObject bullet_3;

    private GameObject bulletPos;

    protected override void Awake()
    {
        base.Awake();
        bulletPos = transform.GetChild(0).gameObject;
        hp = 400;
        StartCoroutine(Attack());
    }
    protected override void Update()
    {
        base.Update();
        if (hp <= 0) Destroy(gameObject);
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(Attack_());
        StartCoroutine(Attack());
    }
    IEnumerator Attack_()
    {
        int rand = Random.Range(1,7);
        int rot;
        switch (rand)
        {
            
            case 1:
                rot = Random.Range(130, 160);
                for (int i = 0; i < 10; i++)
                {
                    bulletPos.transform.eulerAngles = new Vector3(0, 0, rot);
                    Instantiate(bullet_1, bulletPos.transform.position, bulletPos.transform.rotation);
                    rot += 10;
                    yield return new WaitForSeconds(0.4f);
                }
                break;
            case 2:
                for(int i = 0; i < 20; i ++)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().moveSpeed = 2.5f;
                    yield return new WaitForSeconds(1f);
                }
                
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().moveSpeed = 5;
                break;
            case 3:
                rot = Random.Range(130, 160);
                for (int i = 0; i < 4; i++)
                {
                    rot = Random.Range(140, 150);
                    for (int j = 0; j < 5; j++)
                    {
                        bulletPos.transform.eulerAngles = new Vector3(0, 0, rot);
                        Instantiate(bullet_1, bulletPos.transform.position, bulletPos.transform.rotation);
                        rot += 15;
                    }
                    
                    yield return new WaitForSeconds(0.7f);
                }
                break;
            case 4:
                rot = Random.Range(150, 210);
                for (int i = 0; i < 10; i++)
                {
                    rot = Random.Range(170, 190);
                    for (int j = 0; j < 2; j++)
                    {
                        bulletPos.transform.eulerAngles = new Vector3(0, 0, rot);
                        Instantiate(bullet_1, bulletPos.transform.position, bulletPos.transform.rotation);
                        rot += 30;
                    }

                    yield return new WaitForSeconds(0.2f);
                }
                break;
            case 5:
                rot = Random.Range(130, 160);
                for (int i = 0; i < 5; i++)
                {
                    bulletPos.transform.eulerAngles = new Vector3(0, 0, rot);
                    Instantiate(bullet_2, bulletPos.transform.position, bulletPos.transform.rotation);
                    rot += 15;
                }
                break;
            case 6:
                for (int i = 0; i < 2; i++)
                {
                    Vector3 dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
                    bulletPos.transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
                    Instantiate(bullet_3, bulletPos.transform.position, bulletPos.transform.rotation);
                    yield return new WaitForSeconds(0.2f);
                }
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }
    }
}
