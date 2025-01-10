# Basic Calculator / Temel Hesap Makinesi

This is a basic calculator application developed using C# and Windows Forms. It supports standard arithmetic operations, decimal numbers, and additional functions like square root, square, reciprocal, and sign toggling. The application also dynamically adjusts its layout and font sizes based on the window size and supports keyboard input.

Bu, C# ve Windows Forms kullanılarak geliştirilmiş temel bir hesap makinesi uygulamasıdır. Standart aritmetik işlemleri, ondalık sayıları ve karekök, kare, karşılık ve işaret değiştirme gibi ek işlevleri destekler. Uygulama ayrıca pencere boyutuna göre düzenini ve yazı tipi boyutlarını dinamik olarak ayarlar ve klavye girişini destekler.

## Features / Özellikler

*   **Basic Arithmetic Operations / Temel Aritmetik İşlemler:** Addition, subtraction, multiplication, and division (+, -, x, /). / Toplama, çıkarma, çarpma ve bölme (+, -, x, /).
*   **Decimal Number Support / Ondalık Sayı Desteği:** Supports calculations with decimal numbers. / Ondalık sayılarla hesaplamaları destekler.
*   **Additional Functions / Ek İşlevler:** Square root (√), square (x²), reciprocal (1/x), and sign toggle (+/-). / Karekök (√), kare (x²), karşılık (1/x) ve işaret değiştirme (+/-).
*   **Error Handling / Hata Yönetimi:** Handles division by zero and invalid input for square root (negative numbers). / Sıfıra bölme ve karekök için geçersiz giriş (negatif sayılar) durumlarını ele alır.
*   **Dynamic Layout and Font Sizing / Dinamik Düzen ve Yazı Tipi Boyutlandırma:** Automatically adjusts layout and font sizes based on the form size. / Form boyutuna göre düzeni ve yazı tipi boyutlarını otomatik olarak ayarlar.
*   **Keyboard Input Support / Klavye Giriş Desteği:** Supports keyboard input for numbers, operators, and Enter/Backspace/Delete keys. / Sayılar, operatörler ve Enter/Backspace/Delete tuşları için klavye girişini destekler.
*   **Input Validation/Giriş Doğrulaması:** Ekran boyutunu aşan girişleri engeller ve taşma durumlarını kontrol eder.

## Requirements / Gereksinimler

*   .NET Framework (Recommended version: .NET Framework 4.7.2 or higher) / .NET Framework (Önerilen sürüm: .NET Framework 4.7.2 veya üzeri)
*   Visual Studio (or any compatible C# IDE) / Visual Studio (veya uyumlu herhangi bir C# IDE'si)

## Running Instructions / Çalıştırma Adımları

1.  **Clone the Repository (if available):** / **Depoyu Klonlayın (varsa):**
    ```bash
    git clone [repository_url] // Örneğin: [geçersiz URL kaldırıldı]
    ```

2.  **Open the Solution:** / **Çözümü Açın:**
    Open the `BasicCalculator.sln` file in Visual Studio. / `BasicCalculator.sln` dosyasını Visual Studio'da açın.

3.  **Build and Run:** / **Derleyin ve Çalıştırın:**
    Build the project (Build -> Build Solution) and run it (Debug -> Start Debugging or press F5). / Projeyi derleyin (Oluştur -> Çözümü Oluştur) ve çalıştırın (Hata Ayıkla -> Hata Ayıklamayı Başlat veya F5'e basın).

## Development Notes / Geliştirme Notları

*   The application uses `TableLayoutPanel` controls for dynamic layout adjustment. / Uygulama, dinamik düzen ayarlaması için `TableLayoutPanel` kontrollerini kullanır.
*   Font sizes are calculated based on the form height for better responsiveness. / Yazı tipi boyutları, daha iyi yanıt verebilirlik için form yüksekliğine göre hesaplanır.
*   You can extend the calculator with more advanced functions (e.g., trigonometric functions, memory functions) or improve the user interface. / Hesap makinesini daha gelişmiş işlevlerle (örneğin, trigonometrik fonksiyonlar, bellek işlevleri) genişletebilir veya kullanıcı arayüzünü iyileştirebilirsiniz.
*   Kod, klavye girişlerini ve farklı hata senaryolarını ele alacak şekilde düzenlenmiştir.

## Contact / İletişim

For questions, suggestions, or bug reports, please contact me through: / Sorular, öneriler veya hata bildirimleri için lütfen benimle iletişime geçin:

*   GitHub: [Your GitHub Username] / [GitHub Kullanıcı Adınız]
*   Email: [Your Email Address] / [E-posta Adresiniz]
