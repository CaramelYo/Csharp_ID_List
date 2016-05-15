using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week04_2
{
    public partial class Form1 : Form
    {
        bool[] sex = new bool[50];
        string[] id = new string[50], number = new string[50], address = new string[50];
        Label[] labels = new Label[7];
        Button[] buttons = new Button[8];
        TextBox[] textboxes = new TextBox[6];
        int count=0, i, j;

        public Form1()
        {
            InitializeComponent();

            Font f = new Font("微軟正黑體", 15, FontStyle.Bold);

            labels[0] = label1;
            labels[0].Text = "帳號：";
            labels[1] = label2;
            labels[1].Text = "密碼：";
            labels[2] = label3;
            labels[2].Text = "身分證字號";
            labels[3] = label4;
            labels[3].Text = "性別";
            labels[4] = label5;
            labels[4].Text = "電話";
            labels[5] = label6;
            labels[5].Text = "地址";
            labels[6] = label7;

            for(i=0;i<6;++i)
            {
                labels[i].Font = f;
                labels[i].ForeColor = Color.SkyBlue;
            }

            textboxes[0] = textBox1;
            textboxes[1] = textBox2;
            textboxes[2] = textBox3;
            textboxes[3] = textBox4;
            textboxes[4] = textBox5;
            textboxes[5] = textBox6;

            buttons[0] = button1;
            buttons[0].Text = "登入";
            buttons[1] = button2;
            buttons[1].Text = "新增";
            buttons[2] = button3;
            buttons[2].Text = "查詢";
            buttons[3] = button4;
            buttons[3].Text = "刪除";
            buttons[4] = button5;
            buttons[4].Text = "登出";
            buttons[5] = button6;
            buttons[5].Text = "確認";
            buttons[6] = button7;
            buttons[6].Text = "搜尋";
            buttons[7] = button8;
            buttons[7].Text = "確認刪除?";

            textboxes[1].PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialization to login
            for(i=0;i<2; ++i)
                labels[i].Visible = true;

            for (;i<7;++i)
                labels[i].Visible = false;

            for (i = 0; i < 2; ++i)
                textboxes[i].Visible = true;

            for(;i<6;++i)
                textboxes[i].Visible = false;

            for (i = 0; i < 1; ++i)
                buttons[i].Visible = true;

            for (; i < 8; ++i)
                buttons[i].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //search
            for (i = 0; i < 7;++i)
                labels[i].Visible = i!=2? false :true;

            for (i = 0; i < 6; ++i)
                textboxes[i].Visible = i != 2 ? false : true;
            textboxes[2].Text = "";

            for (i = 1; i < 6; ++i)
                buttons[i].Visible = true;
            buttons[0].Visible = false;
            buttons[5].Visible = false;
            buttons[7].Visible = false;
            buttons[6].Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete
            for (i = 0; i < 7; ++i)
                labels[i].Visible = i != 2 ? false : true;

            for (i = 0; i < 6; ++i)
                textboxes[i].Visible = i != 2 ? false : true;
            textboxes[2].Text = "";

            for (i = 1; i < 6; ++i)
                buttons[i].Visible = true;
            buttons[0].Visible = false;
            buttons[5].Visible = false;
            buttons[6].Visible = false;
            buttons[7].Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //delete1
            if (textboxes[2].Text != "")
            {
                for (i = 0; i < count; ++i)
                    if (id[i] == textboxes[2].Text)
                    {
                        if(--count != 0)
                        {
                            id[i] = id[count];
                            sex[i] = sex[count];
                            number[i] = number[count];
                            address[i] = address[count];
                        }
                        else
                        {
                            id[0] = null;
                        }

                        labels[6].Visible = true;
                        labels[6].Text = "刪除成功!!";
                        return;
                    }

                textboxes[2].Text = "";
                labels[6].Visible = true;
                labels[6].Text = "無此筆資料";
                return;
            }
            else
            {
                labels[6].Visible = true;
                labels[6].Text = "欄位不能為空!";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1_Load(this,e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //search1

            if (textboxes[2].Text != "")
            {
                for (i = 0; i < count; ++i)
                    if (id[i] == textboxes[2].Text)
                    {
                        for (j = 3; j < 6; ++j)
                            labels[j].Visible = true;

                        for (j = 3; j < 6; ++j)
                            textboxes[j].Visible = true;

                        textboxes[2].Text = id[i];
                        textboxes[3].Text = sex[i] ? "女" : "男";
                        textboxes[4].Text = number[i];
                        textboxes[5].Text = address[i];
                        labels[6].Text = "";

                        return;
                    }

                button3_Click(this, e);
                labels[6].Visible = true;
                labels[6].Text = "無此筆資料";
                return;
            }
            else
            {
                labels[6].Visible = true;
                labels[6].Text = "欄位不能為空!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //login to menu
            if(textboxes[0].Text == "F74024070" && textboxes[1].Text == "74024070")
            {
                //correct
                for(i=0;i<7;++i)
                    labels[i].Visible = false;

                for (i = 0; i < 6; ++i)
                    textboxes[i].Visible = false;

                buttons[0].Visible = false;
                for (i = 1; i < 5; ++i)
                    buttons[i].Visible = true;
                for (; i < 8; ++i)
                    buttons[i].Visible = false;
            }
            else
            {
                //wrong
                labels[6].Visible = true;
                labels[6].Text = "帳密錯誤";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //menu to new data
            for (i = 0; i < 2; ++i)
                labels[i].Visible = false;
            for (; i < 6; ++i)
                labels[i].Visible = true;
            labels[i].Visible = false;

            for (i = 0; i < 2; ++i)
            {
                textboxes[i].Visible = false;
                textboxes[i].Text = "";
            }
            for (; i < 6; ++i)
            {
                textboxes[i].Visible = true;
                textboxes[i].Text = "";
            }

            for (i = 1; i < 6; ++i)
                buttons[i].Visible = true;
            buttons[0].Visible = false;
            buttons[6].Visible = false;
            buttons[7].Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //new
            if(textboxes[2].Text != "" && textboxes[3].Text != "" && textboxes[4].Text != "" && textboxes[5].Text != "")
            {
                id[count] = textboxes[2].Text;
                sex[count] = textboxes[3].Text == "女" ? true : false;
                number[count] = textboxes[4].Text;
                address[count++] = textboxes[5].Text;

                for(i=2;i<6;++i)
                    textboxes[i].Text = "";

                labels[6].Visible = true;
                labels[6].Text = "資料已存入\n目前已有" + count +"筆資料!!";
            }
            else
            {
                labels[6].Visible = true;
                labels[6].Text = "各欄位不能為空,請重新輸入";
            }
        }
    }
}
