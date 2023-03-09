using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Text skill_1_CoolTime;
    public Text skill_2_CoolTime;

    private float skill_1;
    private float skill_2;

    void Start()
    {
        skill_1 = 0;
        skill_2 = 0;
        skill_1_CoolTime.gameObject.SetActive(false);
        skill_2_CoolTime.gameObject.SetActive(false);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q) && skill_1 <= 0f)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().hp += 5;
            skill_1_CoolTime.gameObject.SetActive(true);
            skill_1 = 10f;
            StartCoroutine(CoolTime(1));
        }
        if (Input.GetKeyDown(KeyCode.E) && skill_2 <= 0f)
        {
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            DestroyAll(bullets);
            GiveDamageToAll(enemies, 15);
            skill_2_CoolTime.gameObject.SetActive(true);
            skill_2 = 15f;
            StartCoroutine(CoolTime(2));
        }
        skill_1_CoolTime.text = ((int)skill_1).ToString();
        skill_2_CoolTime.text = ((int)skill_2).ToString();
        if (skill_1 <= 0f) skill_1_CoolTime.gameObject.SetActive(false);
        if (skill_2 <= 0f) skill_2_CoolTime.gameObject.SetActive(false);

    }
    void GiveDamageToAll(GameObject[] enemies, int damage)
    {
        foreach (GameObject e in enemies)
        {
            e.GetComponent<Enemy>().hp -= damage;
        }
    }
    void DestroyAll(GameObject[] bullets )
    {
        foreach(GameObject b in bullets)
        {
            Destroy(b);
        }
    }
    IEnumerator CoolTime(int s)
    {
        switch (s)
        {
            case 1:
                while (skill_1 > 0f)
                {
                    skill_1 -= Time.deltaTime;
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 2:
                while (skill_2 > 0f)
                {
                    skill_2 -= Time.deltaTime;
                    yield return new WaitForFixedUpdate();
                }
                break;
        }
    }
}
