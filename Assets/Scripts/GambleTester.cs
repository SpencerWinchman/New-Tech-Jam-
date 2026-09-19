using UnityEngine;

public class GambleTester : MonoBehaviour
{

    [SerializeField] private GamblerLogic myGambler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Program start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void majorLossPressed() {
        Debug.Log("Button pressed");
        myGambler.majorLoss();
        Debug.Log("Button pressed");
    }

    public void minorLossPressed() {
        myGambler.minorLoss();
    }

    public void minorWinPressed() {
        myGambler.minorWin();
    }

    public void majorWinPressed() {
        myGambler.majorWin();
    }
}
