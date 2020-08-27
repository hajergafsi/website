/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 4
**				ÖĞRENCİ ADI............: Hajer Gafsi 
**				ÖĞRENCİ NUMARASI.......: B181210562
**              DERSİN ALINDIĞI GRUP...: 1B
****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace b181210562_projeOdevi
{
    public partial class Form1 : Form
    {

        public interface IAtik
        {
            int Hacim { get; }
            System.Drawing.Image Image { get; }
        }

        public interface IAtikKutusu : IDolabilen
        {

            //Atık kutusu boşaltıldığında oyun puanına kaç puan ekleneceğini döndürür.           
            int BosaltmaPuani { get; }
            // Atık kutusunda gönderilen atığı alacak kadar boş yer varsa atığı kutuya ekler.
            /// </summary>
            /// <param name="atik">Eklenecek Atık</param>
            /// <returns>Atığın kutuya eklenip eklenmediğini döndürür.</returns>
            bool Ekle(Atik atik);

            /// <summary>
            /// Atık kutusunun doluluk oranı %75'in üstündeyse atık kutusunu boşaltır.
            /// </summary>
            /// <returns>Atık kutusunun boşaltılıp boşaltılmadığını döndürür.</returns>
            bool Bosalt();
        }
        //RandomNumber fonksyonu rastgele bir sayi uretir
        public int RandomNumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
        //resimUret fonksyonu rastgele bir resim uretir
        public Image resimUret()
        {
            Domates d1 = new Domates();
            Salatalik s1 = new Salatalik();
            Gazete g = new Gazete();
            Dergi d2 = new Dergi();
            SalcaKutusu s2 = new SalcaKutusu();
            KolaKutusu k = new KolaKutusu();
            camSise c = new camSise();
            Bardak b = new Bardak();
            Image[] tablo = new Image[8] { d1.Image, s1.Image, g.Image, d2.Image, s2.Image, c.Image, k.Image, b.Image };
            return tablo[RandomNumber(0, 7)];
        }

        int kalanSure;
        //oyunbasla fonksyonu scroru temizleyerek ve sureye tekrar 60 saniyeyi aktararak yeni oyun butonuna tiklayinca yeni bir oyunu baslar
        public void oyunuBasla()
        {
            butonuAc(organikAtikButonu);
            butonuAc(kagitButonu);
            butonuAc(camButonu);
            butonuAc(metalButonu);
  
            butonuAc(organikAtikBosaltButonu); 
            butonuAc(kagitBosaltButonu);
            butonuAc(camBosaltButonu);
            butonuAc(metalBosaltButonu);

            progressBarOrganik.Value = 0;
            progressBarKagit.Value = 0;
            progressBarCam.Value = 0;
            progressBarMetal.Value = 0;

            OrganikAtikListesi.Items.Clear();
            kagitListesi.Items.Clear();
            camListesi.Items.Clear();
            metalListesi.Items.Clear();

            puanLabel.Text = "0";


            Atik A = new Atik();
            pictureBox1.Image = resimUret();
            kalanSure = 60;
            timer1.Start();
            puanLabel.Text = "0";


        }

        public class Atik : IAtik
        {
            public int Hacim { get; }

            public Image Image { get; set; }
        }

        public class camSise : Atik
        {
            public int Hacim { get; }
            public Image Image { get; }
            //camSise kurucu fonksyonuhacimi ve resimi aktarir
            public camSise()
            {
                Hacim = 600;
                Image = Image.FromFile(@"sise.jpg");
            }

        }

        public class Bardak : Atik
        {
            public int Hacim { get; }
            //Bardak kurucu fonksyonu atigin hacmini ve resimi aktarir
            public Bardak()
            {
                Hacim = 250;
                Image = Image.FromFile(@"bardak.jfif");
            }
            public Image Image { get; }


        }

        public class Gazete : Atik
        {
            public Image Image { get; }
            public int Hacim { get; }
            //Gazete kurucu fonksyonu atigin hacmini ve resimi aktarir
            public Gazete()
            {
                Hacim = 250;
                Image = Image.FromFile(@"gazete.jpg");
            }



        }

        public class Dergi : Atik
        {
            public int Hacim { get; }
            public Image Image { get; }
            //Dergi kurucu fonksyonu atigin hacmini ve resimi aktarir
            public Dergi()
            {
                Hacim = 200;
                Image = Image.FromFile(@"dergi.jfif");
            }



        }

        public class Domates : Atik
        {
            public int Hacim { get; }

            public Image Image { get; }
            //Domates kurucu fonksyonu atigin hacmini ve resimi aktarir
            public Domates()
            {
                //string filename = ;
                Hacim = 150;
                Image = Image.FromFile(@"domates.jpg");
            }
        }

        public class Salatalik : Atik
        {
            public int Hacim { get; }

            public Image Image { get; }
            //Salatalik kurucu fonksyonu atigin hacmini ve resimi aktarir
            public Salatalik()
            {
                Hacim = 120;
                Image = Image.FromFile(@"salatalik.jfif");
            }
        }

        public class KolaKutusu : Atik
        {
            public int Hacim { get; }

            public Image Image { get; }
            //kolakutusu kurucu fonksyonu atigin hacmini ve resimi aktarir
            public KolaKutusu()
            {
                Hacim = 350;
                Image = Image.FromFile(@"kola.jfif");
            }

        }

        public class SalcaKutusu : Atik
        {
            public int Hacim { get; }

            public Image Image { get; }
            //Salcakutusu kurucu fonksyonu atigin hacmini ve resimi aktarir
            public SalcaKutusu()
            {
                Hacim = 550;
                Image = Image.FromFile(@"salca.jpg");
            }
        }
        public interface IDolabilen
        {
            int Kapasite { get; set; }
            int DoluHacim { get; }
            int DolulukOrani { get; }
        }

        public class OrganikAtikKutusu : IAtikKutusu
        {
            public int BosaltmaPuani { get; }

            public int Kapasite { get; set; }

            public int DoluHacim { get; set; }

            public int DolulukOrani { get; set; }
            //OrganikAtikKutusu kurucu fonksyonu kutunun kapasiteyi DolulukOranini vs..  aktarir
            public OrganikAtikKutusu()
            {
                Kapasite = 700;
                DolulukOrani = (DoluHacim * 100) / Kapasite;
                DoluHacim = 0;
                BosaltmaPuani = 0;
            }
            //bosalt fonksyonu kutunun 75 % den fazla dolu oldugu zaman bosaltir
            public bool Bosalt()
            {

                if (DolulukOrani >= 75) return true;
                else return false;
            }
            //ekle fonksyonu kullanicinin dogru kutuyu sectigi zaman kutulara atigi ekler
            public bool Ekle(Atik atik)
            {
                Domates d1 = new Domates();
                Salatalik s1 = new Salatalik();
                Bitmap img1 = new Bitmap(d1.Image);
                Bitmap img2 = new Bitmap(s1.Image);
                Bitmap img3 = new Bitmap(atik.Image);
                if (compare(img1, img3) || compare(img2, img3)) return true;
                else return false;
            }
        }



        public class KagitKutusu : IAtikKutusu
        {
            public int BosaltmaPuani { get; }

            public int Kapasite { get; set; }

            public int DoluHacim { get; set; }

            public int DolulukOrani { get; set; }
            //kagitKutusu kurucu fonksyonu kutunun kapasiteyi DolulukOranini vs..  aktarir

            public KagitKutusu()
            {
                Kapasite = 1200;
                DolulukOrani = 0;
                DoluHacim = 0;
                BosaltmaPuani = 1000;
            }
            //bosalt fonksyonu kutunun 75 % den fazla dolu oldugu zaman bosaltir
            public bool Bosalt()
            {
                if (DolulukOrani >= 75) return true;
                else return false;
            }
            //ekle fonksyonu kullanicinin dogru kutuyu sectigi zaman kutulara atigi ekler
            public bool Ekle(Atik atik)
            {
                Gazete g1 = new Gazete();
                Dergi d1 = new Dergi();
                Bitmap img1 = new Bitmap(g1.Image);
                Bitmap img2 = new Bitmap(d1.Image);
                Bitmap img3 = new Bitmap(atik.Image);
                if (compare(img1, img3) || compare(img2, img3)) return true;
                else return false;
            }
        }



        public class MetalKutusu : IAtikKutusu
        {
            public int BosaltmaPuani { get; }

            public int Kapasite { get; set; }

            public int DoluHacim { get; set; }

            public int DolulukOrani { get; set; }
            //metalKutusu kurucu fonksyonu kutunun kapasiteyi DolulukOranini vs..  aktarir

            public MetalKutusu()
            {
                Kapasite = 2300;
                DolulukOrani = 0;
                DoluHacim = 0;
                BosaltmaPuani = 800;
            }
            //bosalt fonksyonu kutunun 75 % den fazla dolu oldugu zaman bosaltir
            public bool Bosalt()
            {
                if (DolulukOrani >= 75) return true;
                else return false;
            }
            //ekle fonksyonu kullanicinin dogru kutuyu sectigi zaman kutulara atigi ekler
            public bool Ekle(Atik atik)
            {
                SalcaKutusu s2 = new SalcaKutusu();
                KolaKutusu k = new KolaKutusu();
                Bitmap img1 = new Bitmap(s2.Image);
                Bitmap img2 = new Bitmap(k.Image);
                Bitmap img3 = new Bitmap(atik.Image);
                if (compare(img1, img3) || compare(img2, img3)) return true;
                else return false;
            }
        }


        public class CamKutusu : IAtikKutusu
        {
            public int BosaltmaPuani { get; }

            public int Kapasite { get; set; }

            public int DoluHacim { get; set; }

            public int DolulukOrani { get; set; }
            //camKutusu kurucu fonksyonu kutunun kapasiteyi DolulukOranini vs..  aktarir
            public CamKutusu()
            {
                Kapasite = 2200;
                DolulukOrani = 0;
                DoluHacim = 0;
                BosaltmaPuani = 600;
            }
            //bosalt fonksyonu kutunun 75 % den fazla dolu oldugu zaman bosaltir
            public bool Bosalt()
            {
                if (DolulukOrani >= 75) return true;
                else return false;
            }
            //ekle fonksyonu kullanicinin dogru kutuyu sectigi zaman kutulara atigi ekler
            public bool Ekle(Atik atik)
            {
                camSise c = new camSise();
                Bardak b = new Bardak();
                Bitmap img1 = new Bitmap(c.Image);
                Bitmap img2 = new Bitmap(b.Image);
                Bitmap img3 = new Bitmap(atik.Image);
                if (compare(img1, img3) || compare(img2, img3)) return true;
                else return false;
            }
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void yeniOyunButonu_Click(object sender, EventArgs e)
        {
            oyunuBasla();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //asagidaki if kosulluyla kalansurenin positif oldugu surece giderek azaltir 
            if (kalanSure > 0)
            {
                timeLabel.Text = kalanSure.ToString();
                kalanSure--;
            }
            //kalansurenin bitti zaman oyununu bitirir ve butonlari engeller
            else if (kalanSure == 0)
            {
                timer1.Stop();
                MessageBox.Show("Sure bitti !! kazandiginiz puan :  " + puanLabel.Text.ToString(), "Time's up" );

                butonuEngelle(organikAtikButonu);
                butonuEngelle(kagitButonu);
                butonuEngelle(camButonu);
                butonuEngelle(metalButonu);


                butonuEngelle(organikAtikBosaltButonu);
                butonuEngelle(kagitBosaltButonu);
                butonuEngelle(camBosaltButonu);
                butonuEngelle(metalBosaltButonu);

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void organikAtikButonu_Click(object sender, EventArgs e)
        {
            Domates d = new Domates();
            Salatalik s = new Salatalik();
            Atik A = new Atik();
            A.Image = pictureBox1.Image;
            OrganikAtikKutusu o1 = new OrganikAtikKutusu();
            progressBarOrganik.Maximum = o1.Kapasite;
            o1.DoluHacim = progressBarOrganik.Value;
            //asagidaki if kosullu kullanicinin dogru kutuyu sectigi zaman puan ya da zaman ekler ve progress bar'a increment yapar
            if (o1.Ekle(A))
            {
                pictureBox1.Image = resimUret();
                //asagidaki if kosullu kullanicinin dogru kutuyu  progress bar in dolu olup olmadigini kontrol eder 
                if (progressBarOrganik.Value < progressBarOrganik.Maximum)
                {
                    Bitmap img1 = new Bitmap(d.Image);
                    Bitmap img2 = new Bitmap(A.Image);
                    //asagidaki if kosullu kullanicinin dogru kutuyu sectigi zaman listeye hangi atigin oldugunu kontrol eder
                    if (compare(img1, img2))
                    {
                        OrganikAtikListesi.Items.Add("Domates (" + d.Hacim + ")");
                        o1.DoluHacim += d.Hacim;
                        progressBarOrganik.Increment(d.Hacim);
                        puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + d.Hacim).ToString();

                    }
                    else
                    {
                        OrganikAtikListesi.Items.Add("Salatalik (" + s.Hacim + ")");
                        o1.DoluHacim += d.Hacim;
                        puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + s.Hacim).ToString();
                        progressBarOrganik.Increment(d.Hacim);
                    }
                }
                



            }

        }
     

        private void butonuEngelle(Button btn)
        {
            btn.Enabled = false;
        }

        private void butonuAc(Button btn)
        {
            btn.Enabled = true;
        }


        private void kagitButonu_Click(object sender, EventArgs e)
        {
            Dergi d = new Dergi();
            Gazete g = new Gazete();
            Atik A = new Atik();
            A.Image = pictureBox1.Image;
            KagitKutusu k1 = new KagitKutusu();
            k1.DoluHacim = progressBarKagit.Value;
            progressBarKagit.Maximum = k1.Kapasite;
            //asagidaki if kosullu kullanicinin dogru kutuyu sectigi zaman puan ya da zaman ekler ve progress bar'a increment yapar
            if (k1.Ekle(A))
            {
                pictureBox1.Image = resimUret();
                //asagidaki if kosullu kullanicinin dogru kutuyu  progress bar in dolu olup olmadigini kontrol eder 
                if (progressBarKagit.Value < progressBarKagit.Maximum)
                {
                    Bitmap img1 = new Bitmap(d.Image);
                    Bitmap img2 = new Bitmap(A.Image);
                    //asagidaki if kosullu kullanicinin dogru kutuyu sectigi zaman listeye hangi atigin oldugunu kontrol eder
                    if (compare(img1, img2))
                    {
                        kagitListesi.Items.Add("Dergi (" + d.Hacim + ")");
                        k1.DoluHacim += d.Hacim;
                        progressBarKagit.Increment(d.Hacim);
                        puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + d.Hacim).ToString();

                    }
                    else
                    {
                        kagitListesi.Items.Add("Gazete (" + g.Hacim + ")");
                        k1.DoluHacim += g.Hacim;
                        progressBarKagit.Increment(g.Hacim);
                        puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + g.Hacim).ToString();

                    }
                }
                
            }
        }

        private void camButonu_Click(object sender, EventArgs e)
        {
            Bardak b = new Bardak();
            camSise s = new camSise();
            Atik A = new Atik();
            A.Image = pictureBox1.Image;
            CamKutusu c1 = new CamKutusu();
            c1.DoluHacim = progressBarCam.Value;
            progressBarCam.Maximum = c1.Kapasite;
            //asagidaki if kosullu kullanicinin dogru kutuyu sectigi zaman puan ya da zaman ekler ve progress bar'a increment yapar
            if (c1.Ekle(A))
            {
                pictureBox1.Image = resimUret();
                //asagidaki if kosullu kullanicinin dogru kutuyu  progress bar in dolu olup olmadigini kontrol eder 
                if (progressBarCam.Value < progressBarCam.Maximum)
                {
                    Bitmap img1 = new Bitmap(b.Image);
                    Bitmap img2 = new Bitmap(A.Image);
                    //asagidaki if kosullu kullanicinin dogru kutuyu sectigi zaman listeye hangi atigin oldugunu kontrol eder
                    if (compare(img1, img2))
                    {
                        camListesi.Items.Add("Bardak (" + b.Hacim + ")");
                        c1.DoluHacim += b.Hacim;
                        progressBarCam.Increment(b.Hacim);
                        puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + b.Hacim).ToString();

                    }
                    else
                    {
                        camListesi.Items.Add("Cam sise (" + s.Hacim + ")");
                        c1.DoluHacim += s.Hacim;
                        progressBarCam.Increment(s.Hacim);
                        puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + s.Hacim).ToString();

                    }
                }

            }
        }

        private void metalButonu_Click(object sender, EventArgs e)
        {
            SalcaKutusu s = new SalcaKutusu();
            KolaKutusu k = new KolaKutusu();
            Atik A = new Atik();
            A.Image = pictureBox1.Image;
            MetalKutusu m1 = new MetalKutusu();
            progressBarMetal.Maximum= m1.Kapasite;
            m1.DoluHacim = progressBarMetal.Value;
            //asagidaki if kosullu kullanicinin dogru kutuyu sectigi zaman puan ya da zaman ekler ve progress bar'a increment yapar
            if (m1.Ekle(A))
            {
                pictureBox1.Image = resimUret();
                //asagidaki if kosullu kullanicinin dogru kutuyu  progress bar in dolu olup olmadigini kontrol eder 
                if (progressBarMetal.Value < progressBarMetal.Maximum)
                {
                    Bitmap img1 = new Bitmap(s.Image);
                    Bitmap img2 = new Bitmap(A.Image);
                    //asagidaki if kosullu kullanicinin dogru kutuyu sectigi zaman listeye hangi atigin oldugunu kontrol eder
                    if (compare(img1, img2))
                    {
                        metalListesi.Items.Add("Salca Kutusu (" + s.Hacim + ")");
                        m1.DoluHacim += s.Hacim;
                        progressBarMetal.Increment(s.Hacim);
                        puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + s.Hacim).ToString();

                    }
                    else
                    {
                        metalListesi.Items.Add("kola kutusu (" + k.Hacim + ")");
                        m1.DoluHacim += k.Hacim;
                        progressBarMetal.Increment(k.Hacim);
                        puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + k.Hacim).ToString();

                    }
                }
                

            }
        }

        private void organikAtikBosaltButonu_Click(object sender, EventArgs e)
        {
            OrganikAtikKutusu o1 = new OrganikAtikKutusu();
            o1.DoluHacim = progressBarOrganik.Value;
            o1.DolulukOrani = (o1.DoluHacim * 100) / o1.Kapasite;
            //asagidaki if kosullu kullanicinin bosalt butonuna tikladigi zaman kutu dolu ise puan ve zaman ekler
            if (o1.Bosalt())
            {
                progressBarOrganik.Value = 0;
                puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + o1.BosaltmaPuani).ToString();
                timeLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + 3).ToString();
            }
        }




        
        private void kagitBosaltButonu_Click(object sender, EventArgs e)
        {
            KagitKutusu k1 = new KagitKutusu();
            k1.DoluHacim = progressBarKagit.Value;
            k1.DolulukOrani = (k1.DoluHacim * 100) / k1.Kapasite;
            //asagidaki if kosullu kullanicinin bosalt butonuna tikladigi zaman kutu dolu ise puan ve zaman ekler
            if (k1.Bosalt())
            {
                progressBarKagit.Value = 0;
                puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + k1.BosaltmaPuani).ToString();
                timeLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + 3).ToString();
            }
        }

        private void camBosaltButonu_Click(object sender, EventArgs e)
        {
            CamKutusu c1 = new CamKutusu();
            c1.DoluHacim = progressBarCam.Value;
            c1.DolulukOrani = (c1.DoluHacim * 100) / c1.Kapasite;
            //asagidaki if kosullu kullanicinin bosalt butonuna tikladigi zaman kutu dolu ise puan ve zaman ekler
            if (c1.Bosalt())
            {
                progressBarCam.Value = 0;
                puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + c1.BosaltmaPuani).ToString();
                timeLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + 3).ToString();
            }
        }

        private void metalBosaltButonu_Click(object sender, EventArgs e)
        {
            MetalKutusu m1 = new MetalKutusu();
            m1.DoluHacim = progressBarMetal.Value;
            m1.DolulukOrani = (m1.DoluHacim * 100) / m1.Kapasite;
            //asagidaki if kosullu kullanicinin bosalt butonuna tikladigi zaman kutu dolu ise puan ve zaman ekler
            if (m1.Bosalt())
            {
                progressBarMetal.Value = 0;
                puanLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + m1.BosaltmaPuani).ToString();
                timeLabel.Text = (Convert.ToInt32(puanLabel.Text.ToString()) + 3).ToString();
            }
        }

        //compare fonksyonu 2 resminin ayni olup olmadigini kontrol eder
        public static bool compare(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  //Inner loop isn't broken

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;
        }

    }
}
