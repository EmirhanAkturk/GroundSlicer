using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] Rigidbody rbCharacter;
    [SerializeField] GameObject target;
    [SerializeField] float speed;
    [SerializeField] float speedModifier;
    bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        CharacterMove();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TouchControl();
    }


    void CharacterMove()
    {
        if (isMove)
        {
            rbCharacter.velocity = new Vector3(0f, 0f, speed);
        }
    }

    void TouchControl()
    {
        if (Input.GetMouseButton(0))
        {
            isMove = true;
            transform.LookAt(target.transform.position);
            TargetPositionUpdate();
        }
        if (Input.GetMouseButtonUp(0))
        {
            // agir cekim
        }
    }

    void TargetPositionUpdate()
    {
        float h = speedModifier * Input.GetAxis("Mouse X");
        float v = speedModifier * Input.GetAxis("Mouse Y");

        target.transform.position = new Vector3(transform.position.x + h, transform.position.y, transform.position.z + v);
    }
}
