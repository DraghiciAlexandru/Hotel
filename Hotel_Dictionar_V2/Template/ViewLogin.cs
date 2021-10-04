using Hotel_Dictionar_V2.Controler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Dictionar_V2.Template
{
    class ViewLogin : Panel
    {
        String path = Application.StartupPath;
        public TextBox txtName;
        public TextBox txtPass;
        public Button btnLogin;
        public Button btnRegister;

        public ViewLogin()
        {
            layout();
        }
        
        public void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(500, 300);
            this.ForeColor = Color.FromArgb(32, 178, 170);
            this.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            this.Location = new Point(0, 0);
            this.Name = "pnlLogin";

            setTxtName();
            setTxtPassword();
            setBtnLogin();
            setBtnRegister();
        }

        private void setTxtName()
        {
            txtName = new TextBox();
            txtName.AutoSize = false;
            txtName.Size = new Size(150, 20);
            txtName.Location = new Point(190, 100);
            txtName.Name = "txtName";
            txtName.Text = "Name:";
            txtName.BorderStyle = BorderStyle.None;
            txtName.BackColor = Color.FromArgb(40, 40, 40);
            txtName.ForeColor = Color.FromArgb(32, 178, 170);

            txtName.Enter += Txt_Enter;
            txtName.Leave += Txt_Leave;

            this.Controls.Add(txtName);
        }

        private void setTxtPassword()
        {
            txtPass = new TextBox();
            txtPass.AutoSize = false;
            txtPass.Size = new Size(150, 20);
            txtPass.Location = new Point(190, 140);
            txtPass.Name = "txtPassword";
            txtPass.Text = "Password:";
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.BackColor = Color.FromArgb(40, 40, 40);
            txtPass.ForeColor = Color.FromArgb(32, 178, 170);

            txtPass.Enter += Txt_Enter;
            txtPass.Leave += Txt_Leave;

            this.Controls.Add(txtPass);
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text.Trim(' ') == "")
            {
                if (text.Name == "txtName")
                    text.Text = "Name:";
                else if (text.Name == "txtPassword")
                {
                    text.Text = "Password:";
                    text.PasswordChar = default;
                }
            }
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text == "Name:" || text.Text == "Password:")
            {
                if(text.Text == "Password:")
                {
                    text.PasswordChar = '●';
                }
                text.Text = "";
            }
        }

        private void setBtnLogin()
        {
            btnLogin = new Button();
            btnLogin.Size = new Size(150, 40);
            btnLogin.Location = new Point(75, 200);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Text = "   Login";
            btnLogin.Name = "btnLogin";
            btnLogin.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            btnLogin.Image = Image.FromFile(path + @"\resources\user_male_30px.png");
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.TextAlign = ContentAlignment.MiddleLeft;
            btnLogin.TextImageRelation = TextImageRelation.ImageBeforeText;

            this.Controls.Add(btnLogin);

        }

        private void setBtnRegister()
        {
            btnRegister = new Button();
            btnRegister.Size = new Size(150, 40);
            btnRegister.Location = new Point(270, 200);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Text = "  Register";
            btnRegister.Name = "btnRegister";
            btnRegister.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            btnRegister.Image = Image.FromFile(path + @"\resources\profiles_30px.png");
            btnRegister.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegister.TextAlign = ContentAlignment.MiddleLeft;
            btnRegister.TextImageRelation = TextImageRelation.ImageBeforeText;

            this.Controls.Add(btnRegister);
        }

    }
}
