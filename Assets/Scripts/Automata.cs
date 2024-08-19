
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

    void Start()
    {
        newCells = new int[size.x * size.z];
        Generate(newCells);
    }

    void Generate(int[] cells)
    {
        GameObject cell;
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = (int)Mathf.Round(Random.value);
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
        oldCells = cells;
        generation++;
    }

    void EvolveFrom(int[] neighbors)
    {

    }

}
