using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class Tile : MonoBehaviour {

    /// <summary>
    /// The object that is on this Tile. Can be null.
    /// </summary>
    public GameObject obj = null;

    /// <summary>
    /// Returns true if this Tile is empty
    /// </summary>
    public bool isEmpty() {
        return (obj == null);
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
