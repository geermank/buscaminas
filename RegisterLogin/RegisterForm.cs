using Buscaminas.RegisterLogin;
using BuscaminasAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class RegisterForm : Form, IRegisterFormView
    {
        private RegisterFormPresenter presenter;

        public RegisterForm()
        {
            InitializeComponent();
            presenter = new RegisterFormPresenter(this);
        }

        public void SetAsLogin()
        {
            presenter.SetAsLogin();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            presenter.OnFormStart();
        }

        private void buttonConfirmClick(object sender, EventArgs e)
        {
            if (presenter.IsLogin)
            {
                LoginUser();
            } else
            {
                RegisterUser();
            }
        }

        public void HideNameInput()
        {
            labelName.Visible = false;
            textBoxName.Visible = false;
        }

        public void SetConfirmButtonText(string confirmButtonText)
        {
            buttonConfirm.Text = confirmButtonText;
        }

        public void HideError()
        {
            labelError.Visible = false;
        }

        public void ShowError(string message)
        {
            labelError.Visible = true;
            labelError.Text = message;
        }

        public void ReturnSuccessResult()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoginUser()
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            presenter.LoginUser(email, password);
        }

        private void RegisterUser()
        {
            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            presenter.CreateUser(name, email, password);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
