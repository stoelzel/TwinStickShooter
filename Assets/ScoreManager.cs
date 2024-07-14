using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	private int bHit;
	private int bMiss;
	private float score;
	public Text scoreText;
	public Text accuracyText;
	public float scoreBase;
	private float comboTime;
	public Text comboText;
	public float comboAdd;
	public float comboMissB;
	public float comboMissF;
	public float comboTimeScale;
	public float comboValue;
	public Text comboValueText;
	private float comboEmergencyTime;
	public float comboETb;
	public float comboStop;
	public bool roundInterSm;
	
    // Start is called before the first frame update
    void Start()
    {
        //possibly add 0s for integers
    }

    // Update is called once per frame
    void Update()
    {
		comboTimeScale = (Mathf.Pow((comboValue + 1), 0.1f));
		
        if (comboTime > 0)
		{
			comboEmergencyTime = comboETb;
			if(comboStop <= 0f && !roundInterSm)
			{
				comboTime -= (Time.deltaTime * comboTimeScale);
			}
		}
		
		if (comboTime <= 0)
		{
			if (comboTime <= -0.2 * comboTimeScale)
			{
				comboEmergencyTime = 0f;
			}
			comboTime = 0f;
			comboEmergencyTime -= Time.deltaTime;
			if(comboEmergencyTime <= 0)
			{
				comboValue = 0f;
			}
		}
		
		if(comboStop > 0f)
		{
			comboStop -= Time.deltaTime;
			if(comboStop > 0.2f)
			{
				comboStop = 0.2f;
			}
		}
		
		if(comboStop < 0f)
		{
			comboStop = 0f;
		}
		
		comboText.text = comboTime.ToString("");
		comboValueText.text = comboValue.ToString("");
    }
	
	public void BulletHit()
	{
		bHit +=1;
		accuracyText.text = Accuracy().ToString("");
	}
	
	public void BulletMiss()
	{
		bMiss +=1;
		accuracyText.text = Accuracy().ToString("");
		comboTime -= comboMissB * comboTimeScale;
	}
	
	public void FruitHit()
	{
		score += scoreBase * (AccuracyBoost() + (1+(comboValue * 0.05f)));
		scoreText.text = score.ToString("#");
		comboTime += comboAdd;
		comboValue += 1f;
		comboStop = 0.2f;
	}
	
	public void FruitMiss()
	{
		comboTime -= comboMissF * comboTimeScale;
	}
	
	public float Accuracy()
	{
		return (float) bHit / (float) (bHit + bMiss);
	}
	
	public float AccuracyBoost()
	{
		return Accuracy() + .5f;
	}
}
