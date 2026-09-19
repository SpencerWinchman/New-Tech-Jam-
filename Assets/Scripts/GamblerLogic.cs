using UnityEngine;
using System;

public class GamblerLogic : MonoBehaviour
{   

    //How much money the gambler has available to use
    public double money = 100.0;
    //How much the gambler is betting each time
    public double bet = 5.0;
    //How much money the gambler bet on their last bet
    public double lastBet;
    //How much longer the gambler is *currently* willing to wait
    public double patience = 30.0;
    //How long the gambler is willing to wait at the start of this gamble
    public double maxPatience = 30.0;
    //If the current gamble has started
    public bool gambleOngoing = false;
    //What the gambler's current "mood" displays as
    public enum Mood {
        Angry,
        Annoyed,
        Neutral,
        Happy,
        Ecstatic
    }
    public static event Action OnGamblerLeaving; 
    public event EventHandler<double> OnMoneyChanging;
    //The gambler's current mood
    public Mood mood = Mood.Neutral;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newGamble();
        money = 100.0;
        bet = 5.0;
        lastBet = 0;
        patience = 30.0;
        maxPatience = 30.0;
        gambleOngoing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //patience = patience - Time.deltaTime;
        if (patience <= 0) {
            gambleOngoing = false;
            endGamble();
        }
    }


    //How the gambler's behavior will change upon a major loss
    public virtual void majorLoss() {
       //Specific behavior
        gambleOngoing = false;
        newGamble();
    }

    //How the gambler's behavior will change upon a minor loss
    public virtual void minorLoss() {
        //Specific behavior
        gambleOngoing = false;
        newGamble();
    }

    //How the gambler's behavior will change upon a minor win
    public virtual void minorWin() {
        //Specific behavior
        gambleOngoing = false;
        newGamble();
    }

    //How the gambler's behavior will change upon a major win
    public virtual void majorWin() {
        //Specific behavior
        gambleOngoing = false;
        newGamble();
    }

    //Sets up the next gamble
    public void newGamble() {
        if (money <= 0 || bet <= 0) {
            endGamble();
        } else {
            if (money < bet) {
                bet = money;
            } 
            money -= bet;
            updateMoney(-bet);
            lastBet = bet;
            patience = maxPatience;
            gambleOngoing = true;
            output();
        }
    }

    //The gambler leaves
    public void endGamble() {
        OnGamblerLeaving?.Invoke();
    }

    //Consolidates all variables as a string and prints it
    public void output() {
        Debug.Log("Money: " + money.ToString() + " Bet: " + bet.ToString() + " Last bet: " + lastBet.ToString() + " Max patience " + maxPatience.ToString() + " Mood: " + mood.ToString());
    }

    protected virtual void updateMoney(double amount) {
        OnMoneyChanging?.Invoke(this, amount);
    }  

}
