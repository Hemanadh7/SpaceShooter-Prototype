using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {

	public float width, height;
	public float formationSpeed;
	public float spawnDelay = 0.5f;

	public int newFormationCount;

	float formMin,formMax;

	public GameObject enemyPrefab;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;
	public GameObject enemyPrefab4;

	private bool movingRight = true;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftedge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightedge = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		formMin = leftedge.x;
		formMax = rightedge.x;

		SpawnUntilFull ();
	
	}

	void SpawnUntilFull()
	{
		if(newFormationCount <=3 )
		{
			Transform freePosition = NextFreePosition ();
			if (freePosition) 
			{
				GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
				enemy.transform.parent = freePosition;
			}
			if(NextFreePosition())
			{
				Invoke("SpawnUntilFull",spawnDelay);
			}
		}
		if(newFormationCount > 3 && newFormationCount <= 6)
		{
			Transform freePosition = NextFreePosition ();
			if (freePosition) 
			{
				GameObject enemy2 = Instantiate (enemyPrefab2, freePosition.position, Quaternion.identity) as GameObject;
				enemy2.transform.parent = freePosition;
			}
			if(NextFreePosition())
			{
				Invoke("SpawnUntilFull",spawnDelay);
			}
		}
		if(newFormationCount > 6 && newFormationCount <= 9)
		{
			Transform freePosition = NextFreePosition ();
			if (freePosition) 
			{
				GameObject enemy3 = Instantiate (enemyPrefab3, freePosition.position, Quaternion.identity) as GameObject;
				enemy3.transform.parent = freePosition;
			}
			if(NextFreePosition())
			{
				Invoke("SpawnUntilFull",spawnDelay);
			}
		}
		if(newFormationCount > 9)
		{
			Transform freePosition = NextFreePosition ();
			if (freePosition) 
			{
				GameObject enemy4 = Instantiate (enemyPrefab4, freePosition.position, Quaternion.identity) as GameObject;
				enemy4.transform.parent = freePosition;
			}
			if(NextFreePosition())
			{
				Invoke("SpawnUntilFull",spawnDelay);
			}
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube (transform.position,new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update () {

		if (movingRight) {
			transform.Translate (formationSpeed * Time.deltaTime, 0, 0);
		} else {
			transform.Translate (-formationSpeed * Time.deltaTime, 0, 0);
		}

		float leftedgeofformation = transform.position.x - (0.5f * width);
		float rightedgeofformation = transform.position.x + (0.5f * width);

		if (leftedgeofformation < formMin) {
			movingRight = true;
		} else if (rightedgeofformation > formMax) 
		{
			movingRight = false;
		}

		if(AllmembersDead())
		{
			Debug.Log("Empty Formation");
			SpawnUntilFull();
			newFormationCount++;
			Debug.Log(newFormationCount);
		}
	}

	Transform NextFreePosition()
	{
		foreach (Transform childPositiongameObject in transform) 
		{
			if(childPositiongameObject.childCount == 0)
			{
				return childPositiongameObject;
			}
		}
		return null;
	}

	bool AllmembersDead()
	{
		foreach (Transform childCountgameObject in transform) 
		{
			if(childCountgameObject.childCount > 0)
			{
				return false;
			}
		}
		return true;
	}

	void Respawn()
	{
		foreach (Transform child in transform) 
		{
			GameObject enemy = Instantiate (enemyPrefab,child.transform.position,Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
}

