using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NemesisSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void OnEnable()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (Global.nemesisImagePath is not null)
        {
            var MySprite = IMG2Sprite.instance.LoadNewSprite(Global.nemesisImagePath, size: 1);
            if (MySprite is not null)
                spriteRenderer.sprite = MySprite;
        }
    }

    void Update()
    {
        spriteRenderer.size = Global.sizeMultiplier;
    }

    [SerializeField] private string nextScene;
    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void IncreaseX()
    {
        Global.sizeMultiplier = new Vector2(Global.sizeMultiplier.x + 0.1f, Global.sizeMultiplier.y);
    }
    public void DecreaseX()
    {
        Global.sizeMultiplier = new Vector2(Global.sizeMultiplier.x - 0.1f, Global.sizeMultiplier.y);
    }
    public void IncreaseY()
    {
        Global.sizeMultiplier = new Vector2(Global.sizeMultiplier.x, Global.sizeMultiplier.y + 0.1f);
    }
    public void DecreaseY()
    {
        Global.sizeMultiplier = new Vector2(Global.sizeMultiplier.x, Global.sizeMultiplier.y - 0.1f);
    }
    public void SideX()
    {
        spriteRenderer.transform.position = new Vector2(spriteRenderer.transform.position.x + 0.05f, spriteRenderer.transform.position.y);
    }
    public void SideY()
    {
        spriteRenderer.transform.position = new Vector2(spriteRenderer.transform.position.x, spriteRenderer.transform.position.y + 0.05f);
    }
    public void SideX2()
    {
        spriteRenderer.transform.position = new Vector2(spriteRenderer.transform.position.x - 0.05f, spriteRenderer.transform.position.y);
    }
    public void SideY2()
    {
        spriteRenderer.transform.position = new Vector2(spriteRenderer.transform.position.x, spriteRenderer.transform.position.y - 0.05f);
    }
}
