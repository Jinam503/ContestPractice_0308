using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject playerBullet;

    private float curShootDelay;
    public float maxShootDelay;

    public bool cantDie;

    public int hp = 10;
    public int gas = 100;
    public int bulletLvl = 3;

    public Image hpBar;
    public Image gasBar;
    public GameObject gameOverPanel;

    private bool isTriggerT = false;
    private bool isTriggerB = false;
    private bool isTriggerL = false;
    private bool isTriggerR = false;

    SpriteRenderer sr;
    // Start is called before the first frame update
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        gameOverPanel.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
        R();
        hpBar.fillAmount = hp * 0.1f;
        gasBar.fillAmount = gas * 0.01f;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            gameOverPanel.gameObject.SetActive(true);
        }
    }
    private void R()
    {
        curShootDelay += Time.deltaTime;
    }
    private void Shoot()
    {
        if (curShootDelay < maxShootDelay) return;
        Vector3 firstBulletPos;
        Vector3 secondBulletPos;
        Vector3 thirdBulletPos;
        switch (bulletLvl)
        {
            case 1:
                secondBulletPos = new Vector3(transform.position.x + 0f, transform.position.y + 0.4f, 0);
                Instantiate(playerBullet, secondBulletPos, transform.rotation);
                break;
            case 2:
                firstBulletPos = new Vector3(transform.position.x - 0.15f, transform.position.y + 0.4f, 0);
                secondBulletPos = new Vector3(transform.position.x + 0.15f, transform.position.y + 0.4f, 0);
                Instantiate(playerBullet, firstBulletPos, transform.rotation);
                Instantiate(playerBullet, secondBulletPos, transform.rotation);
                break;
            case 3:
                Debug.Log("d");
                firstBulletPos = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f, 0);
                secondBulletPos = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f, 0);
                thirdBulletPos = new Vector3(transform.position.x + 0f, transform.position.y + 0.7f, 0);
                Instantiate(playerBullet, firstBulletPos, transform.rotation);
                Instantiate(playerBullet, secondBulletPos, transform.rotation);
                Instantiate(playerBullet, thirdBulletPos, transform.rotation);
                break;
            case 4:
                break;
        }
        
        curShootDelay = 0;
    }
    private void Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if ((ver == 1 && isTriggerT) || (ver == -1 && isTriggerB)) ver = 0;
        if ((hor == 1 && isTriggerR) || (hor == -1 && isTriggerL)) hor = 0;
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(hor, ver, 0) * moveSpeed * Time.deltaTime;
        transform.position = nextPos + curPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "L":
                isTriggerL = true;
                break;
            case "R":
                isTriggerR = true;
                break;
            case "T":
                isTriggerT = true;
                break;
            case "B":
                isTriggerB = true;
                break;
        }
        if(collision.gameObject.tag == "EnemyBullet" && !cantDie)
        {
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            Onhit(b.damage);
        }
    }
    void Onhit(int damage)
    {
        cantDie = true;
        hp -= damage;
        sr.material.color =
           new Color(sr.material.color.r,
                     sr.material.color.g,
                     sr.material.color.b, 0.5f);
        Invoke("ReturnColor", 1f);
    }
    void ReturnColor()
    {
        
        sr.material.color =
              new Color(sr.material.color.r,
                        sr.material.color.g,
                        sr.material.color.b, 1f);
        cantDie = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "L":
                isTriggerL = false;
                break;
            case "R":
                isTriggerR = false;
                break;
            case "T":
                isTriggerT = false;
                break;
            case "B":
                isTriggerB = false;
                break;
        }
    }
}
