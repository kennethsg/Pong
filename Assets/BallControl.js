#pragma strict

var ballSpeed : float = 100;

function Start () 
{
	yield WaitForSeconds(2);
	GoBall();
}

function Update()
{
	var xVel : float = GetComponent.<Rigidbody2D>().velocity.x;
	
	if (xVel < 18 && xVel > -18 && xVel != 0)
	{
		if (xVel > 0)
		{
			GetComponent.<Rigidbody2D>().velocity.x = 20;
		}	
		else
		{
			GetComponent.<Rigidbody2D>().velocity.x = -20;
		}
//		Debug.Log("Velocity Before " + xVel);
//		Debug.Log("Velocity After " + rigidbody2D.velocity.x);
	}
}

/**
Makes the ball Y axis velocity be affected by
the velocity and direction of the player Y axis
**/
function OnCollisionEnter2D (colInfo : Collision2D) 
{
	if(colInfo.collider.tag == "Player")
	{
		var velocityY = GetComponent.<Rigidbody2D>().velocity.y;
		var playerVelocityY = colInfo.collider.GetComponent.<Rigidbody2D>().velocity.y;	
		velocityY = velocityY/2 + playerVelocityY/3;
		GetComponent.<Rigidbody2D>().velocity.y = velocityY;
		
		//Play a sound
		GetComponent.<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
		GetComponent.<AudioSource>().Play();
	}
}

//Resets the ball's position and velocity
function ResetBall ()
{
	GetComponent.<Rigidbody2D>().velocity.y = 0;
	GetComponent.<Rigidbody2D>().velocity.x = 0;
	transform.position.x = 0;
	transform.position.y = 0;
	
	yield WaitForSeconds(0.5);
	GoBall();
}

/**
Applies a force to the ball
in a random direction
**/
function GoBall ()
{
	var randomNumber = Random.Range(0, 2);

	if (randomNumber <= 0.5)
	{
		GetComponent.<Rigidbody2D>().AddForce(new Vector2(this.ballSpeed, 10));
	}
	else 
	{
		GetComponent.<Rigidbody2D>().AddForce(new Vector2(-this.ballSpeed, -10));
	}
}