using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = GameObject.Find("Confirm").GetComponent<Button>();
        button.onClick.AddListener(OnMouseDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnMouseDown()
	{
        InputField in1 = GameObject.Find("Login").GetComponent<InputField>();
        InputField in2 = GameObject.Find("Password").GetComponent<InputField>();
        string login = in1.text;
        string password = in2.text;
        if (login == "")
        {
            print("Enter login");
            return;
        }
        if(password == "")
        {
            print("Enter password");
            return;
        }
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://time-gun.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;       
        FirebaseDatabase.DefaultInstance
      .GetReference("logins")
      .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {              
              DataSnapshot snapshot = task.Result;
              bool add = true;
              foreach(DataSnapshot names in snapshot.Children)
              {                  
                  if(login == names.Key.ToString())
                  {
                      add = false;
                      break;
                  }
              }
              if (add == true)
              {
                  
                  print("Success   user " + login + " password " + password);
                  reference.Child("logins").Child(login).SetValueAsync(password);
                  
              }
              else
                  print("This login already exists");
          }
      });

    }	
}
