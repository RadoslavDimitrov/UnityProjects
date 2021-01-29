using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject naught;
    public GameObject cross;

    int turn = 1;
    int winner = 0;
    int clickCount = 0;

    int[] squares = new int[9];
 

 

    public void SquareClicked(GameObject square)
    {

        //get the square number
        int squareNumber = square.GetComponent<ClickableSquares>().squareNumber;

        clickCount++;

        SpawnPrefab(square.transform.position);

        //Make the player own the square
        squares[squareNumber] = turn;

        CheckForWinner();
        //next player's turn
        NextTurn();

    }

    void CheckForWinner()
    {
        for (int player = 1; player <= 2; player++)
        if (squares[0] == player && squares[1] == player && squares[2] == player)
        {
                DisableSquares();
                print(player + "Win");
                winner = player;
        }
        else if (squares[3] == player && squares[4] == player && squares[5] == player)
        {
                DisableSquares();
                print(player + "Win");
                winner = player;
            }
        else if (squares[6] == player && squares[7] == player && squares[8] == player)
        {
                DisableSquares();
                print(player + "Win");
                winner = player;
            }
        else if (squares[0] == player && squares[3] == player && squares[6] == player)
        {
                DisableSquares();
                print(player + "Win");
                winner = player;
            }
        else if (squares[1] == player && squares[4] == player && squares[7] == player)
        {
                DisableSquares();
                print(player + "Win");
                winner = player;
            }
        else if (squares[2] == player && squares[5] == player && squares[8] == player)
        {
                DisableSquares();
                print(player + "Win");
                winner = player;
            }
        else if (squares[0] == player && squares[4] == player && squares[8] == player)
        {
                DisableSquares();
                print(player + "Win");
                winner = player;
            }
        else if (squares[2] == player && squares[4] == player && squares[6] == player)
        {
                DisableSquares();
                print(player + "Win");
                winner = player;
        }
        if(clickCount == 9 && winner == 0)
        {
            winner = 3;
        }


    }

    void DisableSquares()
    {
        //Destroy remaining squares
        foreach(ClickableSquares square in GameObject.FindObjectsOfType<ClickableSquares>())
        {
            Destroy(square);
        }
    }

    void SpawnPrefab(Vector3 position)
    {
        if(turn == 1)
        {
            Instantiate(naught, position, Quaternion.identity);
        }
        else if (turn == 2)
        {
            Instantiate(cross, position, Quaternion.identity);
        }

    }

    void NextTurn()
    {
        turn += 1;
        if(turn == 3)
        {
            turn = 1;
        }
    }

    private void OnGUI()
    {
        //check if we have a winner
        if(winner == 1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Naught is Winner!");
            

        }
        else if (winner == 2)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Cross is Winner!");
           
        }
        else if (winner == 3)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "It's a Draw!");
        }
        if(winner != 0)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 50), "Restart!"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }


}
