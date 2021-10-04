using Hotel_Dictionar_V2.Controler;
using Hotel_Dictionar_V2.Model;
using Hotel_Dictionar_V2.Template;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Dictionar_V2.View
{
    class FrmView : Form
    {
        private Panel Header;
        private Panel Aside;
        private Panel Main;
        private Button currentBtn;
        private ControlCustomers controlCustomers;

        String path = Application.StartupPath;

        public FrmView()
        {
            Header = new Panel();
            Aside = new Panel();
            Main = new Panel();
            controlCustomers = new ControlCustomers();

            layoutLogin();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParm, int lParam);

        public void layoutLogin()
        {
            this.Text = "";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
            this.Size = new Size(500, 300);
            this.MinimumSize = new Size(500, 300);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Icon = new Icon(path + @"\resources\hotel_building.ico");

            setLogin();
        }

        public void layoutRegister()
        {
            Controls.Clear();
            this.Size = new Size(500, 400);
            this.Location = new Point(400, 150);

            setRegister();
        }

        public void layout()
        {
            this.Text = "";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(150, 100);
            this.ControlBox = false;
            this.Size = new Size(1000, 500);
            this.MinimumSize = new Size(800, 400);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Icon = new Icon(path + @"\resources\hotel_building.ico");

            setAside(Aside);
            setHeader(Header);
            setMain(Main);
        }

        private void setHeader(Panel header)
        {
            header.Size = new Size(1000, 75);
            header.Dock = DockStyle.Top;
            header.BackColor = Color.FromArgb(40, 40, 40);
            header.BorderStyle = BorderStyle.FixedSingle;
            header.MouseDown += Header_MouseDown;

            setBtnClose(header);

            Controls.Add(header);
        }

        private void setBtnClose(Panel header)
        {
            Button btnClose = new Button();
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(965, 5);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Name = "btnClose";
            btnClose.Image = Image.FromFile(path + @"\resources\cancel_24px.png");

            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnClose.Click += BtnClose_Click;

            header.Controls.Add(btnClose);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void setAside(Panel aside)
        {
            aside.Size = new Size(150, 500);
            aside.Dock = DockStyle.Left;
            aside.BackColor = Color.FromArgb(40, 40, 40);
            aside.BorderStyle = BorderStyle.FixedSingle;
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            aside.ForeColor = Color.FromArgb(32, 178, 170);

            setReserve(aside);
            setArhivaStaff(aside);
            setHotelStaff(aside);

            Controls.Add(aside);
        }

        private void setHotelStaff(Panel aside)
        {
            Button btnHotel = new Button();
            btnHotel.Size = new Size(150, 50);
            btnHotel.Location = new Point(0, 0);
            btnHotel.FlatStyle = FlatStyle.Flat;
            btnHotel.FlatAppearance.BorderSize = 0;
            btnHotel.Text = " Hotel";
            btnHotel.Name = "btnHotel";
            btnHotel.Image = Image.FromFile(path + @"\resources\home_32px.png");
            btnHotel.ImageAlign = ContentAlignment.MiddleCenter;
            btnHotel.TextAlign = ContentAlignment.MiddleLeft;
            btnHotel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHotel.ForeColor = Color.FromArgb(32, 178, 170);
            btnHotel.Dock = DockStyle.Top;

            btnHotel.Click += BtnHotel_Click;

            aside.Controls.Add(btnHotel);
        }

        private void BtnHotel_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);
            Main.Controls.Clear();

            ViewHotel viewHotel = new ViewHotel();
            Main.Controls.Add(viewHotel);
        }

        private void setArhivaStaff(Panel aside)
        {
            Button btnArchive = new Button();
            btnArchive.Size = new Size(150, 50);
            btnArchive.Location = new Point(0, 50);
            btnArchive.FlatStyle = FlatStyle.Flat;
            btnArchive.FlatAppearance.BorderSize = 0;
            btnArchive.Text = " Archive";
            btnArchive.Name = "btnArchive";
            btnArchive.Image = Image.FromFile(path + @"\resources\archive_folder_32px.png");
            btnArchive.ImageAlign = ContentAlignment.MiddleRight;
            btnArchive.TextAlign = ContentAlignment.MiddleLeft;
            btnArchive.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnArchive.ForeColor = Color.FromArgb(32, 178, 170);
            btnArchive.Dock = DockStyle.Top;

            btnArchive.Click += BtnArchive_Click;

            aside.Controls.Add(btnArchive);
        }

        private void BtnArchive_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);
            Main.Controls.Clear();

            ViewArhiva viewArhiva = new ViewArhiva();
            Main.Controls.Add(viewArhiva);
        }

        private void setReserve(Panel aside)
        {
            Button btnReserve = new Button();
            btnReserve.Size = new Size(150, 50);
            btnReserve.Location = new Point(0, 100);
            btnReserve.FlatStyle = FlatStyle.Flat;
            btnReserve.FlatAppearance.BorderSize = 0;
            btnReserve.Text = " Reserv";
            btnReserve.Name = "btnReserve";
            btnReserve.Image = Image.FromFile(path + @"\resources\check_file_32px.png");
            btnReserve.ImageAlign = ContentAlignment.MiddleRight;
            btnReserve.TextAlign = ContentAlignment.MiddleLeft;
            btnReserve.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReserve.ForeColor = Color.FromArgb(32, 178, 170);
            btnReserve.Dock = DockStyle.Top;

            btnReserve.Click += BtnReserve_Click;

            aside.Controls.Add(btnReserve);
        }

        private void BtnReserve_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);
            Main.Controls.Clear();

            PanelRezervare panelRezervare = new PanelRezervare(controlCustomers.loged);
            Main.Controls.Add(panelRezervare);
        }

        private void setMain(Panel main)
        {
            main.Dock = DockStyle.Fill;
            main.Size = new Size(600, 1000);
            main.BackColor = Color.FromArgb(40, 40, 40);
            main.BorderStyle = BorderStyle.FixedSingle;

            Controls.Add(main);
        }

        private void setLogin()
        {
            setHeader(Header);

            ViewLogin viewLogin = new ViewLogin();
            Controls.Add(viewLogin);

            Button btnLogin = new Button();
            Button btnRegister = new Button();

            btnLogin = viewLogin.btnLogin;
            btnRegister = viewLogin.btnRegister;

            btnLogin.Click += BtnLogin_Click;
            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            layoutRegister();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ViewLogin viewLogin = new ViewLogin();

            foreach (Control x in Controls)
            {
                if (x.Name == "pnlLogin")
                    viewLogin = x as ViewLogin;
            }

            if (viewLogin.txtName.Text != "Name:" && viewLogin.txtPass.Text != "Password:") 
            {
                if (controlCustomers.getClient(viewLogin.txtName.Text) != null) 
                {
                    if (controlCustomers.getClient(viewLogin.txtName.Text).Password == viewLogin.txtPass.Text) 
                    {
                        controlCustomers.loged = controlCustomers.getClient(viewLogin.txtName.Text);
                        Controls.Clear();
                        layout();
                    }
                }
            }

        }

        private void ActivateBtn(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentBtn != (Button)btnSender)
                {
                    DisableBtn();
                    currentBtn = (Button)btnSender;
                    currentBtn.BackColor = Color.FromArgb(98, 138, 136);
                    currentBtn.ForeColor = Color.Black;
                    currentBtn.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Regular);
                }
            }
        }

        private void DisableBtn()
        {
            foreach (Control prevBtn in Aside.Controls)
            {
                if (prevBtn.GetType() == typeof(Button))
                {
                    prevBtn.BackColor = Color.FromArgb(40, 40, 40);
                    prevBtn.ForeColor = Color.FromArgb(32, 178, 170);
                    prevBtn.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
                }
            }
        }

        private void setRegister()
        {
            Controls.Clear();
            setHeader(Header);

            ViewRegister viewRegister = new ViewRegister();
            Controls.Add(viewRegister);

            Button btnFinal = new Button();
            btnFinal = viewRegister.btnFinal;

            btnFinal.Click += BtnFinal_Click;
        }

        private void BtnFinal_Click(object sender, EventArgs e)
        {
            ViewRegister viewRegister = new ViewRegister();
            foreach (Control x in Controls)
            {
                if (x.Name == "pnlRegister")
                    viewRegister = x as ViewRegister;
            }

            if (viewRegister.txtName.Text != "Name:" && viewRegister.txtPass.Text != "Password:" || viewRegister.txtConfPass.Text != "Confirm password:" || viewRegister.txtEmail.Text != "Email:" || viewRegister.txtTelefon.Text != "Phone:")
            {
                if (viewRegister.txtPass.Text == viewRegister.txtConfPass.Text)
                {
                    if (controlCustomers.getClient(viewRegister.txtName.Text) == null) 
                    {
                        Client client = new Client(0, viewRegister.txtName.Text, viewRegister.txtPass.Text, viewRegister.txtEmail.Text, viewRegister.txtTelefon.Text);
                        controlCustomers.add(client);
                        controlCustomers.loged = client;
                        controlCustomers.save();

                        Controls.Clear();
                        layout();
                    }
                }
            }
        }
    }
}
