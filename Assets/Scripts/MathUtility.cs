using UnityEngine;
using System.Collections;

/// <summary>
/// Contains general Math functions introduced in this project that are not readily found in Unity classes.
/// 
/// </summary>
public class MathUtility : MonoBehaviour {

    /// <summary>
    /// Returns a Vector3 that is at most 'max' distance away from the given vector
    /// </summary>
    /// <param name="mine">The Vector3 to clamp</param>
    /// <param name="other">The Vector3 to compare distance with</param>
    /// <param name="max">The max distance from other Vector3</param>
    /// <returns></returns>
    public static Vector3 ClampVectorDistance(Vector3 mine, Vector3 other, float max) {
        if (Vector3.Distance(mine, other) < max) {
            return mine;
        } else {
            Vector3 val = mine - other;
            val = Vector3.ClampMagnitude(val, max);
            return val + other;
        }
        
    }

    public static Vector2 getCamSize() {
        float h = Camera.main.orthographicSize * 2.0f;
        float w = Camera.main.aspect * h;
        return new Vector2(w, h);
    }
}
