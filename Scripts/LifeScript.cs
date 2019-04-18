using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour {

	public Text life;
	public PlayerController player;

	// Use this for initialization
	void Start () 
	{
		life.text =  "3";
	}
	
	// Update is called once per frame
	void Update () 
	{
		life.text = PlayerController.Lives.ToString();
	}
}
