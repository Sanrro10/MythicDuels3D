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
            if (usernameInputField.text.Length != 0 && emailInputField.text.Length != 0 && passwordInputField.text.Length != 0 && repeatPasswordInputField.text.Length != 0)
            {
                if (passwordInputField.text.Equals(repeatPasswordInputField.text))
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
            else { }
        }
        else
        {
            state = false;
            repeatPasswordText.SetText("Repeat password");
            repeatPasswordInputField.ActivateInputField();
            repeatPasswordInputField.gameObject.SetActive(true);
            signInButton.transform.localPosition = new Vector3(signInButton.transform.localPosition.x, - 238, signInButton.transform.localPosition.z);
            createAccountButton.transform.localPosition = new Vector3(createAccountButton.transform.localPosition.x, -238, createAccountButton.transform.localPosition.z);

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
                errorText.text = error.GenerateErrorReport();
            });
        }
        else
        {
            state = true;
            repeatPasswordText.SetText("");
            repeatPasswordInputField.DeactivateInputField();
            repeatPasswordInputField.gameObject.SetActive(false);
            signInButton.transform.localPosition = new Vector3(signInButton.transform.localPosition.x, -138, signInButton.transform.localPosition.z);
            createAccountButton.transform.localPosition = new Vector3(createAccountButton.transform.localPosition.x, -138, createAccountButton.transform.localPosition.z);

        }

    }

}
