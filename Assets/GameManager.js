#pragma strict

static var playerScore01 : int = 0;
static var playerScore02 : int = 0;

var skin : GUISkin;

var ball : Transform;

function Start ()
{
	ball = GameObject.FindGameObjectWithTag("Ball").transform;
	ResetScore();
}

static function Score (wallName : String) 
{
	if (wallName == "rightWall")
	{
		playerScore01 += 1;
	}
	else
	{
		playerScore02 += 1;
	}
//	Debug.Log("Player 1 Score is " + playerScore01);
//	Debug.Log("Player 2 Score is " + playerScore02);
}

function ResetScore()
{
	playerScore01 = 0;
	playerScore02 = 0;
	this.ball.gameObject.SendMessage("ResetBall");
}

function OnGUI ()
{
	GUI.skin = this.skin;
	GUI.Label(new Rect (Screen.width/2-150-18, 80, 100, 100), "" + playerScore01);
	GUI.Label(new Rect (Screen.width/2+150, 80, 100, 100), "" + playerScore02);
/**	
	if (GUI.Button (new Rect (Screen.width/2-(121/2), 35, 121, 53), "RESET"))
	{
		playerScore01 = 0;
		playerScore02 = 0;
		
		this.ball.gameObject.SendMessage("ResetBall");
	}
**/
}