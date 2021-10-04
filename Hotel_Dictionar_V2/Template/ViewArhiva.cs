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
    class ViewArhiva : Panel
    {
        String path = Application.StartupPath;
        private ControlBookings controlBookings;
        private ControlCustomers controlCustomers;

        public ViewArhiva()
        {
            controlBookings = new ControlBookings();
            controlCustomers = new ControlCustomers();

            layout();
        }

        public void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(850, 409);
            this.ForeColor = Color.FromArgb(32, 178, 170);
            this.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            this.Location = new Point(150, 75);
            this.Name = "pnlArchiva";
            this.AutoScroll = true;

            this.BringToFront();

            setArchiva();
        }

        public void setArchiva()
        {
            int y = 10;
            for (int i = 0; i < controlBookings.listaRezervari.size(); i++) 
            {
                PanelArchive panelArchive = new PanelArchive(controlCustomers.getClient(controlBookings.listaRezervari.getAtPosition(i).ClientID), controlBookings.getRezervare(controlBookings.listaRezervari.getAtPosition(i).ID));
                panelArchive.Location = new Point(135, y);
                y += 210;

                this.Controls.Add(panelArchive);
            }
        }

    }
}
