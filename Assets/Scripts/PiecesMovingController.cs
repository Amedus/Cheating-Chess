using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesMovingController : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onMakeMove += MakeMove; //подписываемся на событие MakeMove
    }

    private void MakeMove(string move) //описываем действия, которые будут выполняться при запуске события
    {
        GameObject fromSquare = GameObject.Find(move.Substring(0, 2)); //находим по первым двум символам хода начальную клетку
        GameObject toSquare = GameObject.Find(move.Substring(2, 2)); //по последним двум символам хода находим целевую клетку
        GameObject currentPiece = fromSquare.transform.GetChild(0).gameObject; //на начальной клетке находим фигуру, коуторую хотим переместить из начальной в целевую клетку
        if ((fromSquare) && (toSquare) && (currentPiece)) //убеждаемся, что нашли начальную и целевую клетку, и что на начальной была фигура
        {
            if (toSquare.transform.GetChild(0).gameObject)
                Destroy(toSquare.transform.GetChild(0).gameObject); //если на целевой клетке была фигура - уничтожаем её

            currentPiece.transform.SetParent(toSquare.transform); //привязываем перемещаемую фигуру к новой клетке
            currentPiece.transform.position = toSquare.transform.position; //двигаем фигуру на новую клетку
        }
        else
            Debug.Log("Can't make a move:" + move);     
    }

    void Update()
    {
        
    }
}
