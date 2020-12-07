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
    float m2;
    Vector2 firstPos;
    Vector2 lastPos;
    //bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        rbCharacter = GetComponent<Rigidbody>();
        vY0 = speed;
    }

    void Update()
    {
        TouchControl();
    }

    void TouchControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vX1 = vX0;
            vY1 = vY0;
            rbCharacter.velocity = new Vector3(vX0, 0, vY0);

            firstPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            lastPos = Input.mousePosition;

            Debug.Log("*****" + firstPos.x + " - " + firstPos.y + "*****");
            Debug.Log(Input.mousePosition.x + " - " + Input.mousePosition.y);
            if (firstPos != lastPos)
            {
                m2 = (lastPos.y - firstPos.y) / (lastPos.x - firstPos.x);
                vX1 = speed / Mathf.Sqrt(1 + m2 * m2);
                vX1 = Mathf.Abs(vX1);
                if (lastPos.x < firstPos.x)
                {
                    vX1 *= -1;
                }
                vY1 = m2 * vX1;

                rbCharacter.velocity = new Vector3(vX1, 0, vY1);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            vX0 = vX1;
            vY0 = vY1;
            // agir cekim
        }
    }
}
