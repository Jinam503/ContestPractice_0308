using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject playerBullet1;
    public GameObject playerBullet2;

    private float curShootDelay;
    public float maxShootDelay;

    public bool cantDie;

    public int hp = 10;
    public float gas = 100f;
    public int CurBulletLvl ;
    private int MaxBulletLvl = 8;

    public Image hpBar;
    public Image gasBar;
    public GameObject gameOverPanel;

    private GameObject barrier;

    private bool isTriggerT = false;
    private bool isTriggerB = false;
    private bool isTriggerL = false;
    private bool isTriggerR = false;

    private bool isBarrior = false;

    SpriteRenderer sr;
    // Start is called before the first frame update
    private void Awake()
    {
        barrier = transform.GetChild(0).gameObject;
        //barrier.SetActive(false);
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
        Gas_Hp();
        
    }
    private void Gas_Hp()
    {
        gas -= Time.deltaTime * 3;
        hpBar.fillAmount = hp * 0.1f;
        gasBar.fillAmount = gas * 0.01f;
        if (hp <= 0 || gas <= 0)
        {
            gameObject.SetActive(false);
            gameOverPanel.gameObject.SetActive(true);
        }
        if (hp > 10) hp = 10;
        if (gas > 100) gas = 100;
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
        switch (CurBulletLvl)
        {
            case 1:
                secondBulletPos = new Vector3(transform.position.x + 0f, transform.position.y + 0.4f, 0);
                Instantiate(playerBullet1, secondBulletPos, transform.rotation);
                break;
            case 2:
                firstBulletPos = new Vector3(transform.position.x - 0.15f, transform.position.y + 0.4f, 0);
                secondBulletPos = new Vector3(transform.position.x + 0.15f, transform.position.y + 0.4f, 0);
                Instantiate(playerBullet1, firstBulletPos, transform.rotation);
                Instantiate(playerBullet1, secondBulletPos, transform.rotation);
                break;
            case 3:
                firstBulletPos = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f, 0);
                secondBulletPos = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f, 0);
                thirdBulletPos = new Vector3(transform.position.x + 0f, transform.position.y + 0.7f, 0);
                Instantiate(playerBullet1, firstBulletPos, transform.rotation);
                Instantiate(playerBullet1, secondBulletPos, transform.rotation);
                Instantiate(playerBullet1, thirdBulletPos, transform.rotation);
                break;
            case 4:
                secondBulletPos = new Vector3(transform.position.x + 0f, transform.position.y + 0.4f, 0);
                Instantiate(playerBullet2, secondBulletPos, transform.rotation);
                break;
            case 5:
                firstBulletPos = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f, 0);
                secondBulletPos = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f, 0);
                thirdBulletPos = new Vector3(transform.position.x + 0f, transform.position.y + 0.7f, 0);
                Instantiate(playerBullet1, firstBulletPos, transform.rotation);
                Instantiate(playerBullet1, secondBulletPos, transform.rotation);
                Instantiate(playerBullet2, thirdBulletPos, transform.rotation);
                break;
            case 6:
                firstBulletPos = new Vector3(transform.position.x - 0.15f, transform.position.y + 0.4f, 0);
                secondBulletPos = new Vector3(transform.position.x + 0.15f, transform.position.y + 0.4f, 0);
                Instantiate(playerBullet2, firstBulletPos, transform.rotation);
                Instantiate(playerBullet2, secondBulletPos, transform.rotation);
                break;
            case 7:
                firstBulletPos = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f, 0);
                secondBulletPos = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f, 0);
                thirdBulletPos = new Vector3(transform.position.x + 0f, transform.position.y + 0.7f, 0);
                Instantiate(playerBullet2, firstBulletPos, transform.rotation);
                Instantiate(playerBullet2, secondBulletPos, transform.rotation);
                Instantiate(playerBullet1, thirdBulletPos, transform.rotation);
                break;
            case 8:
                firstBulletPos = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f, 0);
                secondBulletPos = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f, 0);
                thirdBulletPos = new Vector3(transform.position.x + 0f, transform.position.y + 0.7f, 0);
                Instantiate(playerBullet2, firstBulletPos, transform.rotation);
                Instantiate(playerBullet2, secondBulletPos, transform.rotation);
                Instantiate(playerBullet2, thirdBulletPos, transform.rotation);
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
        
        if(collision.gameObject.tag == "EnemyBullet" && !cantDie)
        {
            if (isBarrior)
            {
                return;
            }
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            Onhit(b.damage);
        }
        else if(collision.gameObject.tag == "Item")
        {
            GameObject item = collision.gameObject;
            Item item_ = item.GetComponent<Item>();
            switch (item_.type)
            {
                case "Gas":
                    gas += 40;
                    break;
                case "Fix":
                    hp += 5;
                    break;
                case "Upgrade":
                    CurBulletLvl++;
                    if (CurBulletLvl > MaxBulletLvl) CurBulletLvl = MaxBulletLvl;
                    break;
                case "Invincibility":
                    StopCoroutine(BarrierCouroutine());
                    StartCoroutine(BarrierCouroutine());
                    break;
            }
            Destroy(item);
        }
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
            default:
                break;
        }
    }
    IEnumerator BarrierCouroutine()
    {
        isBarrior = true;
        barrier.SetActive(true);
        yield return new WaitForSeconds(5);
        isBarrior = false;
        barrier.SetActive(false);
    }
    void Onhit(int damage)
    {
        cantDie = true;
        hp -= damage;
        sr.material.color =
           new Color(sr.material.color.r,
                     sr.material.color.g,
                     sr.material.color.b, 0.5f);
        Invoke("ReturnColor", 0.5f);
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
