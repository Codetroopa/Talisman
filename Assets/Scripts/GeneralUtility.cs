using UnityEngine;
using System.Collections;

public class GeneralUtility : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    /// <summary>
    /// Utility function to set the x value of a transform and leave the others unchanged
    /// </summary>
    /// <param name="trans">The transform to update</param>
    /// <param name="val">The x value</param>
    public static void SetTransformX(ref Transform trans, float val) {
        trans.position = new Vector3(val, trans.position.y, trans.position.z);
    }
}
