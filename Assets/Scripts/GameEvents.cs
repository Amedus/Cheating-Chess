using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current; //объ€вл€ем систему событий

    private void Awake() //инициализируем систему событий
    {
        current = this;
    }

    public event Action<string> onMakeMove; //объ€вл€ем событие "сделать ход"
    public void MakeMove(string move) //объ€вл€ем публичный метод дл€ событи€ 
    {
        if (onMakeMove != null) //перед вызовом убеждаемс€, что событие существует
            onMakeMove(move);
    }

    public event Action<string> onSendSquare; //отправка координат дл€ хода
    public void SendSquare(string square)
    {
        if (onSendSquare != null)
            onSendSquare(square);
    }    
}
