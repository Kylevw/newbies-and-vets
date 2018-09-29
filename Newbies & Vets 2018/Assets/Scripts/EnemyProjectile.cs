using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public float speed;

    private Transform player;
    private Vector2 target;

    Transform closerPlayer;

	// Use this for initialization
	void Start () {

        //Check which player is closer
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player1").transform.position) <= Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player2").transform.position))
        {
            closerPlayer = GameObject.FindGameObjectWithTag("Player1").transform;
        }
        else if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player1").transform.position ) > Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player2").transform.position))
        {
            closerPlayer = GameObject.FindGameObjectWithTag("Player2").transform;
        }
        //else if(Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player1").transform.position) == Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player2").transform.position))
        //{
        //    closerPlayer = GameObject.FindGameObjectWithTag("Player1").transform;
        //}

        //Set target location
        target = new Vector2(closerPlayer.position.x, closerPlayer.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}
}
