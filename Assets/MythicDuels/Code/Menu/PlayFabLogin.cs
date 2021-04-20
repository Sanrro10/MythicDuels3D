using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField] private GameObject signInDisplay = default;
    [SerializeField] private TMP_InputField usernameInputField = default;
    [SerializeField] private TMP_InputField emailInputField = default;
    [SerializeField] private TMP_InputField passwordInputField = default;
    [SerializeField] private TMP_InputField repeatPasswordInputField = default;
    [SerializeField] private TMP_Text errorText = default;
    [SerializeField] private TMP_Text repeatPasswordText = default;
    [SerializeField] private GameObject signInButton;
    [SerializeField] private GameObject createAccountButton;

    public static string SessionTicket;
    public static string EntityId;
    private static bool state = true;

    private void Start()
    {
        repeatPasswordText.SetText("");
        repeatPasswordInputField.DeactivateInputField();
        repeatPasswordInputField.gameObject.SetActive(false);
    }

    public void CreateAccount()
    {
        if (!state)
        {
            if (passwordInputField.text.Equals(passwordInputField.text))
            {
                PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
                {
                    Username = usernameInputField.text,
                    Email = emailInputField.text,
                    Password = passwordInputField.text
                }, result =>
                {
                    SessionTicket = result.SessionTicket;
                    EntityId = result.EntityToken.Entity.Id;
                    signInDisplay.SetActive(false);
                }, error =>
                {
                    Debug.LogError(error.GenerateErrorReport());
                    errorText.text = error.GenerateErrorReport();
                });
                errorText.SetText("");
            }
            else
            {
                errorText.SetText("Passwords don't match. Please retry");
            }
        }
        else
        {
            state = false;
            repeatPasswordText.SetText("Repeat password");
            repeatPasswordInputField.ActivateInputField();
            repeatPasswordInputField.gameObject.SetActive(true);
            signInButton.transform.position = new Vector3(signInButton.transform.position.x, -238, signInButton.transform.position.z);
            createAccountButton.transform.position = new Vector3(signInButton.transform.position.x, -238, signInButton.transform.position.z);

        }


    }

    public void SignIn()
    {
        if (state)
        {
            PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
            {
                Username = usernameInputField.text,
                Password = passwordInputField.text
            }, result =>
            {
                SessionTicket = result.SessionTicket;
                EntityId = result.EntityToken.Entity.Id;
                signInDisplay.SetActive(false);
            }, error =>
            {
                Debug.LogError(error.GenerateErrorReport());
            });
        }
        else
        {
            state = true;
            repeatPasswordText.SetText("");
            repeatPasswordInputField.DeactivateInputField();
            repeatPasswordInputField.gameObject.SetActive(false);
            signInButton.transform.position = new Vector3(signInButton.transform.position.x, -138, signInButton.transform.position.z);
            createAccountButton.transform.position = new Vector3(signInButton.transform.position.x, -138, signInButton.transform.position.z);

        }

    }

}
