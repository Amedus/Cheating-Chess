using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnSquare : MonoBehaviour
{
    void OnMouseDown()
    {
        GameEvents.current.SendSquare(this.gameObject.name); //указываем, что пользователь кликнул на определённую клетку        
    }
}
