using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    


    private Vector3 _startPosition = new Vector3(0, 18, 0);
    private float _time;


    public static int LeftPosition = -18;
    public static int RightPosition = 18;
    public static int BottomPosition = -18;
    public static int TopPosition = -18;
    public static int gridWidth = 11;
    public static int gridHeight = 14;
    public bool _createNewPiece = false;
    public Score Score;
    public UIManager UIMan;


    public Transform [,] grid = new Transform[gridWidth, gridHeight];

    public Piece thisPiece;



	// Use this for initialization
	void Start () 
    {
        
        string pieceToLoad = RandomPiece();
        thisPiece = Instantiate(Resources.Load(pieceToLoad, typeof(Piece)), transform.position = _startPosition, Quaternion.identity) as Piece;
        Subcribe(thisPiece);
        thisPiece.UIMan = this.UIMan;

	}
	
	// Update is called once per frame
	void Update () 
    {
        if(!UIMan.GameOver)
        {
            _time += Time.deltaTime;

            if (_createNewPiece)
            {
                Unsubcribe(thisPiece);
                string pieceToLoad = RandomPiece();
                thisPiece = Instantiate(Resources.Load(pieceToLoad, typeof(Piece)), transform.position = _startPosition, Quaternion.identity) as Piece;
                Subcribe(thisPiece);
                thisPiece.UIMan = this.UIMan;

                _createNewPiece = false;
            }
            
        }
		
	}

    string RandomPiece()
    {
        int rand = Random.Range(0, 3);
        string pieceName = "Prefabs/B_piece";

        switch (rand)
        {
            case 0:
                pieceName = "Prefabs/I_piece";
                break;

            case 1:

                pieceName = "Prefabs/J_piece";
                break;

            case 2:
                pieceName = "Prefabs/B_piece";
                break;
                

            default:
                break;
        }

        return pieceName;
    }

    public void SetGrid(Piece piece)
    {


        foreach(Transform square in piece.transform)
        {
            Vector3 pos = square.position;

            //if(pos.y+18 < TopPosition)
            {
                Debug.Log(pos.x+15);
                Debug.Log(pos.y+18);
                grid[(int)(((int)pos.x + 15)/3), (int)(((int)pos.y + 18)/3)] = square;


            }

        }

        //Destroy(grid[0, 0].gameObject);
        Debug.Log(grid[0,0]);
        Debug.Log(grid[1, 0]);
        Debug.Log(grid[1, 1]);
        Debug.Log(grid[2, 1]);
    }

    public bool CheckGridIsEmpty(Piece piece)
    {
        foreach(Transform square in piece.transform)
        {
            Vector3 pos = square.position;

            if(grid[(int)(((int)pos.x + 15) / 3), (int)(((int)pos.y + 18) / 3)] != null)
            {
                return false;
            }
        }

        return true;
        
    }


    private void Subcribe(Piece piece)
    {
        
        piece.OnOutOfGame += HandleOutOfGame;
        piece.OnGameOver += HandleGameOver;
        
    }
    private void Unsubcribe(Piece piece)
    {
        
        piece.OnOutOfGame -= HandleOutOfGame;
        piece.OnGameOver -= HandleGameOver;

    }

    private void HandleOutOfGame(Piece piece)
    {
        _createNewPiece = true;
        CheckRows();
    }

    private void HandleGameOver(Piece piece)
    {
        
        UIMan.GameOver = true;
        DestroyAll();
        
    }

    public bool IsInside(Vector3 position)
    {
        return ((int)position.x > LeftPosition && (int)position.x < RightPosition && (int)position.y > BottomPosition);
        
    }

    //Check rows after each piece is ended
    void CheckRows()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            bool deleteRow = true;

            for (int x = 0; x < gridWidth; x++)
            {
                if(grid[x,y] == null)
                {
                    deleteRow = false;
                }
                
            }

            if(deleteRow)
            {
                DeleteRow(y);
            }
        }
        
    }

    void DeleteRow(int row)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            Destroy(grid[x, row].gameObject);
        }

        for (int y = row+1; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if(grid[x, y]!=null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y].position -= new Vector3(0, 3, 0);
                    grid[x, y] = null;
                }
            }
        }


        Score.Scoreint += 100;
        
    }

    void DestroyAll()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if(grid[x,y] != null)
                {
                    Destroy(grid[x, y].gameObject); 
                }

            }
        }
        
    }


}
