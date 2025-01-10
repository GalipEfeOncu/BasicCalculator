# Basic Calculator

Bu, C# ve Windows Forms ile oluşturulmuş basit bir hesap makinesi uygulamasıdır.

## Özellikler

*   Temel aritmetik işlemleri gerçekleştirir (toplama, çıkarma, çarpma, bölme)
*   Ondalık sayıları destekler
*   Karekök, kare, karşılık ve işaret değiştirme gibi işlevler sunar
*   Temel hata yönetimi içerir (sıfıra bölme)
*   Pencere boyutuna göre yazı tipi boyutlarını ve düzeni dinamik olarak ayarlar

## Başlangıç

1.  Bu depoyu klonlayın veya indirin.
2.  Çözüm dosyasını (`BasicCalculator.sln`) Visual Studio'da açın.
3.  Uygulamayı çalıştırın (F5'e basın).

## Nasıl Kullanılır

*   Sayı girmek için sayı düğmelerine (0-9) tıklayın.
*   Hesaplamalar yapmak için aritmetik düğmelerini (+, -, \*, /) kullanın.
*   Sonuç, üst etikette (`lblText`) görüntülenecektir.
*   Hesaplama geçmişi, alt etikette (`lblText1`) gösterilecektir.
*   Ek işlevler için aşağıdaki düğmeleri kullanın:
    *   `C` (Temizle): Hem ekranı hem de hesaplama geçmişini temizler.
    *   `CE` (Girişi Temizle): Yalnızca ekranı temizler.
    *   `Backspace`: Girilen son rakamı siler.
    *   `+/-`: Görüntülenen sayının işaretini değiştirir.
    *   `.` (Ondalık): Görüntülenen sayıya ondalık nokta ekler.
    *   `sqrt`: Görüntülenen sayının karekökünü hesaplar.
    *   `x^2`: Görüntülenen sayının karesini alır.
    *   `1/x`: Görüntülenen sayının karşılığını hesaplar.

## Geliştirme Ortamı

*   C#
*   Windows Forms

## Lisans

Bu proje şu anda lisanssızdır. Daha geniş kullanım ve katkı için MIT veya Apache 2.0 gibi bir açık kaynak lisansı uygulamayı düşünebilirsiniz.

## İleri Geliştirme

Bu temel bir hesap makinesidir ve aşağıdaki gibi daha fazla özellik ekleyerek genişletebilirsiniz:

*   Bellek işlevleri (değerleri saklama ve geri çağırma)
*   Yüzde hesaplamaları
*   Bilimsel işlemler (trigonometri, logaritmalar)
*   Kullanıcı tercihleri (özelleştirilebilir renkler, temalar)

İhtiyaçlarınıza göre kodu değiştirmekten ve işlevler eklemekten çekinmeyin.
