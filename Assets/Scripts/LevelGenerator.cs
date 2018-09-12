using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public static LevelGenerator instance;
    //all level pieces blueprints used to copy from
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    //starting point of the very first level piece 
    public Transform levelStartPoint;
    //all level pieces that are currently in the level
    public List<LevelPiece> pieces = new List<LevelPiece>();

    private void Awake()
    {
        instance = this;
    }

    public void GenerateInitialPieces()
    {
        for(int i = 0; i < 2; i++)
        {
            AddPiece();
        }
    }

    public void AddPiece()
    {
        //pick a random numer 
        int randomIndex = Random.Range(0, levelPrefabs.Count);

        //Instantiate copy of random level prefab and store it in piece variable
        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        //position
        if(pieces.Count == 0)
        {
            //First Piece
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            //Take exit point from last piece as spawn point of new piece 
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        }

        piece.transform.position = spawnPosition;
        pieces.Add(piece);
    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }

    public void RemoveAllPieces()
    {
        LevelPiece currentPiece;

        for(int i = 0; i < pieces.Count; i++)
        {
            currentPiece = pieces[i];
            Destroy(currentPiece.gameObject);
        }
        pieces.Clear();
    }
}
