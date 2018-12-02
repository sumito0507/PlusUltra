using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;

namespace GPSSample
{
    public partial class Form1 : Form
    {
        private GeoCoordinateWatcher _wtc = new GeoCoordinateWatcher();
        public Form1()
        {
            InitializeComponent();

            _wtc.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(wtc_PositionChanged);
            //_wtc.Start();
            _wtc.TryStart(false, TimeSpan.FromMilliseconds(1000));
        }

        void wtc_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            try
            {

                if (e.Position.Location.IsUnknown != true)
                {
                    this.tbLatitude.Text = e.Position.Location.Latitude.ToString();
                    this.tbLongitude.Text = e.Position.Location.Longitude.ToString();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbLatitude.Text = _wtc.Position.Location.Latitude.ToString();
            this.tbLongitude.Text = _wtc.Position.Location.Longitude.ToString();
        }
    }
}
