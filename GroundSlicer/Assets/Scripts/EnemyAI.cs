using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject character;
    [SerializeField] float bulletSpawnSpeed;
    [SerializeField] float bulletSpeed;
    float bulletTimer;
    GameObject newBullet;
    Vector3 characterAtackPos;
    Vector3 currentPos;
    float characterAtackPosX;
    float characterAtackPosY;
    float characterAtackPosZ;
    float m2;
    float vX1;
    float vY1;

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
            //new Bullet(character.transform.position, transform.position);
            characterAtackPos = character.transform.position;
            
            m2 = (characterAtackPos.z - transform.position.z) / (characterAtackPos.x - transform.position.x);
            vX1 = bulletSpeed / Mathf.Sqrt(1 + m2 * m2);
            vX1 = Mathf.Abs(vX1);
            if (characterAtackPos.x < transform.position.x)
            {
                vX1 *= -1;
            }
            vY1 = m2 * vX1;
            
            Vector3 bulletPosition = new Vector3(transform.position.x + vX1 * 1, transform.position.y + 3, transform.position.z + vY1 * 1);
            
            bulletTimer = 0;
            newBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);
            newBullet.transform.SetParent(gameObject.transform);
            //Destroy(newBullet, bulletSpawnSpeed - 0.2f);
            //characterAtackPosX = character.transform.position.x;
            //characterAtackPosY = character.transform.position.y;
            //characterAtackPosZ = character.transform.position.z;


        }
        if (newBullet != null)
        {
            ////newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
            //newBullet.transform.position = Vector3.MoveTowards(newBullet.transform.position, characterAtackPos, bulletSpeed * Time.deltaTime);
         
            //newBullet.GetComponent<Rigidbody>().velocity = new Vector3(vX1, 0, vY1);
        }


    }

    public float GetVX1()
    {
        return vX1;
    }

    public float GetVY1()
    {
        return vY1;
    }
}
