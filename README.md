Serilog Logging Sample (.NET Web API)

Bu proje, .NET Web API üzerinde Serilog kullanılarak loglama, hata yönetimi ve API dokümantasyonu konularını örneklemek amacıyla hazırlanmıştır.

⚙️ Kullanılan Teknolojiler

.NET Web API

Serilog

Serilog.Sinks.File

Serilog.Sinks.Console

JSON Formatter

OpenAPI

Scalar UI

🧱 API İçerikleri
GET /api/home/trigger

Test amaçlı olarak bilinçli şekilde exception fırlatır

Hata loglama ve stack trace davranışını gözlemlemek için kullanılır

GET /api/home/slow

Yavaş çalışan bir işlemi simüle eder

Uzun süren işlemlerde log akışını göstermek amacıyla eklenmiştir

GET /api/home/user/{userId}

Örnek kullanıcı verisi döner

Parametre doğrulama ve farklı log seviyelerinin kullanımını gösterir

🧭 API Dokümantasyonu

API sözleşmesi OpenAPI standardı ile oluşturulmuştur.

Endpoint’ler Scalar UI üzerinden görüntülenebilir ve test edilebilir.

/openapi
📝 Log Yapısı

Loglar JSON formatında dosyaya yazılır

Hata durumlarında exception ve stack trace bilgileri loglanır
