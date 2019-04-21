using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float velocity;
    private float _limitOnX;

    void Start()
    {
        Camera cam = Camera.main;
        float platformWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        _limitOnX = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - platformWidth;
    }

    void Update()
    {
        float movementMouseX = Input.GetAxis("Mouse X");
        bool isMouse = System.Math.Abs(movementMouseX) > 0.01;

        float movementKeyboardX = Input.GetAxis("Horizontal");
        bool isKeyboard = System.Math.Abs(movementKeyboardX) > 0.01;

        if (!isMouse && !isKeyboard)
            return;

        float movement = isMouse ? movementMouseX : movementKeyboardX;
        Transform t = GetComponent<Transform>();
        t.position = t.position + (Vector3.right * movement * velocity * Time.deltaTime);
        float currX = t.position.x;
        currX = Mathf.Clamp(currX, -_limitOnX, _limitOnX);
        t.position = new Vector3(currX, t.position.y, t.position.z);
    }
}
