using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 70;
    }
    void Update()
    {
        if (hp <= 0) Destroy(gameObject);
    }
}
