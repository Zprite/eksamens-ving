using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eksamensoppgaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            alleHytter = new Hytte[] {hGjendesheim,hGlitterheim,hMemurubu,hGjendebu,hSpiterstulen,hLeirvassbu,hOlavsbu };
            foreach (Hytte h in alleHytter)
            {
                comboBoxHytte1.Items.Add(h.Navn);
            }
        }
        #region Oppgave 1
        string anbefaltFilFormat = "Anbefalt filformat: ";
        string begrunnelse = "Begrunnelse: ";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            labelAnbefaltFilformat.Text = anbefaltFilFormat + "jpg/png";
            labelBegrunnelse.Text = begrunnelse +  "\nBildet trenger ikke støtte for gjennomsiktighet, og skal hovedsaklig brukes på en nettside." +
                "Derfor er alle filtyper for raster-grafikk greit å bruke her. Det viktige å vurdere er om man vil at bildet skal komprimeres eller ikke." +
                "Hvis bildet skal vises i full størrelse er nok det best å gå for et tapsfritt format som .png." +
                "Hvis bildet skal brukes i liten størrelse så er det bedre å komprimere bildet slik at det tar mindre plass på serveren.";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            labelAnbefaltFilformat.Text = anbefaltFilFormat + "png/gif";
            labelBegrunnelse.Text = begrunnelse + "\nBildet har en transparent bakgrunn og må derfor ha et raster-filformat som støtter dette." +
                "Png er kanskje mest populært, men formater som GIF, BMP og TIFF kan også benyttes.";

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            labelAnbefaltFilformat.Text = anbefaltFilFormat + "svg";
            labelBegrunnelse.Text = begrunnelse + "\nEttersom dette bildet skal brukes som logo på store reklameskilt, må logoen kunne skaleres opp i stor skala." +
                "Derfor er det lurt å bruke et vektorbasert filformat ettersom bildekvaliteten er lik uansett skalaen på bildet." +
                "Svg er et vektorbasert format som også støtter gjennomsiktighet, og derfor er dette det beste valget i dette tilfellet.";
        }
        #endregion

        #region Oppgave 2
        private void numericUpDownBredde_ValueChanged(object sender, EventArgs e)
        {
            /* Gjøres med NumericUpDown.Maximum property
            NumericUpDown n = (NumericUpDown)sender;
            if(n.Name == "numericUpDownBredde" && n.Value > 1920)
            {
                n.Value = 1920;
            } 
            */
            int bredde = (int)numericUpDownBredde.Value;
            int høyde = (int)numericUpDownHøyde.Value;
            textBoxAntallPiksler.Text = "" + RegnPiksler(bredde,høyde);
            pictureBoxImageFormat.Image = LagIllustrasjon(bredde, høyde);
        }

        private int RegnPiksler(int bredde, int høyde)
        {
            return bredde * høyde;
        }

        private Image LagIllustrasjon(int bredde, int høyde)
        {
            if (bredde == 0 || høyde == 0)
                return null;
            if(bredde < høyde)
                return Image.FromFile("stående.jpg");
            if(bredde > høyde)
                return Image.FromFile("liggende.jpg");
            if(bredde == høyde)
                return Image.FromFile("kvadratisk.jpg");
            else
            {
                return null;
            }
        }
        #endregion

        #region Oppgave 3
        Hytte hytte1;
        Hytte hytte2;
        Hytte hytte3;

        const string gjendesheim = "Gjendesheim";
        const string glitterheim = "Glitterheim";
        const string memurubu = "Memurubu";
        const string gjendebu = "Gjendebu";
        const string leirvassbu = "Leirvassbu";
        const string spiterstulen = "Spiterstulen";
        const string olavsbu = "Olavsbu";
        Hytte[] alleHytter;
        Hytte hGjendesheim = new Hytte(gjendesheim, new Sti[] { new Sti(glitterheim, 22), new Sti(memurubu, 14) });
        Hytte hGlitterheim = new Hytte(glitterheim, new Sti[] { new Sti(gjendesheim, 22), new Sti(memurubu, 18) });
        Hytte hMemurubu = new Hytte(memurubu, new Sti[] { new Sti(gjendesheim, 14), new Sti(glitterheim, 18), new Sti(gjendebu,10) });
        Hytte hGjendebu = new Hytte(gjendebu, new Sti[] { new Sti(leirvassbu, 19), new Sti(memurubu, 10), new Sti(spiterstulen, 24), new Sti(olavsbu,11) });
        Hytte hSpiterstulen = new Hytte(spiterstulen, new Sti[] { new Sti(gjendebu, 24), new Sti(leirvassbu, 15), new Sti(glitterheim,17) });
        Hytte hLeirvassbu = new Hytte(leirvassbu, new Sti[] { new Sti(gjendebu,19), new Sti(spiterstulen,15), new Sti(olavsbu,11) });
        Hytte hOlavsbu = new Hytte(olavsbu, new Sti[] { new Sti(gjendebu, 16), new Sti(leirvassbu, 11) });

        private Hytte FinnHytteMedString(string str, Hytte[] hytter)
        {
            foreach(Hytte h in hytter)
            {
                string navn = h.Navn;
                if(str == h.Navn)
                {
                    return h;
                }
            }
            return null;
        }

        private int FinnDistanse(Hytte h1, Hytte h2)
        {
            foreach(Sti s in h1.TilgjengeligeStier)
            {
                if(s.HytteTil == h2.Navn)
                {
                    return s.Lengde;
                }
            }
            return -1;
        }

        private Boolean HytteInneholderSti(Hytte h, string hytteTil)
        {
           foreach(Sti s in h.TilgjengeligeStier)
            {
                if (s.HytteTil == hytteTil)
                    return true;
            }
            Console.WriteLine("Hytte inneholder ikke sti til " + hytteTil);
            return false;
        }

        private void ResetComboBox(ComboBox box) {
            box.Items.Clear();
            box.SelectedIndex = -1;
            box.SelectedItem = null;
            box.ResetText();
            Console.WriteLine("Clearer box");
        }

        private void comboBoxHytte1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            hytte1 = FinnHytteMedString(comboBox.SelectedItem.ToString(), alleHytter);
            // Må resette alle items
            comboBoxHytte2.Items.Clear();
            // Må resette text og selected item
            if (hytte2!=null && !HytteInneholderSti(hytte1, hytte2.Navn))
            {
                ResetComboBox(comboBoxHytte2);
                ResetComboBox(comboBoxHytte3);
                hytte2 = null;
                hytte3 = null;
            }

            foreach(Sti s in hytte1.TilgjengeligeStier)
            {
                comboBoxHytte2.Items.Add(s.HytteTil);
            }
        }

        private void comboBoxHytte2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            hytte2 = FinnHytteMedString(comboBox.SelectedItem.ToString(), alleHytter);
            comboBoxHytte3.Items.Clear();
            if(hytte3!= null && !HytteInneholderSti(hytte2, hytte3.Navn))
            {
                ResetComboBox(comboBoxHytte3);
                hytte3 = null;
            }
            foreach (Sti s in hytte2.TilgjengeligeStier)
            {
                comboBoxHytte3.Items.Add(s.HytteTil);
            }
        }
        private void comboBoxHytte3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            hytte3 = FinnHytteMedString(comboBox.SelectedItem.ToString(), alleHytter);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if(hytte2 != null)
            {
                int tilbakelagtDistanse = 0;
                groupBoxOppsummering.Visible = true;
                labelStart.Text = "Start: " + hytte1.Navn;
                tilbakelagtDistanse += FinnDistanse(hytte1, hytte2);
                labelMellomstopp.Text = "Mellomstopp: " + hytte2.Navn + " (" + tilbakelagtDistanse + "km)";
                if(hytte3 != null)
                {
                    tilbakelagtDistanse += FinnDistanse(hytte2, hytte3);
                    labelDestinasjon.Text = "Destinasjon: " + hytte3.Navn + " (" + FinnDistanse(hytte2, hytte3) + "km)";
                }

                labelTotal.Text = "Tilbakelagt distanse: " + tilbakelagtDistanse + "km";
            }
        }
    }
}
