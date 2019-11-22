using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMContoller : MonoBehaviour
{
    private static BGMContoller instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("BGM") == "ON" || PlayerPrefs.GetString("BGM") == "")
        {
            PlayerPrefs.SetString("BGM", "ON");
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
    
    void Update()
    {

    }
    // Music Global Start
    public static BGMContoller Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Music Global End
}
