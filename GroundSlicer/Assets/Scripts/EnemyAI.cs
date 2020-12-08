using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject character;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletSpawnSpeed;

    float bulletTimer;
    GameObject newBullet;
    List<Bullet> bullets;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<Bullet>();
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
            Vector3 bulletPosition = new Vector3(0, 0, 0);

            newBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);
            bullets.Add( new Bullet (character.transform.position, transform.position,newBullet,bulletSpeed));
            bulletTimer = 0;
        }
      

        for(int i=0; i< bullets.Count; ++i)
        {
            bullets[i].BulletPositionUpdate();
        }

    }

}
