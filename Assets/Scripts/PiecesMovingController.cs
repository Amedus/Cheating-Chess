using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesMovingController : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onMakeMove += MakeMove; //������������� �� ������� MakeMove
    }

    private void MakeMove(string move) //��������� ��������, ������� ����� ����������� ��� ������� �������
    {
        GameObject fromSquare = GameObject.Find(move.Substring(0, 2)); //������� �� ������ ���� �������� ���� ��������� ������
        GameObject toSquare = GameObject.Find(move.Substring(2, 2)); //�� ��������� ���� �������� ���� ������� ������� ������
        GameObject currentPiece = fromSquare.transform.GetChild(0).gameObject; //�� ��������� ������ ������� ������, �������� ����� ����������� �� ��������� � ������� ������
        if ((fromSquare) && (toSquare) && (currentPiece)) //����������, ��� ����� ��������� � ������� ������, � ��� �� ��������� ���� ������
        {
            if (toSquare.transform.GetChild(0).gameObject)
                Destroy(toSquare.transform.GetChild(0).gameObject); //���� �� ������� ������ ���� ������ - ���������� �

            currentPiece.transform.SetParent(toSquare.transform); //����������� ������������ ������ � ����� ������
            currentPiece.transform.position = toSquare.transform.position; //������� ������ �� ����� ������
        }
        else
            Debug.Log("Can't make a move:" + move);     
    }

    void Update()
    {
        
    }
}
