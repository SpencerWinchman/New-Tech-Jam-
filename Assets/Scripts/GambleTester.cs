using UnityEngine;

public class GambleTester : MonoBehaviour
{

    [SerializeField] private GamblerLogic myGambler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void majorLossPressed() {
        myGambler.majorLoss();
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
