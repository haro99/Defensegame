using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject ClearText, GameOverText, Score;
    public int totalpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ゲームクリア
    public void Clear()
    {
        ClearText.SetActive(true);
    }

    //ゲームオーバー
    public void GameOver()
    {
        GameOverText.SetActive(true);
    }

    public void PointAdd(int point)
    {
        totalpoint += point;
        Score.GetComponent<Text>().text = totalpoint.ToString();
    }

    public void Sceneload()
    {
        SceneManager.LoadScene(0);
    }
}
