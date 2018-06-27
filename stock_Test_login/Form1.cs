using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxKHOpenAPILib;

namespace stock_Test_login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loginMenu.Click += LoginMenu;
            button1.Click += BtnClick;
            button2.Click += BtnClick;
            button3.Click += BtnClick;
            axKHOpenAPI1.OnEventConnect += OnEventCon;
        }

        private void BtnClick(object sender, EventArgs e)
        {
            if (sender.Equals(button1))
            {
                listBox1.Items.Add(axKHOpenAPI1.GetLoginInfo("USER_NAME") + "님 ");
            }
            if (sender.Equals(button2))
            {
                listBox1.Items.Add(axKHOpenAPI1.GetLoginInfo("ACCOUNT_CNT") + "개의 계좌");
            }
            if (sender.Equals(button3))
            {
                listBox1.Items.Add(axKHOpenAPI1.GetLoginInfo("ACCNO") + "계좌");
            }
        }

        public void LoginMenu(object sender, EventArgs e)
        {
            if(sender.Equals(loginMenu))
            {
                axKHOpenAPI1.CommConnect(); 
            }
        }
        public void OnEventCon(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                listBox1.Items.Add(axKHOpenAPI1.GetLoginInfo("USER_ID") +"님 로그인 했읍니다.");
            }
        
            else if (e.nErrCode == 1)
                listBox1.Items.Add("연결 Fail ...");
        }
    }
}
