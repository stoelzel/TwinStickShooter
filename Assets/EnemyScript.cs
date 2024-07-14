using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public GameObject Enemy;
	public ScoreManager scoreManager;
	public EnemySpawn enemySpawn;
	private bool isHit;
	
	[SerializeField] private ParticleSystem deathpart;
	
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreManagerObject = GameObject.Find("Score Manager");
		scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
		
		GameObject enemySpawnObject = GameObject.Find("EnemySpawn");
		enemySpawn = enemySpawnObject.GetComponent<EnemySpawn>();
		
		enemySpawn.fruitLeft += 1f;
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			isHit = true;
			//needs to be seperated from body before destruction
			deathpart.Play();
			scoreManager.FruitHit();
			enemySpawn.fruitLeft -= 1f;
			Destroy(Enemy);
		}
	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Area")
		{
			if (!isHit)
			{
				enemySpawn.fruitLeft -= 1f;
				Destroy(Enemy);
				scoreManager.FruitMiss();
			}
		}
	}
}
