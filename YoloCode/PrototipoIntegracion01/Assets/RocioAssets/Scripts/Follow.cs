using UnityEngine;
using System.Collections;

public class Follow : State
{
    public State alertState;
    public GameObject player;
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.Normalize(player.transform.position - transform.position) * speed * Time.deltaTime);
    }

    public override void CheckExit()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            stateMachine.ChangeState(alertState);
        }
    }
}
