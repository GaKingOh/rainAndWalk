using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class colliderTrim : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    BoxCollider2D col;
    readonly List<Vector2> pts = new();

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        Fit();
    }

    public void Fit()
    {
        var sp = sr.sprite;
        if (sp == null) return;

        int shapeCount = sp.GetPhysicsShapeCount();

        // Physics Shape가 없으면 그냥 sprite bounds로
        if (shapeCount == 0)
        {
            col.size = sp.bounds.size;
            col.offset = sp.bounds.center;
            return;
        }

        Vector2 min = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        Vector2 max = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        for (int i = 0; i < shapeCount; i++)
        {
            pts.Clear();
            sp.GetPhysicsShape(i, pts);
            for (int k = 0; k < pts.Count; k++)
            {
                min = Vector2.Min(min, pts[k]);
                max = Vector2.Max(max, pts[k]);
            }
        }

        col.size = max - min;
        col.offset = (min + max) * 0.5f;
    }
}
