using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDefense : MonoBehaviour
{
    public List<GameObject> Target = new List<GameObject>();
    public GameObject Attackobj, Sword;
    public bool Coroutinerun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Attack()
    {
        while (true)
        {
            //Enemymove enemymove = Attackobj.GetComponent<Enemymove>();
            Vector2 offset = Target[0].transform.position - transform.position;

            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg * -90f;

            Debug.Log(angle);
            GameObject sword = Instantiate(Sword, transform.position, Quaternion.identity);

            sword.transform.rotation = Quaternion.Euler(0, 0, angle);

            //enemymove.Damage(10);

            yield return new WaitForSeconds(3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Target.Add(collision.gameObject);
        if (Attackobj == null)
        {
            Attackobj = Target[0];
            StartCoroutine("Attack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Target.Remove(collision.gameObject);

        if (Target.Count == 0)
        {
            StopCoroutine("Attack");
        }
        else
        {
            Attackobj = Target[0];
        }
    }
}
