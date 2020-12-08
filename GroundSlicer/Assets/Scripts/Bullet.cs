using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField] 
public class Bullet : MonoBehaviour
{
    EnemyAI enemyAI;
    //[SerializeField] GameObject bullet;
    //[SerializeField] float bulletSpawnSpeed;
    //[SerializeField] float bulletSpeed;

    GameObject newBullet;
    Vector3 characterAtackPos;

    float bulletTimer;
    float m2;
    float x;
    float y;

    //public Bullet(Vector3 playerPos, Vector3 shoterPos)
    //{
    //    //characterAtackPos = character.transform.position;
    //
    //    m2 = (playerPos.z - shoterPos.z) / (playerPos.x - shoterPos.x);
    //    vX1 = bulletSpeed / Mathf.Sqrt(1 + m2 * m2);
    //    vX1 = Mathf.Abs(vX1);
    //    if (playerPos.x < shoterPos.x)
    //    {
    //        vX1 *= -1;
    //    }
    //    vY1 = m2 * vX1;
    //
    //    Vector3 bulletPosition = new Vector3(transform.position.x + vX1 * 1, transform.position.y + 3, transform.position.z + vY1 * 1);
    //
    //    bulletTimer = 0;
    //    newBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);
    //
    //}

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = transform.parent.GetComponent<EnemyAI>();
        x = enemyAI.GetVX1();
        y = enemyAI.GetVY1();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BulletPositionUpdate();
    }

    public void BulletPositionUpdate()
    {
        transform.GetComponent<Rigidbody>().velocity = new Vector3(x, 0, y);
    }
    void BulletCalculator()
    {
        //Destroy(newBullet, bulletSpawnSpeed - 0.2f);
        //characterAtackPosX = character.transform.position.x;
        //characterAtackPosY = character.transform.position.y;
        //characterAtackPosZ = character.transform.position.z;
    }
}
