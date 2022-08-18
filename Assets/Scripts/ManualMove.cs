using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManualMove : MonoBehaviour
{
    private int moveStatus = 0;
    void Start()
    {
        GameEvents.current.onSendSquare += SendSquare;
    }

    private void SendSquare(string square)
    {
        switch (moveStatus)

        {
            case 0:
                this.gameObject.GetComponent<TextMeshPro>().text = square;
                moveStatus += 1;
                break;
            case 1:
                this.gameObject.GetComponent<TextMeshPro>().text += square;
                GameEvents.current.MakeAMove(this.gameObject.GetComponent<TextMeshPro>().text);
                moveStatus = 0;
                break;
        }
    }
}
