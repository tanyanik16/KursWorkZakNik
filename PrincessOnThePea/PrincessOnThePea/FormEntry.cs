using System;
using System.Windows.Forms;
using PrincessonthepeaBussinesLogic.BuisnessLogic;
using Unity;


namespace PrincessOnThePea
{
    public partial class FormEntry : Form
    {
        private readonly ClientLogic _logicC;
        public FormEntry(ClientLogic logicC)
        {
            InitializeComponent();
            _logicC = logicC;
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {

            var form = Program.Container.Resolve<FormAutorization>();
            form.ShowDialog();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormRegistration>();
            form.ShowDialog();
        }
    }
}
