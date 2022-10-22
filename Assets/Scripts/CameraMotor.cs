using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt; // за кем следить
    public float boundX = 0.15f; // расстояния для следования камеры 
    public float boundY = 0.05f;

    private void LateUpdate()  // лейт не просто апдейт чтобы не было задержки 
    {
        Vector3 delta = Vector3.zero;
        // слежение за объектом (lookAt)
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }

        }


        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }
        // обновление позиции х у камеры
        transform.position += new Vector3(delta.x, delta.y, 0);

    }
}
