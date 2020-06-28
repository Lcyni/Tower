using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIControl : MonoBehaviour {
    private   Text goldText;
    public  static  int gold = 1000;

    void Start () {
        goldText = GameObject.Find("UICanvas").transform.GetChild(1).GetComponent<Text>();
   }
	void Update () {
        //Debug.Log(gold);
    
        goldText.text = gold.ToString();
	}
    //花费
    public  bool Cost(int values)
    {
        if (gold>= values)
        {
            gold -= values;
            return true;
        }
        else
        {
            return false;
        }
    }

   

    public void retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void backmenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void exit()
    {
        Debug.Log("退出游戏");
        Application.Quit();
    }

  

}
