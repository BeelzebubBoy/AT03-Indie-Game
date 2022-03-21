using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour, IInteractable
{
    #region boolean definition
    private bool exampleBool;

    public bool ExampleBool
    {
        get { return exampleBool; }
    }
    #endregion

    public delegate void InteractionDelegate();

    public event InteractionDelegate interactionEvent;
    private void OnEnable()
    {
        interactionEvent = new InteractionDelegate(TestMethod);
        interactionEvent += TestMethod;
    }

    private void OnDisable()
    {
        interactionEvent -= TestMethod;
        interactionEvent -= TestMethodTwo;
    }

    public void Activate()
    {
        interactionEvent.Invoke();
    }

    private void TestMethod()
    {
        Debug.Log("First Method has been executed.");
    }

    private void TestMethodTwo()
    {
        Debug.Log("Second Method has been executed");
    }

}
