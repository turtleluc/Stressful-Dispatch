using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unit_Handeler : MonoBehaviour
{
    [SerializeField]
    private int Units = 10;

    public TMP_Text UnitText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnitUpdate();
    }

    void UnitUpdate()
    {
        UnitText.text = Units.ToString();
    }
}
