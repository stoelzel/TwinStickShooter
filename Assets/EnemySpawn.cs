using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public GameObject[] Enemies;
	private float timer;
	private float trueTimer;
	public float timeToSpawn;
	private bool active;
	public float aMax;
	public float aMin;
	public float spawnPos;
	public ScoreManager scoreManager;
	public float spawnTimeScale;
	public int fruitToSpawn;
	public float fruitLeft;
	public int wave;
	public int waveLeft;
	private bool roundInter;
	public int round;
	
    // Start is called before the first frame update
    void Start()
    {
        active = false;
		
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
		spawnTimeScale = (Mathf.Pow((scoreManager.comboValue + 1f), 0.05f));
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(!active)
			{
			active = true;
			}
			else
			{
			active = false;
			}
		}
		
		if (waveLeft > 10 && fruitLeft <= 0f)
		{
			if (!roundInter)
			{
			trueTimer = 0f;
			roundInter = true;
			scoreManager.roundInterSm = true;
			}
			else
			{
				if(trueTimer >= 2f)
				{
				waveLeft = 0;
				roundInter = false;
				scoreManager.roundInterSm = false;
				round += 1;
				}
				
			}
		}
		
        if(fruitLeft <= 0f || (timer >= 2f && waveLeft <= 10))
		{
			if(fruitToSpawn <= 0 && !roundInter)
			{
				fruitToSpawn = Random.Range((5), (8));
				wave += 1;
				waveLeft += 1;
				timer = 0f;
			}
		}
		
		timer += (Time.deltaTime * spawnTimeScale);
		trueTimer += Time.deltaTime;
		
		if(timer > timeToSpawn && !roundInter)
		{
			if(active && fruitToSpawn > 0)
			{
			timer = 0;
			FruitSpawn();
			fruitToSpawn -= 1;
			}
		}
		
    }
	
	void FruitSpawn()
	{
		int randomIndex = Random.Range(0, Enemies.Length);
		spawnPos = (Random.Range(-8f, 8f));
		Vector2 randomSpawnPosition = new Vector2((spawnPos), -7);
			
		GameObject newEnemy = Instantiate(Enemies[randomIndex], randomSpawnPosition, transform.rotation);
		newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range((aMin - (spawnPos * 0.25f)), (aMax - (spawnPos * 0.25f))), Random.Range(8f, 9f));
	}
}