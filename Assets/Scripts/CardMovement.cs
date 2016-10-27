using UnityEngine;
using System.Collections;

public class CardMovement : MonoBehaviour {

    Vector3 rootPos;

	// Use this for initialization
	void Start() {
        rootPos = new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update() {
	    
	}

    void OnMouseDown() {
        rootPos = transform.position;
    }

    void OnMouseUp() {
        transform.position = rootPos;
    }

    void OnMouseDrag() {
        // Have the card follow the mouse on click
        Camera cam = Camera.main;
        Vector3 newPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        float height = cam.orthographicSize * 2f;
        float width = cam.aspect * height;
        Vector2 camPos = new Vector2(cam.transform.position.x - width / 2, cam.transform.position.y - height / 2);
        Rect view = new Rect(camPos, new Vector2(width, height));

        // Only update x/y coords if it is within bounds of camera view
        if ((newPos.x <= view.x + view.width) && (newPos.x >= view.x)) {
            transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
        }

        if ((newPos.y <= view.y + view.height) && (newPos.y >= view.y)) {
            transform.position = new Vector3(transform.position.x, newPos.y, transform.position.z);
        }
    }
}
