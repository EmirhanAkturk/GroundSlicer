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
    float characterAtackPosX;
    float characterAtackPosY;
    float characterAtackPosZ;

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
            newBullet = Instantiate(bullet, transform.position, transform.rotation);
            //Destroy(newBullet, bulletSpawnSpeed - 0.2f);
            characterAtackPos = character.transform.position * 5;
            characterAtackPosX = character.transform.position.x;
            characterAtackPosY = character.transform.position.y;
            characterAtackPosZ = character.transform.position.z;
        }
        if (newBullet != null)
        {
            //newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
            newBullet.transform.position = Vector3.MoveTowards(newBullet.transform.position, characterAtackPos, bulletSpeed * Time.deltaTime);
        }
    }
}
