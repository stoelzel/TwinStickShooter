using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
	public GameObject Prefab;
	private float timer;
	public float reloadTime;
	
	[SerializeField] private ParticleSystem FiringParticles;
	[SerializeField] private AudioSource fire;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && timer > reloadTime)
		{
			Instantiate(Prefab, transform.position, transform.rotation);
			FiringParticles.Play();
			fire.Play();
			timer = 0;
		}
		
		timer += Time.deltaTime;
    }
}
