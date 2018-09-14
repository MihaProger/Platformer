using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;

    private float GameFieldX = 0;
    private float GameFieldY = 0;
    private float GameFieldWidth = 10.24f;
    private float GameFieldHeigh = 10.24f;

    private Vector2 _movementDirection;

	void Start () {
		
	}
	
	void Update () {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.x != 0) {
            if ((input.x < 0 && transform.position.x < GameFieldX) || (input.x > 0 && transform.position.x > GameFieldWidth - GameFieldX - 0.64f)) {
                return;
            }
            _movementDirection.Set(input.x, 0f);
        } else if (input.y != 0) {
            if ((input.y < 0 && transform.position.y < GameFieldY) || (input.y > 0 && transform.position.y > GameFieldHeigh - GameFieldY)) {
                return;
            }
            _movementDirection.Set(0f, input.y);
        } else {
            _movementDirection = Vector2.zero;
        }



        if (transform.position.x > GameFieldX - 2 && transform.position.y > GameFieldY - 2 && transform.position.x < GameFieldHeigh - GameFieldX + 2 && transform.position.y < GameFieldWidth - GameFieldY + 2) {
            transform.position += (Vector3)_movementDirection * speed * Time.deltaTime;
        }

        
    }
}
