using UnityEngine;
using System.Collections;

public class Camera1_follow : MonoBehaviour {


    public GameObject player;
    public float distance = 10.0f, smoothFactor = 5f;
    Vector3 velocity = Vector3.zero;


    void Start() {

    }


    void Update()
    {
        if (player)
        {
            velocity = new Vector3((player.transform.position.x - transform.position.x) / smoothFactor,
                               (player.transform.position.y - transform.position.y) / smoothFactor,
                                0);
            transform.position += velocity;
        }
    }
}
