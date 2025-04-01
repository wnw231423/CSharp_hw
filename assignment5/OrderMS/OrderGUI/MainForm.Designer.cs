namespace OrderGUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UserSelectPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            UserSelect = new ComboBox();
            GotoMain = new Button();
            MainPanel = new Panel();
            dataGridView1 = new DataGridView();
            flowLayoutPanel2 = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            button1 = new Button();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            button2 = new Button();
            textBox2 = new TextBox();
            groupBox3 = new GroupBox();
            button3 = new Button();
            textBox3 = new TextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            UserSelectPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // UserSelectPanel
            // 
            UserSelectPanel.Controls.Add(flowLayoutPanel1);
            UserSelectPanel.Location = new Point(12, 12);
            UserSelectPanel.Name = "UserSelectPanel";
            UserSelectPanel.Size = new Size(776, 426);
            UserSelectPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(UserSelect);
            flowLayoutPanel1.Controls.Add(GotoMain);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(342, 159);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 10, 0, 10);
            flowLayoutPanel1.Size = new Size(86, 103);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // UserSelect
            // 
            UserSelect.Anchor = AnchorStyles.None;
            UserSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            UserSelect.FormattingEnabled = true;
            UserSelect.Location = new Point(3, 13);
            UserSelect.Name = "UserSelect";
            UserSelect.Size = new Size(75, 25);
            UserSelect.TabIndex = 0;
            // 
            // GotoMain
            // 
            GotoMain.AutoSize = true;
            GotoMain.Dock = DockStyle.Fill;
            GotoMain.Location = new Point(3, 44);
            GotoMain.Name = "GotoMain";
            GotoMain.Size = new Size(75, 27);
            GotoMain.TabIndex = 1;
            GotoMain.Text = "确定";
            GotoMain.UseVisualStyleBackColor = true;
            GotoMain.Click += GotoMain_Click;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(flowLayoutPanel3);
            MainPanel.Controls.Add(dataGridView1);
            MainPanel.Controls.Add(flowLayoutPanel2);
            MainPanel.Location = new Point(12, 12);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(776, 426);
            MainPanel.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(271, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(501, 356);
            dataGridView1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(groupBox1);
            flowLayoutPanel2.Controls.Add(groupBox2);
            flowLayoutPanel2.Controls.Add(groupBox3);
            flowLayoutPanel2.Location = new Point(2, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(261, 423);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(249, 101);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "ID查找";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button1
            // 
            button1.Location = new Point(84, 51);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "确认";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 23);
            textBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(3, 110);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(249, 101);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "商品查找";
            // 
            // button2
            // 
            button2.Location = new Point(84, 51);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "确认";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(20, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(209, 23);
            textBox2.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Location = new Point(3, 217);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(249, 101);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "按用户查找";
            // 
            // button3
            // 
            button3.Location = new Point(84, 51);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "确认";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(20, 22);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(209, 23);
            textBox3.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(button4);
            flowLayoutPanel3.Controls.Add(button5);
            flowLayoutPanel3.Controls.Add(button6);
            flowLayoutPanel3.Location = new Point(271, 376);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(502, 43);
            flowLayoutPanel3.TabIndex = 2;
            // 
            // button4
            // 
            button4.Location = new Point(3, 3);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 0;
            button4.Text = "添加订单";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(84, 3);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 1;
            button5.Text = "修改订单";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(165, 3);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 2;
            button6.Text = "删除订单";
            button6.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainPanel);
            Controls.Add(UserSelectPanel);
            Name = "MainForm";
            Text = "Order MS";
            Load += MainForm_Load;
            UserSelectPanel.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel UserSelectPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox UserSelect;
        private Button GotoMain;
        private Panel MainPanel;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox groupBox1;
        private Button button1;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private Button button2;
        private TextBox textBox2;
        private GroupBox groupBox3;
        private Button button3;
        private TextBox textBox3;
        private DataGridView dataGridView1;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}
