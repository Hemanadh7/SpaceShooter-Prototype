using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveCounter : MonoBehaviour {

	public FormationController formationController;
	public Text waveCounter;

	// Use this for initialization
	void Start () 
	{
		waveCounter.text = formationController.newFormationCount.ToString() ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		waveCounter.text = formationController.newFormationCount.ToString() ;
	}
}
