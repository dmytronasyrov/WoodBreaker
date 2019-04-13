using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float velocity;
    public float limitOnX;

    void Start()
    {
    
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
        currX = Mathf.Clamp(currX, -limitOnX, limitOnX);
        t.position = new Vector3(currX, t.position.y, t.position.z);
    }
}
