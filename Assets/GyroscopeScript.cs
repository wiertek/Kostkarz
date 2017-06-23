using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroscopeScript : MonoBehaviour {
    public GUIStyle style;
    public Gyroscope gyroscope;
    public GameObject system, dice4, dice6, dice8, dice10, dice12;
    public Rigidbody diceRigidbody;
    public Button plusButton, minusButton;
    public int frameCounter;
    public int diceType = 1;
    public Queue<GameObject> dices4, dices6, dices8, dices10, dices12;
    public Dropdown diceTypeDropdown;
    // Use this for initialization
    void Start () {
		gyroscope = Input.gyro;
        gyroscope.enabled = true;
        system = GameObject.Find("System");
        dice4 = GameObject.Find("Dice4");
        dice6 = GameObject.Find("Dice6");
        dice8 = GameObject.Find("Dice8");
        dice10 = GameObject.Find("Dice10");
        dice12 = GameObject.Find("Dice12");
        dices4 = new Queue<GameObject>();
        dices6 = new Queue<GameObject>();
        dices8 = new Queue<GameObject>();
        dices10 = new Queue<GameObject>();
        dices12 = new Queue<GameObject>();
        GameObject tmp = Object.Instantiate(dice6, new Vector3(-0.1f, 2.5f, -0.8f), new Quaternion(), system.transform);
        dices6.Enqueue(tmp);
        diceRigidbody = dice6.GetComponent(typeof(Rigidbody)) as Rigidbody;     
        plusButton = GameObject.Find("PlusButton").GetComponent(typeof(Button)) as Button;
        plusButton.onClick.AddListener(OnPlusButtonClicked);
        minusButton = GameObject.Find("MinusButton").GetComponent(typeof(Button)) as Button;
        minusButton.onClick.AddListener(OnMinusButtonClicked);
        diceTypeDropdown = GameObject.Find("DiceTypeList").GetComponent(typeof(Dropdown)) as Dropdown;
        diceTypeDropdown.onValueChanged.AddListener(OnDiceTypeChange);
   }
	
	// Update is called once per frame
	void Update () {
        int k = 5;
        double border = 0.25;
        system.transform.rotation = Quaternion.Euler(gyroscope.gravity.y*90, 0, gyroscope.gravity.x * -90);
        if (Mathf.Abs(gyroscope.userAcceleration.x) > border || Mathf.Abs(gyroscope.userAcceleration.y) > border || Mathf.Abs(gyroscope.userAcceleration.z) > border)
        {
            diceRigidbody.AddForce(new Vector3(gyroscope.userAcceleration.x * k, gyroscope.userAcceleration.y * k, gyroscope.userAcceleration.z * k), ForceMode.Impulse);
            Rigidbody tmp;
            foreach (GameObject obj in dices4)
            {
                tmp = obj.GetComponent(typeof(Rigidbody)) as Rigidbody;
                tmp.AddForce(new Vector3(gyroscope.userAcceleration.x * k, gyroscope.userAcceleration.y * k, gyroscope.userAcceleration.z * k), ForceMode.Impulse);
            }
            foreach (GameObject obj in dices6)
            {
                tmp = obj.GetComponent(typeof(Rigidbody)) as Rigidbody;
                tmp.AddForce(new Vector3(gyroscope.userAcceleration.x * k, gyroscope.userAcceleration.y * k, gyroscope.userAcceleration.z * k), ForceMode.Impulse);
            }
            foreach (GameObject obj in dices8)
            {
                tmp = obj.GetComponent(typeof(Rigidbody)) as Rigidbody;
                tmp.AddForce(new Vector3(gyroscope.userAcceleration.x * k, gyroscope.userAcceleration.y * k, gyroscope.userAcceleration.z * k), ForceMode.Impulse);
            }
            foreach (GameObject obj in dices10)
            {
                tmp = obj.GetComponent(typeof(Rigidbody)) as Rigidbody;
                tmp.AddForce(new Vector3(gyroscope.userAcceleration.x * k, gyroscope.userAcceleration.y * k, gyroscope.userAcceleration.z * k), ForceMode.Impulse);
            }
            foreach (GameObject obj in dices12)
            {
                tmp = obj.GetComponent(typeof(Rigidbody)) as Rigidbody;
                tmp.AddForce(new Vector3(gyroscope.userAcceleration.x * k, gyroscope.userAcceleration.y * k, gyroscope.userAcceleration.z * k), ForceMode.Impulse);
            }
        }        
    }

    public void OnPlusButtonClicked()
    {
        GameObject tmp;
        if (diceType == 0) //4
        {
            tmp = Object.Instantiate(dice4, new Vector3(-0.1f, 2.5f, -0.8f), new Quaternion(), system.transform);
            dices4.Enqueue(tmp);
        } else if(diceType == 1) //6
        {
           tmp = Object.Instantiate(dice6, new Vector3(-0.1f, 2.5f, -0.8f), new Quaternion(), system.transform);
           dices6.Enqueue(tmp);

        } else if (diceType == 2) //8
        {
            tmp = Object.Instantiate(dice8, new Vector3(-0.1f, 2.5f, -0.8f), new Quaternion(), system.transform);
            dices8.Enqueue(tmp);
        } else if (diceType == 3) //10
        {
            tmp = Object.Instantiate(dice10, new Vector3(-0.1f, 2.5f, -0.8f), new Quaternion(), system.transform);
            dices10.Enqueue(tmp);

        } else if (diceType == 4) //12
        {
            tmp = Object.Instantiate(dice12, new Vector3(-0.1f, 2.5f, -0.8f), new Quaternion(), system.transform);
            dices12.Enqueue(tmp);
        }
       
    }
    public void OnMinusButtonClicked()
    {
        GameObject tmp;
        if (diceType == 0) //4
        {
            tmp = dices4.Dequeue();
            Object.Destroy(tmp);
        }
        else if (diceType == 1) //6
        {
            tmp = dices6.Dequeue();
            Object.Destroy(tmp);

        }
        else if (diceType == 2) //8
        {
            tmp = dices8.Dequeue();
            Object.Destroy(tmp);
        }
        else if (diceType == 3) //10
        {
            tmp = dices10.Dequeue();
            Object.Destroy(tmp);

        }
        else if (diceType == 4) //12
        {
            tmp = dices12.Dequeue();
            Object.Destroy(tmp);
        }
      
    }

    public void OnDiceTypeChange(int index)
    {
        diceType = index;
    }
    /* void OnGUI()
     {
         GUI.Label(new Rect(10, 10, 100, 20), "Test gyroscopu", style);
         GUI.Label(new Rect(10, 40, 100, 20), "Gravity: x:" + gyroscope.gravity.x + " y: " + gyroscope.gravity.y + " z:" + gyroscope.gravity.z, style);
         GUI.Label(new Rect(10, 70, 100, 20), "User acceleration: x:" + gyroscope.userAcceleration.x*10 + " y:" + gyroscope.userAcceleration.y * 10 + " z: " + gyroscope.userAcceleration.z * 10, style);
         GUI.Label(new Rect(10, 100, 100, 20), "User acceleration:" + gyroscope.userAcceleration.ToString());
     }*/
}
