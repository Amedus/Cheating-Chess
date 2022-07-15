using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesMovingController : MonoBehaviour
{
    private GameObject from = null;
    private GameObject to = null;
    private bool isMoving = false;
    void Start()
    {
        GameEvents.current.onMakeMove += MakeMove; //подписываемся на событие MakeMove
    }

    private void MakeMove(string move) //описываем действия, которые будут выполняться при запуске события
    {
        GameObject fromSquare = GameObject.Find(move.Substring(0, 2)); //находим по первым двум символам хода начальную клетку
        GameObject toSquare = GameObject.Find(move.Substring(2, 2)); //по последним двум символам хода находим целевую клетку
        if (fromSquare.transform.childCount > 0) //проверяем, что на начальной клетке есть фигура
        {
            GameObject currentPiece = fromSquare.transform.GetChild(0).gameObject; //на начальной клетке находим фигуру, коуторую хотим переместить из начальной в целевую клетку

            if ((fromSquare) && (toSquare) && (currentPiece) && (toSquare != fromSquare)) //убеждаемся, что нашли начальную и целевую клетку, и что на начальной была фигура
            {
                isMoving = true; //указываем, что нужно двигать фигуру
                from = fromSquare; //откуда
                to = toSquare; //и куда
            }
            else
                Debug.Log("Can't make a move:" + move);
        }
        else
            Debug.Log("Can't make a move:" + move);

    }

    void Update()
    {
        if (isMoving) //если нужно двигать фигуру
        {
            GameObject currentPiece = from.transform.GetChild(0).gameObject; //ищем фигуру на исходной клетке через дочерний объект
            currentPiece.transform.position = Vector3.MoveTowards(currentPiece.transform.position, to.transform.position, 0.025f); //двигаем фигуру на 2,5% за кадр
            if (currentPiece.transform.position == to.transform.position) //если фигура доехала
            {
                isMoving = false; //указываем, что движение завершено
                if (to.transform.childCount > 0)
                    Destroy(to.transform.GetChild(0).gameObject); //если на целевой клетке была фигура - уничтожаем её

                currentPiece.transform.SetParent(to.transform); //привязываем перемещаемую фигуру к новой клетке
                currentPiece.transform.position = to.transform.position; //двигаем фигуру на новую клетку*/
            }                
        }
    }
}
