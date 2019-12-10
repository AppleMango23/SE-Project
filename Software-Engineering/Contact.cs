
using System.Windows.Forms;

namespace Software_Engineering
{
    public partial class Contact : Form
    {
        public Contact()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        public void displayMessages()
        {
            if(comboBox1.SelectedIndex == 0)
            {
                label3.Text = "- Wing, Floor -, Bay -, Bed - ";
                label5.Text = "-(-)";
                label7.Text = "-";
                label9.Text = "00-00-0000 00:00:00 --";
            }

            if(comboBox2.SelectedIndex == 0)
            {
                label16.Text = "- Wing, Floor -, Bay -, Bed - ";
                label14.Text = "-(-)";
                label12.Text = "-";
                label10.Text = "00-00-0000 00:00:00 --";
            }

            if (comboBox3.SelectedIndex == 0)
            {
                label24.Text = "- Wing, Floor -, Bay -, Bed - ";
                label22.Text = "-(-)";
                label20.Text = "-";
                label18.Text = "00-00-0000 00:00:00 --";
            }


        }
    }
}
