using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManualMove : MonoBehaviour
{
    private int moveStatus = 0; //0 - ход не задан, 1 - задано откуда ходим
    void Start()
    {
        GameEvents.current.onSendSquare += SendSquare;
    }

    private void SendSquare(string square)
    {
        switch (moveStatus) //проверяем начальные ли это координаты или конечные
        {
            case 0:
                this.gameObject.GetComponent<TextMeshPro>().text = square; //если начальные - сохраняем
                moveStatus += 1;
                break;
            case 1:
                this.gameObject.GetComponent<TextMeshPro>().text += square;
                GameEvents.current.MakeMove(this.gameObject.GetComponent<TextMeshPro>().text); //если конечные - делаем ход
                moveStatus = 0;
                break;
        }
    }

    void Update()
    {
        
    }
}
