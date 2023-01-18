using UnityEngine;

public class Main : Functions
{
    private void Update()
    {
        if (!Input.anyKeyDown) return;

        var inputString = Input.inputString;
        if (int.TryParse(inputString, out var number))
            Debug.Log("The square is: " + Square(number));
        else
            Debug.Log("Invalid input");
    }
}