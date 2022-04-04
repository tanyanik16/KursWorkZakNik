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
using PrincessonthepeaBussinesLogic.Enums;
using Unity;
namespace PrincessOnThePea
{
    public partial class FormRegistration : Form
    {
        private readonly ClientLogic _logicC;
        public FormRegistration(ClientLogic logicC) {

            InitializeComponent();
            _logicC = logicC;
            comboBoxRole.Items.AddRange(new string[] { "Клиент", "Сотрудник" });
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPassword.Text) ||
               comboBoxRole.SelectedValue != null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(comboBoxRole.Text))
            {
                MessageBox.Show("Необходимо выбрать роль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ClientBindingModel model = new ClientBindingModel
                {
                    Email = textBoxEmail.Text,
                    Password = textBoxPassword.Text,
                    Login = textBoxLogin.Text,
                    Status = (RoleStatus)Enum.Parse(typeof(RoleStatus), comboBoxRole.Text)
                };
                _logicC.CreateOrUpdate(model);
                Program.Client = _logicC.Read(model)?[0];
                MessageBox.Show("Регистрация прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                var form = Program.Container.Resolve<FormAutorization>();
                form.ShowDialog();
                Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
