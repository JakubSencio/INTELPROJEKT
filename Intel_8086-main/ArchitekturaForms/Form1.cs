using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchitekturaForms
{
    public partial class Form1 : Form
    {
        //Inicjalizacja pamięci procesora oraz RESET MEMORY button
        string[] memory = new string[131072];

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = "00";
                memoryQueue.Clear();
            }
        }
        //Inicjalizacja pamięci memoryQueue
        Queue<string> memoryQueue = new Queue<string>();
        

        public Form1()
        {
            InitializeComponent();
            //Uzupełnienie pamięci zerami
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = "00";
            }
        }

        //Wyczyszczenie starych wyborów oraz podświetlenie odpowiednich
        private void indexButton_CheckedChanged(object sender, EventArgs e)
        {
            siButton.Enabled = true;
            diButton.Enabled = true;
            bxButton4.Checked = false;
            bxButton4.Enabled = false;
            bpButton.Checked = false;
            bpButton.Enabled = false;
            sibpButton.Checked = false;
            sibpButton.Enabled = false;
            sibxButton.Checked = false;
            sibxButton.Enabled = false;
            dibpButton.Checked = false;
            dibpButton.Enabled = false;
            dibxButton.Checked = false;
            dibxButton.Enabled = false;
        }
        private void baseButton_CheckedChanged(object sender, EventArgs e)
        {
            siButton.Enabled = false;
            diButton.Enabled = false;
            siButton.Checked = false;
            bxButton4.Enabled = true;
            diButton.Checked = false;
            bpButton.Enabled = true;
            sibpButton.Checked = false;
            sibpButton.Enabled = false;
            sibxButton.Checked = false;
            sibxButton.Enabled = false;
            dibpButton.Checked = false;
            dibpButton.Enabled = false;
            dibxButton.Checked = false;
            dibxButton.Enabled = false;
        }
        private void indexBaseButton_CheckedChanged(object sender, EventArgs e)
        {
            siButton.Enabled = false;
            diButton.Enabled = false;
            siButton.Checked = false;
            bxButton4.Enabled = false;
            diButton.Checked = false;
            bpButton.Enabled = false;
            bpButton.Checked = false;
            bxButton4.Checked = false;
            sibpButton.Enabled = true;
            sibxButton.Enabled = true;
            dibpButton.Enabled = true;
            dibxButton.Enabled = true;
        }


        //Sprawdzanie czy podany string jest hex
        public bool isTextHex(string isHex)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(isHex, @"\A\b[0-9a-fA-F]+\b\Z");
        }
        //Sprowadzenie hexa do dziesiętnej
        public int hexToDecimal(string hex)
        {
            return Convert.ToInt32(hex, 16);

        }
        //Przycisk SET dla rejsetru oraz sprawdzanie czy wprowadzone dane są poprawne
        private void set_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(axBox.Text) || !isTextHex(axBox.Text) || axBox.Text.Length != 4) { }
            else
                axLabel.Text = axBox.Text.ToUpper();

            if (String.IsNullOrWhiteSpace(bxBox.Text) || !isTextHex(bxBox.Text) || bxBox.Text.Length != 4) { }
            else
                bxLabel.Text = bxBox.Text.ToUpper();

            if (String.IsNullOrWhiteSpace(cxBox.Text) || !isTextHex(cxBox.Text) || cxBox.Text.Length != 4) { }
            else
                cxLabel.Text = cxBox.Text.ToUpper();

            if (String.IsNullOrWhiteSpace(dxBox.Text) || !isTextHex(dxBox.Text) || dxBox.Text.Length != 4) { }
            else
                dxLabel.Text = dxBox.Text.ToUpper();

            axBox.Text = "";
            bxBox.Text = "";
            cxBox.Text = "";
            dxBox.Text = "";
        }
        //Przycisk SET dla pamięci oraz sprawdzanie czy wprowadzone dane są poprawne
        private void set2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(siBox.Text) || !isTextHex(siBox.Text) || siBox.Text.Length != 4) { }
            else
                siLabel.Text = siBox.Text.ToUpper();

            if (String.IsNullOrWhiteSpace(diBox.Text) || !isTextHex(diBox.Text) || diBox.Text.Length != 4) { }
            else
                diLabel.Text = diBox.Text.ToUpper();

            if (String.IsNullOrWhiteSpace(bpBox.Text) || !isTextHex(bpBox.Text) || bpBox.Text.Length != 4) { }
            else
                bpLabel.Text = bpBox.Text.ToUpper();

            if (String.IsNullOrWhiteSpace(dispBox.Text) || !isTextHex(dispBox.Text) || dispBox.Text.Length != 4) { }
            else
                dispLabel.Text = dispBox.Text.ToUpper();

            siBox.Text = "";
            diBox.Text = "";
            bpBox.Text = "";
            dispBox.Text = "";
        }

        //Losowanie danych
        private static readonly Random _RND = new Random();
        private string generateRandomHex()
        {
            return string.Concat(Enumerable.Range(0, 4).Select(_ => _RND.Next(16).ToString("X")));

        }
        private void randomButton_Click(object sender, EventArgs e)
        {
            axLabel.Text = generateRandomHex();
            bxLabel.Text = generateRandomHex();
            cxLabel.Text = generateRandomHex();
            dxLabel.Text = generateRandomHex();
            siLabel.Text = generateRandomHex();
            dispLabel.Text = generateRandomHex();
            diLabel.Text = generateRandomHex();
            bpLabel.Text = generateRandomHex();
        }
        //Czyszczenie danych
        private void clearEvr_Click(object sender, EventArgs e)
        {
            axBox.Text = "";
            bxBox.Text = "";
            cxBox.Text = "";
            dxBox.Text = "";
            siBox.Text = "";
            diBox.Text = "";
            bpBox.Text = "";
            dispBox.Text = "";

            axLabel.Text = "0000";
            bxLabel.Text = "0000";
            cxLabel.Text = "0000";
            dxLabel.Text = "0000";
            siLabel.Text = "0000";
            diLabel.Text = "0000";
            bpLabel.Text = "0000";
            dispLabel.Text = "0000";
        }
        //Rozkaz MOV dla rejestru
        private void mov_Click(object sender, EventArgs e)
        {
            if (axButton1.Checked)
            {
                if (bxButton2.Checked)
                    axLabel.Text = bxLabel.Text;
                if (cxButton2.Checked)
                    axLabel.Text = cxLabel.Text;
                if (dxButton2.Checked)
                    axLabel.Text = dxLabel.Text;
            }
            if (bxButton1.Checked)
            {
                if (axButton2.Checked)
                    bxLabel.Text = axLabel.Text;
                if (cxButton2.Checked)
                    bxLabel.Text = cxLabel.Text;
                if (dxButton2.Checked)
                    bxLabel.Text = dxLabel.Text;
            }
            if (cxButton1.Checked)
            {
                if (axButton2.Checked)
                    cxLabel.Text = axLabel.Text;
                if (bxButton2.Checked)
                    cxLabel.Text = bxLabel.Text;
                if (dxButton2.Checked)
                    cxLabel.Text = dxLabel.Text;
            }
            if (dxButton1.Checked)
            {
                if (axButton2.Checked)
                    dxLabel.Text = axLabel.Text;
                if (cxButton2.Checked)
                    dxLabel.Text = cxLabel.Text;
                if (dxButton2.Checked)
                    dxLabel.Text = dxLabel.Text;
            }

        }
        //Rozkaz XCH dla rejestru
        private void xch_Click(object sender, EventArgs e)
        {
            string temp = "";
            if (axButton1.Checked)
            {
                if (bxButton2.Checked)
                {
                    temp = axLabel.Text;
                    axLabel.Text = bxLabel.Text;
                    bxLabel.Text = temp;
                }
                if (cxButton2.Checked)
                {
                    temp = axLabel.Text;
                    axLabel.Text = cxLabel.Text;
                    cxLabel.Text = temp;
                }
                if (dxButton2.Checked)
                {
                    temp = axLabel.Text;
                    axLabel.Text = dxLabel.Text;
                    dxLabel.Text = temp;
                }
            }
            if (bxButton1.Checked)
            {
                if (axButton2.Checked)
                {
                    temp = bxLabel.Text;
                    bxLabel.Text = axLabel.Text;
                    axLabel.Text = temp;
                }
                if (cxButton2.Checked)
                {
                    temp = bxLabel.Text;
                    bxLabel.Text = cxLabel.Text;
                    cxLabel.Text = temp;
                }
                if (dxButton2.Checked)
                {
                    temp = bxLabel.Text;
                    bxLabel.Text = dxLabel.Text;
                    dxLabel.Text = temp;
                }
            }
            if (cxButton1.Checked)
            {
                if (bxButton2.Checked)
                {
                    temp = cxLabel.Text;
                    cxLabel.Text = bxLabel.Text;
                    bxLabel.Text = temp;
                }
                if (axButton2.Checked)
                {
                    temp = cxLabel.Text;
                    cxLabel.Text = axLabel.Text;
                    axLabel.Text = temp;
                }
                if (dxButton2.Checked)
                {
                    temp = cxLabel.Text;
                    cxLabel.Text = dxLabel.Text;
                    dxLabel.Text = temp;
                }
            }
            if (dxButton1.Checked)
            {
                if (bxButton2.Checked)
                {
                    temp = dxLabel.Text;
                    dxLabel.Text = bxLabel.Text;
                    bxLabel.Text = temp;
                }
                if (cxButton2.Checked)
                {
                    temp = dxLabel.Text;
                    dxLabel.Text = cxLabel.Text;
                    cxLabel.Text = temp;
                }
                if (axButton2.Checked)
                {
                    temp = dxLabel.Text;
                    dxLabel.Text = axLabel.Text;
                    axLabel.Text = temp;
                }
            }
        }

        private void mov2_Click(object sender, EventArgs e)
        {

            int si = hexToDecimal(siLabel.Text);
            int di = hexToDecimal(diLabel.Text);
            int bp = hexToDecimal(bpLabel.Text);
            int disp = hexToDecimal(dispLabel.Text);
            int bxd = hexToDecimal(bxLabel.Text);
            string ax = axLabel.Text.Substring(0, 2);
            string bx = bxLabel.Text.Substring(0, 2);
            string cx = cxLabel.Text.Substring(0, 2);
            string dx = dxLabel.Text.Substring(0, 2);
            string ax2 = axLabel.Text.Substring(2, 2);
            string bx2 = bxLabel.Text.Substring(2, 2);
            string cx2 = cxLabel.Text.Substring(2, 2);
            string dx2 = dxLabel.Text.Substring(2, 2);

            if (stateToMemoryButton.Checked)
            {
                if (indexButton.Checked)
                {
                    if (siButton.Checked)
                    {
                        if (axButton3.Checked)
                        {
                            memory[si + disp] = ax2;
                            memory[si + disp + 1] = ax;
                        }
                        if (bxButton3.Checked)
                        {
                            memory[si + disp] = bx2;
                            memory[si + disp + 1] = bx;
                        }
                        if (cxButton3.Checked)
                        {
                            memory[si + disp] = cx2;
                            memory[si + disp + 1] = cx;
                        }
                        if (dxButton3.Checked)
                        {
                            memory[si + disp] = dx2;
                            memory[si + disp + 1] = dx;
                        }
                    }
                    if (diButton.Checked)
                        {
                        if (axButton3.Checked)
                        {
                            memory[di + disp] = ax2;
                            memory[di + disp + 1] = ax;
                        }
                        if (bxButton3.Checked)
                        {
                            memory[di + disp] = bx2;
                            memory[di + disp + 1] = bx;
                        }
                        if (cxButton3.Checked)
                        {
                            memory[di + disp] = cx2;
                            memory[di + disp + 1] = cx;
                        }
                        if (dxButton3.Checked)
                        {
                            memory[di + disp] = dx2;
                            memory[di + disp + 1] = dx;
                        }
                    }
                    
                }
                if (baseButton.Checked)
                {
                    if (bxButton4.Checked)
                    {
                        if (axButton3.Checked)
                        {
                            memory[bxd + disp] = ax2;
                            memory[bxd + disp + 1] = ax;
                        }
                        if (bxButton3.Checked)
                        {
                            memory[bxd + disp] = bx2;
                            memory[bxd + disp + 1] = bx;
                        }
                        if (cxButton3.Checked)
                        {
                            memory[bxd + disp] = cx2;
                            memory[bxd + disp + 1] = cx;
                        }
                        if (dxButton3.Checked)
                        {
                            memory[bxd + disp] = dx2;
                            memory[bxd + disp + 1] = dx;
                        }
                    }
                    if (bpButton.Checked)
                    {
                        if (axButton3.Checked)
                        {
                            memory[bp + disp] = ax2;
                            memory[bp + disp + 1] = ax;
                        }
                        if (bxButton3.Checked)
                        {
                            memory[bp + disp] = bx2;
                            memory[bp + disp + 1] = bx;
                        }
                        if (cxButton3.Checked)
                        {
                            memory[bp + disp] = cx2;
                            memory[bp + disp + 1] = cx;
                        }
                        if (dxButton3.Checked)
                        {
                            memory[bp + disp] = dx2;
                            memory[bp + disp + 1] = dx;
                        }
                    }
                }
                if (indexBaseButton.Checked)
                {
                    if (sibxButton.Checked)
                    {
                        if (axButton3.Checked)
                        {
                            memory[si + bxd + disp] = ax2;
                            memory[si + bxd + disp + 1] = ax;
                        }
                        if (bxButton3.Checked)
                        {
                            memory[si + bxd + disp] = bx2;
                            memory[si + bxd + disp + 1] = bx;
                        }
                        if (cxButton3.Checked)
                        {
                            memory[si + bxd + disp] = cx2;
                            memory[si + bxd + disp + 1] = cx;
                        }
                        if (dxButton3.Checked)
                        {
                            memory[si + bxd + disp] = dx2;
                            memory[si + bxd + disp + 1] = dx;
                        }
                    }
                    if (dibxButton.Checked)
                    {
                        if (axButton3.Checked)
                        {
                            memory[di + bxd + disp] = ax2;
                            memory[di + bxd + disp + 1] = ax;
                        }
                        if (bxButton3.Checked)
                        {
                            memory[di + bxd + disp] = bx2;
                            memory[di + bxd + disp + 1] = bx;
                        }
                        if (cxButton3.Checked)
                        {
                            memory[di + bxd + disp] = cx2;
                            memory[di + bxd + disp + 1] = cx;
                        }
                        if (dxButton3.Checked)
                        {
                            memory[di + bxd + disp] = dx2;
                            memory[di + bxd + disp + 1] = dx;
                        }
                        if (sibpButton.Checked)
                        {
                            if (axButton3.Checked)
                            {
                                memory[si + bp + disp] = ax2;
                                memory[si + bp + disp + 1] = ax;
                            }
                            if (bxButton3.Checked)
                            {
                                memory[si + bp + disp] = bx2;
                                memory[si + bp + disp + 1] = bx;
                            }
                            if (cxButton3.Checked)
                            {
                                memory[si + bp + disp] = cx2;
                                memory[si + bp + disp + 1] = cx;
                            }
                            if (dxButton3.Checked)
                            {
                                memory[si + bp + disp] = dx2;
                                memory[si + bp + disp + 1] = dx;
                            }
                        }
                        if (dibpButton.Checked)
                        {
                            if (axButton3.Checked)
                            {
                                memory[di + bp + disp] = ax2;
                                memory[di + bp + disp + 1] = ax;
                            }
                            if (bxButton3.Checked)
                            {
                                memory[di + bp + disp] = bx2;
                                memory[di + bp + disp + 1] = bx;
                            }
                            if (cxButton3.Checked)
                            {
                                memory[di + bp + disp] = cx2;
                                memory[di + bp + disp + 1] = cx;
                            }
                            if (dxButton3.Checked)
                            {
                                memory[di + bp + disp] = dx2;
                                memory[di + bp + disp + 1] = dx;
                            }
                        }
                    }

                }
            }
            if (memoryToStateButton.Checked)
            {
                if (indexButton.Checked)
                {
                    if (siButton.Checked)
                    {
                        if (memory[si + disp] != null && memory[si + disp].Length > 0 && memory[si + disp + 1] != null && memory[si + disp + 1].Length > 0)
                        {
                            if (axButton3.Checked)
                                axLabel.Text = memory[si + disp+1] + memory[si + disp];
                            if (bxButton3.Checked)
                                bxLabel.Text = memory[si + disp + 1] + memory[si + disp];
                            if (cxButton3.Checked)
                                cxLabel.Text = memory[si + disp + 1] + memory[si + disp];
                            if (dxButton3.Checked)
                                dxLabel.Text = memory[si + disp + 1] + memory[si + disp];
                        }
                    }
                    if (diButton.Checked)
                    {
                        if (memory[di + disp] != null && memory[di + disp].Length > 0 && memory[di + disp + 1] != null && memory[di + disp + 1].Length > 0)
                        {
                            if (axButton3.Checked)
                                axLabel.Text = memory[di + disp + 1] + memory[di + disp];
                            if (bxButton3.Checked)
                                bxLabel.Text = memory[di + disp + 1] + memory[di + disp];
                            if (cxButton3.Checked)
                                cxLabel.Text = memory[di + disp + 1] + memory[di + disp];
                            if (dxButton3.Checked)
                                dxLabel.Text = memory[di + disp + 1] + memory[di + disp];
                        }
                    }

                }
                if (baseButton.Checked)
                {
                    if (bxButton4.Checked)
                    {
                        if (memory[bxd + disp] != null && memory[bxd + disp].Length > 0 && memory[bxd + disp + 1] != null && memory[bxd + disp + 1].Length > 0)
                        {
                            if (axButton3.Checked)
                                axLabel.Text = memory[bxd + disp + 1] + memory[bxd + disp];
                            if (bxButton3.Checked)
                                bxLabel.Text = memory[bxd + disp + 1] + memory[bxd + disp];
                            if (cxButton3.Checked)
                                cxLabel.Text = memory[bxd + disp + 1] + memory[bxd + disp];
                            if (dxButton3.Checked)
                                dxLabel.Text = memory[bxd + disp + 1] + memory[bxd + disp];
                        }
                    }
                    if (bpButton.Checked)
                    {
                        if (memory[bp + disp] != null && memory[bp + disp].Length > 0 && memory[bp + disp + 1] != null && memory[bp + disp + 1].Length > 0)
                        {
                            if (axButton3.Checked)
                                axLabel.Text = memory[bp + disp + 1] + memory[bp + disp];
                            if (bxButton3.Checked)
                                bxLabel.Text = memory[bp + disp + 1] + memory[bp + disp];
                            if (cxButton3.Checked)
                                cxLabel.Text = memory[bp + disp + 1] + memory[bp + disp];
                            if (dxButton3.Checked)
                                dxLabel.Text = memory[bp + disp + 1] + memory[bp + disp];
                        }
                    }
                }
                if (indexBaseButton.Checked)
                {
                    if (sibxButton.Checked)
                    {
                        if (memory[si + bxd + disp] != null && memory[si + bxd + disp].Length > 0 && memory[si + bxd + disp + 1] != null && memory[si + bxd + disp + 1].Length > 0)
                        {
                            if (axButton3.Checked)
                                axLabel.Text = memory[si + bxd + disp + 1] + memory[si + bxd + disp];
                            if (bxButton3.Checked)
                                bxLabel.Text = memory[si + bxd + disp + 1] + memory[si + bxd + disp];
                            if (cxButton3.Checked)
                                cxLabel.Text = memory[si + bxd + disp + 1] + memory[si + bxd + disp];
                            if (dxButton3.Checked)
                                dxLabel.Text = memory[si + bxd + disp + 1] + memory[si + bxd + disp];
                        }
                    }
                    if (dibxButton.Checked)
                    {
                        if (memory[di + bxd + disp] != null && memory[di + bxd + disp].Length > 0 && memory[di + bxd + disp + 1] != null && memory[di + bxd + disp + 1].Length > 0)
                        {
                            if (axButton3.Checked)
                                axLabel.Text = memory[di + bxd + disp + 1] + memory[di + bxd + disp];
                            if (bxButton3.Checked)
                                bxLabel.Text = memory[di + bxd + disp + 1] + memory[di + bxd + disp];
                            if (cxButton3.Checked)
                                cxLabel.Text = memory[di + bxd + disp + 1] + memory[di + bxd + disp];
                            if (dxButton3.Checked)
                                dxLabel.Text = memory[di + bxd + disp + 1] + memory[di + bxd + disp];
                        }
                    }
                    if (sibpButton.Checked)
                    {
                        if (memory[si + bp + disp] != null && memory[si + bp + disp].Length > 0 && memory[si + bp + disp + 1] != null && memory[si + bp + disp + 1].Length > 0)
                        {
                            if (axButton3.Checked)
                                axLabel.Text = memory[si + bp + disp + 1] + memory[si + bp + disp];
                            if (bxButton3.Checked)
                                bxLabel.Text = memory[si + bp + disp + 1] + memory[si + bp + disp];
                            if (cxButton3.Checked)
                                cxLabel.Text = memory[si + bp + disp + 1] + memory[si + bp + disp];
                            if (dxButton3.Checked)
                                dxLabel.Text = memory[si + bp + disp + 1] + memory[si + bp + disp];
                        }
                    }
                    if (dibpButton.Checked)
                    {
                        if (memory[di + bp + disp] != null && memory[di + bp + disp].Length > 0 && memory[di + bp + disp + 1] != null && memory[di + bp + disp + 1].Length > 0)
                        {
                            if (axButton3.Checked)
                                axLabel.Text = memory[di + bp + disp + 1] + memory[di + bp + disp];
                            if (bxButton3.Checked)
                                bxLabel.Text = memory[di + bp + disp + 1] + memory[di + bp + disp];
                            if (cxButton3.Checked)
                                cxLabel.Text = memory[di + bp + disp + 1] + memory[di + bp + disp];
                            if (dxButton3.Checked)
                                dxLabel.Text = memory[di + bp + disp + 1] + memory[di + bp + disp];
                        }
                    }
                }
            }
        }

        private void xch2_Click(object sender, EventArgs e)
        {
            int si = hexToDecimal(siLabel.Text);
            int di = hexToDecimal(diLabel.Text);
            int bp = hexToDecimal(bpLabel.Text);
            int disp = hexToDecimal(dispLabel.Text);
            int bxd = hexToDecimal(bxLabel.Text);
            string ax = axLabel.Text.Substring(0, 2);
            string bx = bxLabel.Text.Substring(0, 2);
            string cx = cxLabel.Text.Substring(0, 2);
            string dx = dxLabel.Text.Substring(0, 2);
            string ax2 = axLabel.Text.Substring(2, 2);
            string bx2 = bxLabel.Text.Substring(2, 2);
            string cx2 = cxLabel.Text.Substring(2, 2);
            string dx2 = dxLabel.Text.Substring(2, 2);

            if (indexButton.Checked)
            {
                if (siButton.Checked)
                {
                    if (axButton3.Checked)
                    {
                        axLabel.Text = memory[si + disp + 1] + memory[si + disp];
                        memory[si + disp] = ax2;
                        memory[si + disp + 1] = ax;
                    }
                    if (bxButton3.Checked)
                    {
                        bxLabel.Text = memory[si + disp + 1] + memory[si + disp];
                        memory[si + disp] = bx2;
                        memory[si + disp + 1] = bx;
                    }
                    if (cxButton3.Checked)
                    {
                        cxLabel.Text = memory[si + disp + 1] + memory[si + disp];
                        memory[si + disp] = cx2;
                        memory[si + disp + 1] = cx;
                    }
                    if (dxButton3.Checked)
                    {
                        dxLabel.Text = memory[si + disp + 1] + memory[si + disp];
                        memory[si + disp] = dx2;
                        memory[si + disp + 1] = dx;
                    }
                }
                if (diButton.Checked)
                {
                    if (axButton3.Checked)
                    {
                        axLabel.Text = memory[si + disp + 1] + memory[si + disp];
                        memory[si + disp] = ax2;
                        memory[si + disp + 1] = ax;
                    }
                    if (bxButton3.Checked)
                    {
                        bxLabel.Text = memory[si + disp + 1] + memory[si + disp];
                        memory[si + disp] = bx2;
                        memory[si + disp + 1] = bx;
                    }
                    if (cxButton3.Checked)
                    {
                        cxLabel.Text = memory[si + disp + 1] + memory[si + disp];
                        memory[si + disp] = cx2;
                        memory[si + disp + 1] = cx;
                    }
                    if (dxButton3.Checked)
                    {
                        dxLabel.Text = memory[si + disp + 1] + memory[si + disp];
                        memory[si + disp] = dx2;
                        memory[si + disp + 1] = dx;
                    }
                }
            }
            if (baseButton.Checked)
            {
                if (bxButton4.Checked)
                {
                    if (axButton3.Checked)
                    {
                        axLabel.Text = memory[bxd + disp + 1] + memory[bxd + disp];
                        memory[bxd + disp] = ax2;
                        memory[bxd + disp + 1] = ax;
                    }
                    if (bxButton3.Checked)
                    {
                        bxLabel.Text = memory[bxd + disp + 1] + memory[bxd + disp];
                        memory[bxd + disp] = bx2;
                        memory[bxd + disp + 1] = bx;
                    }
                    if (cxButton3.Checked)
                    {
                        cxLabel.Text = memory[bxd + disp + 1] + memory[bxd + disp];
                        memory[bxd + disp] = cx2;
                        memory[bxd + disp + 1] = cx;
                    }
                    if (dxButton3.Checked)
                    {
                        dxLabel.Text = memory[bxd + disp + 1] + memory[bxd + disp];
                        memory[bxd + disp] = dx2;
                        memory[bxd + disp + 1] = dx;
                    }
                }
                if (bpButton.Checked)
                {
                    if (axButton3.Checked)
                    {
                        axLabel.Text = memory[bp + disp + 1] + memory[bp + disp];
                        memory[bp + disp] = ax2;
                        memory[bp + disp + 1] = ax;
                    }
                    if (bxButton3.Checked)
                    {
                        bxLabel.Text = memory[bp + disp + 1] + memory[bp + disp];
                        memory[bp + disp] = bx2;
                        memory[bp + disp + 1] = bx;
                    }
                    if (cxButton3.Checked)
                    {
                        cxLabel.Text = memory[bp + disp + 1] + memory[bp + disp];
                        memory[bp + disp] = cx2;
                        memory[bp + disp + 1] = cx;
                    }
                    if (dxButton3.Checked)
                    {
                        dxLabel.Text = memory[bp + disp + 1] + memory[bp + disp];
                        memory[bp + disp] = dx2;
                        memory[bp + disp + 1] = dx;
                    }
                }
            }
            if (indexBaseButton.Checked)
            {
                if (sibxButton.Checked)
                {
                    if (axButton3.Checked)
                    {
                        axLabel.Text = memory[si + bxd + disp + 1] + memory[si + bxd + disp];
                        memory[si + bxd + disp] = ax2;
                        memory[si + bxd + disp + 1] = ax;
                    }
                    if (bxButton3.Checked)
                    {
                        bxLabel.Text = memory[si + bxd + disp + 1] + memory[si + bxd + disp];
                        memory[si + bxd + disp] = bx2;
                        memory[si + bxd + disp + 1] = bx;
                    }
                    if (cxButton3.Checked)
                    {
                        cxLabel.Text = memory[si + bxd + disp + 1] + memory[si + bxd + disp];
                        memory[si + bxd + disp] = cx2;
                        memory[si + bxd + disp + 1] = cx;
                    }
                    if (dxButton3.Checked)
                    {
                        dxLabel.Text = memory[bp + disp + 1] + memory[si + bxd + disp];
                        memory[si + bxd + disp] = dx2;
                        memory[si + bxd + disp + 1] = dx;
                    }
                }
                if (dibxButton.Checked)
                {
                    if (axButton3.Checked)
                    {
                        axLabel.Text = memory[di + bxd + disp + 1] + memory[di + bxd + disp];
                        memory[di + bxd + disp] = ax2;
                        memory[di + bxd + disp + 1] = ax;
                    }
                    if (bxButton3.Checked)
                    {
                        bxLabel.Text = memory[bp + disp + 1] + memory[di + bxd + disp];
                        memory[di + bxd + disp] = bx2;
                        memory[di + bxd + disp + 1] = bx;
                    }
                    if (cxButton3.Checked)
                    {
                        cxLabel.Text = memory[bp + disp + 1] + memory[di + bxd + disp];
                        memory[di + bxd + disp] = cx2;
                        memory[di + bxd + disp + 1] = cx;
                    }
                    if (dxButton3.Checked)
                    {
                        dxLabel.Text = memory[bp + disp + 1] + memory[di + bxd + disp];
                        memory[di + bxd + disp] = dx2;
                        memory[di + bxd + disp + 1] = dx;
                    }
                }
                if (sibpButton.Checked)
                {
                    if (axButton3.Checked)
                    {
                        axLabel.Text = memory[si + bp + disp + 1] + memory[si + bp + disp];
                        memory[si + bp + disp] = ax2;
                        memory[si + bp + disp + 1] = ax;
                    }
                    if (bxButton3.Checked)
                    {
                        bxLabel.Text = memory[si + bp + disp + 1] + memory[si + bp + disp];
                        memory[si + bp + disp] = bx2;
                        memory[si + bp + disp + 1] = bx;
                    }
                    if (cxButton3.Checked)
                    {
                        cxLabel.Text = memory[si + bp + disp + 1] + memory[si + bp + disp];
                        memory[si + bp + disp] = cx2;
                        memory[si + bp + disp + 1] = cx;
                    }
                    if (dxButton3.Checked)
                    {
                        dxLabel.Text = memory[si + bp + disp + 1] + memory[si + bp + disp];
                        memory[si + bp + disp] = dx2;
                        memory[si + bp + disp + 1] = dx;
                    }
                }
                if (dibpButton.Checked)
                {
                    if (axButton3.Checked)
                    {
                        axLabel.Text = memory[di + bp + disp + 1] + memory[di + bp + disp];
                        memory[di + bp + disp] = ax2;
                        memory[di + bp + disp + 1] = ax;
                    }
                    if (bxButton3.Checked)
                    {
                        bxLabel.Text = memory[di + bp + disp + 1] + memory[di + bp + disp];
                        memory[di + bp + disp] = bx2;
                        memory[di + bp + disp + 1] = bx;
                    }
                    if (cxButton3.Checked)
                    {
                        cxLabel.Text = memory[di + bp + disp + 1] + memory[di + bp + disp];
                        memory[di + bp + disp] = cx2;
                        memory[di + bp + disp + 1] = cx;
                    }
                    if (dxButton3.Checked)
                    {
                        dxLabel.Text = memory[di + bp + disp + 1] + memory[di + bp + disp];
                        memory[di + bp + disp] = dx2;
                        memory[di + bp + disp + 1] = dx;
                    }
                }
            }
        }

        //Memory Queue Push Button
        private void pushButton_Click(object sender, EventArgs e)
        {
            string ax = axLabel.Text.Substring(0, 2);
            string bx = bxLabel.Text.Substring(0, 2);
            string cx = cxLabel.Text.Substring(0, 2);
            string dx = dxLabel.Text.Substring(0, 2);
            string ax2 = axLabel.Text.Substring(2, 2);
            string bx2 = bxLabel.Text.Substring(2, 2);
            string cx2 = cxLabel.Text.Substring(2, 2);
            string dx2 = dxLabel.Text.Substring(2, 2);
            if (axButton5.Checked)
            {
                memoryQueue.Enqueue(ax);
                memoryQueue.Enqueue(ax2);
            }
            if (bxButton5.Checked)
            {
                memoryQueue.Enqueue(bx);
                memoryQueue.Enqueue(bx2);
            }
            if (cxButton5.Checked)
            {
                memoryQueue.Enqueue(cx);
                memoryQueue.Enqueue(cx2);
            }
            if (dxButton5.Checked)
            {
                memoryQueue.Enqueue(dx);
                memoryQueue.Enqueue(dx2);
            }
        }

        //Memory Queue Pop Button
        private void popButton_Click(object sender, EventArgs e)
        {
            if (memoryQueue.Any())
            {

                if (axButton5.Checked)
                {
                    axLabel.Text = memoryQueue.Dequeue() + memoryQueue.Dequeue();
                }
                if (bxButton5.Checked)
                {
                    bxLabel.Text = memoryQueue.Dequeue() + memoryQueue.Dequeue();
                }
                if (cxButton5.Checked)
                {
                    cxLabel.Text = memoryQueue.Dequeue() + memoryQueue.Dequeue();
                }
                if (dxButton5.Checked)
                {
                    dxLabel.Text = memoryQueue.Dequeue() + memoryQueue.Dequeue();
                }
            }
        }
    }
}
