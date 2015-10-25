using UnityEngine;
using System.Collections;

public class PerePhysics : MonoBehaviour
{

    public LayerMask collisionMask;
    [HideInInspector]
    public bool grounded;
    private BoxCollider2D boxCollider;
    private Vector2 c, s;
    [HideInInspector]
    public float deltaX, deltaY;
    public float skin = .005f;
    Ray2D ray;
    RaycastHit2D hit;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        c = boxCollider.offset;
        s = boxCollider.size;

    }

    // Use this for initialization
    public void Move(Vector3 moveAmount)
    {
        deltaY = moveAmount.y;
        deltaX = moveAmount.x;
        Vector2 p = transform.position;

        grounded = false;

        //collisions haut/bas
        for (int i = 0; i < 3; i++)
        {
            float dir = Mathf.Sign(deltaY);
            float x = (p.x + c.x - s.x / 2) + s.x / 2 * i;
            float y = p.y + c.y + s.y / 2 * dir;
            Vector2 origin = new Vector2(x, y);
            ray = new Ray2D(origin, new Vector2(0, dir));
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Abs(deltaY), collisionMask);

            Debug.DrawRay(ray.origin, ray.direction);
            if (hit)
            {
                float dst = Vector2.Distance(origin, hit.point);
                if (dst > skin)
                {
                    deltaY = dir * dst - dir * skin;
                }
                else
                {
                    deltaY = 0;
                }
                grounded = true;
                break;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            float dir = Mathf.Sign(deltaX);
            float x = p.x + c.x + s.x / 2 * dir;
            float y = (p.y + c.y - s.y / 2) + s.y / 2 * i;
            Vector2 origin = new Vector2(x, y);
            ray = new Ray2D(origin, new Vector2(dir, 0));
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Abs(deltaX), collisionMask);

            Debug.DrawRay(ray.origin, ray.direction);
            if (hit)
            {
                float dst = Vector2.Distance(origin, hit.point);

                if (dst > skin)
                {
                    deltaX = dir * dst - dir * skin;
                }
                else
                {
                    deltaX = 0;
                }
                break;
            }
        }

        Vector3 transformMod = new Vector3(deltaX, deltaY, 0);

        transform.position += transformMod;
    }
}

