using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovemnte : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed = 0.2f;
    CharacterController player;
    public TextMeshProUGUI textHp;
    public int playerHp =100;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        player.Move(move * Time.deltaTime * speed);

        textHp.text = "Player Hp: " + playerHp;
    }
}
