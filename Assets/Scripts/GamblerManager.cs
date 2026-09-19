using UnityEngine;

public class GamblerManager : MonoBehaviour
{

    [SerializeField] private GameObject myGambler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable() {
        GamblerLogic.OnGamblerLeaving += swapGambler;
    }

    void OnDisable() {
        GamblerLogic.OnGamblerLeaving -= swapGambler;
    }

    public void swapGambler() {
        GamblerLogic oldGambler = myGambler.GetComponent<GamblerLogic>();
        if (oldGambler != null) {
            Destroy(oldGambler);
        }
        myGambler.AddComponent<DefaultGambler>();
    }

}
