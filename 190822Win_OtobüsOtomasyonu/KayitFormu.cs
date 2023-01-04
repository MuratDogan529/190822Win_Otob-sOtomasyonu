using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _190822Win_OtobüsOtomasyonu
{
    public partial class KayitFormu : Form
    {
        public KayitFormu()
        {
            InitializeComponent();
        }

        private void KayitFormu_Load(object sender, EventArgs e)
        {

        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (txtIsim.Text == string.Empty)
            {
                errorProvider1.SetError(txtIsim, "Boş Geçilemez");
            }
                if (txtSoyIsim.Text == string.Empty)
                {
                    errorProvider1.SetError(txtSoyIsim, "Boş Geçilemez");
                }
                if (txtSoyIsim.Text != string.Empty && txtSoyIsim.Text != string.Empty)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            
        }
    }
}
