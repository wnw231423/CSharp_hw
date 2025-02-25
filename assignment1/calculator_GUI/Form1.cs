namespace calculator_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a1 = Int32.Parse(textBox1.Text);
            int a2 = Int32.Parse(textBox2.Text);
            int res = 0;
            switch (comboBox1.Text) {
                case "+":
                    res = a1 + a2;
                    break;
                case "-":
                    res = a1 - a2;
                    break;
                case "*":
                    res = a1 * a2;
                    break;
                case "/":
                    res = a1 / a2;
                    break;
            }
            label3.Text = res.ToString();
        }
    }
}
