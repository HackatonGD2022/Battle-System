using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    private const int size = 9 * 4;
    private List<Cell> cells = new List<Cell>(size);

    [SerializeField]
    private Cell cell;

    public void ShowItems()
    {
        foreach(Cell cell in cells)
        {
            if (cell.HasItem())
                cell.gameObject.SetActive(true);
        }
    }

    public void AddItem(Item item)
    {
        foreach(Cell cell in cells)
        {
            if(!cell.HasItem())
            {
                cell.SetItem(item);
                break;
            }
        }
    }

    public void Show()
    {
        foreach (Cell cell in cells)
            cell.gameObject.SetActive(true);
    }
    public void Hide()
    {
        foreach (Cell cell in cells)
            cell.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                cells.Add(Instantiate(cell, cell.transform.position + new Vector3(j * 50, -i * 43, 0), Quaternion.identity, gameObject.transform));
                cells[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
