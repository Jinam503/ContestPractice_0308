using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Enemy
{
    public GameObject bullet;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        hp = 20;
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) Destroy(gameObject);
        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
    }
    IEnumerator Attack()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(Attack());
    }
}
