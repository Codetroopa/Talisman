using UnityEngine;
using System.Collections;

/// <summary>
/// Enforces that the sprite is scaled to fit in the Parent's BoxCollider of this object
/// </summary>
[RequireComponent (typeof(SpriteRenderer))]
public class SpriteScale : MonoBehaviour {

	void Start () {
        // required vars
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        BoxCollider2D col = GetComponentInParent<BoxCollider2D>();

        // change transform scale
        transform.localScale = new Vector3(
            col.size.x / rend.sprite.bounds.size.x,
            col.size.y / rend.sprite.bounds.size.y, transform.localScale.z);
    }
	

}
