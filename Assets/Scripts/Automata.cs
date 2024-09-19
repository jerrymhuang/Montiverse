using System.Linq;
using UnityEngine;


/// <summary>
/// Implements a 2D version of cellular automata as organic cubic sculptures.
/// </summary>
public class Automata : MonoBehaviour
{
    [SerializeField]
    Vector3Int size = Vector3Int.one * 8;

    [SerializeField, Range(0f, 1f)]
    float gapSize = 0.125f;

    [SerializeField]
    GameObject cellBlock;

    int[] oldCells, newCells;
    int generation = 0;
    int cellCount;


    void Start()
    {
        cellCount = size.x * size.z;
        newCells = new int[cellCount];
        Generate(newCells);
    }


    void Generate(int[] cells)
    {
        GameObject cell;

        for (int j = 0; j < size.y; j++)
        {
            for (int i = 0; i < cellCount; i++)
            {
                if (j == 0)
                {
                    cells[i] = (int)Mathf.Round(Random.value);
                }
                else
                {
                    int[] neighbors = GetNeighbors(i);
                    cells[i] = EvolveFrom(neighbors);
                }

                if (cells[i] == 1)
                {
                    float x = (i % size.x) - 0.5f * (size.x - 1);
                    float z = Mathf.FloorToInt(i / size.z) - 0.5f * (size.z - 1);
                    cell = Instantiate(cellBlock);
                    cell.transform.position =
                        new Vector3(x, generation, z) * (1 + gapSize);
                    cell.transform.parent = transform;
                }
            }
        }
        oldCells = cells;
        generation++;
    }


    int EvolveFrom(int[] neighbors)
    {
        int newCell = 0;
        if (neighbors.Sum() < 2 || neighbors.Sum() > 3) newCell = 0;
        else if (neighbors.Sum() == 3) newCell = 1;
        Debug.Log(neighbors.Sum());
        return newCell;
    }


    int[] GetNeighbors(int location)
    {
        int[] neighbors = new int[9];
        neighbors[0] = (location - size.x - 1) % cellCount;
        neighbors[1] = (location - size.x) % cellCount;
        neighbors[2] = (location - size.x + 1) % cellCount;
        neighbors[3] = (location - 1) % cellCount;
        neighbors[4] = location % cellCount;
        neighbors[5] = (location + 1) % cellCount;
        neighbors[6] = (location + size.x - 1) % cellCount;
        neighbors[7] = (location + size.x) % cellCount;
        neighbors[8] = (location + size.x + 1) % cellCount;
        return neighbors;
    }

}
