using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundMonsterMovement : PhysicsObject {
    public Transform player;
    public float maxSpeed = 6;
    public float timeTilChange = 60;
    public float currentTime = 0;
    protected Vector2 move = Vector2.zero;
    public bool check;
    public RaycastHit2D edgeCheck;
    void Start () {
        edgeCheck = Physics2D.Raycast(transform.position -new Vector3(.25f,.35f,0), Vector2.down,10);

    }
    protected override void ComputeVelocity()
    {
        check = edgeCheck.collider == null;
        if (edgeCheck.collider != null) {
            if (Mathf.Abs(player.position.x - transform.position.x) <= 5 && Mathf.Abs(player.position.x - transform.position.x) > .8 && Physics2D.Raycast(transform.position, Vector2.down, 3))
            {
                if (player.position.x > transform.position.x)
                {
                    move = Vector2.right;
                }
                else
                {
                    move = Vector2.left;
                }
                targetVelocity = move * maxSpeed;
            }
            else if (Mathf.Abs(player.position.x - transform.position.x) > 5)
            {
                if (currentTime > timeTilChange)
                {
                    if (Random.value < .333)
                    {
                        move = Vector2.right;
                    }
                    else if (Random.value > .667)
                    {
                        move = Vector2.left;
                    }
                    else
                    {
                        move = Vector2.zero;
                    }
                    currentTime = 0;
                }
                currentTime += 1;
                targetVelocity = move * (maxSpeed - 5);
            }

            else
            {
                move = Vector2.zero;
                targetVelocity = move * maxSpeed;
            }
        }
        else
        {
            move = Vector2.zero;
            targetVelocity = move * maxSpeed;
        }
        Debug.DrawRay(transform.position - new Vector3(.25f,.35f,0), Vector2.down * 10, Color.red);
      

        
       
    }
    

}
