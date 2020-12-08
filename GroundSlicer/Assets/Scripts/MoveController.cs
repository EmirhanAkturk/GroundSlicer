using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveController : MonoBehaviour
{
    [SerializeField] Rigidbody rbCharacter;
    //[SerializeField] GameObject target;
    [SerializeField] float speed;
    //[SerializeField] float speedModifier;
    float vX0, vX1;
    float vY0, vY1;
    float m1, m2;
    Vector2 firstPos;
    Vector2 lastPos;
    Vector3 currVelocity;
    float rotationAngle;
    bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        rbCharacter = GetComponent<Rigidbody>();
        vY0 = speed;
        currVelocity = new Vector3(0, 0, vY0);
        //currVelocity = new Vector3(-speed, 0, 0);
    }

    void Update()
    {
        //vY0 = speed;

        //rbCharacter.velocity = new Vector3(vX0, 0, vY0);
        rbCharacter.velocity = currVelocity;
        TouchControl();
        transform.rotation = Quaternion.Euler(0, rotationAngle, 0);
    }

    void TouchControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMove = true;

            vX1 = vX0;
            vY1 = vY0;
            currVelocity = new Vector3(vX0, 0, vY0);

            firstPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && isMove)
        {
            lastPos = Input.mousePosition;

            //Debug.Log("*****" + firstPos.x + " - " + firstPos.y + "*****");
            //Debug.Log(Input.mousePosition.x + " - " + Input.mousePosition.y);
            if (firstPos != lastPos)
            {
                if (firstPos.x == lastPos.x)
                {
                    if (firstPos.y < lastPos.y)
                    {
                        rotationAngle = 0;
                        vX1 = 0;
                        vY1 = speed;
                    }
                    else
                    {
                        rotationAngle = 180;
                        vX1 = 0;
                        vY1 = -speed;
                    }
                }

                else if (firstPos.y == lastPos.y)
                {
                    if (firstPos.x < lastPos.x)
                    {
                        rotationAngle = 90;
                        vY1 = 0;
                        vX1 = speed;
                    }
                    else
                    {
                        rotationAngle = 270;
                        vY1 = 0;
                        vX1 = -speed;
                    }
                }

                else
                {


                    if (vX0 != 0)
                        m1 = vY0 / vX0;

                    m2 = (lastPos.y - firstPos.y) / (lastPos.x - firstPos.x);
                    vX1 = speed / Mathf.Sqrt(1 + m2 * m2);
                    vX1 = Mathf.Abs(vX1);
                    if (lastPos.x < firstPos.x)
                    {
                        vX1 *= -1;
                    }
                    vY1 = m2 * vX1;

                    //float tanTeta = (m1 - m2) / (1 + m1 * m2);
                    //rotationAngle = Mathf.Atan(tanTeta) * Mathf.Rad2Deg;
                    //Debug.Log("Angle:" + rotationAngle);

                    if(lastPos.x > firstPos.x )//1. veya 2. bölgede
                    {
                        if(lastPos.y > firstPos.y)//1. bölge
                        {
                            float tanTheta = vX1 / vY1;
                            rotationAngle = Mathf.Atan(tanTheta) * Mathf.Rad2Deg;
                        }
                        else //2. bölge
                        {
                            float tanTheta = vY1 / vX1;
                            rotationAngle =90+ Mathf.Atan(tanTheta) * Mathf.Rad2Deg;
                        }
                    }
                    else //3. veya 4. bölge
                    {
                        if (lastPos.y < firstPos.y)//3. bölge
                        {
                            float tanTheta = vX1 / vY1;
                            rotationAngle = 180+ Mathf.Atan(tanTheta) * Mathf.Rad2Deg;
                        }
                        else //4. bölge
                        {
                            float tanTheta = vY1 / vX1;
                            rotationAngle = 270 + Mathf.Atan(tanTheta) * Mathf.Rad2Deg;
                        }
                    }
                }
                currVelocity = new Vector3(vX1, 0, vY1);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMove = false;
            vX0 = vX1;
            vY0 = vY1;
            // agir cekim
        }
    }
}