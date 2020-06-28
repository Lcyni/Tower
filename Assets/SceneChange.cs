using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public Button mButton;
    //private GameObject uiCanvas;
    //private GameObject setting;
    // Start is called before the first frame update
    public Button setting;
    private GameObject Audio;

    void Start()
    {
        //Gets ButtonMount
        Button btnMount = mButton.GetComponent<Button>();
        btnMount.onClick.AddListener(TaskOnClick);

        //uiCanvas = transform.Find("uiCanvas").gameObject;
        //setting = uiCanvas.transform.GetChild(2).gameObject;  
     
        Button sett = setting.GetComponent<Button>();
        sett.onClick.AddListener(Setting);

     
        Audio = GameObject.Find("AUdio").transform.gameObject;
        
    }

    void TaskOnClick()
    {
        //Loading Scene1
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
      
    }
        
    void Setting()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void Music()
    {
        Audio.SetActive(false);

    }

    //public void settingImage(bool isOn)
    //{
    //    if (isOn)
    //    {
    //        setting.SetActive(true);
    //    }
    //}
}
