using UnityEngine;

public class DefaultGambler : GamblerLogic
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("New gambler");
        output();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //How the gambler's behavior will change upon a major loss
    public override void majorLoss() {
        //Lose everything they spent
        maxPatience -= 15.0;
        bet -= 10.0;
        gambleOngoing = false;
        newGamble();
    }

    //How the gambler's behavior will change upon a minor loss
    public override void minorLoss() {
        //Gain back half the money they spent
        money += lastBet * 0.5;
        updateMoney(lastBet*0.5);
        maxPatience -= 1.0;
        bet += 5;
        gambleOngoing = false;
        newGamble();
    }

    //How the gambler's behavior will change upon a minor win
    public override void minorWin() {
        //Gain 1.5x what they spent
        money += lastBet * 1.5;
        updateMoney(lastBet*1.5);
        maxPatience += 5.0;
        bet += 10.0;
        gambleOngoing = false;
        newGamble();
    }

    //How the gambler's behavior will change upon a major win
    public override void majorWin() {
        //Gain 3x what they spent
        money += lastBet * 3;
        updateMoney(lastBet*3);
        maxPatience += 15.0;
        bet *= 1.5;
        gambleOngoing = false;
        newGamble();
    }
}
