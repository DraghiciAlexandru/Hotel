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
    class ViewHotel : Panel
    {
        String path = Application.StartupPath;
        ControlRooms controlRooms;
        ControlBookings controlBookings;
        ControlCancel controlCancel;
        ControlCustomers controlCustomers;
        private PanelCalendar panelCalendar;
        int roomNr;

        public ViewHotel()
        {
            controlRooms = new ControlRooms();
            controlBookings = new ControlBookings();
            controlCancel = new ControlCancel();
            controlCustomers = new ControlCustomers();
            panelCalendar = new PanelCalendar();

            setOcupat();
            layout();
        }

        private void setOcupat()
        {
            for (int i = 0; i < controlBookings.listaRezervari.size(); i++)
            {
                if (controlBookings.listaRezervari.getAtPosition(i).CheckIn.Date.CompareTo(DateTime.Today) != 1 && controlBookings.listaRezervari.getAtPosition(i).CheckOut.Date.CompareTo(DateTime.Today) != -1)
                {
                    if (controlCancel.isCancel(controlBookings.listaRezervari.getAtPosition(i).ID) == false)
                    {
                        controlRooms.updateState(controlBookings.listaRezervari.getAtPosition(i).CameraID, true);
                    }
                    else
                    {
                        controlRooms.updateState(controlBookings.listaRezervari.getAtPosition(i).CameraID, false);
                    }
                }
            }
        }

        public void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(850, 409);
            this.ForeColor = Color.FromArgb(32, 178, 170);
            this.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            this.BackgroundImage = Image.FromFile(path + @"\resources\rsz_hotel.png");
            this.BackgroundImageLayout = ImageLayout.None;
            this.Location = new Point(150, 75);
            this.Name = "pnlHotel";

            setRoom1();
            setRoom2();
            setRoom3();
            setRoom4();
            setRoom5();
            setRoom6();
            setRoom7();
            this.Controls.Add(panelCalendar);
            setBtnDetails();
        }

        private void setRoom1()
        {
            RoundButton btnRoom1 = new RoundButton();
            btnRoom1.Location = new Point(75, 60);
            btnRoom1.AutoSize = false;
            btnRoom1.Size = new Size(50, 30);
            btnRoom1.Text = "1";
            btnRoom1.FlatStyle = FlatStyle.Flat;
            btnRoom1.FlatAppearance.BorderSize = 0;
            btnRoom1.OnHoverButtonColor = Color.White;
            btnRoom1.OnHoverBorderColor = Color.Black;
            btnRoom1.Name = "btnRoom1";
            btnRoom1.BackColor = Color.Black;
            btnRoom1.BringToFront();

            if(controlRooms.isOcupat(1))
            {
                btnRoom1.ButtonColor = Color.Red;
            }
            else
            {
                btnRoom1.ButtonColor = Color.Green;
            }

            btnRoom1.Click += BtnRoom_Click;

            Controls.Add(btnRoom1);

        }

        private void BtnRoom_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            PanelCalendar calendar = new PanelCalendar();

            foreach (Control x in this.Controls)
            {
                if (x.Name == "pnlCalendar")
                    calendar = x as PanelCalendar;
            }

            roomNr = int.Parse(btn.Text);

            List<SpecialDate> specialDates = new List<SpecialDate>();
            for (int i = 0; i < controlBookings.listaRezervari.size(); i++)
            {
                if ((controlBookings.listaRezervari.getAtPosition(i).CameraID == roomNr) && (controlCancel.isCancel(controlBookings.listaRezervari.getAtPosition(i).ID) == false))  
                {
                    DateTime chkIn = controlBookings.listaRezervari.getAtPosition(i).CheckIn;
                    DateTime chkOut = controlBookings.listaRezervari.getAtPosition(i).CheckOut;

                    while (chkIn.CompareTo(chkOut) == -1)
                    {
                        SpecialDate special = new SpecialDate();
                        special.Value = chkIn;
                        special.BackColor = Color.Red;
                        special.ForeColor = Color.Black;
                        specialDates.Add(special);
                        chkIn = chkIn.AddDays(1);
                    }
                }
            }

            calendar.setDates(specialDates);
        }

        private void setRoom2()
        {
            RoundButton btnRoom2 = new RoundButton();
            btnRoom2.Size = new Size(50, 30);
            btnRoom2.Location = new Point(170, 60);
            btnRoom2.Text = "2";
            btnRoom2.FlatStyle = FlatStyle.Flat;
            btnRoom2.FlatAppearance.BorderSize = 0;
            btnRoom2.OnHoverButtonColor = Color.White;
            btnRoom2.OnHoverBorderColor = Color.Black;
            btnRoom2.Name = "btnRoom2";
            btnRoom2.BackColor = Color.Black;
            btnRoom2.BringToFront();

            if (controlRooms.isOcupat(2))
            {
                btnRoom2.ButtonColor = Color.Red;
            }
            else
            {
                btnRoom2.ButtonColor = Color.Green;
            }

            btnRoom2.Click += BtnRoom_Click;

            Controls.Add(btnRoom2);
        }

        private void setRoom3()
        {
            RoundButton btnRoom3 = new RoundButton();
            btnRoom3.Size = new Size(50, 30);
            btnRoom3.Location = new Point(275, 60);
            btnRoom3.Text = "3";
            btnRoom3.FlatStyle = FlatStyle.Flat;
            btnRoom3.FlatAppearance.BorderSize = 0;
            btnRoom3.OnHoverButtonColor = Color.White;
            btnRoom3.OnHoverBorderColor = Color.Black;
            btnRoom3.Name = "btnRoom3";
            btnRoom3.BackColor = Color.Black;
            btnRoom3.BringToFront();

            if (controlRooms.isOcupat(3))
            {
                btnRoom3.ButtonColor = Color.Red;
            }
            else
            {
                btnRoom3.ButtonColor = Color.Green;
            }

            btnRoom3.Click += BtnRoom_Click;

            Controls.Add(btnRoom3);
        }

        private void setRoom4()
        {
            RoundButton btnRoom4 = new RoundButton();
            btnRoom4.Size = new Size(50, 30);
            btnRoom4.Location = new Point(420, 60);
            btnRoom4.Text = "4";
            btnRoom4.FlatStyle = FlatStyle.Flat;
            btnRoom4.FlatAppearance.BorderSize = 0;
            btnRoom4.OnHoverButtonColor = Color.White;
            btnRoom4.OnHoverBorderColor = Color.Black;
            btnRoom4.Name = "btnRoom4";
            btnRoom4.BackColor = Color.Black;
            btnRoom4.BringToFront();

            if (controlRooms.isOcupat(4))
            {
                btnRoom4.ButtonColor = Color.Red;
            }
            else
            {
                btnRoom4.ButtonColor = Color.Green;
            }

            btnRoom4.Click += BtnRoom_Click;

            Controls.Add(btnRoom4);
        }

        private void setRoom5()
        {
            RoundButton btnRoom5 = new RoundButton();
            btnRoom5.Size = new Size(50, 30);
            btnRoom5.Location = new Point(155, 290);
            btnRoom5.Text = "5";
            btnRoom5.FlatStyle = FlatStyle.Flat;
            btnRoom5.FlatAppearance.BorderSize = 0;
            btnRoom5.OnHoverButtonColor = Color.White;
            btnRoom5.OnHoverBorderColor = Color.Black;
            btnRoom5.Name = "btnRoom5";
            btnRoom5.BackColor = Color.Black;
            btnRoom5.BringToFront();

            if (controlRooms.isOcupat(5))
            {
                btnRoom5.ButtonColor = Color.Red;
            }
            else
            {
                btnRoom5.ButtonColor = Color.Green;
            }

            btnRoom5.Click += BtnRoom_Click;

            Controls.Add(btnRoom5);
        }

        private void setRoom6()
        {
            RoundButton btnRoom6 = new RoundButton();
            btnRoom6.Size = new Size(50, 30);
            btnRoom6.Location = new Point(275, 290);
            btnRoom6.Text = "6";
            btnRoom6.FlatStyle = FlatStyle.Flat;
            btnRoom6.FlatAppearance.BorderSize = 0;
            btnRoom6.OnHoverButtonColor = Color.White;
            btnRoom6.OnHoverBorderColor = Color.Black;
            btnRoom6.Name = "btnRoom6";
            btnRoom6.BackColor = Color.Black;
            btnRoom6.BringToFront();

            if (controlRooms.isOcupat(6))
            {
                btnRoom6.ButtonColor = Color.Red;
            }
            else
            {
                btnRoom6.ButtonColor = Color.Green;
            }

            btnRoom6.Click += BtnRoom_Click;

            Controls.Add(btnRoom6);
        }

        private void setRoom7()
        {
            RoundButton btnRoom7 = new RoundButton();
            btnRoom7.Size = new Size(50, 30);
            btnRoom7.Location = new Point(420, 290);
            btnRoom7.Text = "7";
            btnRoom7.FlatStyle = FlatStyle.Flat;
            btnRoom7.FlatAppearance.BorderSize = 0;
            btnRoom7.OnHoverButtonColor = Color.White;
            btnRoom7.OnHoverBorderColor = Color.Black;
            btnRoom7.Name = "btnRoom7";
            btnRoom7.BackColor = Color.Black;
            btnRoom7.BringToFront();

            if (controlRooms.isOcupat(7))
            {
                btnRoom7.ButtonColor = Color.Red;
            }
            else
            {
                btnRoom7.ButtonColor = Color.Green;
            }

            btnRoom7.Click += BtnRoom_Click;

            Controls.Add(btnRoom7);
        }

        private void setBtnDetails()
        {
            Button btnDetails = new Button();
            PanelCalendar calendar = new PanelCalendar();

            foreach (Control x in this.Controls)
            {
                if (x.Name == "pnlCalendar")
                    calendar = x as PanelCalendar;
            }

            btnDetails = calendar.btnDetails;
            btnDetails.Click += BtnDetails_Click;

        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            DateTime select = panelCalendar.getSelected();
            Rezervare rezervare = null;

            if (panelCalendar.isSpecial(select))
            {
                for (int i = 0; i < controlBookings.listaRezervari.size(); i++)
                {
                    if (controlBookings.listaRezervari.getAtPosition(i).CameraID == roomNr)
                    {
                        if (controlBookings.listaRezervari.getAtPosition(i).CheckIn.CompareTo(select) != 1 && controlBookings.listaRezervari.getAtPosition(i).CheckOut.CompareTo(select) != -1)
                        {
                            rezervare = controlBookings.listaRezervari.getAtPosition(i);
                        }
                    }
                }
            }

            if (rezervare != null)
            {
                PanelDetails panelDetails = new PanelDetails(controlCustomers.getClient(rezervare.ClientID), rezervare);
                Controls.Add(panelDetails);
                panelDetails.BringToFront();
            }
        }
    }
}
