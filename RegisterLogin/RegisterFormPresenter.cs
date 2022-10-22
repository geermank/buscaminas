using BuscaminasAuth;
using System;

namespace Buscaminas.RegisterLogin
{
    internal interface IRegisterFormView
    {
        void HideNameInput();
        void SetConfirmButtonText(string confirmButtonText);
        void HideError();
        void ShowError(string message);
        void ReturnSuccessResult();
    }

    internal class RegisterFormPresenter
    {
        private IRegisterFormView form;
        private bool isLogin;

        private Authentication authentication;

        public bool IsLogin
        {
            get { return isLogin; }
        }

        public RegisterFormPresenter(IRegisterFormView form)
        {
            this.form = form;
            this.authentication = Authentication.GetInstance();
        }

        public void OnFormStart()
        {
            if (isLogin)
            {
                form.HideNameInput();
                form.SetConfirmButtonText("Iniciar sesion");
            } else
            {
                form.SetConfirmButtonText("Registrarse");
            }
        }

        public void CreateUser(string name, string email, string password)
        {
            form.HideError();
            try
            {
                authentication.CreateUser(name, email, password);
                form.ReturnSuccessResult();
            } catch(AuthException ex)
            {
                form.ShowError(ex.Message);
            } catch(Exception)
            {
                form.ShowError("Hubo un error al crear el usuario, inténtelo nuevamente."); 
            }
        }

        public void LoginUser(string email, string password)
        {
            form.HideError();
            try
            {
                authentication.Login(email, password);
                form.ReturnSuccessResult();
            }   
            catch (AuthException ex)
            {
                form.ShowError(ex.Message);
            }
            catch (Exception)
            {
                form.ShowError("Hubo un error al iniciar sesión, inténtelo nuevamente.");
            }
        }

        public void SetAsLogin()
        {
            this.isLogin = true;
        }
    }
}
