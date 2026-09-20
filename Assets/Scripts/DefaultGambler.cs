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
        switch (mood) {
            case Mood.Ecstatic: {
                mood = Mood.Neutral;
                timesTillMoodChange = 3;
                bet -= 15;
                patience -= 15;
                break;
            } case Mood.Happy: {
                mood = Mood.Annoyed;
                timesTillMoodChange = 3;
                bet -=10;
                patience -= 10;
                break;
            } case Mood.Neutral: {
                mood = Mood.Angry;
                timesTillMoodChange = 3;
                bet += 10;
                patience -= 20;
                break;
            } case Mood.Annoyed: {
                endGamble();
                break;
            } case Mood.Angry: {
                endGamble();
                break;
            }
        }
        gambleOngoing = false;
        newGamble();
    }

    //How the gambler's behavior will change upon a minor loss
    public override void minorLoss() {
        //Gain back half the money they spent
        money += lastBet * 0.5;
        updateMoney(lastBet*0.5);
        switch (mood) {
            case Mood.Ecstatic: {
                mood = Mood.Happy;
                timesTillMoodChange = 3;
                bet -= 5;
                patience -= 5;
                break;
            } case Mood.Happy: {
                mood = Mood.Neutral;
                timesTillMoodChange = 3;
                bet -= 10;
                patience -= 5;
                break;
            } case Mood.Neutral: {
                timesTillMoodChange -= 1;
                if (timesTillMoodChange <= 0) {
                    mood = Mood.Annoyed;
                    timesTillMoodChange = 3;
                    bet -= 5;
                    patience -= 5;
                }
                break;
            } case Mood.Annoyed: {
                mood = Mood.Angry;
                timesTillMoodChange = 3;
                bet -= 5;
                patience -= 10;
                break;
            } case Mood.Angry: {
                endGamble();
                break;
            }
        }
        gambleOngoing = false;
        newGamble();
    }

    //How the gambler's behavior will change upon a minor win
    public override void minorWin() {
        //Gain 1.5x what they spent
        money += lastBet * 1.5;
        updateMoney(lastBet*1.5);
        switch (mood) {
            case Mood.Ecstatic: {
                bet += 5;
                patience += 1;
                break;
            } case Mood.Happy: {
                timesTillMoodChange -= 1;
                if (timesTillMoodChange <= 0) {
                   mood = Mood.Ecstatic;
                   timesTillMoodChange = 3;
                   bet += 15;
                   patience -= 10; 
                }
                break;
            } case Mood.Neutral: {
                mood = Mood.Happy;
                timesTillMoodChange = 3;
                bet += 10;
                patience += 5;
                break;
            } case Mood.Annoyed: {
                timesTillMoodChange -= 1;
                if (timesTillMoodChange <= 0) {
                   mood = Mood.Neutral;
                   timesTillMoodChange = 3;
                   bet += 5;
                   patience += 10; 
                }
                break;
            } case Mood.Angry: {
                timesTillMoodChange -= 1;
                if (timesTillMoodChange <= 0) {
                   mood = Mood.Ecstatic;
                   timesTillMoodChange = 3;
                   bet += 5;
                   patience += 5; 
                }
                break;
            }
        }
        gambleOngoing = false;
        newGamble();
    }

    //How the gambler's behavior will change upon a major win
    public override void majorWin() {
        //Gain 3x what they spent
        money += lastBet * 3;
        updateMoney(lastBet*3);
        switch (mood) {
            case Mood.Ecstatic: {
                bet += 15;
                maxPatience -= 10;
                break;
            } case Mood.Happy: {
                mood = Mood.Ecstatic;
                timesTillMoodChange = 3;
                bet += 10;
                maxPatience -= 5;
                break;
            } case Mood.Neutral: {
                mood = Mood.Ecstatic;
                timesTillMoodChange = 3;
                bet += 15;
                maxPatience -= 15;
                break;
            } case Mood.Annoyed: {
                mood = Mood.Neutral;
                timesTillMoodChange = 3;
                maxPatience += 10;
                break;
            } case Mood.Angry: {
                mood = Mood.Neutral;
                timesTillMoodChange = 3;
                bet -= 5;
                patience += 5;
                break;
            }
        }
        gambleOngoing = false;
        newGamble();
    }
}
