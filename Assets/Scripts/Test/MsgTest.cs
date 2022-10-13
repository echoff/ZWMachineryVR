using System.Collections;
using System.Collections.Generic;
using com.ootii.Messages;
using UnityEngine;

public class MsgTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MessageDispatcher.AddListener("PartSelect",OnPartSelect);
    }

    private void OnPartSelect(IMessage rmessage)
    {
        print(rmessage.Data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
