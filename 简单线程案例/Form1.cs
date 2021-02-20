using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //并行任务
using System.Windows.Forms;

using System.Threading;      //Thread类

/*
   需求： 用多线程来解决一个复杂的查询，不影响程序的响应性和性能

    技术应用点： 多线程 Thread类
 */


namespace 简单线程案例
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //关闭跨线程调用的检查
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //1. 请助手 （创建线程,并告诉他要做什么事）
            Thread t = new Thread( new ThreadStart(BigQuery) ); //ThreadStart委托对应的是void返回类型，没有参数的方法

            //2. 请助手开始做
            t.Start();
        }


        //写一个函数 进行繁重的查询(模拟）
        private void BigQuery()
        {
            //模拟查询一百万条数据
            for (int i = 0; i < 1000000; i++)
            {
                this.textBox1.Text = i.ToString();
            }
        }
    }
}
