﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton class for use of general functions across multiple scenes.
/// </summary>
public class GameManager : MonoBehaviour {
    //
    // Publics
    //
    public GameObject tilePrefab;

    //
    // Privates
    //
    private static GameManager _instance;
    private Tile[,] board;

    // disable use of regular constructor
    private GameManager () { }

    /// <summary>
    /// Get the instance of the GameManager
    /// </summary>
    /// <returns></returns>
	public static GameManager instance {
        get {
            if (_instance == null) {
                _instance = (new GameObject("GMContainer").AddComponent<GameManager>());
            }
            return _instance;
        }
    }

    /// <summary>
    /// Generates a board that fits within the given constraints. startLoc is the centre of the board
    /// </summary>
    public void generateBoard(float width, float height, int x, int y, Vector2 center) {
        float tileHeight = height / y;
        float tileWidth = tileHeight;

        // create a template for the tiles
        GameObject container = new GameObject("GridContainer");
        container.transform.position = center;

        // create a 2d array of Tiles
        for (int i = Mathf.CeilToInt(y / 2.0f) - 1; i >= -(y / 2); i--) {
            for (int j = -(x / 2); j < Mathf.CeilToInt(x / 2.0f); j++) {
                Vector3 pos = new Vector3(center.x + (j * tileWidth + (((x + 1) % 2) * (tileWidth / 2))),
                   center.y + (i * tileHeight + (((y + 1) % 2) * (tileHeight / 2))), 0);

                // Instantiate prefab and add to Board
                GameObject obj = (GameObject) Instantiate(tilePrefab, container.transform);
                obj.name = "tile(" + (Mathf.CeilToInt(y / 2.0f) - (i + 1)) + "," + (j + x / 2) + ")";
                obj.transform.position = pos;
                BoxCollider2D col = obj.GetComponent<BoxCollider2D>();
                col.size = new Vector2(tileWidth, tileHeight);

                board[Mathf.CeilToInt(y / 2.0f) - (i + 1), j + x / 2] = obj.GetComponent<Tile>();

                //TODO: fill board with user defined 'decklist'
                // populateBoard(BoardState state, blah blah)
                
            }
        }
    }

    // For testing purposes. Generates a board that fills the whole camera field of view
    public void generateBoardFromCamera(int x, int y) {
        Camera cam = Camera.main;
        float height = cam.orthographicSize * 2f;
        float width = cam.aspect * height;
        board = new Tile[x, y];
        
        generateBoard(width, height, x, y, cam.transform.position);
    }

    void Awake() {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
