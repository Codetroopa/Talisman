﻿using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public int maxAttack;
    int attack;
    bool isDrag = false;
    bool canAttack = true;

	// Use this for initialization
	void Start () {
        attack = maxAttack;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp() {
        if (!isDrag) return;

        // Try and see if the mouse was over a valid target for attacking
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction);

        if (rayHit && rayHit.collider) {
            if (gameObject.Equals(rayHit.collider.gameObject)) return;
            Health enemyHp = rayHit.collider.GetComponent<Health>();
            Attack enemy = rayHit.collider.GetComponent<Attack>();
            if (enemyHp) {
                enemyHp.OnDamage(attack);
                canAttack = false;
            }
            Health hp = GetComponent<Health>();
            if (enemy) {
                hp.OnDamage(enemy.attack);
            }
        }

        isDrag = false;
    }

    void OnMouseDrag() {
        if (attack >= 1) isDrag = true;
    }

}
