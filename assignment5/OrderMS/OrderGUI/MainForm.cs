global using OrderCLI;
global using OrderCLI.entity;

namespace OrderGUI
{
    public partial class MainForm : Form
    {
        private OrderService service;
        private List<Order> dv1_data;
        public MainForm()
        {
            InitializeComponent();
            ShowUserSelect();
        }

        private void ShowUserSelect()
        {
            UserSelectPanel.Visible = true;
            MainPanel.Visible = false;
        }

        private void ShowMain()
        {
            UserSelectPanel.Visible = false;
            MainPanel.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UserSelect.DataSource = User.Users;
            UserSelect.DisplayMember = "Name";
        }

        private void UserSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GotoMain_Click(object sender, EventArgs e)
        {
            ShowMain();
            service = new OrderService(UserSelect.SelectedItem as User);
            dv1_data = service.GetOrders();
            dataGridView1.DataSource = dv1_data;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
