using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public string level1;
    public string level2;
    public string level3;
    public string story1;
    public string story2;
    public string story3;
    public string win;
    public Text msg;
    string story;
    public bool done;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        msg.text = story;
        yield return new WaitForSeconds(4);
        msg.text = " ";
        done = true;
    }

    public void StartRoom1()
    {
        story = story1;
        msg.text = level1;
        done = false;
        StartCoroutine(Delay());
    }

    public void StartRoom2()
    {
        story = story2;
        msg.text = level2;
        done = false;
        StartCoroutine(Delay());
    }

    public void StartRoom3()
    {
        story = story3;
        msg.text = level3;
        done = false;
        StartCoroutine(Delay());
    }
    public void Win()
    {
        story = win;
        msg.text = win;
        done = false;
        StartCoroutine(Delay());
    }
}
