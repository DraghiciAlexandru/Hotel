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
    class PanelCalendar : Panel
    {
        String path = Application.StartupPath;
        public SfCalendar sfCalendar { get; set; }
        public Button btnDetails;
        public List<SpecialDate> specialDates;

        public PanelCalendar()
        {
            sfCalendar = new SfCalendar();
            btnDetails = new Button();
            
            layout();
        }

        public void layout()
        {
            this.Size = new Size(250, 409);
            this.Location = new Point(550, 75);
            this.Dock = DockStyle.Right;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Name = "pnlCalendar";

            setSFCalendar();
            setDetails();
        }

        private void setSFCalendar()
        {
            sfCalendar.Name = "sfCalendar";
            sfCalendar.Location = new Point(5, 5);
            sfCalendar.Size = new Size(225, 250);
            sfCalendar.MaxDate = new DateTime(2023, 12, 31);
            sfCalendar.FirstDayOfWeek = DayOfWeek.Monday;
            sfCalendar.Style.Header.BackColor = Color.FromArgb(32, 178, 170);
            sfCalendar.Style.Header.DayNamesBackColor = Color.FromArgb(40, 40, 40);
            sfCalendar.Style.Header.DayNamesForeColor = Color.White;
            sfCalendar.Style.Cell.CellBackColor = Color.FromArgb(40, 40, 40);
            sfCalendar.Style.Cell.CellForeColor = Color.White;
            sfCalendar.Style.Cell.TrailingCellBackColor = Color.FromArgb(40, 40, 40);
            sfCalendar.Style.Cell.TrailingCellForeColor = Color.FromArgb(60, 60, 60);
            sfCalendar.Style.BorderColor = Color.FromArgb(40, 40, 40);
            sfCalendar.Style.Cell.SelectedCellBorderColor = Color.FromArgb(32, 178, 170);

            this.Controls.Add(sfCalendar);
        }

        private void setDetails()
        {
            btnDetails.Size = new Size(100, 30);
            btnDetails.Location = new Point(75, 275);
            btnDetails.FlatStyle = FlatStyle.Flat;
            btnDetails.Text = "Details";
            btnDetails.Name = "btnDetails";
            btnDetails.Image = Image.FromFile(path + @"\resources\search_26px.png");
            btnDetails.ImageAlign = ContentAlignment.MiddleRight;
            btnDetails.TextAlign = ContentAlignment.MiddleLeft;
            btnDetails.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            btnDetails.ForeColor = Color.FromArgb(32, 178, 170);

            this.Controls.Add(btnDetails);
        }

        public void setDates(List<SpecialDate> specialDates)
        {
            SfCalendar sfCalendar = new SfCalendar();
            foreach(Control x in Controls)
            {
                if (x.Name == "sfCalendar")
                    sfCalendar = x as SfCalendar;
            }
            this.specialDates = null;
            sfCalendar.SpecialDates = null;

            sfCalendar.SpecialDates = specialDates;
            this.specialDates = specialDates;
        }

        public DateTime getSelected()
        {
            if (sfCalendar.SelectedDate.HasValue)
                return sfCalendar.SelectedDate.Value.Date;
            return default;
        }

        public bool isSpecial(DateTime date)
        {
            foreach(SpecialDate special in specialDates)
            {
                if (special.Value.Date == date)
                    return true;
            }
            return false;
        }
    }
}
