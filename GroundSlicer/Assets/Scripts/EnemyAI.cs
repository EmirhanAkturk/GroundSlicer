using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform player;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletSpawnSpeed;
    [SerializeField] float fear;
    [SerializeField] float smoothSpeed;

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
        transform.LookAt(player.position);
        Atack();
    }

    void Atack()
    {
        bulletTimer += Time.deltaTime;

        if (IsClose(fear))
        {
            if (bulletTimer >= bulletSpawnSpeed )
            {
                Vector3 bulletPosition = new Vector3(0, 0, 0);

                newBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);
                bullets.Add( new Bullet (player.position, transform.position,newBullet,bulletSpeed));
                bulletTimer = 0;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, smoothSpeed * Time.deltaTime);
        }

        for (int i=0; i< bullets.Count; ++i)
        {
            bullets[i].BulletPositionUpdate();
        }
        Debug.Log("---" + Vector3.Distance(player.position, transform.position));
    }

    bool IsClose(float fear)
    {
        if (Vector3.Distance(player.position, transform.position) <= fear)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
