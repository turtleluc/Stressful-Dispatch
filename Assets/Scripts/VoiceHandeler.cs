using System.Collections;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class VoiceHandeler : MonoBehaviour
{

    private string[] keywords = new string[] { "test"};
    private KeywordRecognizer keywordRecognizer;


    // Start is called before the first frame update
    void Start()
    {
        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            keywordRecognizer.Start();
            Debug.Log("V in");
        }

        if(Input.GetKeyUp(KeyCode.V))
        {
            keywordRecognizer.Stop();
           
        }


    }


    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (args.text == "test")
        {
            Debug.Log("test");
        }
    }

}

    