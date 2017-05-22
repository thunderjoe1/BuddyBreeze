using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindlineLifetimeScript : MonoBehaviour {


	void Awake()
	{
		ParticleSystem.Particle.lifetime = .5f;    
	}
}
