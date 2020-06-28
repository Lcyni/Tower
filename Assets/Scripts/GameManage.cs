using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GameManage : MonoBehaviour
{
    private GameObject selectPanel;
    private GameObject firstPanel;
    private GameObject nextSelectPanel;
    public GameObject[] towers;
    private GameObject selectTower;
    private Transform basePos;

    private UIControl script;

    void Start()
    {
        selectTower = null;
        selectPanel = transform.Find("SelectCanvas").gameObject;
        firstPanel = selectPanel.transform.GetChild(0).gameObject;
        nextSelectPanel = selectPanel.transform.GetChild(1).gameObject;
        script = GameObject.Find("UICanvas").GetComponent<UIControl>();
    }


    void Update()
    {
        //  Debug.Log("现在的怪物数量:" + count);
        //if (isFinish && 0 == count)
        //{
        //    gameover.SetActive(true);
        //    gameover.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "你赢了!";
        //    //UnityEditor.EditorApplication.isPaused = true;
        //}
        if (Input.GetMouseButtonDown(0))
            SelectBase();
    }


    private void SelectBase()
    {
      
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200) && EventSystem.current.IsPointerOverGameObject() == false)
        {

            if (hit.transform.tag == "TowerBase")//这是个地基，可以创建炮台
            {

                ShowSelectPanel(hit.transform);
                basePos = hit.transform;
                nextSelectPanel.SetActive(false);
            }
        }
    }

    private void ShowSelectPanel(Transform pos)
    {
        selectPanel.transform.SetParent(pos, false);
        selectPanel.transform.localPosition = new Vector3(0, 7, 0);
        selectPanel.transform.rotation = Quaternion.Euler(90, -2, 0);
        selectPanel.SetActive(true);
    }
    private void InItUI()
    {
        selectTower = null;
        selectPanel.SetActive(false);
        nextSelectPanel.SetActive(false);
        firstPanel.SetActive(true);
    }
    public void SelecttowerOne(bool isOn)
    {
        if (isOn)
        {
            selectTower = towers[0];
          // firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }
   
    public void SelecttowerTwo(bool isOn)
    {
        if (isOn)
        {
            selectTower = towers[1];
         //  firstPanel.SetActive(true);
            nextSelectPanel.SetActive(true);
        }
    }

    public void SelecttowerThree(bool isOn)
    {
        if (isOn)
        {
            selectTower = towers[2];
            firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }
   
    public void CreateTower()
    {
        Debug.Log("创建");
        if (selectTower != null)
        {
            if (!script.Cost(300)) { Debug.Log("金币不足"); return; }
            GameObject tempTower = Instantiate(selectTower);
            tempTower.transform.SetParent(basePos, false);
            tempTower.transform.localPosition = Vector3.up * 2.5f;

            tempTower.AddComponent<TowerAI>();
            InItUI();
        }

    }

    public void CellTower()
    {
        Debug.Log("出售");
        if (basePos.childCount >= 2)
        {
            Destroy(basePos.GetChild(0).gameObject);
            InItUI();
        }
        else
        {
            Debug.Log("目标地基没有炮塔，无法操作！");
        }
    }
   public void CloseAll()
    {
        selectPanel.SetActive(false);
        nextSelectPanel.SetActive(false);
        firstPanel.SetActive(true);
    }

    public void CloseNext()
    {
        nextSelectPanel.SetActive(false);
        firstPanel.SetActive(true);
    }
  
}