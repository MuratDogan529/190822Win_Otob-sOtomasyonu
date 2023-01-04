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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void cmbOtobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbOtobus.Text)
            {
                case "Travego": KoltukDoldur(8, false);
                    break;
                case "Setra": KoltukDoldur(12, true); 
                    break;
                case "Neoplan": KoltukDoldur(10, false);
                    break;
                default:
                    break;
            }
        }
        void KoltukDoldur(int sira, bool arkaBesliMi)
        {   yavaslat:
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = ctrl as Button;

                    if(btn.Text=="KAYDET")
                    {
                        continue;
                    }
                    else
                    {
                        this.Controls.Remove(ctrl);
                        goto yavaslat;//foreeach yavaş çalışsın hata olmasın diye yavaşlatıyoruz.
                    }
                }
            }
            int koltukNo = 1;
            for(int i = 0; i < sira; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i==sira/2 && j>2)
                    {
                        continue;
                    }
                    if (arkaBesliMi==true)
                    {
                        if(i!=sira-1 && j==2)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (j == 2)
                            continue;
                    }
                   
                    Button koltuk = new Button();
                    koltuk.Height = koltuk.Width=40;
                    koltuk.Top = 30+(i*45);//formun üst kısmından 30piksel aşağı da başlasın butonlar
                    koltuk.Left = 5 + (j * 45);
                    koltuk.Text = koltukNo.ToString();
                    koltuk.ContextMenuStrip = contextMenuStrip1;
                    koltukNo++;
                    this.Controls.Add(koltuk);
                    koltuk.MouseDown += Koltuk_MouseDown;
                }
            }
        }
        Button tiklanan;
        private void Koltuk_MouseDown(object sender, MouseEventArgs e)
        {
            tiklanan = sender as Button;
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void rezerveEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbOtobus.SelectedIndex==-1)
            {
                errorProvider1.SetError(cmbOtobus, "Otobüs Seçiniz");
            }
            if (cmbNerden.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbNerden, "Boş Geçilemez");
            }
            if (cmbNereye.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbNereye, "Boş Geçilemez");
            }
            if (cmbOtobus.SelectedIndex == -1 || cmbNerden.SelectedIndex == -1 || cmbNereye.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Gerekli Aanları Doldurunuz.");
                return;
            }
            KayitFormu kf = new KayitFormu();

            DialogResult sonuc= kf.ShowDialog();
            if (sonuc==DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = String.Format("{0} {1}", kf.txtIsim.Text, kf.txtSoyIsim.Text);
                lvi.SubItems.Add(kf.mskdTelefon.Text);
                if (kf.rdbBay.Checked)
                {
                    lvi.SubItems.Add("BAY");
                    tiklanan.BackColor = Color.Blue;
                }
                if (kf.rdbBayan.Checked)
                {
                    lvi.SubItems.Add("BAYAN");
                    tiklanan.BackColor = Color.Pink;
                }
                //sırayla yazmalısın kolonlara göre
                lvi.SubItems.Add(cmbNerden.Text);
                lvi.SubItems.Add(cmbNereye.Text);
                lvi.SubItems.Add(tiklanan.Text);
                lvi.SubItems.Add(dtpTarih.Text);
                lvi.SubItems.Add(nudFiyat.Value.ToString());
                listView1.Items.Add(lvi);

            }
        }
    }
}
