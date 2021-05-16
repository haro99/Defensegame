using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status{
        Ready,
        Run,
        Wait
}
public class Enemyset : MonoBehaviour
{


    public GameObject Soldier;
    public Status status;
    public int count, phase;

    // Start is called before the first frame update
    void Start()
    {
        phase++;
        Debug.Log(phase);
        status = Status.Wait;
        StartCoroutine("setEnemy");

    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case Status.Ready:
                phase++;
                Debug.Log(phase);
                status = Status.Run;
                break;

            case Status.Run:
                status = Status.Wait;
                StartCoroutine("setEnemy");
                break;
        }
    }

    IEnumerator setEnemy()
    {
        while (count < 5)
        {
            Instantiate(Soldier, new Vector3(-10, 3, 0), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            count++;
        }

    }

    public void Enemydead()
    {
        count--;
        if (count == 0)
        {
            status = Status.Ready;
        }
    }
}
