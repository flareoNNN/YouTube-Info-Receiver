[![Release](https://img.shields.io/github/v/release/flareoNNN/YouTube-Info-Receiver "Release")](https://github.com/flareoNNN/YouTube-Info-Receiver/releases "Release")
[![License](https://img.shields.io/github/license/flareoNNN/YouTube-Info-Receiver "License")](https://github.com/flareoNNN/YouTube-Info-Receiver/blob/master/LICENSE "License")

# YouTube Info Receiver

C# için yazılmış YouTube video bilgisi çekme kütüphanesi.<br>
Versiyon: *1.0.1*

# Kurulum

YouTube Info Receiver Link: [https://github.com/flareoNNN/YouTube-Info-Receiver/releases](https://github.com/flareoNNN/YouTube-Info-Receiver/releases)<br><br>

YouTube Info Receiver'ı visual studio'da projenize girerek references(başvurular) kısmından .dll dosyası olarak ekleyebilirsiniz. Herhangi bir videonun bilgilerini çekmek için aşağıdaki kullanım örneğine göz atabilirsiniz.

# Kullanım

````c#
using System;
using Youtube_Info_Receiver;

namespace OrnekUygulama
{
    class Program
    {
        static void Main(string[] args)
        {
            YTInfo bilgi = new YTInfo();

            bilgi.URL_Ayarla("https://www.youtube.com/watch?v=idqdUopJazc");

            string videoIsim = bilgi.IsimCek();
            string videoSure = bilgi.SureCek();
            int videoIzlenme = bilgi.IzlenmeCek();
            string videoKanal = bilgi.KanalCek();
            double videoLike = bilgi.LikeCek();
            double videoDissLike = bilgi.DisslikeCek();
            string videoAciklama = bilgi.AciklamaCek();
            string videoThumbnail = bilgi.ThumbnailCek();

            Console.WriteLine("Isim: " + videoIsim);
            Console.WriteLine("Süre: " + videoSure);
            Console.WriteLine("İzlenme: " + videoIzlenme);
            Console.WriteLine("Kanal: " + videoKanal);
            Console.WriteLine("Like: " + videoLike);
            Console.WriteLine("DissLike: " + videoDissLike);
            Console.WriteLine("Thumbnail: " + videoThumbnail + "\n");
            Console.WriteLine("Açıklama: " + videoAciklama);

            Console.ReadKey();
        }
    }
}
````

Çıktı:
````
Isim: DİDOMİDO feat. EGLO G  - NİMET
Süre: 00:02:17
İzlenme: 30231260
Kanal: Didem
Like: 448783
DissLike: 14102
Thumbnail: https://i.ytimg.com/vi/idqdUopJazc/maxresdefault.jpg

Açıklama: Didomido - Nimet (ft. Eglo G)

Sosyal Medya:
Didem İnstagram » https://instagram.com/Didomidosong
Eglo G İnstagram » https://instagram.com/Eglog_official

Söz & Müzik : Eglo G
Kayıt & Aranje : Onur Aşar
Beat : Aksil Beats


'' Nimet '' Şarkı Sözleri
Yerimde saydım bak kalbim karıştırır aklımı.
Tenimde nemlik var elimde yaş gibi anladım.
Ansızın gözgöze geldim bir bak,bakışları nimet nimet.
Kim bilir belki de peşinde kimler kimler var.

Aklımı aldın sen ver geri nolur nolur.
Yardım et yarab sen gözleri boncuk boncuk.
Saçları bal rengi yanakları allana allana
Tatlı mı tatlı ah kalbimi ver geri boşluk var.

Aah dert başa vurdu bi gülmedim halen ah.
Dargınım düşlere olmadı hiç biri ah.
A-ha yorma.

Erdemi yansır taş çatlatır nazlı mı nazlı bi kalp.
Sardırır tütünü çakmağı yak başladı kabusum sil baştan.

Ansızın gözgöze geldim bir bak,bakışları nimet nimet.
Kim bilir belki de peşinde kimler kimler var.

Aklımı aldın sen ver geri nolur nolur.
Yardım et yarab sen gözleri boncuk boncuk.
Saçları bal rengi yanakları allana allana
Tatlı mı tatlı ah kalbimi ver geri boşluk var.

Beni özleminle değil
Beni sözlerinle değil
Tutup ellerinle beni,gözlerinde deli et.

Aklımı aldın sen ver geri nolur nolur.
Yardım et yarab sen gözleri boncuk boncuk.
Saçları bal rengi yanakları allana allana
Tatlı mı tatlı ah kalbimi ver geri boşluk var.

© WeLog Music 2020
````

# Lisans

Apache License 2.0
