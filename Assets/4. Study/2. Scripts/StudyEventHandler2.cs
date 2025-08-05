using System;
using UnityEngine;

public class StudyEventHandler2 : MonoBehaviour
{

    public class DataClass : EventArgs
    {
        public string dataName;
        public DataClass(String dataName)
        {
            this.dataName = dataName;
        }
    }

    private event EventHandler<DataClass> handler;
    private void Start()
    {
        handler += MethodB;

        DataClass dataClass = new DataClass("Hello Unity");
        handler?.Invoke(this, dataClass);

    }

    private void MethodB(object o, DataClass e)
    {
        Debug.Log(e.dataName);
    }
}
