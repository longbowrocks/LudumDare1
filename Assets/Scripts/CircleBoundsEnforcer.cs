using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoundsEnforcer : MonoBehaviour
{
    public float circleRadius;
    private Vector2 center;
    // Start is called before the first frame update
    void Start()
    {
        center = gameObject.transform.position;
        var line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 50;
        for (int i=0; i<line.positionCount; i++)
        {
            float x = Mathf.Sin(2 * Mathf.PI * i / line.positionCount);
            float y = Mathf.Cos(2 * Mathf.PI * i / line.positionCount);
            x *= circleRadius;
            y *= circleRadius;
            x += center.x;
            y += center.y;
            line.SetPosition(i, new Vector3(x, y, 0));
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var rigidBodies = GetComponentsInChildren<Rigidbody2D>();
        foreach (var rigidBody in rigidBodies)
        {
            var oldPos = rigidBody.position;
            var relativetoCenterPos = oldPos - center;
            if (relativetoCenterPos.magnitude > circleRadius - GameController.PLAYER_RADIUS)
            {
                relativetoCenterPos *= (circleRadius - GameController.PLAYER_RADIUS) / relativetoCenterPos.magnitude;
                rigidBody.position = center + relativetoCenterPos;
                rigidBody.velocity = Vector2.zero;
            }
        }
    }
}
