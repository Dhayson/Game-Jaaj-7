using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClickImage : Click
{
    private Vector2 @default;
    private Image image;
    new protected void Start()
    {
        image = GetComponent<Image>();
        @default = image.rectTransform.sizeDelta;
        base.Start();
    }
    new void Update()
    {
        base.Update();
        RaycastHit2D hit = Global.MouseClick(Camera.main);
        if (hit && hit.collider.gameObject == gameObject && gameObject.activeInHierarchy)
        {
            image.rectTransform.sizeDelta = @default * 1.2f;
        }
        else
        {
            image.rectTransform.sizeDelta = @default;
        }
    }
}
