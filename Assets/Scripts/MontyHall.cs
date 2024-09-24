using UnityEngine;


/* 
 * The following code is substantially modified
 * based on outputs from ChatGPT.
 */

public class MontyHall : MonoBehaviour
{
    public GameObject[] doors;  // Array to hold the 3 door GameObjects
    private int winningDoor;     // Index of the door with the prize
    private int playerChoice;    // Player's choice
    private int revealedDoor;    // Host's revealed door
    private bool gameEnded = false;

    // Colors for doors
    private Color defaultColor = Color.white;
    private Color chosenColor = Color.blue;
    private Color revealedColor = Color.red;
    private Color winningColor = Color.green;

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        // Reset all doors to default color
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].GetComponent<Renderer>().material.color = defaultColor;
        }

        // Randomly assign the prize behind one of the doors
        winningDoor = Random.Range(0, doors.Length);
        playerChoice = -1;
        revealedDoor = -1;
        gameEnded = false;
    }

    void Update()
    {
        if (!gameEnded)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    PlayerChooseDoor(i);
                }
            }
        }

        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            InitializeGame();
        }
    }

    void PlayerChooseDoor(int choice)
    {
        if (playerChoice == -1)
        {
            playerChoice = choice;
            doors[playerChoice].GetComponent<Renderer>().material.color = chosenColor;
            RevealHostDoor();
        }
        else
        {
            // If player chooses again after host reveals
            playerChoice = choice;
            doors[playerChoice].GetComponent<Renderer>().material.color = chosenColor;
            CheckWin();
        }
    }

    void RevealHostDoor()
    {
        // Reveal one of the remaining doors that does not have the prize
        for (int i = 0; i < doors.Length; i++)
        {
            if (i != playerChoice && i != winningDoor)
            {
                revealedDoor = i;
                doors[revealedDoor].GetComponent<Renderer>().material.color = revealedColor;
                break;
            }
        }
    }

    void CheckWin()
    {
        // Change the colors to indicate winning or losing
        gameEnded = true;

        for (int i = 0; i < doors.Length; i++)
        {
            if (i == winningDoor)
            {
                doors[i].GetComponent<Renderer>().material.color = winningColor;
            }
            else if (i != revealedDoor && i != winningDoor)
            {
                doors[i].GetComponent<Renderer>().material.color = chosenColor;
            }
        }

        // Print result
        if (playerChoice == winningDoor)
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("You lose! The winning door was: " + (winningDoor + 1));
        }
    }
}