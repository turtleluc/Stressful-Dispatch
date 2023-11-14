using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class TeensyTest : MonoBehaviour
{

    SerialPort arduino;

    void Start()
    {
        arduino = new SerialPort("usb:0/140000/0/1", 115200);
        arduino.Open();
    }

    void Update()
    {
        // Example: Press 'R' to toggle the Red boolean
        if (Input.GetKeyDown(KeyCode.R))
        {
            arduino.Write("R");
        }

        // Example: Press 'B' to toggle the Blue boolean
        if (Input.GetKeyDown(KeyCode.B))
        {
            arduino.Write("B");
        }

        // Example: Press 'G' to toggle the Green boolean
        if (Input.GetKeyDown(KeyCode.G))
        {
            arduino.Write("G");
        }
    }

}
