using Hotel_Dictionar_V2.Controler;
using Hotel_Dictionar_V2.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Dictionar_V2.Template
{
    class PanelArchive : Panel
    {
        String path = Application.StartupPath;
        private Client Client;
        private Rezervare Rezervare;
        private ControlCancel controlCancel;

        public PanelArchive(Client Client, Rezervare Rezervare)
        {
            this.Client = Client;
            this.Rezervare = Rezervare;
            controlCancel = new ControlCancel();

            layout();
        }

        private void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(580, 200);
            this.ForeColor = Color.FromArgb(32, 178, 170);
            this.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            this.Name = "pnlArchive" + Rezervare.ID;
            this.BorderStyle = BorderStyle.Fixed3D;

            setPicProfil();
            setPicBook();
            setLblName();
            setLblTelefon();
            setLblEmail();
            setLblRoom();
            setLblChkIn();
            setLblChkOut();
            setBtnCancel();

            if(controlCancel.isCancel(Rezervare.ID)==true)
            {
                this.Enabled = false;
            }
        }

        private void setPicProfil()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(30, 30);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\profile_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.BorderStyle = BorderStyle.Fixed3D;

            this.Controls.Add(pic);
        }

        private void setPicBook()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(320, 30);
            pic.BackgroundImage = Image.FromFile(path + @"\resources\Hotel Room_100px.png");
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.BorderStyle = BorderStyle.Fixed3D;

            this.Controls.Add(pic);
        }

        private void setLblName()
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(150, 30);
            lbl.Text = Client.Nume;

            this.Controls.Add(lbl);
        }

        private void setLblTelefon()
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(150, 70);
            lbl.Text = Client.Telefon;

            this.Controls.Add(lbl);
        }

        private void setLblEmail()
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(150, 110);
            lbl.Text = Client.Email;

            this.Controls.Add(lbl);
        }

        private void setLblRoom()
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(440, 30);
            lbl.Text = "Room: " + Rezervare.CameraID;

            this.Controls.Add(lbl);
        }

        private void setLblChkIn()
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(440, 70);
            lbl.Text = "Check in: " + Rezervare.CheckIn.ToString("d");

            this.Controls.Add(lbl);
        }

        private void setLblChkOut()
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new Point(440, 110);
            lbl.Text = "Check out: " + Rezervare.CheckOut.ToString("d");

            this.Controls.Add(lbl);
        }

        private void setBtnCancel()
        {
            Button btnCancel = new Button();
            btnCancel.Size = new Size(150, 40);
            btnCancel.Location = new Point(225, 150);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Text = "   Cancel";
            btnCancel.Name = "btnCancel";
            btnCancel.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            btnCancel.Image = Image.FromFile(path + @"\resources\cancel_subscription_32px.png");
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;

            if (Rezervare.CheckOut.Date.CompareTo(DateTime.Today.Date) != 1)
                btnCancel.Enabled = false;

            btnCancel.Click += BtnCancel_Click;

            this.Controls.Add(btnCancel);

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            controlCancel.add(Rezervare);
            controlCancel.save();

            Button btn = sender as Button;
            btn.Image = Image.FromFile(path + @"\resources\approval_32px.png");
            btn.Enabled = false;
        }
    }
}
