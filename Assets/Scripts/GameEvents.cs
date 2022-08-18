using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<string> onMakeAMove;
    public void MakeAMove(string move)
    {
        if (onMakeAMove != null)
            onMakeAMove(move);
    }

    public event Action<string> onSendSquare;
    public void SendSquare(string square)
    {
        if (onSendSquare != null)
            onSendSquare(square);
    }

    public event Action<string> onNextTurn;
    public void NextTurn(string playerColor)
    {
        if (onNextTurn != null)
            onNextTurn(playerColor);
    }
}
