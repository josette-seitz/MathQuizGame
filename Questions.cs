using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class Questions : MonoBehaviour {
    public GameObject catObj;
    public GameObject question;
    public GameObject answerA;
    public GameObject answerB;
    public GameObject answerC;
    private GameObject[] disableQuestions;
    private GameObject[] objState;
    public GameObject correct;
    public GameObject incorrect;
    public GameObject seek;
    public EventTrigger choiceA;
    public EventTrigger choiceB;
    public EventTrigger choiceC;
    private BoxCollider box;
    private RaycasterScript rayScript;
    public List<TextMeshPro> textChoice;
    private AudioSource sourcePS;
    private AudioSource sourceMain;
    private AudioSource sourceCat;

    // Use this for initialization
    void Start () {
        disableQuestions = new GameObject[]{question, answerA, answerB, answerC};
        objState = new GameObject[] {catObj, correct, seek};
        correct.SetActive(false);
        seek.SetActive(false);
        incorrect.SetActive(false);
        box = catObj.GetComponent<BoxCollider>();
        rayScript = GameObject.FindObjectOfType(typeof(RaycasterScript)) as RaycasterScript;
        //Particle System of Cat
        sourcePS = catObj.transform.GetChild(2).GetComponent<AudioSource>();
        sourceMain = GameObject.Find("Player").GetComponent<AudioSource>();
        sourceCat = catObj.GetComponent<AudioSource>();

        //Set PointClick trigger UI via code
        //EventTrigger trigger = GetComponent<EventTrigger>();
        //EventTrigger.Entry entry = new EventTrigger.Entry();
        //entry.eventID = EventTriggerType.PointerClick;
        //entry.callback.AddListener((eventData) => { FirstQuestion(); });
        //trigger.triggers.Add(entry);

        //entry.callback.RemoveListener((eventData) => { FirstQuestion(); });
        //trigger.triggers.Remove(entry);
    }

    public void FirstQuestion()
    {
        if (gameObject.name == "C")
        {
            SetObjectState(true);
            DisableQuestion();
            question.GetComponent<TextMeshPro>().SetText("9 - 5 =");
            answerA.GetComponent<TextMeshPro>().SetText("4");
            answerB.GetComponent<TextMeshPro>().SetText("3");
            answerC.GetComponent<TextMeshPro>().SetText("2");
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "FirstQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "FirstQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "FirstQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "SecondQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "SecondQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "SecondQuestion", UnityEventCallState.RuntimeOnly);
        }
        if (gameObject.name == "A" || gameObject.name == "B")
        {
            incorrect.SetActive(true);
            Invoke("DisableIncorrect", 1.5f);
        }
    }

    public void SecondQuestion()
    {
        box.size = new Vector3(1f, 1f, 10f);
        if (gameObject.name == "A")
        {
            SetObjectState(true);
            DisableQuestion();
            question.GetComponent<TextMeshPro>().SetText("5 + 6 =");
            answerA.GetComponent<TextMeshPro>().SetText("10");
            answerB.GetComponent<TextMeshPro>().SetText("11");
            answerC.GetComponent<TextMeshPro>().SetText("12");
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "SecondQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "SecondQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "SecondQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "ThirdQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "ThirdQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "ThirdQuestion", UnityEventCallState.RuntimeOnly);
        }
        if (gameObject.name == "B" || gameObject.name == "C")
        {
            incorrect.SetActive(true);
            Invoke("DisableIncorrect", 1.5f);
        }
    }

    public void ThirdQuestion()
    {
        box.size = new Vector3(1f, 1f, 1f);
        if (gameObject.name == "B")
        {
            SetObjectState(true);
            DisableQuestion();
            question.GetComponent<TextMeshPro>().SetText("6 - 0 =");
            answerA.GetComponent<TextMeshPro>().SetText("5");
            answerB.GetComponent<TextMeshPro>().SetText("6");
            answerC.GetComponent<TextMeshPro>().SetText("7");
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "ThirdQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "ThirdQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "ThirdQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "FourthQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "FourthQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "FourthQuestion", UnityEventCallState.RuntimeOnly);
        }
        if (gameObject.name == "A" || gameObject.name == "C")
        {
            incorrect.SetActive(true);
            Invoke("DisableIncorrect", 1.5f);
        }
    }

    public void FourthQuestion()
    {
        box.size = new Vector3(1f, 1f, 5f);
        if (gameObject.name == "B")
        {
            SetObjectState(true);
            DisableQuestion();
            question.GetComponent<TextMeshPro>().SetText("21 + 5 =");
            answerA.GetComponent<TextMeshPro>().SetText("26");
            answerB.GetComponent<TextMeshPro>().SetText("16");
            answerC.GetComponent<TextMeshPro>().SetText("25");
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "FourthQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "FourthQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "FourthQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "FifthQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "FifthQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "FifthQuestion", UnityEventCallState.RuntimeOnly);
        }
        if (gameObject.name == "A" || gameObject.name == "C")
        {
            incorrect.SetActive(true);
            Invoke("DisableIncorrect", 1.5f);
        }
    }

    public void FifthQuestion()
    {
        if (gameObject.name == "A")
        {
            SetObjectState(true);
            DisableQuestion();
            question.GetComponent<TextMeshPro>().SetText("19 - 4 =");
            answerA.GetComponent<TextMeshPro>().SetText("23");
            answerB.GetComponent<TextMeshPro>().SetText("12");
            answerC.GetComponent<TextMeshPro>().SetText("15");
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "FifthQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "FifthQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "FifthQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "SixthQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "SixthQuestion", UnityEventCallState.RuntimeOnly);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "SixthQuestion", UnityEventCallState.RuntimeOnly);
        }
        if (gameObject.name == "B" || gameObject.name == "C")
        {
            incorrect.SetActive(true);
            Invoke("DisableIncorrect", 1.5f);
        }
    }

    public void SixthQuestion()
    {
        if (gameObject.name == "C")
        {
            DisableQuestion();
            foreach (TextMeshPro choice in textChoice)
            {
                choice.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            correct.GetComponent<TextMeshPro>().SetText("winner!");
            correct.SetActive(true);
            seek.SetActive(false);
            catObj.transform.localScale -= new Vector3(2f, 2f, 2f);
            catObj.SetActive(true);
            sourcePS.volume = 0f;
            sourceMain.mute = true;
            sourceCat.Play();
            rayScript.ActivateAnim();
            SetEventTriggerState(choiceA, EventTriggerType.PointerClick, "SixthQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceB, EventTriggerType.PointerClick, "SixthQuestion", UnityEventCallState.Off);
            SetEventTriggerState(choiceC, EventTriggerType.PointerClick, "SixthQuestion", UnityEventCallState.Off);
        }
        if (gameObject.name == "A" || gameObject.name == "B")
        {
            incorrect.SetActive(true);
            Invoke("DisableIncorrect", 1.5f);
        }
    }

    private void DisableQuestion()
    {
        foreach (GameObject question in disableQuestions)
        {
            question.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void EnableQuestion()
    {
        foreach (GameObject question in disableQuestions)
        {
            question.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void NextQuestion()
    {
        SetObjectState(false);
        EnableQuestion();
    }
    
    private void DisableIncorrect()
    {
        incorrect.SetActive(false);
    }

    private void SetObjectState(bool setState)
    {
        foreach (GameObject obj in objState)
        {
            obj.SetActive(setState);
        }
    }

    private void SetEventTriggerState(EventTrigger eventTrigger, EventTriggerType triggerType, string methodName, UnityEventCallState triggerState)
    {
        foreach (EventTrigger.Entry trigger in eventTrigger.triggers)
        {
            EventTrigger.Entry entry = trigger;
            EventTrigger.TriggerEvent callBack = entry.callback;

            for (int i = 0; i < callBack.GetPersistentEventCount(); i++)
            {
                if (callBack.GetPersistentMethodName(i) == methodName && entry.eventID == triggerType && triggerState == UnityEventCallState.Off)
                {
                    callBack.SetPersistentListenerState(i, UnityEventCallState.Off);
                }
                if (callBack.GetPersistentMethodName(i) == methodName && entry.eventID == triggerType && triggerState == UnityEventCallState.RuntimeOnly)
                {
                    callBack.SetPersistentListenerState(i, UnityEventCallState.RuntimeOnly);
                }
            }
        }
    }
}
