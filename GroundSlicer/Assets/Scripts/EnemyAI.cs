using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpawnSpeed;
    [SerializeField] float bulletSpeed;
    float bulletTimer;
    GameObject newBullet;
    Vector3 characterAtackPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(character.transform.position);
        Atack();
    }

    void Atack()
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= bulletSpawnSpeed)
        {
            bulletTimer = 0;
            newBullet = Instantiate(bullet);
            Destroy(newBullet, bulletSpawnSpeed - 0.2f);
            characterAtackPos = character.transform.position;
        }
        if (newBullet != null)
        {
            newBullet.transform.position = Vector3.MoveTowards(transform.position, characterAtackPos, bulletSpeed * Time.deltaTime);
        }
    }
}
