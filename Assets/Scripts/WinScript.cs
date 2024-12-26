using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    int fullElement;
    public static int myElement;
    public GameObject Puzzle;
    public GameObject Panel;
    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        fullElement = Puzzle.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(fullElement == myElement)
        {
            Panel.SetActive(false);
            winPanel.SetActive(true);
        }
    }
    public static void AddElement()
    {
        myElement++;
    }


}
