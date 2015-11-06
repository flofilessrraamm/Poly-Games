using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public int startingLives = 5, currentLives = 4;

    public Vector3 oldTotemPosition, initTotemPos, oldCameraPosition;

    public bool totemUpdated = true, isOG;

    void Awake()
    {
        GameController OG = GameObject.Find("GameController").GetComponent<GameController>();
        if (instance != null && instance != this || OG.isOG && OG!=this)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        isOG = true;
    }
    void Start()
    {
        initTotemPos = GameObject.Find("totem").transform.position;
        Debug.Log("r pour reset");
    }
    void Update()
    {
        if(!totemUpdated)
            GameObject.Find("totem").GetComponent<TotemScript>().Descend();
    }



    

}

