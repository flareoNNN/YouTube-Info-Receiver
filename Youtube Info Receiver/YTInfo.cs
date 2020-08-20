using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Youtube_Info_Receiver
{
    public class YTInfo : anaSinif
    {
        string Isim;
        string Sure;
        string Aciklama;
        string Thumbnail;
        string Kanal;
        double Like;
        double Disslike;
        int Izlenme;

        public override void URL_Ayarla(string url)
        {
            try
            {
                Regex r = new Regex(@"#(?<=v=)[a-zA-Z0-9-]+(?=&)|(?<=v\/)[^&\n]+|(?<=v=)[^&\n]+|(?<=youtu.be/)[^&\n]+#");
                if (!r.IsMatch(url))
                {
                    throw new Exception("Geçersiz URL!");
                }

                WebClient wc = new WebClient();
                string satir = wc.DownloadString(url);

                bool getDesc = true;
                bool noLike = false;
                string str = satir;
                string str2 = satir;
                string str3 = satir;
                string str4 = satir;
                string str5 = satir;
                string str6 = satir;
                string str7 = satir;

                if (satir.Contains("\"status\":\"ERROR\""))
                {
                    throw new Exception("Video bulunamadı!");
                }

                if (satir.Contains("LOGIN_REQUIRED"))
                {
                    throw new Exception("Bu video gizli.");
                }

                if (satir.Contains("\\\"shortDescription\\\":\\\"\\\",\\\""))
                {
                    getDesc = false;
                }

                if (!satir.Contains("\"likeStatus\""))
                {
                    noLike = true;
                }

                int bul = str.IndexOf("<title>");
                str = str.Remove(0, bul);
                str = str.Remove(0, 7);
                bul = str.IndexOf(" - YouTube</title>");
                str = str.Remove(bul, str.Length - bul);
                Isim = IsimDuzelt(str);

                bul = str2.IndexOf("\\\"lengthSeconds\\\":\\\"");
                str2 = str2.Remove(0, bul);
                str2 = str2.Remove(0, 20);
                bul = str2.IndexOf("\\\"");
                str2 = str2.Remove(bul, str2.Length - bul);
                Sure = str2;

                bul = str3.IndexOf("<link rel=\"image_src\" href=\"");
                str3 = str3.Remove(0, bul);
                str3 = str3.Remove(0, 28);
                bul = str3.IndexOf("\">");
                str3 = str3.Remove(bul, str3.Length - bul);
                Thumbnail = str3;

                if (getDesc)
                {
                    bul = str4.IndexOf("\"description\\\":{\\\"simpleText\\\":\\\"");
                    str4 = str4.Remove(0, bul);
                    str4 = str4.Remove(0, 33);
                    bul = str4.IndexOf("\\\"},\\\"lengthSec");
                    str4 = str4.Remove(bul, str4.Length - bul);
                    Aciklama = IsimDuzelt(str4);
                }
                else
                {
                    Aciklama = "N/A";
                }

                if (!noLike)
                {
                    bul = str5.IndexOf("\"tooltip\":\"", str5.IndexOf("\"tooltip\":\"") + 1);
                    str5 = str5.Remove(0, bul);
                    str5 = str5.Remove(0, 11);
                    bul = str5.IndexOf("\"}},");
                    str5 = str5.Remove(bul, str5.Length - bul);
                    var ayir = str5.Split('/');
                    Like = double.Parse(ayir[0]);
                    Disslike = double.Parse(ayir[1]);
                }

                bul = str6.IndexOf("\"viewCount\\\":\\\"");
                str6 = str6.Remove(0, bul);
                str6 = str6.Remove(0, 15);
                bul = str6.IndexOf("\\\",");
                str6 = str6.Remove(bul, str6.Length - bul);
                Izlenme = int.Parse(str6);

                bul = str7.IndexOf("author\\\":\\\"");
                str7 = str7.Remove(0, bul);
                str7 = str7.Remove(0, 11);
                bul = str7.IndexOf("\\\",");
                str7 = str7.Remove(bul, str7.Length - bul);
                Kanal = IsimDuzelt(str7);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string IsimCek()
        {
            return Isim;
        }

        public override string SureCek()
        {
            try
            {
                TimeSpan t = TimeSpan.FromSeconds(int.Parse(Sure));
                return t.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string ThumbnailCek()
        {
            return Thumbnail;
        }

        public override string AciklamaCek()
        {
            return Aciklama;
        }

        public override double LikeCek()
        {
            return Like;
        }

        public override double DisslikeCek()
        {
            return Disslike;
        }

        public override int IzlenmeCek()
        {
            return Izlenme;
        }

        public override string KanalCek()
        {
            return Kanal;
        }

        static string IsimDuzelt(string str)
        {
            try
            {
                str = str.Replace("Ä±", "ı")
                        .Replace("Ä°", "İ")
                        .Replace("Ã‡", "Ç")
                        .Replace("Ã§", "ç")
                        .Replace("Ã¼", "ü")
                        .Replace("Ãœ", "Ü")
                        .Replace("Ã¶", "ö")
                        .Replace("Ã–", "Ö")
                        .Replace("ÅŸ", "ş")
                        .Replace("Å", "Ş")
                        .Replace("ÄŸ", "ğ")
                        .Replace("Ä", "Ğ")
                        .Replace("Ş?", "Ş")
                        .Replace("&amp;", "&")
                        .Replace("&quot;", "\"")
                        .Replace("&#39;", "'")
                        .Replace("”", "'")
                        .Replace("“", "'")
                        .Replace("’", "'")
                        .Replace("\\\\u0026", "&")
                        .Replace("\\/", "/")
                        .Replace("\\\\r", "")
                        .Replace("\\\\\\", "")
                        .Replace("Â©", "©")
                        .Replace("\\\\n", Environment.NewLine);
                return str;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}