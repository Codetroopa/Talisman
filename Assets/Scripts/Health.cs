using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    int maxHealth;
    int health;
    int armour;

    public void OnDamage(int dmg) {
        if (armour >= 0) {
            dmg = Mathf.Clamp(dmg - armour, 0, int.MaxValue);
            armour--;
        }
        health = Mathf.Clamp(health - dmg, 0, maxHealth);
    }

    public void OnHeal(int heal) {
        health = Mathf.Clamp(health + heal, 0, maxHealth);
    }

    // Public getters
    public int getHealth() {
        return health;
    }

    public int getArmour() {
        return armour;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
