using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector3 firstPosition;
    private Vector3 finalPosition;
    private float swipeAngle;

    void OnMouseDown()
    {
        firstPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void OnMouseUp()
    {
        finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }
    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalPosition.y - firstPosition.y, finalPosition.x - firstPosition.x) * 180 / Mathf.PI;
        MoveTile();
    }

    void MoveTile()
    {
        if (swipeAngle > -45 && swipeAngle <= 45)
        {
            //Right swipe
            Debug.Log("Right swipe");
        }
        else if (swipeAngle > 45 && swipeAngle <= 135)
        {
            //Up swipe
            Debug.Log("Up swipe");
        }
        else if (swipeAngle > 135 || swipeAngle <= -135)
        {
            //Left swipe
            Debug.Log("Left swipe");
        }
        else if (swipeAngle < -45 && swipeAngle >= -135)
        {
            //Down swipe
            Debug.Log("Down swipe");
        }
    }
}
