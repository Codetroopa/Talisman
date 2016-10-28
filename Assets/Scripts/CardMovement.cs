using UnityEngine;
using System.Collections;

public class CardMovement : MonoBehaviour {

    public float smoothFactor = 5.4f;
    public float maxClamp = 0.1f;

    Vector3 rootPos;
    bool isClicked;
    bool isAtRoot;

	// Use this for initialization
	void Start() {
        rootPos = new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update() {
        // Update boolean
        if (transform.position == rootPos) {
            isAtRoot = true;
        } else {
            isAtRoot = false;
        }

	    // If the card is not clicked, and the card has moved away from its rootPos, we smoothdamp its position
        if (!isClicked && !isAtRoot) {
            transform.position = Vector3.Lerp(transform.position, rootPos, Time.deltaTime * smoothFactor);
        }
	}

    void OnMouseDown() {
        isClicked = true;
    }

    void OnMouseUp() {
        isClicked = false;
    }

    void OnMouseDrag() {
        // Don't move the card if it is "on its way back"
        if (!isAtRoot && !isClicked) return;

        // Have the card follow the mouse on click
        Camera cam = Camera.main;
        Vector3 newPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        float height = cam.orthographicSize * 2f;
        float width = cam.aspect * height;
        Vector2 camPos = new Vector2(cam.transform.position.x - width / 2, cam.transform.position.y - height / 2);
        Rect view = new Rect(camPos, new Vector2(width, height));

        // Update x and y co-ordinates with smoothing
        // I don't want the distance between the card and the mouse to be too high, so I clamp the distance.
        float xTranslate = Mathf.Lerp(transform.position.x, newPos.x, Time.deltaTime * smoothFactor * 2);
        float yTranslate = Mathf.Lerp(transform.position.y, newPos.y, Time.deltaTime * smoothFactor * 2);
        transform.position = MathUtility.ClampVectorDistance(new Vector3(xTranslate, yTranslate, transform.position.z), transform.position, maxClamp);

        // Adjust if out of camera bounds
        if (newPos.x > view.x + view.width) {
            transform.position = new Vector3(view.x + view.width, transform.position.y, transform.position.z);
        }

        if (newPos.x < view.x) {
            transform.position = new Vector3(view.x, transform.position.y, transform.position.z);
        }

        if (newPos.y > view.y + view.height) {
            transform.position = new Vector3(transform.position.x, view.y + view.height, transform.position.z);
        }

        if (newPos.y < view.y) {
            transform.position = new Vector3(transform.position.x, view.y, transform.position.z);
        }
    }
}
