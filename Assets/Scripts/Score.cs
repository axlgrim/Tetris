using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    public TextMeshProUGUI _scoreText;
    public int Scoreint = 0;
    private int _changed = 0;
    private Animator animator;


	// Use this for initialization
	void Start () 
    {
        _scoreText.text = "0";
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Scoreint > _changed)
        {
            animator.SetTrigger("ScoreChanged");
            _changed = Scoreint;
        }
        _scoreText.text = Scoreint.ToString();


	}
}
