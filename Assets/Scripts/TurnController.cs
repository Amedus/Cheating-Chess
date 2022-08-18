using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public string currentTurn = "White";
    public int whiteCheatStage = 0;
    public int blackCheatStage = 0;

    void Start()
    {
        GameEvents.current.onNextTurn += NextTurn;
    }

    public string SquareAside(string square, int plusX, int plusY) //return name of square +X +Y coords or return empty string if new square not exist
    {
        string newSquare = "";

        if (square.Length == 2)
        {
            char squareX = (char)((int)square[0] + plusX);
            char squareY = (char)((int)square[1] + plusY);
            newSquare = string.Join("", squareX, squareY);
        }

        if (GameObject.Find(newSquare))
            return newSquare;
        else
            return "";
    }

    public List<string> SquaresAside(string square, int plusX, int plusY) //return list of names of square +X +Y coords or return empty string if new square not exist
    {
        List<string> possibleSquares = new List<string>();
        GameObject nextSquare = GameObject.Find(SquareAside(square, plusX, plusY));

        while (nextSquare != null)
        {
            possibleSquares.Add(nextSquare.name);
            nextSquare = GameObject.Find(SquareAside(nextSquare.name, plusX, plusY));

            if ((nextSquare != null) && (nextSquare.transform.childCount > 1))
            {
                possibleSquares.Add(nextSquare.name);
                return possibleSquares;
            }
        }

        return possibleSquares;
    }

    private string WhosThere(string squareName) //return piece color or empty string of target square
    {
        GameObject targetSquare = GameObject.Find(squareName);
        if (targetSquare.transform.childCount > 1)
            return targetSquare.transform.GetChild(1).gameObject.tag;
        else
            return "";
    }

    private List<string> ValidMoves(List<string> possibleSquares, string fromSquare, string playerColor)
    {
        possibleSquares.RemoveAll(x => x == ""); //remove not existing squares
        possibleSquares.RemoveAll(x => WhosThere(x) == playerColor); //remove squares with allies

        for (int i = 0; i < possibleSquares.Count; ++i)
            possibleSquares[i] = fromSquare + possibleSquares[i]; //add fromsquare to moves

        return possibleSquares;
    }    

    public List<string> PlayerPossibleMoves(string playerColor) //return list of possible moves for specific player
    {
        List<string> possibleMoves = new List<string>();

        return possibleMoves;
    }

    private List<string> KingMoves(string color, string fromSquare, int cheatStage) //return list of possible moves for King with specific color on fromSquare
    {
        List<string> possibleSquares = new List<string>();

        possibleSquares.Add(SquareAside(fromSquare, 0, 1));
        possibleSquares.Add(SquareAside(fromSquare, 1, 1));
        possibleSquares.Add(SquareAside(fromSquare, 1, 0));
        possibleSquares.Add(SquareAside(fromSquare, 1, -1));
        possibleSquares.Add(SquareAside(fromSquare, 0, -1));
        possibleSquares.Add(SquareAside(fromSquare, -1, -1));
        possibleSquares.Add(SquareAside(fromSquare, -1, 0));
        possibleSquares.Add(SquareAside(fromSquare, -1, 1));

        return ValidMoves(possibleSquares, fromSquare, color);
    }

    private List<string> QueenMoves(string color, string fromSquare, int cheatStage) //return list of possible moves for Queen with specific color on fromSquare
    {
        List<string> possibleSquares = new List<string>();

        possibleSquares.AddRange(SquaresAside(fromSquare, 0, 1));
        possibleSquares.AddRange(SquaresAside(fromSquare, 1, 1));
        possibleSquares.AddRange(SquaresAside(fromSquare, 1, 0));
        possibleSquares.AddRange(SquaresAside(fromSquare, 1, -1));
        possibleSquares.AddRange(SquaresAside(fromSquare, 0, -1));
        possibleSquares.AddRange(SquaresAside(fromSquare, -1, -1));
        possibleSquares.AddRange(SquaresAside(fromSquare, -1, 0));
        possibleSquares.AddRange(SquaresAside(fromSquare, -1, 1));

        return ValidMoves(possibleSquares, fromSquare, color);
    }

    private void NextTurn(string playerColor)
    {

    }

    void Update()
    {

        if (currentTurn == "White")
        {
            foreach (string move in QueenMoves("White", "A3", 0))
                Debug.Log(move);

            currentTurn = "Black";
        }

    }
}
