using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyIncubator : MonoBehaviour
{
    public  GameObject[] enemys;
    private float times;//每波间隔
    private float time;//一波之中的生成间隔
    private float percount;//boshu
    /// </summary>
    private float counts;//每波数量
    private int elsecount;//剩下怪物数
    
    private bool isFinish;//怪物全部生产完了
    private  GameObject gameover;

    void Start()
    {

        isFinish = false;
        elsecount = 0;
        time = 2;
        times = 1;
        percount = 5;
        counts = 4;
        StartCoroutine(CreateEnemy());
        gameover = GameObject.Find("UICanvas").transform.GetChild(3).gameObject;

    }

    public int GetCount
    {
        set { elsecount = value; }
        get { return elsecount; }
    }
    public GameObject GetGameOver
    {
        set { gameover = value; }
        get { return gameover; }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("现在的怪物数量:" + elsecount);
        if (isFinish && 0 == elsecount)
        {
            gameover.SetActive(true);
            //gameover.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "你赢了!";
            //UnityEditor.EditorApplication.isPaused = true;
        }

    }


    private IEnumerator CreateEnemy()//生产怪物
    {
        for (int i = 0; i < percount; i++)
        {
            for (int j = 0; j < counts; j++)
            {
                Instantiate(enemys[Random.Range(0, enemys.Length)], transform.position,Quaternion.identity);
                elsecount++;
                yield return new WaitForSeconds(times);

            }
            yield return new WaitForSeconds(time);
        }
        isFinish = true;
        StopCoroutine(CreateEnemy());
    }
}
