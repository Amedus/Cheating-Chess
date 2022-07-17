using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInitialization : MonoBehaviour
{
    [Header("Board Prefabs")]
    public GameObject gameBoard; //префаб шахматного поля
    public GameObject whiteSquare; //префаб для белых клеток
    public GameObject blackSquare; //префаб для чёрных клеток
    public GameObject squareName; //префаб для подписей к клеткам

    [Header("Pieces Prefabs")]
    public GameObject[] chessPieces; //префабы фигур в порядке: Король, Королева, Ладья, Слон, Конь, Пешка (сперва белые, потом чёрные)

    void AddPieceToTheSquare(string pieceName, string squareName) //функция помещает указанную фигуру на нужную клетку, формат "White Pawn", "A2"
    {
        int pieceNumber = 0;
        //выбираем номер фигуры по названию
        switch (pieceName.Split(' ')[1])
        {
            case "King":
                pieceNumber = 0;
                break;
            case "Queen":
                pieceNumber = 1;
                break;
            case "Rook":
                pieceNumber = 2;
                break;
            case "Bishop":
                pieceNumber = 3;
                break;
            case "Knight":
                pieceNumber = 4;
                break;
            case "Pawn":
                pieceNumber = 5;
                break;                                                                                
            default:
                Debug.Log("Piecename error!");
                break;
        }

        if (pieceName.Split(' ')[0] == "Black")
            pieceNumber += 6; //если нужна чёрная фигура, то к индексу фигуры добавляем 6
        
        GameObject currentSquare = GameObject.Find(squareName); //находим нужную клетку по названию
        GameObject currentPiece = Instantiate(chessPieces[pieceNumber], currentSquare.transform.position, currentSquare.transform.rotation); //создаём нужную фигуру на нужной клетке
        currentPiece.transform.SetParent(currentSquare.transform); //указываем новой фигуре родительский объект в качестве клетки
        currentPiece.name = chessPieces[pieceNumber].name; //переименовываем фигуру
    }

    void CreateBoard()
    {
        GameObject board = Instantiate(gameBoard, new Vector3(0,0,0), Quaternion.identity); //создаём экземпляр родительского объекта шахматного поля
        board.name = gameBoard.name; //переименовываем объект игровой доски

        //расставляем клетки доски
        for (int i = 0; i < 8; ++i)
        {
            int currentGap = 0; //определяем чётность данного столбца
            if (i % 2 == 0)
                currentGap = 1;
            for (int j = 0; j < 8; ++j)
                {
                    GameObject squareType = whiteSquare;
                    if (j % 2 != currentGap) //определяем текущую клетку, в зависимости от чётности столбца и ряда
                        squareType = blackSquare;
                    GameObject currentSquare = Instantiate(squareType, new Vector3(i,j,0), Quaternion.identity); //создаём клетку нужного типа
                    currentSquare.transform.SetParent(board.transform); //указываем для текущей клетки объект GameBoard в качестве родителя
                    currentSquare.name = (char)(65 + i) + (j + 1).ToString(); //переименовываем клетку в соответствии с её названием на шахматной доске
                }
        }

        //ищем родительский объект для подписей
        GameObject squareNames = GameObject.Find("SquaresNames");

        //создаём подписи к столбцам
        for (int i = 0; i < 8; ++i)
        {
            GameObject currentText = Instantiate(squareName, new Vector3(i,-1,0), Quaternion.identity); //создаём подпись из префаба
            currentText.name = ((char)(65 + i)).ToString(); //меняем имя объекта на нужный
            currentText.GetComponent<TextMeshPro>().text = currentText.name; //меняем текст подписи на нужный
            currentText.transform.SetParent(squareNames.transform); //указываем для текущей подписи объект CellsNames в качестве родителя
        }

        //создаём подписи к строкам
        for (int i = 0; i < 8; ++i)
        {
            GameObject currentText = Instantiate(squareName, new Vector3(-1,i,0), Quaternion.identity); //создаём подпись из префаба
            currentText.name = (i + 1).ToString(); //меняем имя объекта на нужный
            currentText.GetComponent<TextMeshPro>().text = currentText.name; //меняем текст подписи на нужный
            currentText.transform.SetParent(squareNames.transform); //указываем для текущей подписи объект CellsNames в качестве родителя
        }
    }

    void AddPiecesToStartingPositions() //расстановка фигур на стартовые позиции
    {
        AddPieceToTheSquare("White King","E1");
        AddPieceToTheSquare("Black King","E8");
        AddPieceToTheSquare("White Queen","D1");
        AddPieceToTheSquare("Black Queen","D8");
        AddPieceToTheSquare("White Rook","A1");
        AddPieceToTheSquare("Black Rook","A8");
        AddPieceToTheSquare("White Rook","H1");
        AddPieceToTheSquare("Black Rook","H8");
        AddPieceToTheSquare("White Bishop","C1");
        AddPieceToTheSquare("Black Bishop","C8");
        AddPieceToTheSquare("White Bishop","F1");
        AddPieceToTheSquare("Black Bishop","F8");
        AddPieceToTheSquare("White Knight","B1");
        AddPieceToTheSquare("Black Knight","B8");
        AddPieceToTheSquare("White Knight","G1");
        AddPieceToTheSquare("Black Knight","G8");

        for (int i = 0; i < 8; ++i) //расставляем пешки
        {
            AddPieceToTheSquare("White Pawn",((char)(65 + i)).ToString() + "2");
            AddPieceToTheSquare("Black Pawn",((char)(65 + i)).ToString() + "7");
        }
        
    }

    void Start()
    {
        CreateBoard();
        AddPiecesToStartingPositions();
        
    }

    void Update()
    {
        
    }
}
