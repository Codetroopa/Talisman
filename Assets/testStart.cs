using UnityEngine;
using System.Collections;

public class testStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.instance().generateBoardFromCamera(8, 8);
	}
	
}
