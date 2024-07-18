using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public GameObject Enemy;
	public ScoreManager scoreManager;
	public EnemySpawn enemySpawn;
	private bool isHit;
	public GameObject particles;
	public CameraShake cameraShake;
	public SoundFruit soundFruit;
	public GameObject sound;
	
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreManagerObject = GameObject.Find("Score Manager");
		scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
		
		GameObject enemySpawnObject = GameObject.Find("EnemySpawn");
		enemySpawn = enemySpawnObject.GetComponent<EnemySpawn>();
		
		GameObject cameraShakeObject = GameObject.Find("Main Camera");
		cameraShake = cameraShakeObject.GetComponent<CameraShake>();
		
		GameObject soundFruitObject = GameObject.Find("Sound Fruit");
		soundFruit = soundFruitObject.GetComponent<SoundFruit>();
		
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
			Instantiate(particles, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
			cameraShake.timer = 0.1f;
			soundFruit.PlaySounds();
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
