# Banking Project (.NET Framework)

Bu proje, bir bankacılık sisteminin temel operasyonlarını yönetmek amacıyla **N-Tier Architecture (Çok Katmanlı Mimari)** prensipleriyle geliştirilmiş kurumsal bir yazılım örneğidir. Proje, veri güvenliği ve katmanlar arası düşük bağımlılık (loose coupling) hedeflenerek inşa edilmiştir.

## Mimari Yapı

Proje, sorumlulukların net ayrımı (**Separation of Concerns**) için 4 ana katmandan oluşmaktadır:

* **BankingProject.EntityLayer:** Bankacılık süreçlerini temsil eden nesnelerin (POCO) bulunduğu katman.
* **BankingProject.DataAccessLayer:** Verilerin bellek üzerinde (**In-Memory List**) yönetildiği ve temel CRUD operasyonlarının simüle edildiği katman.
* **BankingProject.BusinessLayer:** İş mantığının, hesaplama süreçlerinin ve validasyonların yönetildiği katman.
* **BankingProject.PresentationLayer:** Kullanıcı ile etkileşimin sağlandığı arayüz katmanı.

## Öne Çıkan Teknik Özellikler

* **LINQ & Collections:** Veri filtreleme ve arama süreçlerinde performanslı **LINQ** sorguları ve generic koleksiyonlar kullanılmıştır.
* **Encapsulation:** Veri güvenliği için tüm entity sınıflarında kapsülleme prensipleri uygulanmıştır.
* **Validation Logic:** Hatalı veri girişini ve mantıksal hataları (yetersiz bakiye vb.) önlemek için Business katmanında güçlü kontrol mekanizmaları kurulmuştur.

## Kullanılan Teknolojiler

* **Dil:** C#
* **Framework:** .NET Framework
* **Veri Yönetimi:** In-Memory Collections (Generic Lists)
* **Mimari:** N-Tier Architecture (Katmanlı Mimari)

## Klasör Yapısı

```text
📂 BankingProject
├── 📂 BankingProject.BusinessLayer      # İş Kuralları & Mantık
├── 📂 BankingProject.DataAccessLayer    # Veri Yönetimi (List-Based)
├── 📂 BankingProject.EntityLayer        # Modeller & Nesneler
└── 📂 BankingProject.PresentationLayer  # UI / Arayüz

Projede herhangi bir veritabanı yapılandırması yapılmadığı için doğrudan çalıştırılmaya hazırdır. 
Aşağıdaki adımları izleyebilirsiniz:

1. Repoyu Klonlayın:
   git clone [https://github.com/mercansezer/BankingProject.git](https://github.com/mercansezer/BankingProject.git)

2. Projeyi Açın:
   Visual Studio kullanarak .sln uzantılı çözüm dosyasını çalıştırın.

3. Derleme (Build):
   Solution Explorer üzerinden projeye sağ tıklayıp Build seçeneğine basın.

4. Çalıştır:
   Üst paneldeki Start (veya F5) butonuna basarak uygulamayı test etmeye başlayın.
