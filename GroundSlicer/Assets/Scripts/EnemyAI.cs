using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject player;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletSpawnSpeed;
    [SerializeField] float fear;
    [SerializeField] float smoothSpeed;
    Animation anim;

    float bulletTimer;
    GameObject newBullet;
    List<Bullet> bullets;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<Bullet>();
        anim = GetComponent<Animation>();
        StartCoroutine(BulletSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        GameOverControl();
        Atack();
    }

    void Atack()
    {
        if (player != null)
        {
            bulletTimer += Time.deltaTime;
            transform.LookAt(player.transform.position);

            if (IsClose(fear))
            {
                if (bulletTimer >= bulletSpawnSpeed)
                {
                    anim.Stop("Run");
                    StartCoroutine(BulletSpawner());
                    bulletTimer = 0;
                }
            }
            else
            {
                anim.Play("Run");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, smoothSpeed * Time.deltaTime);
            }

            for (int i = 0; i < bullets.Count; ++i)
            {
                bullets[i].BulletPositionUpdate();
            }
        }
        else
        {
            for (int i = 0; i < bullets.Count; ++i)
            {
                Destroy(bullets[i].GetBulletObject());
                bullets.RemoveAt(i);
            }
        }
    }

    bool IsClose(float fear)
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= fear)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator BulletSpawner()
    {
        anim.Play("Shot");
        yield return new WaitForSeconds(0.5f);
        Vector3 bulletPosition = new Vector3(0, 0, 0);
        newBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);
        bullets.Add(new Bullet(player.transform.position, transform.position, newBullet, bulletSpeed));
    }

    void GameOverControl()
    {
        if (player == null)
        {
            GetComponent<EnemyAI>().enabled = false;
        }
    }
}
