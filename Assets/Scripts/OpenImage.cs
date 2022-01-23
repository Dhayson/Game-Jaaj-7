using System.Collections;
using System.Collections.Generic;
using SFB;
using UnityEngine;

public class OpenImage : MonoBehaviour
{
    [SerializeField] GameObject Nemesis;
    // Start is called before the first frame update
    void Start()
    {
        //game introduction before this
        var extensions = new[]
        {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg" )
        };
        var path = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true);
        if (path.Length > 0)
        {
            Debug.Log(path[0]);
            Global.nemesisImagePath = path[0];
        }
        Nemesis.SetActive(true);
    }
}
