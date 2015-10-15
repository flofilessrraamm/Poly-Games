using UnityEngine;
using System.Collections;

public class Buisson : MonoBehaviour {

    // Use this for initialization

    public GameObject fille, pere, aura;
    bool corrupted, isPere, isFille;
    Sprite buisson, buissonC;

    void Start()
    {
        buisson = Resources.Load("buisson", typeof(Sprite)) as Sprite;
        buissonC = Resources.Load("buisson_corrupt", typeof(Sprite)) as Sprite;
    }

    void Update()
    {
        if (isFille)
        {
            fille.GetComponent<FilleControl>().isDead = true;
        }
        if (isPere && corrupted)
        {
            pere.GetComponent<PereControl>().isDead = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == fille)
        {
            isFille = true;
        }
        if (col.gameObject == pere)
        {
            isPere = true;
        }
        if (col.gameObject == aura)
        {
            corrupted = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = buissonC;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == fille)
        {
            isPere = false;
        }
        if (col.gameObject == pere && corrupted)
        {
            isPere = false;
        }
        if (col.gameObject == aura)
        {
            corrupted = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = buisson;
        }
    }
}
