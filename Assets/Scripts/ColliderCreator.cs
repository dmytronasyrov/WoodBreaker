using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCreator : MonoBehaviour
{

    public Camera cam;
    public EdgeCollider2D edgeCollider;

    void Start()
    {
        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topLeft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 bottomRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        edgeCollider.points = new Vector2[5] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
    }

    void Update()
    {

    }
}
