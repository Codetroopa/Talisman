using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth;
    int health;
    int armour;

    public void DoDamage(int dmg) {
        if (armour > 0) {
            dmg = Mathf.Clamp(dmg - armour, 0, int.MaxValue);
            armour--;
        }
        health = Mathf.Clamp(health - dmg, 0, maxHealth);
    }

    public void DoHeal(int heal) {
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
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
