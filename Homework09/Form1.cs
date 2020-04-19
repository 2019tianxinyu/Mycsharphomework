using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crawler2
{
   
    public partial class Form1 : Form
    {
        Crawler2 crawler = new Crawler2();
        public Form1()
        {
            InitializeComponent();
            crawler.PageDownload += Crawler_PageDownload;
        }

        private void Crawler_PageDownload(string obj)
        {
            if (this.listBox1.InvokeRequired)
            {
                Action<String> action = this.AddUrl;
                this.Invoke(action, new object[] { obj });
            }
            else
            {
                listBox1.Items.Add(obj);
            }
        }

        private void AddUrl(string url)
        {
            listBox1.Items.Add(url);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            crawler.StartUrl = textBox1.Text;
            listBox1.Items.Clear();
            new Thread(crawler.Start).Start();

        }
    }
    class Crawler2
    {
        public event Action<String> PageDownload;
        private Hashtable urls = new Hashtable();
        private int n = 0;
        private string startUrl = "";
        public string StartUrl
        {
            get => startUrl;
            set
            {
                startUrl = value;
                urls = new Hashtable();
                urls.Add(value, false);
            }

        }

        public  void Start(){
            Console.WriteLine("----开始爬行----");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url])
                        continue;
                    current = url;
                }
                if (current == null || n > 10) break;
                Console.WriteLine("爬行" + current + "页面");
                string html = Download(current);
                urls[current] = true;
                n++;
                Parse(html);
                Console.WriteLine("----爬行结束----");
            }
        }

        private string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = n.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                PageDownload(url);
                return html;
            }
            catch(Exception ex)
            {
                PageDownload(url + " Error:" + ex.Message);
                return "";


            }
        }
        private void Parse(string html)
        {
            string strRef = @"(href | HREF)[] *=[] *[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }

    }
}
