using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PhysicsObject {
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
	// Use this for initialization
	void Start () {
		
	}
	
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        
        targetVelocity = move*maxSpeed;
    }
}
