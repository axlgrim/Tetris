using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    


    private Vector3 _startPosition = new Vector3(0, 18, 0);
    private float _time;




	// Use this for initialization
	void Start () 
    {
        string pieceToLoad = RandomPiece();
        Piece thisPiece = Instantiate(Resources.Load(pieceToLoad, typeof(GameObject)), transform.position = _startPosition, Quaternion.identity) as Piece;
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        _time += Time.deltaTime;

        if (_time > 20.0)
        {
            _time = 0;
            transform.position -= new Vector3(0, 3, 0);
            string pieceToLoad = RandomPiece();
            Piece thisPiece = (Piece)Instantiate(Resources.Load(pieceToLoad, typeof(GameObject)), transform.position = _startPosition, Quaternion.identity);

        }

		
	}

    string RandomPiece()
    {
        int rand = Random.Range(0, 3);
        string pieceName = "Prefabs/B_piece";

        switch (rand)
        {
            case 0:
                pieceName = "Prefabs/J_piece";
                break;

            case 1:

                pieceName = "Prefabs/I_piece";
                break;

            case 2:
                pieceName = "Prefabs/Z_piece";
                break;
                

            default:
                break;
        }

        return pieceName;
    }
}
