using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class CombatantDeath : MonoBehaviour {

    Health hp;

	// Use this for initialization
	void Start () {
        hp = gameObject.GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (hp.getHealth() == 0) {
            Destroy(gameObject);
            //TODO: Fancy death animations
        }
	}
}
