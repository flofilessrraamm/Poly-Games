using UnityEngine;
using System.Collections;

public class Camera2_follow : MonoBehaviour
{


    public GameObject player;
    public float distance = 10.0f, smoothFactor = 5f, width = 256f, height = 256f;
    Vector3 velocity, screenPos;
    Camera aura;
    public Camera main;



    void Start()
    {
        aura = GetComponent<Camera>();

    }


    void Update()
    {
        screenPos = main.WorldToScreenPoint(player.transform.position);
        aura.rect = new Rect((screenPos.x) / Screen.width - width/2,  (screenPos.y) / Screen.height - height/2, width, height);
        /*
        if (player)
        {
            velocity = new Vector3((player.transform.position.x - transform.position.x) / smoothFactor,
                               (player.transform.position.y - transform.position.y) / smoothFactor,
                                0);
            transform.position += velocity;
        }
        */
    }
}

