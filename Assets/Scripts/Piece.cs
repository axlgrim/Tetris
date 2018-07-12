using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

    private float _time;
    private Vector3 _startPosition = new Vector3(0, 18, 0);

    public bool InGame = true;
    public bool Pause;
    public UIManager UIMan;


    public event Action<Piece> OnOutOfGame;
    public event Action<Piece> OnGameOver;




	// Use this for initialization
	void Start () 
    {
        
        
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(transform.position == _startPosition)
        {
            if(!FindObjectOfType<GameManager>().CheckGridIsEmpty(this))
            {
                if (OnGameOver != null)
                {
                    OnGameOver(this);
                }
                InGame = false;
            }
            
        }

        _time += Time.deltaTime;

        if(InGame)
        {
            if (_time > 1.0)
            {
                _time = 0;
                transform.position -= new Vector3(0, 3, 0);
                if(!FindObjectOfType<GameManager>().CheckGridIsEmpty(this))
                {
                    transform.position += new Vector3(0, 3, 0);
                    FindObjectOfType<GameManager>().SetGrid(this);
                    InGame = false;
                }
            }
            if(InGame)
            {
               CheckInput(); 
            }


            //InGame = FindObjectOfType<GameManager>().CheckGridIsEmpty(this);
        }
        else
        {
            FindObjectOfType<GameManager>().SetGrid(this);
            if(OnOutOfGame!= null)
            {
                OnOutOfGame(this); 
            }

        }




	}

    void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
             
            transform.position += new Vector3(3, 0, 0);
            if(!CheckPosition() || !FindObjectOfType<GameManager>().CheckGridIsEmpty(this))
            {
                StepLeft(); 
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            transform.position += new Vector3(-3, 0, 0);
            //CheckMovement();
            if (!CheckPosition() || !FindObjectOfType<GameManager>().CheckGridIsEmpty(this))
            {
                StepRight();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            transform.Rotate(0, 0, 90);
            //CheckMovement();
            if (!CheckPosition() || !FindObjectOfType<GameManager>().CheckGridIsEmpty(this))
            {
                transform.Rotate (0, 0, -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            

            transform.Rotate(0, 0, 90);

            if (!CheckPosition() || !FindObjectOfType<GameManager>().CheckGridIsEmpty(this))
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && transform.position.y > -15)
        {
            transform.position -= new Vector3(0, 3, 0);
            Pause = true;
            if (!CheckPosition()|| !FindObjectOfType<GameManager>().CheckGridIsEmpty(this))
            {
                transform.position += new Vector3(0, 3, 0);
                FindObjectOfType<GameManager>().SetGrid(this);
                InGame = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(UIMan.IsPaused)
            {
                UIMan.IsPaused = false;
            }
            else
            {
                UIMan.IsPaused = true;
            }

        }
        else if(!CheckPosition())
        {
            InGame = false;
            
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

    bool CheckPosition()
    {
        foreach(Transform square in transform)
        {
            Vector3 pos = square.position;
            if(FindObjectOfType<GameManager>().IsInside(pos) == false)
            {
                return false;
            }
        }
        return true;

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
                square.position = new Vector3(square.position.x, -18, 0);
                InGame = false;
                FindObjectOfType<GameManager>().SetGrid(this);
            }
        }
        
    }
}
