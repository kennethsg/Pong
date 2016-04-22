#pragma strict

var mainCam : Camera;

var screenTopRightCorner : Vector2;

var topWall : BoxCollider2D;
var bottomWall : BoxCollider2D;
var leftWall : BoxCollider2D;
var rightWall : BoxCollider2D;

var Player01 : Transform;
var Player02 : Transform;

function Start () 
{
	//Place the top right corner in world units according to the screen size
	setScreenTopRightCorner();
	
	//Place the border walls
	setTopWall();
	setBottomWall();
	setRightWall();
	setLeftWall();
	
	//Position the players
	Player01.position.x = mainCam.ScreenToWorldPoint(new Vector3 (75f, 0f, 0f)).x;
	Player02.position.x = mainCam.ScreenToWorldPoint(new Vector3 (Screen.width - 75f , 0f, 0f)).x;
}

/**
Sets a point at the top right corner
of the screen in world units
**/
function setScreenTopRightCorner()
{
	var screenPoint : Vector3 = new Vector3(Screen.width, Screen.height, 0f);
	var worldPoint : Vector3 = mainCam.ScreenToWorldPoint(screenPoint);
	
	this.screenTopRightCorner = new Vector2(worldPoint.x, worldPoint.y);
}

//Build and position a wall
function setTopWall()
{
	this.topWall.size = new Vector2(screenTopRightCorner.x * 2f, 1f);
	this.topWall.offset = new Vector2(0f, screenTopRightCorner.y + 0.5f);
}

//Build and position a wall
function setBottomWall()
{
	this.bottomWall.size = new Vector2(screenTopRightCorner.x * 2f, 1f);
	this.bottomWall.offset = new Vector2(0f, -(screenTopRightCorner.y + 0.5f));
}

//Build and position a wall
function setRightWall()
{
	this.rightWall.size = new Vector2(1f, screenTopRightCorner.y * 2f);
	this.rightWall.offset = new Vector2(screenTopRightCorner.x + 0.5f, 0f);
}

//Build and position a wall
function setLeftWall()
{
	this.leftWall.size = new Vector2(1f, screenTopRightCorner.y * 2f);
	this.leftWall.offset = new Vector2(-(screenTopRightCorner.x + 0.5f), 0f);
}