using Hotel_Dictionar_V2.Controler;
using Hotel_Dictionar_V2.Model;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Dictionar_V2.Template
{
    class PanelRezervare : Panel
    {
        String path = Application.StartupPath;
        private ControlCustomers controlCustomers;
        private ControlBookings controlBookings;

        public PanelRezervare(Client loged)
        {
            controlCustomers = new ControlCustomers();
            controlBookings = new ControlBookings();
            controlCustomers.loged = loged;

            layout();
        }

        private void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(600, 409);
            this.Location = new Point(300, 75);
            this.ForeColor = Color.FromArgb(32, 178, 170);
            this.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            this.Name = "pnlRezerve";

            setPicProfil();
            setPicBook();
            setTxtName();
            setTxtTelefon();
            setTxtEmail();
            setTxtRoom();
            setSfChkIn();
            setSfChkOut();
            setBtnRezervare();
            setDate();
        }

        private void setDate()
        {
            if (controlCustomers.loged != null)
            {
                TextBox txtName = new TextBox();
                TextBox txtTelefon = new TextBox();
                TextBox txtEmail = new TextBox();

                foreach (Control x in Controls)
                {
                    if (x.Name == "txtName")
                        txtName = x as TextBox;
                    if (x.Name == "txtTelefon")
                        txtTelefon = x as TextBox;
                    if (x.Name == "txtEmail")
                        txtEmail = x as TextBox;
                }

                txtName.Text = controlCustomers.loged.Nume;
                txtTelefon.Text = controlCustomers.loged.Telefon;
                txtEmail.Text = controlCustomers.loged.Email;
            }
        }

        private void setPicProfil()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(180, 50);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\profile_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.BorderStyle = BorderStyle.Fixed3D;

            this.Controls.Add(pic);
        }

        private void setPicBook()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(180, 170);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\Hotel Room_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.BorderStyle = BorderStyle.Fixed3D;

            this.Controls.Add(pic);
        }

        private void setTxtName()
        {
            TextBox txtName = new TextBox();
            txtName.AutoSize = false;
            txtName.Size = new Size(150, 20);
            txtName.Location = new Point(300, 50);
            txtName.Name = "txtName";
            txtName.Text = "Name:";
            txtName.BorderStyle = BorderStyle.None;
            txtName.BackColor = Color.FromArgb(40, 40, 40);
            txtName.ForeColor = Color.FromArgb(32, 178, 170);

            txtName.Enter += Txt_Enter;
            txtName.Leave += Txt_Leave;

            this.Controls.Add(txtName);
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text.Trim(' ') == "")
            {
                if (text.Name == "txtName")
                    text.Text = "Name:";
                else if (text.Name == "txtTelefon")
                    text.Text = "Phone number:";
                else if (text.Name == "txtEmail")
                    text.Text = "Email:";
                else if (text.Name == "txtRoom")
                    text.Text = "Room:";
            }
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text == "Name:" || text.Text == "Phone number:" || text.Text == "Email:" || text.Text == "Room:") 
            {
                text.Text = "";
            }
        }

        private void setTxtTelefon()
        {
            TextBox txtTelefon = new TextBox();
            txtTelefon.AutoSize = false;
            txtTelefon.Size = new Size(150, 20);
            txtTelefon.Location = new Point(300, 90);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Text = "Phone number:";
            txtTelefon.BorderStyle = BorderStyle.None;
            txtTelefon.BackColor = Color.FromArgb(40, 40, 40);
            txtTelefon.ForeColor = Color.FromArgb(32, 178, 170);

            txtTelefon.Enter += Txt_Enter;
            txtTelefon.Leave += Txt_Leave;

            this.Controls.Add(txtTelefon);
        }

        private void setTxtEmail()
        {
            TextBox txtEmail = new TextBox();
            txtEmail.AutoSize = false;
            txtEmail.Size = new Size(150, 20);
            txtEmail.Location = new Point(300, 130);
            txtEmail.Name = "txtEmail";
            txtEmail.Text = "Email:";
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.BackColor = Color.FromArgb(40, 40, 40);
            txtEmail.ForeColor = Color.FromArgb(32, 178, 170);

            txtEmail.Enter += Txt_Enter;
            txtEmail.Leave += Txt_Leave;

            this.Controls.Add(txtEmail);
        }

        private void setTxtRoom()
        {
            TextBox txtRoom = new TextBox();
            txtRoom.AutoSize = false;
            txtRoom.Size = new Size(150, 20);
            txtRoom.Location = new Point(300, 170);
            txtRoom.Name = "txtRoom";
            txtRoom.Text = "Room:";
            txtRoom.BorderStyle = BorderStyle.None;
            txtRoom.BackColor = Color.FromArgb(40, 40, 40);
            txtRoom.ForeColor = Color.FromArgb(32, 178, 170);

            txtRoom.Enter += Txt_Enter;
            txtRoom.Leave += Txt_Leave;

            this.Controls.Add(txtRoom);
        }

        private void setSfChkIn()
        {
            SfDateTimeEdit sfChkIn = new SfDateTimeEdit();
            sfChkIn.AutoSize = false;
            sfChkIn.Size = new Size(110, 30);
            sfChkIn.Location = new Point(300, 205);
            sfChkIn.MinDateTime = new DateTime(2021, 1, 1);
            sfChkIn.MaxDateTime = new DateTime(2023, 12, 31);
            sfChkIn.Name = "sfChkIn";

            sfChkIn.Style.BackColor = Color.FromArgb(40, 40, 40);
            sfChkIn.ForeColor = Color.FromArgb(32, 178, 170);
            sfChkIn.Style.ForeColor= Color.FromArgb(32, 178, 170); 
            sfChkIn.Style.DropDown.ForeColor= Color.FromArgb(32, 178, 170);
            sfChkIn.Style.DropDown.BackColor = Color.FromArgb(40, 40, 40);

            this.Controls.Add(sfChkIn);
        }

        private void setSfChkOut()
        {
            SfDateTimeEdit sfChkOut = new SfDateTimeEdit();
            sfChkOut.AutoSize = false;
            sfChkOut.Size = new Size(110, 30);
            sfChkOut.Location = new Point(300, 240);
            sfChkOut.MinDateTime = new DateTime(2021, 1, 1);
            sfChkOut.MaxDateTime = new DateTime(2023, 12, 31);
            sfChkOut.Name = "sfChkOut";

            sfChkOut.Style.BackColor = Color.FromArgb(40, 40, 40);
            sfChkOut.ForeColor = Color.FromArgb(32, 178, 170);
            sfChkOut.Style.ForeColor = Color.FromArgb(32, 178, 170);
            sfChkOut.Style.DropDown.ForeColor = Color.FromArgb(32, 178, 170);
            sfChkOut.Style.DropDown.BackColor = Color.FromArgb(40, 40, 40);

            this.Controls.Add(sfChkOut);
        }

        private void setBtnRezervare()
        {
            Button btnRezervare = new Button();
            btnRezervare.Size = new Size(150, 40);
            btnRezervare.Location = new Point(225, 310);
            btnRezervare.FlatStyle = FlatStyle.Flat;
            btnRezervare.Text = "   Rezerve";
            btnRezervare.Name = "btnRezerve";
            btnRezervare.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            btnRezervare.Image = Image.FromFile(path + @"\resources\check_file_32px.png");
            btnRezervare.ImageAlign = ContentAlignment.MiddleLeft;
            btnRezervare.TextAlign = ContentAlignment.MiddleLeft;
            btnRezervare.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRezervare.Click += BtnRezervare_Click;

            this.Controls.Add(btnRezervare);

        }

        private void BtnRezervare_Click(object sender, EventArgs e)
        {
            TextBox txtName = new TextBox();
            TextBox txtNumar = new TextBox();
            TextBox txtEmail = new TextBox();
            TextBox txtRoom = new TextBox();
            SfDateTimeEdit sfChkIn = new SfDateTimeEdit();
            SfDateTimeEdit sfChkOut = new SfDateTimeEdit();

            foreach (Control x in Controls)
            {
                if (x.Name == "txtName")
                    txtName = x as TextBox;
                else if (x.Name == "txtTelefon")
                    txtNumar = x as TextBox;
                else if (x.Name == "txtEmail")
                    txtEmail = x as TextBox;
                else if (x.Name == "txtRoom")
                    txtRoom = x as TextBox;
                else if (x.Name == "sfChkIn")
                    sfChkIn = x as SfDateTimeEdit;
                else if (x.Name == "sfChkOut")
                    sfChkOut = x as SfDateTimeEdit;
            }

            if(controlCustomers.getClient(txtName.Text)==null)
            {
                controlCustomers.add(new Client(0, txtName.Text, "123", txtEmail.Text, txtNumar.Text));
                controlBookings.add(new Rezervare(0, controlCustomers.lastId() - 1, int.Parse(txtRoom.Text), sfChkIn.Value.Value, sfChkOut.Value.Value));

                controlCustomers.save();
                controlBookings.save();

                Button btn = sender as Button;
                btn.Image = Image.FromFile(path + @"\resources\approval_32px.png");
                btn.Enabled = false;
            }
            else
            {
                controlBookings.add(new Rezervare(0, controlCustomers.getClient(txtName.Text).ID, int.Parse(txtRoom.Text), sfChkIn.Value.Value, sfChkOut.Value.Value));
                controlBookings.save();

                Button btn = sender as Button;
                btn.Image = Image.FromFile(path + @"\resources\approval_32px.png");
                btn.Enabled = false;
            }

        }
    }
}
