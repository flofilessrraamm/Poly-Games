using UnityEngine;
using System.Collections;

public class Camera2_follow : MonoBehaviour
{


    public GameObject player2;
    public float distance = 10.0f, smoothFactor = 5f, width = 256f, height = 256f;
    Vector3 velocity = Vector3.zero;


    void Start()
    {

    }


    void Update()
    {
        if (player2)
        {
            velocity = new Vector3((player2.transform.position.x - transform.position.x) / smoothFactor,
                               (player2.transform.position.y - transform.position.y) / smoothFactor,
                                0);
            transform.position += velocity;
        }
    }
}

