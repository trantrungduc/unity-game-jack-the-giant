using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float speed = 1f, acceleration = 0.2f, maxSpeed = 3.0f,easySpeed=3.0f,mediumSpeed=3.7f,hardSpeed=4.4f;

    [HideInInspector]
    public bool moveCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (GamePreferences.GetEeasyDifficulty() == 1)
        {
            maxSpeed = easySpeed;
        }
        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            maxSpeed = mediumSpeed;
        }
        if (GamePreferences.GetHardDifficulty() == 1)
        {
            maxSpeed = hardSpeed;
        }
        Debug.Log("Max speed: " + maxSpeed);
        moveCamera = true;    
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCamera)
        {
            MoveCamera();
        }
    }
    void MoveCamera()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y, newY = temp.y - (speed * Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y, oldY, newY);
        transform.position = temp;
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
