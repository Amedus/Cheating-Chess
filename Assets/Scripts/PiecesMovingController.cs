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
        GameEvents.current.onMakeMove += MakeMove; //������������� �� ������� MakeMove
    }

    private void MakeMove(string move) //��������� ��������, ������� ����� ����������� ��� ������� �������
    {
        GameObject fromSquare = GameObject.Find(move.Substring(0, 2)); //������� �� ������ ���� �������� ���� ��������� ������
        GameObject toSquare = GameObject.Find(move.Substring(2, 2)); //�� ��������� ���� �������� ���� ������� ������� ������
        if (fromSquare.transform.childCount > 1) //���������, ��� �� ��������� ������ ���� ������
        {
            GameObject currentPiece = fromSquare.transform.GetChild(1).gameObject; //�� ��������� ������ ������� ������, �������� ����� ����������� �� ��������� � ������� ������

            if ((fromSquare) && (toSquare) && (currentPiece) && (toSquare != fromSquare)) //����������, ��� ����� ��������� � ������� ������, � ��� �� ��������� ���� ������
            {
                isMoving = true; //���������, ��� ����� ������� ������
                from = fromSquare; //������
                to = toSquare; //� ����
            }
            else
                Debug.Log("Can't make a move:" + move);
        }
        else
            Debug.Log("Can't make a move:" + move);

    }

    void Update()
    {
        if (isMoving) //���� ����� ������� ������
        {
            GameObject currentPiece = from.transform.GetChild(1).gameObject; //���� ������ �� �������� ������ ����� �������� ������
            currentPiece.transform.position = Vector3.MoveTowards(currentPiece.transform.position, to.transform.position, 0.025f); //������� ������ �� 2,5% �� ����
            if (currentPiece.transform.position == to.transform.position) //���� ������ �������
            {
                isMoving = false; //���������, ��� �������� ���������
                if (to.transform.childCount > 1)
                    Destroy(to.transform.GetChild(1).gameObject); //���� �� ������� ������ ���� ������ - ���������� �

                currentPiece.transform.SetParent(to.transform); //����������� ������������ ������ � ����� ������
                currentPiece.transform.position = to.transform.position; //������� ������ �� ����� ������*/
            }                
        }
    }
}
