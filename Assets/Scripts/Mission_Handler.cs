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

    List<Bolos> bolos = new List<Bolos>();

    List<Warrents> warrents = new List<Warrents>();

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
        BolosAdd();
        WarrentsAdd();
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
        if (Input.GetKeyDown("w"))
        {
            PullWarrents();
        }
        if (Input.GetKeyDown("b"))
        {
            PullBolos();
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

    void BolosAdd()
    {
        bolos.Add(new Bolos("Porsche 911 9-RTV-32"));
        bolos.Add(new Bolos("Pontiac Trans AM 3-TNM-27"));
        bolos.Add(new Bolos("Dodge Challenger 9-IYU-46"));
        bolos.Add(new Bolos("Ford Pinto 7-VSD-75"));
        bolos.Add(new Bolos("1979 Chevrolet Camaro Z28 4-BNS-62"));
        bolos.Add(new Bolos("Mercedes 200/300 4-FOP-84"));
        bolos.Add(new Bolos("1977 Ford Bronco 6-EFG-14"));
        bolos.Add(new Bolos("Rover 2000 2-JWX-79"));
        bolos.Add(new Bolos("NSU Ro80 5-KRS-91"));
        bolos.Add(new Bolos("Citroën GS 1-ZBN-10"));
        bolos.Add(new Bolos("Fiat 128 8-THS-19"));
        bolos.Add(new Bolos("Mercedes 450S 9-LYD-92"));
        bolos.Add(new Bolos("Lancia Delta 3-GMX-52"));

    }

    void WarrentsAdd()
    {
        warrents.Add(new Warrents("Bill Verkaap"));
        warrents.Add(new Warrents("Margo Spaat"));
        warrents.Add(new Warrents("Mohammed Scharrel"));
        warrents.Add(new Warrents("Jasmijn van Rodermaan"));
        warrents.Add(new Warrents("Browie Bramwie"));
        warrents.Add(new Warrents("Silvie Rovan"));
        warrents.Add(new Warrents("Sven Mooi"));
        warrents.Add(new Warrents("Tanja Ploeger"));
        warrents.Add(new Warrents("Johan de groot"));
        warrents.Add(new Warrents("Veronique Bouchier"));
        warrents.Add(new Warrents("Ronald van Duinen"));
        warrents.Add(new Warrents("Zeno Schijf"));
        warrents.Add(new Warrents("Ali Schipperen"));
        warrents.Add(new Warrents("Jamil Putter"));
        warrents.Add(new Warrents("Carlijn Versteegen"));
        warrents.Add(new Warrents("Shakir van Helvoort"));
        warrents.Add(new Warrents("Silke Kruijt"));
        warrents.Add(new Warrents("Wouter Verlinde"));
        warrents.Add(new Warrents("Janien Kilinç"));
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

    void PullWarrents()
    {
        if(warrents.Count > 0)
        {
            int randomIndexP = Random.Range(0, warrents.Count);
            Warrents randomWarrent = warrents[randomIndexP];
            Debug.Log("Er is een Warrent op " + randomWarrent.ID + " Kan je die checken ");
        }
    }

    void PullBolos()
    {
        if(bolos.Count > 0) 
        { 
            int randomIndexP = Random.Range(0, bolos.Count);
            Bolos randomBolos = bolos[randomIndexP];
            Debug.Log("Er is een Bolo op " + randomBolos.kenteken + " Kan je die checken ");
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

class Bolos 
{
    public string kenteken;
    
    public Bolos(string _kenteken)
    {
        this.kenteken = _kenteken;
    }
}

class Warrents
{
    public string ID;


    public Warrents(string ID)
    {
        this.ID = ID;
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