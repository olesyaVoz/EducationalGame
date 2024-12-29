using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Actions : MonoBehaviour
{
    bool move;
    Vector2 mousePos;
    float startPosX;
    float startPosY;
    public GameObject form;
    private bool placed = false;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            mousePos = Input.mousePosition;
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = 10; 
            }
        }
    }

    void OnMouseUp()
    {
        move = false;
        if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 30f &&
            Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 30f)
        {
            if (!placed)
            {
                WinScript.AddElement();
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                this.transform.position = form.transform.position;
                if (spriteRenderer != null)
                {
                    spriteRenderer.sortingOrder = 1;
                }
                placed = true;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
           
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && !placed)
            {
                spriteRenderer.sortingOrder = 5; 
            }
        }
    }
    void Update()
    {
        if (move)
        {
            mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }
}