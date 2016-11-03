using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public int attack;
    bool isDrag = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp() {
        if (!isDrag) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction);

        isDrag = false;
    }

    void OnMouseDrag() {
        isDrag = true;
    }

}
