using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType { MachineGun, Player, Sniper};
    public BulletType bt;
    public int damage;
    
    private void Update()
    {
        switch (bt)
        {
            case BulletType.MachineGun:
                damage = 1;
                transform.Translate(Vector3.up * 8 * Time.deltaTime);
                break;
            case BulletType.Player:
                damage = 1;
                transform.Translate(Vector3.up * 25 * Time.deltaTime);
                break;
            case BulletType.Sniper:
                damage = 3;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SniperBullet")
        {
            return;
        }
        if (collision.gameObject.tag == "BulletWall" ||
            (collision.gameObject.tag == "Player" && bt != BulletType.Player )||
            (collision.gameObject.tag == "Enemy" && bt == BulletType.Player)
            )
        {
            Destroy(gameObject);
        }
        
        
    }

}
