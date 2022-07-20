using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesMovingController : MonoBehaviour
{
    public float movingSpeed = 7.5f; // скорость движения фигуры по доске

    private GameObject fromSquare = null; //начальная клетка хода
    private GameObject toSquare = null; //целевая клетка хода
    private GameObject currentPiece = null; //передвигаемая фигура
    private bool isMoving = false; //флаг указывающий, что сейчас передвигается фигура

    void Start()
    {
        GameEvents.current.onMakeMove += MakeMove; //подписываемся на событие MakeMove
    }

    private void MakeMove(string move) //выполнение хода формата "E2E4" из строки move при триггере события MakeMove
    {
        fromSquare = GameObject.Find(move.Substring(0, 2)); //ищем начальную клетку (первые два символа хода)
        toSquare = GameObject.Find(move.Substring(2, 2)); //ищем конечную клетку (последние два символа хода)
        if (fromSquare.transform.childCount > 1) //убеждаемся, что на начальной клетке есть фигура (более двух потомков у объекта)
        {
            currentPiece = fromSquare.transform.GetChild(1).gameObject; //запоминаем фигуру, которую будем двигать

            if ((fromSquare) && (toSquare) && (currentPiece) && (toSquare != fromSquare)) //убеждаемся, что корректно нашлись исходные и целевые клетки, фигура, а также что исходная клетка не равна целевой (ходить E2E2 нельзя)
            {
                isMoving = true; //переключаем флаг, что фигуру нужно двигать
            }
            else
                Debug.Log("Can't make a move:" + move); //сообщаем, что текущий ход сделать нельзя
        }
        else
            Debug.Log("Can't make a move:" + move); //сообщаем, что текущий ход сделать нельзя

    }

    void Update()
    {
        if (isMoving) //если фигуру нужно двигать
        {            
            currentPiece.transform.position = Vector3.MoveTowards(currentPiece.transform.position, toSquare.transform.position, movingSpeed * Time.deltaTime); //двигаем фигуру по прямой от начальной к конечной клетке со скоростью movingSpeed
            if (Vector3.Distance(currentPiece.transform.position, toSquare.transform.position) < 0.05f) //если фигура добралась до точки назначения (осталось двигать менее 0.05)
            {
                isMoving = false; //указываем, что больше передвигать фигуру не нужно
                currentPiece.transform.position = toSquare.transform.position; //ставим фигуру точно на нужную позицию

                if (toSquare.transform.childCount > 1)
                    Destroy(toSquare.transform.GetChild(1).gameObject); //если на целевой клетке была другая фигура - уничтожаем её

                currentPiece.transform.SetParent(toSquare.transform); //перепривязываем передвинутую фигуру к конечной клетке

                //обнуляем клетки и фигуру
                fromSquare = null;
                toSquare = null;
                currentPiece = null;
            }                
        }
    }
}
