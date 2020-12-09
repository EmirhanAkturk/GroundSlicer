using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem particle;

    //List<ParticleCollisionEvent> collisionsEvents;
    List<GameObject> cubes;

    bool cycle = false;

    void Start()
    {
        cubes = new List<GameObject>();
        Debug.Log("Particle.duration:" + particle.duration);
    }

    // Update is called once per frame
    void Update()
    {

    }



    void AddRigitBody()
    {

        for (int i = 0; i < cubes.Count; ++i)
        { 
            cubes[i].transform.localScale*=0.95f;
            cubes[i].AddComponent<Rigidbody>();
        }

    }
   

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.transform.gameObject;

        if (!otherObject.CompareTag("Deformable"))
            return;

        if (cubes.Count == 0)
        {
            cubes.Add(otherObject);
            StartCoroutine(RemoveFromList(otherObject, particle.duration));
            Debug.Log(otherObject.transform.position);
        }
        else if(cubes[cubes.Count -1] != otherObject)
        {
            bool isOnList = false;

            for(int i=0; i<cubes.Count; ++i)
            {
                if(cubes[i] == otherObject)
                {
                    isOnList = true;

                    if (!LineCheck() && !SideBySideCheck() && !IsClose(i))
                    {
                        for (int j = 0; j < i; ++j)
                            cubes.RemoveAt(0);
                        
                        AddRigitBody();
                    }
                   
                    break;
                }

            }

            if (!isOnList)
            {
                cubes.Add(otherObject);
                StartCoroutine(RemoveFromList(otherObject,particle.duration));
                Debug.Log(otherObject.transform.position);

            }
        }
    }

    IEnumerator RemoveFromList(GameObject gameObject, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        cubes.Remove(gameObject);
    }



    float Slope(float X0, float Z0, float X1, float Z1)
    {
        float m;

        if (X0 == X1)
            m = 0;

        else if (Z0 == Z1)
            m = 1;

        else
        { 
            m = (Z1 - Z0) / (X1 - X0);
        }

        return m;
    }

    bool LineCheck()
    {
        float X0 = cubes[0].transform.position.x;
        float Z0 = cubes[0].transform.position.z;

        float X1 = cubes[cubes.Count-1].transform.position.x;
        float Z1 = cubes[cubes.Count-1].transform.position.z;
        
        float m = Slope(X0,Z0,X1,Z1);

        for(int i = 1;i<cubes.Count-1; ++i)
        {
            X1 = cubes[i].transform.position.x;
            Z1 = cubes[i].transform.position.z;

            if(m != Slope(X0, Z0, X1, Z1)){
                return false;
            }

        }
        return true;
    }


    bool IsSideBySide(float X0, float Z0, float X1, float Z1)
    {
        if(Mathf.Abs(X1-X0)<3 || Mathf.Abs(Z1-Z0)<3)
            return true;

        return false;
    }

    bool SideBySideCheck()
    {
        float X0 = cubes[0].transform.position.x;
        float Z0 = cubes[0].transform.position.z;

        float X1 = cubes[cubes.Count - 1].transform.position.x;
        float Z1 = cubes[cubes.Count - 1].transform.position.z;


        for (int i = 1; i < cubes.Count - 1; ++i)
        {
            X1 = cubes[i].transform.position.x;
            Z1 = cubes[i].transform.position.z;

            if (!IsSideBySide(X0, Z0, X1, Z1))
            {
                return false;
            }

        }
        return true;
    }

    bool IsClose(int i)
    {
        if (cubes.Count > 8 && (cubes.Count - 1 - i) > 8)
            return false;
        return true;
    }

}
