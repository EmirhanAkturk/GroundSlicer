using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    GameObject newBullet;
    Rigidbody rb;

    float m2;
    float vX1;
    float vY1;


    public Bullet(Vector3 playerPos, Vector3 shoterPos, GameObject bullet, float bulletSpeed)
    {
        m2 = (playerPos.z - shoterPos.z) / (playerPos.x - shoterPos.x);
        vX1 = bulletSpeed / Mathf.Sqrt(1 + m2 * m2);
        vX1 = Mathf.Abs(vX1);
        if (playerPos.x < shoterPos.x)
        {
            vX1 *= -1;
        }
        vY1 = m2 * vX1;

        Vector3 bulletPosition = new Vector3(shoterPos.x + vX1 * 0.5f, shoterPos.y + 3, shoterPos.z + vY1 * 1);

        newBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);

        rb = newBullet.GetComponent<Rigidbody>();
    }


    public void BulletPositionUpdate()
    {
        rb.velocity = new Vector3(vX1, 0, vY1);
    }

}
