using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Points[] points = new Points[4];
    Vector2 gizmosPosition;

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * points[0].transform.position +
                3 * Mathf.Pow(1 - t, 2) * t * points[1].transform.position +
                3 * (1 - t) * Mathf.Pow(t, 2) * points[2].transform.position +
                Mathf.Pow(t, 3) * points[3].transform.position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(points[0].transform.position.x, points[0].transform.position.y),
            new Vector2(points[1].transform.position.x, points[1].transform.position.y));

        Gizmos.DrawLine(new Vector2(points[2].transform.position.x, points[2].transform.position.y),
           new Vector2(points[3].transform.position.x, points[3].transform.position.y));
    }
}
