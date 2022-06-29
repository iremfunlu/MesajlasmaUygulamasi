using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MessageProject
{
    class KodYonetim
    {
        public string DakikSMSMesajGonder(string numaralar, string mesaj, string ApiAdres)
        {
            // DEĞİŞKENLER OLUŞTURULUYOR
            string kullaniciAdi = "ahmet", sifre = "123456", baslik = "Ahmet";
            // XML DESENİ YARATILIYOR.
            string xmlDesen = "<SMS><oturum><kullanici>" + kullaniciAdi + "</kullanici><sifre>" + sifre + "</sifre></oturum><mesaj><baslik>" + baslik + "</baslik><metin>" + mesaj + "</metin><alicilar>" + numaralar.ToString() + "</alicilar><tarih></tarih></mesaj></SMS>";
            // APIYE XML DESENİ VE API ADRESİ GÖNDERİLİYOR.
            WebRequest request = WebRequest.Create(ApiAdres);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(xmlDesen);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
            // DÖNEN CEVAP İLGİLİ YERE GÖNDERİLİYOR.
        }

    }
}
