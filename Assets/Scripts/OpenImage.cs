using System.Collections;
using System.Collections.Generic;
using System.IO;
using SFB;
using UnityEngine;
using UnityEngine.UI;

public class OpenImage : MonoBehaviour
{
    [SerializeField] private GameObject Nemesis;
    [SerializeField] private GameObject Bound;
    // Start is called before the first frame update
    void Start()
    {
        //game introduction before this
        var extensions = new[]
        {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg" )
        };
        bool success = false;
        while (!success)
        {
            var path = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true);
            if (File.Exists(path[0]))
            {
                Debug.Log(path[0]);
                Global.nemesisImagePath = path[0];
                success = true;
            }
        }

        Nemesis.SetActive(true);
        Bound.SetActive(true);
    }
}
