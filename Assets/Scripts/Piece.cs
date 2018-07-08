using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

    private float _time;
    private bool _allowLeft = true;
    private bool _allowRight = true;
    public bool InGame = true;




	// Use this for initialization
	void Start () 
    {
        
        
	}
	
	// Update is called once per frame
	void Update () 
	{
        _time += Time.deltaTime;

        if(InGame)
        {
            if (_time > 1.0)
            {
                _time = 0;
                transform.position -= new Vector3(0, 3, 0);
            }
            CheckInput();

            CheckYPos();


        }




	}

    void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
             
            transform.position += new Vector3(3, 0, 0);
            CheckMovement();
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            transform.position += new Vector3(-3, 0, 0);
            CheckMovement();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            transform.Rotate(0, 0, -90);
            CheckMovement();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
             
            transform.Rotate(0, 0, 90);
            CheckMovement();
        }
    }

    void CheckMovement()
    {
        
        foreach (Transform square in transform)
        {
            Vector3 pos = square.position;
            if(pos.x.Equals(18))
            {
                StepLeft();
            }


            if(pos.x.Equals(-18))
            {
                StepRight();
            }
            Debug.Log(pos.x);

        }
        
    }
    void StepLeft()
    {
        transform.position += new Vector3(-3, 0, 0);
    }

    void StepRight()
    {
        transform.position += new Vector3(3, 0, 0);
    }

    void CheckYPos()
    {
        foreach (Transform square in transform)
        {
            Vector3 pos = square.position;
            if (pos.y <= -18)
            {
                InGame = false;
            }
        }
        
    }
}
