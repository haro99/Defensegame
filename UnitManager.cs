using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public Camera Cam;
    public Vector2 mousePos;
    public GameObject SetPreviewUnit, PutUnit;
    public GameManager gameManager;
    public GameObject[] Units;
    public GameObject[] PreviewUnits;
    public int[] muchs;
    public int much;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);

        if (SetPreviewUnit)
        {
            SetPreviewUnit.transform.position = mousePos;
        }
    }

    public void BayUnitButton(int unitnumber)
    {
        if (!SetPreviewUnit)
        {
            PutUnit = Units[unitnumber];
            SetPreviewUnit = Instantiate(PreviewUnits[unitnumber]);
            much = muchs[unitnumber];
        }
        else
        {
            PutUnit = null;
            Destroy(SetPreviewUnit);
            SetPreviewUnit = null;
            much = 0;
        }
    }

    public void PutUnitDestroy()
    {
        PutUnit = null;
        Destroy(SetPreviewUnit);
    }

    public bool BuyCheck()
    {
        if (PutUnit && gameManager.Buy(much))
            return true;

        return false;
    }
}
