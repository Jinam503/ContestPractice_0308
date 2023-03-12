using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType { MachineGun, Player, Sniper, Boss_1, Boss_2, Boss_3};
    public BulletType bt;
    public int damage;

    private void Awake()
    {
        switch (bt)
        {
            case BulletType.MachineGun:
                damage = 1;
                break;
            case BulletType.Player:
                damage = 1;
                break;
            case BulletType.Sniper:
                damage = 3;
                break;
            case BulletType.Boss_1:
                damage = 1;
                break;
            case BulletType.Boss_2:
                damage = 3;
                break;
            case BulletType.Boss_3:
                damage = 5;
                break;
        }
    }
    private void Update()
    {
        switch (bt)
        {
            case BulletType.MachineGun:
                transform.Translate(Vector3.up * 6 * Time.deltaTime);
                break;
            case BulletType.Player:
                transform.Translate(Vector3.up * 25 * Time.deltaTime);
                break;
            case BulletType.Sniper:
                break;
            case BulletType.Boss_1:
                transform.Translate(Vector3.up * 3 * Time.deltaTime);
                break;
            case BulletType.Boss_2:
                transform.Translate(Vector3.up * 5 * Time.deltaTime);
                break;
            case BulletType.Boss_3:
                transform.Translate(Vector3.up * 10 * Time.deltaTime);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bt == BulletType.Sniper || bt == BulletType.Boss_3) return;
        if (collision.gameObject.tag == "BulletWall" ||
            (collision.gameObject.tag == "Barrior" && bt != BulletType.Player) ||
            (collision.gameObject.tag == "Player" && bt != BulletType.Player )||
            (collision.gameObject.tag == "Player" && bt != BulletType.Player) ||
            (collision.gameObject.tag == "Enemy" && bt == BulletType.Player)
            )
        {
            Destroy(gameObject);
        }
        
        
    }

}
