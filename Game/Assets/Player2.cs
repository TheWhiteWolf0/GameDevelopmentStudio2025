using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float movementSpeed = 1f;

    // Update is called once per frame
    void Update()
    {

        Vector2 input = new Vector2(Input.GetAxis("HorizontalPlayer2"), Input.GetAxis("VerticalPlayer2"));

        if (input.magnitude > 0)
        {
            Vector2 movement = input.normalized * (movementSpeed * Time.deltaTime);

            transform.Translate(movement, Space.World);

            float angle = Mathf.Atan2(input.y, input.x);
            transform.rotation = Quaternion.Euler(0,0, angle);
        }


    }
}