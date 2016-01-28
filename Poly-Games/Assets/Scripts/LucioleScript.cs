using UnityEngine;
using System.Collections;

public class LucioleScript : MonoBehaviour {

    // Use this for initialization
    Vector3 PositionInit;
    public float t, speed = 1;
    public int anim;

	void Start () {
        PositionInit = transform.position;
	}

    // Update is called once per frame
    void Update() {
        t += Time.deltaTime;
        switch (anim) {
            case 0:
                transform.position = new Vector3(PositionInit.x + Mathf.Cos(t * speed), PositionInit.y + (Mathf.Cos(t * speed) * Mathf.Sin(t * speed)), PositionInit.z);
            break;
            case 1:
                transform.position = new Vector3(PositionInit.x + (Mathf.Sin(t * speed)*((Mathf.Exp(Mathf.Cos(t * speed)) - 2 * Mathf.Cos(4 * t * speed) - (Mathf.Sin(Mathf.Pow(t * speed / 12 , 5)))))), PositionInit.y + (Mathf.Cos(t * speed) * ((Mathf.Exp(Mathf.Cos(t * speed)) - 2 * Mathf.Cos(4 * t * speed) - (Mathf.Sin(Mathf.Pow(t * speed / 12, 5)))))), PositionInit.z);
            break;
            default:
            break;
    }
	}
}
