﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FillePhysics))]
public class FilleControl : MonoBehaviour
{

    float currentSpeed;
    public float targetSpeed = 8, jumpHeight = 12, acceleration = 12, gravity = 20;
    private Vector3 amountToMove;
    private FillePhysics physics;
    public bool isDead;
    Sprite dead;

    // Use this for initialization
    void Start()
    {
        dead = Resources.Load("dead", typeof(Sprite)) as Sprite;
        physics = GetComponent<FillePhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        int dir = 0;

        if (!isDead)
        {
                if (Input.GetKey("left"))
            {
                dir = -1;
            }
            else if (Input.GetKey("right"))
            {
                dir = 1;
            }
            if (physics.grounded)
            {
                amountToMove.y = 0;
                if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
                {
                    amountToMove.y = jumpHeight;
                }
            }
        }
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = dead;

        currentSpeed = incrementSpeed(currentSpeed, targetSpeed, acceleration, dir);
        amountToMove.x = currentSpeed;
        amountToMove.y -= gravity * Time.deltaTime;
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

