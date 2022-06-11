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
        sp = new SerialPort("COM3", 9600);
    }

    public void HitRight() {
        sp.Open();
        sp.Write("hr");
        sp.Close();
    }
    public void HitMiddle()
    {
        sp.Open();
        sp.Write("hm");
        sp.Close();
    }
    public void HitLeft()
    {
        sp.Open();
        sp.Write("hl");
        sp.Close();
    }
}
