using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float Bulletspeed;
	public GameObject Bullet1;
	public ScoreManager scoreManager;
	private bool isHit;
	
    // Start is called before the first frame update
    void Start()
    {
		GameObject scoreManagerObject = GameObject.Find("Score Manager");
		if (scoreManagerObject == null)
		{
			Debug.Log("scoreManagerObject not found");
		}
		scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
		if (scoreManager == null)
		{
			Debug.Log("scoreManager not found");
		}
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * Bulletspeed);
    }
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			scoreManager.BulletHit();
			isHit = true;
			Destroy(Bullet1);
		}
	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Area")
		{
			if (!isHit)
			{
				scoreManager.BulletMiss();
				Destroy(Bullet1);
			}
		}
	}
}
