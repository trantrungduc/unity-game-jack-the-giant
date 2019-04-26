using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveJoystick playerMoveJoystick;

    public void Start()
    {
        playerMoveJoystick = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();

    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left")
        {
            playerMoveJoystick.SetMoveLeft(true);
        }
        else
        {
            playerMoveJoystick.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMoveJoystick.StopMoving();
    }
}
