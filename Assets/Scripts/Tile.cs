using UnityEngine;
using System.Collections;

/// <summary>
/// Contains generic information and basic methods for a Tile on the board
/// </summary>
public class Tile : MonoBehaviour {

    /// <summary>
    /// Whether or not an object is on this Tile.
    /// </summary>
    bool occupied = false;

    public Tile() {

    }

    /// <summary>
    /// Returns true if this Tile is empty
    /// </summary>
    public bool isEmpty() {
        return occupied;
    }

    public Vector2 getLocation() {
        return gameObject.transform.position;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
