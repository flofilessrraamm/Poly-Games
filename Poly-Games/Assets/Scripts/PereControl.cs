using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PereControl : MonoBehaviour
{
    [HideInInspector]
    public float currentSpeed;
    [HideInInspector]
    public int dir;
    public float targetSpeed = 8, jumpHeight = 12, acceleration = 12, gravity = 20, sableFall = 3f;
    private Vector3 amountToMove;
    private PlayerPhysics physics;
    public bool isInSable;
    Sprite dead;

    // Use this for initialization
    void Start()
    {
        dead = Resources.Load("dead", typeof(Sprite)) as Sprite;
        physics = GetComponent<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = 0;

        if (!physics.isDead && !physics.isInSable)
        {
            if (Input.GetKey("a"))
            {
                dir = -1;
            }
            else if (Input.GetKey("d"))
            {
                dir = 1;
            }
            if (physics.isGrounded)
            {
                amountToMove.y = 0;
                if (Input.GetKeyDown("w"))
                {
                    amountToMove.y = jumpHeight;
                }
            }


            currentSpeed = incrementSpeed(currentSpeed, targetSpeed, acceleration, dir);
            amountToMove.x = currentSpeed;
            amountToMove.y -= gravity * Time.deltaTime;

            physics.Move(amountToMove * Time.deltaTime);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = dead;
            if (physics.isInSable)
            {
                amountToMove.x = 0;
                amountToMove.y = -sableFall * Time.deltaTime;
                physics.Move(amountToMove * Time.deltaTime);
            }
        }
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

