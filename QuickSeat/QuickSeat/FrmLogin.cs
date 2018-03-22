using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuickSeat
{

    public partial class FrmLogin : Form
    {
        FrmMain mainf = new FrmMain();
        ProgramConfig usernp;
        
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("http://seat.lib.whu.edu.cn/rest/auth?username=" + txtStuID.Text + "&password=" +txtPwd.Text);
            httpRequest.Timeout = 2000;
            httpRequest.Method = "GET";
            httpRequest.CookieContainer = new CookieContainer();
            httpRequest.CookieContainer.Add(mainf.Cookies);
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();
            result = result.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            int status = (int)httpResponse.StatusCode;
            sr.Close();

            JObject res = JObject.Parse(result);
            if (res["message"].ToString() == "")
            {
                //实现记住密码
                usernp.remembered = checkBox1.Checked;
                if (checkBox1.Checked == true)
                {
                    usernp.id = txtStuID.Text;
                    usernp.pw = txtPwd.Text;
                }
                writeconfig(usernp);
                mainf.Token = res["data"]["token"].ToString();
                
                mainf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(res["message"].ToString(), "提示");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //先获取网页版cookies
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("http://seat.lib.whu.edu.cn/simpleCaptcha/captcha");
            httpRequest.Timeout = 2000;
            httpRequest.Accept = "text/html, application/xhtml+xml, image/jxr, */*";
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Safari/537.36 Edge/13.10586";
            httpRequest.Method = "GET";
            httpRequest.Host = "seat.lib.whu.edu.cn";
            httpRequest.KeepAlive = true;
            httpRequest.Referer = "http://seat.lib.whu.edu.cn/simpleCaptcha/captcha";
            httpRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpRequest.Headers.Add("Accept-Language", "zh-CN");

            httpRequest.CookieContainer = new CookieContainer();
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();
            result = result.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            int status = (int)httpResponse.StatusCode;
            sr.Close();
            mainf.Cookies = httpResponse.Cookies;

            ///...读取配置设置,实现记住密码
            usernp = new ProgramConfig();
            if(File.Exists("config.json"))
            {
                FileStream Fs = new FileStream("config.json", FileMode.Open);
                StreamReader Fsr = new StreamReader(Fs, Encoding.UTF8);
                result = Fsr.ReadToEnd();
                Fsr.Close();
                usernp = JsonConvert.DeserializeObject<ProgramConfig>(result);
                
                checkBox1.Checked = usernp.remembered;
                if (checkBox1.Checked)
                {
                    txtStuID.Text = usernp.id;
                    txtPwd.Text = usernp.pw;
                }
            }
            else
            {
                writeconfig(usernp);
            }

            ///
            
        }

        private void writeconfig(ProgramConfig conf)    //写应用程序的配置设置
        {
            string result = JsonConvert.SerializeObject(usernp);
            FileStream Fs = new FileStream("config.json", FileMode.Create);
            StreamWriter Fsw = new StreamWriter(Fs, Encoding.UTF8);
            Fsw.Write(result);
            Fsw.Close();
        }

    }

    internal class ProgramConfig
    {
        public string id;
        public string pw;
        public bool remembered;
        public ProgramConfig()
        {
            id = "";
            pw = "";
            remembered = false;
        }
    }
}
