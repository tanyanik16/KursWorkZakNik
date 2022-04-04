using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.BuisnessLogic;
using Unity;

namespace PrincessOnThePea
{
    public partial class FormAutorization : Form
    {
        private readonly ClientLogic _logicC;
        public FormAutorization(ClientLogic logicC)
        {
            InitializeComponent();
            _logicC = logicC;
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            Program.Client = _logicC.Read(new ClientBindingModel { Login = "user" })?[0];
            var form1 = Program.Container.Resolve<FormMain>();
            form1.ShowDialog();
            Hide();
            return;
            if (string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            var client = _logicC.Read(new ClientBindingModel { Login = textBoxLogin.Text, Password = textBoxPassword.Text })?[0];
            if (client == null)
            {
                MessageBox.Show("Неверный Email или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            else
            {
                Program.Client = client;
                var form = Program.Container.Resolve<FormMainClient>();
                form.ShowDialog();
                Hide();
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
