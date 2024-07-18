using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float timer;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    void Update()
    {
		
		if (timer >= 0)
		{
			timer -= Time.deltaTime;
			CameraShaker();
		}
		
		if (timer < 0)
		{
			timer = 0f;
			transform.position = new Vector3(0f, 0f, -10f);
		}
    }
	
	void CameraShaker()
	{
		transform.position = new Vector3((Random.Range(-0.1f, 0.1f)), (Random.Range(-0.1f, 0.1f)), -10f);
	}
}