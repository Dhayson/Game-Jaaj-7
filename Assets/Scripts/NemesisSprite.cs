using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NemesisSprite : MonoBehaviour
{
    [SerializeField] private bool FirstScene = false;
    void OnEnable()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Global.nemesisImagePath is not null)
        {
            var MySprite = IMG2Sprite.instance.LoadNewSprite(Global.nemesisImagePath, size: 1);
            if (MySprite is not null)
                spriteRenderer.sprite = MySprite;
            spriteRenderer.size = new Vector2(Global.sizeMultiplier, Global.sizeMultiplier);
        }
        if (FirstScene)
        {
            StartCoroutine(NextScene());
        }
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level1");
    }
}
