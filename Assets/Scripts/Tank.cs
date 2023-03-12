using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        hp = 70;
    }
    protected override void Update()
    {
        if (hp <= 0) Destroy(gameObject);
        base.Update();
    }
}
