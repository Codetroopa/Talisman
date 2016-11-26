using UnityEngine;
using System.Collections;

public class LogoGlow : MonoBehaviour {

    public Transform particleSys;

    private ParticleSystem sys;

	void Start () {
        // Init particle system
        sys = particleSys.GetComponent<ParticleSystem>();
        if (!sys) Debug.LogError("No particle system attached!");


	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
