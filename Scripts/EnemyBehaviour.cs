using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 200f;
	public float laserSpeed = 20f;
	public float shotsperSeconds = 1f;
	public int enemyValue = 100;

	public AudioClip enemyShoot;
	public AudioClip enemyDie;

	public ScoreScript Score;
	public GameObject enemyProjectile;

	void Start()
	{
		Score = GameObject.FindObjectOfType<ScoreScript>();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		missile.Hit ();
		if (missile) 
		{
			health -= missile.GetDamage();
			if(health<=0)
			{
				AudioSource.PlayClipAtPoint(enemyDie,transform.position);
				Destroy(gameObject);
				Score.PlayerScore(enemyValue);
			}
		}
	}

	void Update()
	{
		float probability = Time.deltaTime * shotsperSeconds;
		if (Random.value < probability) 
		{
			AudioSource.PlayClipAtPoint(enemyShoot,transform.position);
			Shoot ();
		}
	}

	void Shoot()
	{
		Vector3 offset = transform.position + new Vector3 (0,-1,0);
		GameObject missile;
		missile = Instantiate (enemyProjectile,offset ,Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,-laserSpeed);
	}
}
