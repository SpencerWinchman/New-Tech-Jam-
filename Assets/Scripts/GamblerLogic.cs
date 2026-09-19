using UnityEngine;

public class GamblerLogic : MonoBehaviour
{   

    //How much money the gambler has available to use
    double money = 100.0;
    //How much the gambler is betting each time
    double bet = 5.0;
    //How much money the gambler bet on their last bet
    double lastBet;
    //How much longer the gambler is *currently* willing to wait
    double patience = 30.0;
    //How long the gambler is willing to wait at the start of this gamble
    double max_patience = 30.0;
    //What the gambler's current "mood" displays as
    enum Mood {
        Angry,
        Annoyed,
        Neutral,
        Happy,
        Ecstatic
    }
    //The gambler's current mood
    Mood mood = Mood.Neutral;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        patience = patience - Time.deltaTime;
    }


    //How the gambler's behavior will change upon a major loss
    public void majorLoss() {
        
    }

    //How the gambler's behavior will change upon a minor loss
    public void minorLoss() {
        patience -= 5.0; //arbitrary value
        money -= lastBet * 0.5;
        newGamble();
    }

    //How the gambler's behavior will change upon a minor win
    public void minorWin() {
        newGamble();
    }

    //How the gambler's behavior will change upon a major win
    public void majorWin() {
        newGamble();
    }

    //Sets up the next gamble
    public void newGamble() {
        output();
    }

    //The gambler leaves
    public void endGamble() {
        
    }

    //Consolidates all variables as a string and prints it
    public void output() {
        Debug.Log("Money: " + money.ToString() + " Bet: " + bet.ToString() + " Last bet: " + lastBet.ToString() + " Max patience " + max_patience.ToString());
    }

}
