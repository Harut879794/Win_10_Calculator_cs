using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Windows10_Calculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string operation = "";
        bool enter_value = false;
        string firstnum, secondnum;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }
        private void numbers_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((txtDisplay.Text == "0") || (enter_value))
                txtDisplay.Text = "";
            enter_value = false;
            if(b.Text==".")
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text = txtDisplay.Text + b.Text;
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
            }
        }

        private void Operators_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (result != 0)
            {
                btnEquals.PerformClick();
                enter_value = true;
                operation = b.Text;
                lblShowOps.Text = Convert.ToString(result) + "   " + operation;
            }
            else
            {
                operation = b.Text;
                result = double.Parse(txtDisplay.Text);
                txtDisplay.Text = "";
                lblShowOps.Text = Convert.ToString(result) + "   " + operation;
            }
            firstnum = lblShowOps.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            result = 0;
        }

        private void btnEquals_Click_Click(object sender, EventArgs e)
        {
            secondnum = txtDisplay.Text;
            lblShowOps.Text = "";
            switch(operation)
            {
                case "+":
                    txtDisplay.Text = (result + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "X":
                    txtDisplay.Text = (result * double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (result / double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = double.Parse(txtDisplay.Text);
            operation = "";
            //#####################################

            btnClearHistory.Visible = true;
            rtbDisplayHistoly.AppendText(firstnum+"   "+secondnum+"  =  "+"\n");
            rtbDisplayHistoly.AppendText("\n\t" + txtDisplay.Text + "\n\n");
            lblHistoryDisplay.Text = "";
        }

        private void Btn_Backspace_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length>0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            if(txtDisplay.Text=="")
            {
                txtDisplay.Text = "0";
            }
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            rtbDisplayHistoly.Clear();
            if(lblHistoryDisplay.Text=="")
            {
                lblHistoryDisplay.Text = "There's no history yet";
            }
            btnClearHistory.Visible = false;
            rtbDisplayHistoly.ScrollBars = 0;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Name=="Node2")
            {
                lblTitle.Text = "Standart";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node4")
            {
                lblTitle.Text = "Scientific";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node6")
            {
                lblTitle.Text = "Programmer";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node8")
            {
                lblTitle.Text = "Data Calculation";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node10")
            {
                lblTitle.Text = "Converter";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node12")
            {
                lblTitle.Text = "Currency";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node14")
            {
                lblTitle.Text = "Volume";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node16")
            {
                lblTitle.Text = "Length";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node18")
            {
                lblTitle.Text = "Weigth and Mass";
                treeView1.Visible = false;
            }
            if (e.Node.Name == "Node20")
            {
                lblTitle.Text = "Teperature";
                treeView1.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            treeView1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Visible = false;
        }

        private void MemoryShow_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
