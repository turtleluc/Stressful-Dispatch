using System;
using System.Collections;
using System.Collections.Generic;
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

    bool red;
    bool green;
    bool blue;

    int freq;
    int freqi;

    private SerialConnect connect;

    private Mission currentMission;

    string Rood = "Rood";
    string Groen = "Groen";
    string Blauw = "Blauw";

    string regioCode;
    int regioFreq;

    [SerializeField] 
    GameObject objectWithSerialConnect;

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
        connect = objectWithSerialConnect.GetComponent<SerialConnect>();
    }

    // Update is called once per frame
    void Update()
    {
        unitInput = UnitsIn.text;

        frequi();

        if (Input.GetKeyDown("space"))
        {
            //PullMission();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Zone();
        }
        if (Input.GetKeyDown("w"))
        {
            PullWarrents();
        }
        if (Input.GetKeyDown("b"))
        {
            PullBolos();
        }

        /*if (Input.GetKeyDown("a"))
        {
            freq--;
            Debug.Log(freq);

        }
        if (Input.GetKeyDown("d"))
        {
            freq++;
            Debug.Log(freq);
        }*/

        StateCheck();
    }


    //Call places and missions to go in the list

    void PlaceAdd()
    {

        places.Add(new Place("Balghakt", 169, Rood));
        places.Add(new Place("Sponky Town", 185, Groen));
        places.Add(new Place("Sulka Dust", 177, Groen));
        places.Add(new Place("Jojan", 169, Groen));
        places.Add(new Place("Vis Dorp", 177, Groen));
        places.Add(new Place("BeenBurg", 185, Groen));
        places.Add(new Place("Flores", 187, Groen));
        places.Add(new Place("Abraham", 187, Groen));
        places.Add(new Place("Silverschans", 187, Rood));
        places.Add(new Place("Randes", 169, Rood));
        places.Add(new Place("Glordes", 172, Rood));
        places.Add(new Place("Taalf", 172, Rood));
        places.Add(new Place("Pits", 172, Rood));
        places.Add(new Place("Groo Dorp", 172, Blauw));
        places.Add(new Place("Glaareed", 165, Blauw));
        places.Add(new Place("Zoolf", 165, Blauw));
        places.Add(new Place("Waalm", 165, Blauw));
        places.Add(new Place("Klous", 157, Blauw));
        places.Add(new Place("Daander", 157, Rood));
        places.Add(new Place("Maan Dorp", 157, Rood));
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

    void frequi()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            freqi--;
            Debug.Log(freqi);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            freqi++;
            Debug.Log(freqi);
        }

        if (freqi >= 255 )
        {
            freqi = 255;
        }

        else if (freqi <= 0)
        {
            freqi = 0;
        }

        if (freqi == regioFreq)
        {
            Debug.Log("Connected");
        }
    }

    void StateCheck()
    {
        if (regioCode == Rood)
        {
            connect.commandToSend = connect.COMMAND + "R";
            connect.commandToSend = connect.COMMAND + "R";
            return;
        }

        else if (regioCode == Blauw)
        {
            connect.commandToSend = connect.COMMAND + "B";
            connect.commandToSend = connect.COMMAND + "B";
            return;
        }

        else if (regioCode == Groen)
        {
            connect.commandToSend = connect.COMMAND + "G";
            connect.commandToSend = connect.COMMAND + "G";
            return;
        }
    }

    void PullMission()
    {
        if (missions.Count > 0)
        {
            int randomIndexP = Random.Range(0, places.Count);
            Place randomplace = places[randomIndexP];

            int randomIndex = Random.Range(0, missions.Count);
            Mission randomMission = missions[randomIndex];
            //Debug.Log("Er is een " + randomMission.code + " in " + randomplace.name);

            new Objective(randomMission, randomplace);
            objective.Add(new Objective(randomMission, randomplace));
            MissionText.text = "Er is een " + randomMission.code + " in " + randomplace.name;

            regioCode = randomplace.regio;
            regioFreq = randomplace.frequentie;
            //Instantiate(new Objective(randomMission, randomplace), MisstionParr);
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
            MissionText.text = "Er is een Warrent op " + randomWarrent.ID + " Kan je die checken? ";
        }
    }

    void PullBolos()
    {
        if(bolos.Count > 0) 
        { 
            int randomIndexP = Random.Range(0, bolos.Count);
            Bolos randomBolos = bolos[randomIndexP];
            MissionText.text = "Er is een Bolo op " + randomBolos.kenteken + " Kan je die checken? ";
        }
    }

    void Randomizer(int x)
    {
        switch (x)
        {
            case 0:
                PullMission();
                break;
            case 1:
                PullWarrents();
                break;
            case 2:
                PullBolos();
                break;
        }
    }

    void Zone()
    {
        Randomizer(Random.Range(0, 3));

        if(red == true)
        {

        }

        if(green == true)
        {

        }

        if(blue == true)
        {

        }

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
    public string regio;

    public Place(string name, int freq, string _regio)
    {
        this.name = name;
        frequentie = freq;
        regio = _regio;
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

