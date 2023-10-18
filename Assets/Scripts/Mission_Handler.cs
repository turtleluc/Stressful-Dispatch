using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Random = UnityEngine.Random;

public class Mission_Handler : MonoBehaviour
{
    List<Place> places = new List<Place>();

    List<Mission> missions = new List<Mission>();

    List<Objective> objective = new List<Objective>();

    string unitInput;

    //[SerializeField]
   // TMP_Text MissionText;

    [SerializeField]
    Transform MisstionParr;

    [SerializeField]
    TMP_InputField UnitsIn;

    [SerializeField]
    TMP_InputField FreqIn;

    [SerializeField]
    GameObject MisstionPan;

    // Start is called before the first frame update
    void Start()
    {
        PlaceAdd();
        MissionAdd();
    }

    // Update is called once per frame
    void Update()
    {
        unitInput = UnitsIn.text;

        if (Input.GetKeyDown("space"))
        {
            PullMission();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Dispatch();
        }
    }


    //Call places and missions to go in the list
    
    void PlaceAdd()
    {
        
        places.Add(new Place("Balghakt", 180));
        places.Add(new Place("Klunk Town", 165));
        places.Add(new Place("Sulka Dust", 145));
        places.Add(new Place("Jojan", 169));
        places.Add(new Place("Vis Dorp", 110));
    }
   
    void MissionAdd()
    {
        missions.Add(new Mission("Bank Robbery", "10-50", 7));
        missions.Add(new Mission("Store Robbery", "10-60", 5));
        missions.Add(new Mission("House Robbery", "10-70", 3));
    }
 



    void PullMission()
    {
        if (missions.Count > 0)
        {
            int randomIndexP = Random.Range(0, places.Count);
            Place randomplace = places[randomIndexP];

            int randomIndex = Random.Range(0, missions.Count);
            Mission randomMission = missions[randomIndex];
            Debug.Log("Er is een " + randomMission.code + " in " + randomplace.name);

            /*new Objective(randomMission, randomplace);*/
            /* objective.Add(new Objective(randomMission, randomplace));*/
            /*MissionText.text = "Er is een " + randomMission.code + " in " + randomplace.name;*/

            Instantiate(new Objective(randomMission, randomplace), MisstionParr);
        }
        else
        {
            Debug.Log("Error 420-69.");
        }
    }

    void Dispatch()
    {
        /*Instantiate(MisstionPan, MisstionParr);*/

    }

    void DisCheck()
    {
       
    }
}

// Places
class Place
{
    public string name;
    public int frequentie;

    public Place(string name, int freq)
    {
        this.name = name;
        frequentie = freq;
    }
}

// Missions
class Mission
{
     public string name;
     public string code;
     public int unitmin;

    public Mission(string name, string _code, int umin )
    {
        this.name = name;
        code = _code;
        unitmin = umin;
    }
}

class Objective : MonoBehaviour
{
    Mission mission;
    Place place;

    public Objective(Mission _mission, Place _place)
    {
        mission = _mission;
        place = _place;
    }
    void GetMissionText()
    {

    }
}