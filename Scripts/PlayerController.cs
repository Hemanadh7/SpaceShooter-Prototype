using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float xSpeed;
	public float padding = 1;
	public float projectileSpeed;
	public float fireRate;
	public float Health = 300f;

	public static int Lives = 3;
	
	public GameObject laserProjectile;
	//public Camera playCamera;

	public Transform leftShooter;
	public Transform rightShooter;

	private float xMin;
	private float xMax;

	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;

	}
	void Fire(){
		Vector3 offset = new Vector3 (0,0.5f,0);
		GameObject projectileL;
		projectileL = Instantiate(laserProjectile,leftShooter.position + offset,leftShooter.rotation) as GameObject;
		GameObject projectileR = Instantiate(laserProjectile,rightShooter.position + offset,rightShooter.rotation) as GameObject;
		projectileL.GetComponent<Rigidbody2D>().velocity = new Vector3(0,projectileSpeed,0);
		projectileR.GetComponent<Rigidbody2D>().velocity = new Vector3(0,projectileSpeed,0);
		GetComponent<AudioSource>().Play();
	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
		{
			//Controls the Fire rate of the ship by using 'Invoke' method.
			InvokeRepeating("Fire",0.000001f,fireRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			CancelInvoke("Fire");
		}

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			//move ship towards left.
			transform.Translate(-xSpeed*Time.deltaTime,0,0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			//move ship towards right.
			transform.Translate(xSpeed*Time.deltaTime,0,0);
		}
		float newX = Mathf.Clamp (transform.position.x,xMin,xMax);
		transform.position = new Vector3 (newX,transform.position.y,transform.position.z);
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		missile.Hit ();
		if (missile) 
		{
			Health -= missile.GetDamage();
			if(Health<=0)
			{
				Destroy(gameObject);
				Lives--;
			}
		}

	}
}
