using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public PlayerController player;
	public GameObject playerObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
			if (PlayerController.Lives > 0 && Input.GetKeyDown(KeyCode.C) && transform.childCount <= 0)
			{
			GameObject go = Instantiate(playerObj) as GameObject;
			go.transform.parent = transform;
			}
			if (PlayerController.Lives <= 0)
			{
				LevelManager manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
				manager.LoadLevel("Win Screen");
			}
		}
}
