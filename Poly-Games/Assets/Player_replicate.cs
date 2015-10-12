using UnityEngine;
using System.Collections;

public class Player_replicate : MonoBehaviour {

    public GameObject player;
    public float distance = 41.2f;
    Vector3 position;
    // Use this for initialization

	
	// Update is called once per frame
	void Update () {
        position = new Vector3(player.transform.position.x + distance, player.transform.position.y);
        transform.position = position;
    }
}
