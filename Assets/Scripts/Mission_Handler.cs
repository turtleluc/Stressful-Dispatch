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

    [SerializeField]
    TMP_Text MissionText;

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
        
        places.Add(new Place("Balghakt", 169));
        places.Add(new Place("Sponky Town", 185));
        places.Add(new Place("Sulka Dust", 177));
        places.Add(new Place("Jojan", 169));
        places.Add(new Place("Vis Dorp", 177));
        places.Add(new Place("BeenBurg", 185));
        places.Add(new Place("Flores", 187));
        places.Add(new Place("Abraham", 187));
        places.Add(new Place("Silverschans", 187));
        places.Add(new Place("Randes", 169));
        places.Add(new Place("Glordes", 172));
        places.Add(new Place("Taalf", 172));
        places.Add(new Place("Pits", 172));
        places.Add(new Place("Groo Dorp", 172));
        places.Add(new Place("Glaareed", 165));
        places.Add(new Place("Zoolf", 165));
        places.Add(new Place("Waalm", 165));
        places.Add(new Place("Klous", 157));
        places.Add(new Place("Daander", 157));
        places.Add(new Place("Maan Dorp", 157));
    }
   
    void MissionAdd()
    {
        missions.Add(new Mission("Bank Overval", "10-89", 1));
        missions.Add(new Mission("Winkel Overval", "10-73", 2));
        missions.Add(new Mission("Huis Inbraak", "10-81", 3));
        missions.Add(new Mission("Moord", "10-54", 4));
        missions.Add(new Mission("Illegale Drag Race", "10-47", 5));
        missions.Add(new Mission("Fout Geparkeerde Auto", "10-39", 6));
        missions.Add(new Mission("Rellen", "10-92", 7));
        missions.Add(new Mission("Vandalisme", "10-96", 8));
        missions.Add(new Mission("Mogelijke Ontvoering", "10-41", 9));
        missions.Add(new Mission("Vermist Persoon", "10-65", 10));
        missions.Add(new Mission("Auto Achtervolging", "10-55", 11));
        missions.Add(new Mission("Geluids Overlast", "10-44", 12));
        missions.Add(new Mission("Wanbetalers", "10-83", 13));
        missions.Add(new Mission("Aanrijding", "10-49", 14));
        missions.Add(new Mission("Auto Ongeluk", "10-61", 15));
        missions.Add(new Mission("Schiet Partij", "10-45", 16));
        missions.Add(new Mission("Fietser met telefoon in de hand", "10-69", 17));
        missions.Add(new Mission("Valse ID", "10-37", 18));
        missions.Add(new Mission("Drugs Smokkel", "10-58", 19));
        missions.Add(new Mission("Zwart Rijden", "10-70", 20));


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
            
            /*Instantiate(new Objective(randomMission, randomplace), MisstionParr);*/
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