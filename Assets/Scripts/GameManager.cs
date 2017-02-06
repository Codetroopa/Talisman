using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton class for use of general functions across multiple scenes.
/// </summary>
public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    private Tile[,] board;

    // disable use of regular constructor
    private GameManager () { }

    /// <summary>
    /// Get the instance of the GameManager
    /// </summary>
    /// <returns></returns>
	public static GameManager instance() {
        if (_instance == null) {
            _instance = (new GameObject("GMContainer").AddComponent<GameManager>());
        }
        return _instance;
    }

    /// <summary>
    /// Generates a board that fits within the given constraints. startLoc is the top left corner of the starting postition
    /// </summary>
    public void generateBoard(float width, float height, int x, int y, Vector2 startLoc) {
        float tileWidth = width / x;
        float tileHeight = height / y;
        board = new Tile[x, y];

        // create a template for the tiles
        GameObject container = new GameObject("GridContainer");
        GameObject obj = new GameObject();
        BoxCollider2D col = obj.AddComponent<BoxCollider2D>();
        col.size = new Vector2(tileWidth, tileHeight);

        // create a 2d array of Tiles
        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                obj.name = "tile" + i + "-" + j;
                Instantiate(obj, new Vector3(startLoc.x + ((tileWidth * (2 * i + 1)) / 2), 
                    startLoc.y - ((tileHeight * (2 * j + 1)) / 2), 0), Quaternion.identity);
            }
        }
    }

    // For testing purposes. Generates a board that fills the whole camera field of view
    public void generateBoardFromCamera(int x, int y) {
        Camera cam = Camera.main;
        float height = cam.orthographicSize * 2f;
        float width = cam.aspect * height;

        generateBoard(width, height, x, y, new Vector2(cam.transform.position.x - (width / 2), cam.transform.position.y + (height / 2)));
    }

    void Awake() {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
