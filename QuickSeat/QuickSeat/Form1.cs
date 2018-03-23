using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;   //正则表达式
using Newtonsoft.Json.Linq;
namespace QuickSeat
{
    public partial class FrmMain : Form
    {
        public string Token;
        public CookieCollection Cookies;
        private string[] roomlist = new string[32];
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //读取用户姓名
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("http://seat.lib.whu.edu.cn/rest/v2/user/"); //GET这个网址
            httpRequest.Timeout = 2000;
            httpRequest.Method = "GET";
            httpRequest.Headers.Add("token", Token);
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();
            result = result.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            int status = (int)httpResponse.StatusCode;
            sr.Close();

            JObject res = JObject.Parse(result);    //解析JSON
            labName.Text = "欢迎你：" + res["data"]["name"].ToString() + "  请先选择预约时间：";

            httpRequest = (HttpWebRequest)WebRequest.Create("http://seat.lib.whu.edu.cn/rest/v2/free/filters/"); //GET这个网址
            httpRequest.Timeout = 2000;
            httpRequest.Method = "GET";
            httpRequest.Headers.Add("token", Token);
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
            result = sr.ReadToEnd();
            result = result.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            status = (int)httpResponse.StatusCode;
            sr.Close();

            res = JObject.Parse(result);    //解析JSON

            lstData.Items.Add(res["data"]["dates"][0].ToString());
            lstData.Items.Add(Convert.ToDateTime(res["data"]["dates"][0].ToString()).AddDays(1).ToShortDateString().Replace("/", "-"));

            foreach (JArray item in res["data"]["buildings"])
            {
                lstBuildings.Items.Add(item[1].ToString());
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();     //防止窗体关闭后程序不退出
        }

        private void lstBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("http://seat.lib.whu.edu.cn/rest/v2/room/stats2/" + (lstBuildings.SelectedIndex + 1).ToString()); //GET这个网址
            httpRequest.Timeout = 2000;
            httpRequest.Method = "GET";
            httpRequest.Headers.Add("token", Token);
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();
            result = result.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            int status = (int)httpResponse.StatusCode;
            sr.Close();

            JObject res = JObject.Parse(result);    //解析JSON
            lstRooms.Items.Clear();
            int i = 0;
            foreach (JObject item in res["data"])
            {
                lstRooms.Items.Add(item["room"].ToString());
                roomlist[i] = item["roomId"].ToString();
                i++;
            }
            roomlist[31] = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "取消")
            {
                clkSearching.Enabled = false;
                button1.Text = "开始随机选座";
            }
            else
            {
                button1.Text = "取消";
                clkSearching.Enabled = true;
            }
      
        }

        private void Searching()
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(
    "http://seat.lib.whu.edu.cn/freeBook/ajaxSearch?onDate=" + lstData.Text +
                                                "&building=" + (lstBuildings.SelectedIndex + 1) +
                                                    "&room=" + roomlist[lstRooms.SelectedIndex == -1 ? 31 : lstRooms.SelectedIndex] +
                                                    "&hour=" +
                                                   "&power=" +
                                                "&startMin=" + (lstStartT.SelectedIndex * 30 + 480) +
                                                  "&endMin=" + (lstEndT.SelectedIndex * 30 + 510) + "&offset=0"); //GET这个网址
            httpRequest.Timeout = 2000;
            httpRequest.Method = "GET";
            httpRequest.CookieContainer = new CookieContainer();
            httpRequest.CookieContainer.Add(Cookies);
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();
            result = result.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            int status = (int)httpResponse.StatusCode;
            sr.Close();

            JObject res = JObject.Parse(result);    //解析JSON
            result = res["seatStr"].ToString();

            //正则匹配

            Regex re = new Regex("(?<=id\\=\"seat_)[1-9]+");
            MatchCollection matches = re.Matches(result);

            //System.Collections.IEnumerator enu = matches.GetEnumerator();
            if (matches.Count == 0)
            {
                putline("未能找到符合条件的座位，继续尝试中。。。");
            }
            foreach (Match item in matches)
            {
                //如果匹配到（符合条件的作位），则开始尝试预约
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://seat.lib.whu.edu.cn/rest/v2/freeBook");
                req.Method = "POST";
                req.Headers.Add("token", Token);
                req.ContentType = "application/x-www-form-urlencoded";
                #region 添加Post 参数  
                byte[] data = Encoding.UTF8.GetBytes("startTime=" + (lstStartT.SelectedIndex * 30 + 480) +
                                                      "&endTime=" + (lstEndT.SelectedIndex * 30 + 510) +
                                                         "&seat=" + item.Value +
                                                         "&date=" + lstData.Text);
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }
                #endregion

                HttpWebResponse rep = (HttpWebResponse)req.GetResponse();
                sr = new StreamReader(rep.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd();                //返回数据

                res = JObject.Parse(result);    //解析JSON
                if (res["message"].ToString() == "")
                {
                    putline("服务器返回：" + res["data"]["receipt"].ToString() + res["data"]["location"].ToString());
                    clkSearching.Enabled = false;
                    button1.Text = "开始随机选座";
                }
                else
                {
                    putline("服务器返回：" + res["message"].ToString());
                }
                break;
            }

        }

        private void clkSearching_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if(DateTime.Now > timeStart.Value)
                {
                    Searching();
                }
                else
                {
                    putline("程序将在" + timeStart.Value.ToString() + "时开始选座，距开始选座还有" + (timeStart.Value - DateTime.Now).TotalSeconds + "秒");
                }
            }
            else
            {
                Searching();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                timeStart.Enabled = true;
            }
            else
            {
                timeStart.Enabled = false;
            }
        }


        //标准输出函数
        private void putline(string str)
        {
            txtLog.Text += "\r\n\r\n[" + DateTime.Now.ToLongTimeString() + "]>" + str;
            txtLog.Select(txtLog.TextLength, 0);//光标定位到文本最后
            txtLog.ScrollToCaret();//滚动到光标处
        }
    }
}
