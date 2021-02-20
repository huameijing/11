using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace 多线程操作
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //克隆多线程
            //检查跨线程调用设为false
            CheckForIllegalCrossThreadCalls = false;
        }

        //第一步 把需要线程处理的任务，写一个函数
        private void MissionImpossible(object obj)
        {
            //设定进度条最高值
            this.progressBar1.Maximum = 10000;

            //模拟一个繁重的查询
            for (int i = 1; i <= 10000; i++)
            {
                this.textBox1.Text = obj.ToString() + "\r\n" + i.ToString();

                this.progressBar1.Value = i;   //设定进度条的值

                this.label1.Text = (i * 1.0 / 10000).ToString("p"); //返回百分比字符串
            }

            this.textBox1.Text = "任务已完成";
        }

        //定义一个Thread的对象(类的私有字段）
        private Thread tom;


        private void Button1_Click(object sender, EventArgs e)
        {
            //第二步：创建一个线程
            tom = new Thread(new ParameterizedThreadStart(MissionImpossible));

            //IsBackground用来设定线程为后台线程；  //默认情况下创建的线程都是前台线程
            tom.IsBackground = true;

            //第三步：命令tom开始执行
            tom.Start("保证完成任务！因为我很牛！");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //让线程睡觉5秒
            Thread.Sleep(5000);  //5000毫秒
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //线程的挂起
            //先判断线程状态如果为运行状态，则执行挂起
            if(tom.ThreadState == ThreadState.Running)
            {
                tom.Suspend();  //Suspend(); 方法用来挂起线程
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //先判断线程状态如果为挂起状态，则执行恢复
            if(tom.ThreadState == ThreadState.Suspended)
            {
                tom.Resume(); //Resume();方法用来恢复线程
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //先判断线程是否被创建，如果被创建则终止（解雇这个助手）
            if(tom !=null)
            {
                tom.Abort(); //Abort();方法用来终止线程
            }
        }
    }
}
