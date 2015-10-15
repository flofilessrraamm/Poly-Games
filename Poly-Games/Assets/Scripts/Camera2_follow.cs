using UnityEngine;
using System.Collections;

public class Camera2_follow : MonoBehaviour
{


    public GameObject player;
    public float distance = 10.0f, smoothFactor = 5f, nbCasesAura = 3f;
    private BoxCollider2D auraCollider;
    Vector3 screenPos;
    Camera aura;
    public Camera main;



    void Start()
    {
        aura = GetComponent<Camera>();
        auraCollider = GetComponent<BoxCollider2D>();
        auraCollider.size = new Vector2(nbCasesAura, nbCasesAura);

    }


    void Update()
    {
        float grandeurAura = nbCasesAura * Screen.height / (main.orthographicSize * 2f);
        screenPos = main.WorldToScreenPoint(player.transform.position);
        aura.pixelRect = new Rect(screenPos.x - (grandeurAura) /2, screenPos.y - (grandeurAura) / 2, grandeurAura, grandeurAura);
        aura.orthographicSize = nbCasesAura/2;
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

