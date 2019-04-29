//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ScreenBoundsEnforcer : MonoBehaviour
//{
//    private Vector2 screenBounds;
//    private Vector2 boundedGameObjectExtents;
//    public float maxTravelX;
//    public float maxTravelY;
//    // Start is called before the first frame update
//    void Start()
//    {
//        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
//        var boundedObjectRenderer = GetComponent<SpriteRenderer>();
//        boundedGameObjectExtents = boundedObjectRenderer.bounds.extents;
//        maxTravelX = screenBounds.x - boundedGameObjectExtents.x;
//        maxTravelY = screenBounds.y - boundedGameObjectExtents.y;
//    }

//    // Update is called once per frame
//    void LateUpdate()
//    {
//        Vector3 viewPos = transform.position;
//        viewPos.x = Mathf.Clamp(viewPos.x, -maxTravelX, maxTravelX);
//        viewPos.y = Mathf.Clamp(viewPos.y, -maxTravelY, maxTravelY);
//        transform.position = viewPos;
//    }
//}
