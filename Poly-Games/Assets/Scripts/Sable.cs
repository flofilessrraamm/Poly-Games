using UnityEngine;
using System.Collections;

public class Sable : MonoBehaviour {

    // Use this for initialization

    public GameObject pere, aura;
    bool corrupted;



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == pere && !corrupted)
        {
            pere.GetComponent<PereControl>().isInSable = true;
        }
        if (col.gameObject == aura)
        {
            corrupted = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.333f, 0.333f, 0.333f, 255f);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
            gameObject.layer = 14;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject == pere && pere.GetComponent<PereControl>().isInSable)
        {
            pere.GetComponent<PereControl>().isDead = true;
        }
        if (col.gameObject == aura)
        {
            corrupted = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 0.9f);
            gameObject.layer = 13;
        }
    }
}
