using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PerePhysics))]
public class PereControl : MonoBehaviour
{
    [HideInInspector]
    public float currentSpeed;
    public float targetSpeed = 8, jumpHeight = 12, acceleration = 12, gravity = 20, sableFall = 3f;
    private Vector3 amountToMove;
    private PerePhysics physics;
    public bool isDead, isInSable;
    Sprite dead;

    // Use this for initialization
    void Start()
    {
        dead = Resources.Load("dead", typeof(Sprite)) as Sprite;
        physics = GetComponent<PerePhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        int dir = 0;

        if(!isDead && !isInSable)
        {
            if (Input.GetKey("a"))
            {
                dir = -1;
            }
            else if (Input.GetKey("d"))
            {
                dir = 1;
            }
            if (physics.grounded)
            {
                amountToMove.y = 0;
                if (Input.GetKeyDown("w"))
                {
                    amountToMove.y = jumpHeight;
                }
            }
        }
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = dead;

        currentSpeed = incrementSpeed(currentSpeed, targetSpeed, acceleration, dir);
        amountToMove.x = currentSpeed;
        if(!isInSable)
            amountToMove.y -= gravity * Time.deltaTime;
        else
            amountToMove.y = - sableFall * Time.deltaTime;
        physics.Move(amountToMove * Time.deltaTime);
    }

    private float incrementSpeed(float s, float t, float a, int d)
    {
        t *= d;
        if (s == t)
        {
            return s;
        }
        else
        {
            s += a * Time.deltaTime * d;
            if (Mathf.Abs(s) < Mathf.Abs(t))
            {
                return s;
            }
            else
                return t;
        }
    }
}


