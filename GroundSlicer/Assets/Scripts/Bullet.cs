using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField] 
public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpawnSpeed;
    [SerializeField] float bulletSpeed;

    GameObject newBullet;
    Vector3 characterAtackPos;

    float bulletTimer;
    float m2;
    float vX1;
    float vY1;

    public Bullet(Vector3 playerPos, Vector3 shoterPos)
    {
        //characterAtackPos = character.transform.position;

        m2 = (playerPos.z - shoterPos.z) / (playerPos.x - shoterPos.x);
        vX1 = bulletSpeed / Mathf.Sqrt(1 + m2 * m2);
        vX1 = Mathf.Abs(vX1);
        if (playerPos.x < shoterPos.x)
        {
            vX1 *= -1;
        }
        vY1 = m2 * vX1;

        Vector3 bulletPosition = new Vector3(transform.position.x + vX1 * 1, transform.position.y + 3, transform.position.z + vY1 * 1);

        bulletTimer = 0;
        newBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletPositionUpdate();
    }

    public void BulletPositionUpdate()
    {
        newBullet.GetComponent<Rigidbody>().velocity = new Vector3(vX1, 0, vY1);
    }
    void BulletCalculator()
    {
        //Destroy(newBullet, bulletSpawnSpeed - 0.2f);
        //characterAtackPosX = character.transform.position.x;
        //characterAtackPosY = character.transform.position.y;
        //characterAtackPosZ = character.transform.position.z;
    }
}
