using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject deathParticle;
    [SerializeField] GameObject trailParticle;
    [SerializeField] GameObject splashSprite;
    [SerializeField] GameObject playerMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            health -= health;
            if (health <= 0)
            {
                //FindObjectOfType<EnemyAI>().enabled = false;
                GetComponentInParent<MoveController>().enabled = false;
                deathParticle.SetActive(true);
                trailParticle.SetActive(false);
                splashSprite.SetActive(true);
                Destroy(playerMesh);
                    //i5 
                    //750
                    //12 rm
                    //batarya

            }
        }
    }
}
