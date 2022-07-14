using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateBoard : MonoBehaviour
{
    public GameObject whiteCell; //префаб для белых клеток
    public GameObject blackCell; //префаб для чёрных клеток
    public GameObject cellName; //префаб для подписей к клеткам

    void Start()
    {
        //создаём шахматную доску при запуске сцены
        for (int i = 0; i < 8; ++i)
        {
            int currentGap = 0; //определяем чётность данного столбца
            if (i % 2 == 0)
                currentGap = 1;
            for (int j = 0; j < 8; ++j)
                {
                    GameObject cellType = whiteCell;
                    if (j % 2 != currentGap) //определяем текущую клетку, в зависимости от чётности столбца и ряда
                        cellType = blackCell;
                    GameObject currentCell = Instantiate(cellType, new Vector3(i,j,0), Quaternion.identity); //создаём клетку нужного типа
                    currentCell.transform.SetParent(this.transform); //указываем для текущей клетки объект GameBoard в качестве родителя
                    currentCell.name = (char)(65 + i) + (j + 1).ToString(); //переименовываем клетку в соответствии с её названием на шахматной доске
                }
        }

        //ищем родительский объект для подписей
        GameObject cellsNames = GameObject.Find("CellsNames");

        //создаём подписи к столбцам
        for (int i = 0; i < 8; ++i)
        {
            GameObject currentText = Instantiate(cellName, new Vector3(i,-1,0), Quaternion.identity); //создаём подпись из префаба
            currentText.GetComponent<TextMeshPro>().text = ((char)(65 + i)).ToString(); //меняем текст подписи на нужный
            currentText.transform.SetParent(cellsNames.transform); //указываем для текущей подписи объект CellsNames в качестве родителя
        }

        //создаём подписи к строкам
        for (int i = 0; i < 8; ++i)
        {
            GameObject currentText = Instantiate(cellName, new Vector3(-1,i,0), Quaternion.identity); //создаём подпись из префаба
            currentText.GetComponent<TextMeshPro>().text = (i + 1).ToString(); //меняем текст подписи на нужный
            currentText.transform.SetParent(cellsNames.transform); //указываем для текущей подписи объект CellsNames в качестве родителя
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
