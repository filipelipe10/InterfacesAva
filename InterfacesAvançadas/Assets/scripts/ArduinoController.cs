using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ArduinoController : MonoBehaviour
{
    SerialPort sp;


    // Start is called before the first frame update
    void Start()
    {
        sp = new SerialPort("COM3", 19200);
    }

    public void HitRight() {
        if (!sp.IsOpen) 
            sp.Open();
        sp.Write("hr:");
    }
    public void HitMiddle()
    {
        if (!sp.IsOpen)
            sp.Open();
        sp.Write("hm:");
    }
    public void HitLeft()
    {
        if (!sp.IsOpen)
            sp.Open();
        sp.Write("hl:");
    }
}
