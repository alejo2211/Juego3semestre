using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using UnityEngine.UI;
using TMPro;
using Firebase.Extensions;

public class DBManager : MonoBehaviour
{
    FirebaseAuth auth;
    FirebaseUser user;
    DependencyStatus dependencyStatus;

    [Header("Datos Inicio")]
    public TMP_InputField correo_Inicio;
    public TMP_InputField contrasena_Inicio;

    [Header("Datos Registro")]
    public TMP_InputField correo_Registro;
    public TMP_InputField contrasena_Registro;
    public TMP_InputField Rcontrasena_Registro;

    [Header("Paneles")]
    public GameObject panelInicio;
    public GameObject panelRegitro;
    public GameObject panelWait;
    public GameObject PanelGame;

    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("No firebase services" + dependencyStatus);
            }
        });
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
                panelInicio.SetActive(true);
                panelRegitro.SetActive(true);
                panelWait.SetActive(true);
                PanelGame.SetActive(false);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                panelInicio.SetActive(false);
                panelRegitro.SetActive(false);
                panelWait.SetActive(false);
                PanelGame.SetActive(true);
            }
        }
    }

    TransactionResult AddNewUserTransaction(MutableData mutableData)
    {
        if(mutableData != null)
        {
            List<object> users = mutableData.Value as List<object>;
            if(users == null)
            {
                users = new List<object>();
            }
            users = new List<object>();
            Dictionary<string, object> newUserRegistration = new Dictionary<string, object>();
            newUserRegistration["Email"] = correo_Registro.text;
            //newUserRegistration["Coins"] = "1000";
            //newUserRegistration["Points"] = "1000";
            //newUserRegistration["Diamont"] = "3";
            newUserRegistration["Level"] = "1";
            users.Add(newUserRegistration);
            mutableData.Value = users;
            return TransactionResult.Success(mutableData);
        }
        else
        {
            return TransactionResult.Success(mutableData);
        }
    }
    void AddNewUser()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("users");
        DatabaseReference usersAddNow = reference.Child(user.UserId);
        usersAddNow.RunTransaction(AddNewUserTransaction).ContinueWithOnMainThread(Task => {
            if(Task.Exception != null)
            {
                Debug.Log(Task.Exception.ToString());
            }
            if(Task.IsCompleted)
            {
                Debug.Log("Registro exitoso");
            }
        });
    }

    public void Iniciar()
    {
        StartCoroutine(Iniciar_User(correo_Inicio.text, contrasena_Inicio.text));
    }
    public void Registrar()
    {
        StartCoroutine(Registrar_User(correo_Registro.text, contrasena_Registro.text));
    }



    IEnumerator Iniciar_User(string email, string pass)
    {
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(email, pass);
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);
        if (LoginTask.Exception != null)
        {
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Registro fallido";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Falta correo";
                    break;
                case AuthError.MissingPassword:
                    message = "Falta contraseña";
                    break;
                case AuthError.InvalidEmail:
                    message = "Email Invalido";
                    break;
                case AuthError.UserNotFound:
                    message = "La cuenta no existe";
                    break;
            }
            panelWait.SetActive(false);
            Debug.Log(message);
        }
        else
        {
            user = LoginTask.Result.User;
            panelInicio.SetActive(false);
            panelRegitro.SetActive(false);
            panelWait.SetActive(false);
            PanelGame.SetActive(true);
        }
    }

    IEnumerator Registrar_User(string email, string pass)
    {
        if(contrasena_Registro.text == Rcontrasena_Registro.text)
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(email, pass);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);
            if(RegisterTask.Exception != null)
            {
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Registro fallido";
                switch(errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Falta el correo";
                        break;
                    case AuthError.MissingPassword:
                        message = "Falta la contraseña";
                        break;
                    case AuthError.WrongPassword:
                        message = "Contraseña debil";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Correo ya en uso";
                        break;
                }
                panelWait.SetActive(false);
                Debug.Log(message);
            }
            else
            {
                user = RegisterTask.Result.User;
                AddNewUser();
            }
        }
        else
        {
            Debug.Log("Verifique los datos");
        }
    }

    public void SignOut()
    {
        auth.SignOut();
        //----------borrar al exportar
        panelInicio.SetActive(true);
        panelRegitro.SetActive(true);
        panelWait.SetActive(false);
        PanelGame.SetActive(false);
    }
}
