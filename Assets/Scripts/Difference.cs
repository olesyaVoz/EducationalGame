using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Difference : MonoBehaviour
{
    private Button difference;
    private Image Myimage;
    void Start()
    {
        difference = GetComponent<Button>();
        Myimage = GetComponent<Image>();
        difference.onClick.AddListener(MyVoid);
    }
    void MyVoid()
    {
        Myimage.color = Color.white;
        difference.enabled = false;
    }

}