using UnityEngine;
using System.Collections;

public class Alert : State
{
    public State followState;
    public Color alertColor;
    public float changeRate;
    public float timeToChange;

    private Color normalColor;
    private float timeToExit;
    private float addedTime;

    void OnEnable()
    {
		normalColor = GetComponent<Renderer> ().material.color;
        //normalColor = renderer.material.color;
        timeToExit = 0;
        addedTime = 0;
    }

    void Update()
    {
        timeToExit += Time.deltaTime;
        addedTime += Time.deltaTime;

        if (addedTime >= changeRate)
        {
			if (GetComponent<Renderer> ().material.color.Equals(normalColor)) { GetComponent<Renderer> ().material.color = alertColor; }
			else { GetComponent<Renderer> ().material.color = normalColor; }

            addedTime = 0;
        }
    }

    public override void CheckExit()
    {
        if (timeToExit >= timeToChange)
        {
			GetComponent<Renderer> ().material.color = normalColor;
            stateMachine.ChangeState(followState);
        }
    }
}