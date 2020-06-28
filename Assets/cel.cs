using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cel : MonoBehaviour
{
    public Button xx;
    // Start is called before the first frame update
    void Start()
    {
        Button concel = xx.GetComponent<Button>();
        concel.onClick.AddListener(back);
    }

    // Update is called once per frame
   
    void back()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
