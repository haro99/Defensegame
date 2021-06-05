using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemymove : MonoBehaviour
{
    public GameObject GameManager;
    public LineManager lineManager;
    public Slider Hpslider;
    public Vector3 nextposition;
    public int hp, nextnumber, maxnumber, dropmoney;

    // Start is called before the first frame update
    void Start()
    {
        lineManager = GameObject.Find("LineManager").GetComponent<LineManager>();
        GameManager = GameObject.Find("GameManager");
        maxnumber = lineManager.getLinenumber();
        nextposition = lineManager.Nextposition(nextnumber);
    }

    // Update is called once per frame
    void Update()
    {
        //次の位置の距離の計算
        Vector3 distance = nextposition - transform.position;

        //1フレームの移動計算
        transform.position += distance.normalized * Time.deltaTime;

        //次の位置のベクトルが0.05未満だったら
        if (Mathf.Abs(distance.magnitude) < 0.05f)
        {
            //次の位置を参照する
            transform.position = nextposition;
            nextnumber++;
            if (nextnumber < maxnumber)
            {
                nextposition = lineManager.Nextposition(nextnumber);

            }
            else
            {

                Debug.Log("ハートが減りました");
                GameManager.GetComponent<GameManager>().LifeDamage();
                Destroy(gameObject);
            }
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log(hp);
        Hpslider.value = hp;

        if (hp <= 0)
        {
            Debug.Log("倒されました");
            GameManager.GetComponent<GameManager>().Enemydead(dropmoney);
            Destroy(gameObject);
        }
    }
}
