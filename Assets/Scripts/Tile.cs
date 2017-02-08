using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class Tile : MonoBehaviour {

    /// <summary>
    /// Whether or not an object is on this Tile.
    /// </summary>
    bool occupied = false;

    /// <summary>
    /// Returns true if this Tile is empty
    /// </summary>
    public bool isEmpty() {
        return occupied;
    }

    public Tile() {

    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
