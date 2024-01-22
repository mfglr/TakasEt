using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addseeddata1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "IsRemoved", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedFullName", "NormalizedUserName", "NumberOfPost", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RemovedDate", "SecurityStamp", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "605095b2-c70f-4f4d-b85c-b2adde79c0ec", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8218), new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8217), "mfglr@outlook.com", false, true, false, "Guler", true, new DateTimeOffset(new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Unspecified).AddTicks(8222), new TimeSpan(0, 3, 0, 0, 0)), "Furkan", "MFGLR@OUTLOOK.COM", "FURKAN GULER", "MFGLR", 5, "AQAAAAIAAYagAAAAED6NMviLL2arHtiYhoWGr4sgZ8Fshn5Zle16j09bcR35MFXSGYpE0wskAKdEiV6LYw==", "0000000000", false, null, "MJ3TWU3F4CA3YUYFWTJMO3GXQUXGWT4F", false, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8218), "mfglr" },
                    { 2, 0, "605095b2-c70f-4f4d-b85c-b2adde79c0ec", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8257), new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8257), "test@outlook.com", false, true, false, "test", true, new DateTimeOffset(new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Unspecified).AddTicks(8258), new TimeSpan(0, 3, 0, 0, 0)), "test", "TEST@OUTLOOK.COM", "TEST TEST", "TEST", 5, "AQAAAAIAAYagAAAAED6NMviLL2arHtiYhoWGr4sgZ8Fshn5Zle16j09bcR35MFXSGYpE0wskAKdEiV6LYw==", "0000000001", false, null, "MJ3TWU3F4CA3YUYFWTJMO3GXQUXGWT4F", false, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8258), "test" }
                });

            migrationBuilder.InsertData(
                table: "Following",
                columns: new[] { "FollowerId", "FollowingId", "CreatedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7995), null },
                    { 2, 1, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7997), null }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CategoryId", "Content", "CountOfImages", "CreatedDate", "IsRemoved", "NormalizedTitle", "RemovedDate", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Dikkat! İçerde Felsefespri var!\r\n\r\n“Yılın en matrak çoksatarı” –The Boston Globe\r\n\r\n“Çok güldüm, çok şey öğrendim, çok sevdim” –Roy Blount Jr.\r\n\r\nFelsefe mi? Felsefeyi anlamak için büyük bir dehanın zekâsına ve peygamber sabrına sahip olmak gerekir. Bu doğru değil! Bu komik, ele avuca sığmaz, çok yönlü ve zengin içerikli kitap bu efsaneyi yerle bir ediyor.\r\n\r\n“Platon Bir Gün Kolunda Bir Ornitorenkle Bara Girer…” ile birlikte kendinizi olağanüstü eğlenceli bir felsefe dersinin içinde bulacaksınız. Felsefi kavramların esprilerle nasıl aydınlatılabileceğini, mizahın da aslında büyüleyici bir felsefi içerik barındırdığını göreceksiniz. Ama bir dakika… Bu iki kavrayış yolu, yani felsefe ile espri aynı şey mi yoksa? Fıkra ve esprilerin kuruluşu ve etkisiyle felsefi kavramların kuruluşu ve etkisi aynı malzemelere dayanmaz mı? İkisi de aynı şekilde aklımızı gıdıklamaz mı? Şey, biraz düşünüp sonra söylesek?\r\n\r\nHarvard’lı iki felsefe profesöründen “güldürürken düşündüren” bir Stand-Up…", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8125), false, "PLATON BIR GUN KOLUNDA BIR ORNITORENKLE BARA GIRER : FELSEFEYI MIZAH YOLUYLA ANLAMAK", null, "Platon Bir Gün Kolunda Bir Ornitorenkle Bara Girer : Felsefeyi Mizah Yoluyla Anlamak", null, 1 },
                    { 2, 1, "Bu klâsik ders kitabı, mühendislik, fen bilimleri veya bilgisayar bilimlerine uygulandığı kadarıyla olasılık ve istatistik dersleri alan üçüncü/dördiincü sınıf lisans öğrencileri için güncel konularla ilgili uygulamalara bağlayarak harekete getiren titiz bir temel olasılık teorisi ve istatistiksel kanıtlamaya giriş sunar. Kitap temel yüksek matematik bilgisini öngörür.\r\nÖnceki baskıları kullananlar olağanüstü anlatım ve yazım biçimine övgüye devam ediyor. Ross, olasılığın istatistik problemlerinin içyüzünü kavrama konusundaki rolünün altını çizerken, bu baskının yeni nesil mühendis ve fen bilimcilere cazip geleceğini de garanti ediyor. Kapalı CD-ROM alıştırmalar için gerekli hesaplamaları otomatikleştiren ve olasılık teorisini günlük istatistiksel problemlere ve durumlara uygulamada öğrencilere yardımcı olan kullanımı kolay yazılım içeriyor.", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8127), false, "OLASILIK VE ISTATISTIGE GIRIS -MUHEMDISLER VE FENCILER ICIN- / INTRODUCTION TO PROBABILITY AND STATICTICS FOR ENGINEERS AND SCIENTIST", null, "OLASILIK ve İSTATİSTİĞE GİRİŞ -Mühendisler ve Fenciler için- / Introduction to Probability and Statistics for Engineers and Scientist", null, 1 },
                    { 3, 1, "Yayıncı	Ekin Kitabevi Yayınları\r\nListe Fiyatı	150.00 \r\nFormat	Kitap\r\nBarkod	9786055335854\r\nYayın Tarihi	2018-11-07\r\nBaskı Sayısı	2012.Baskı\r\nSayfa Sayısı	394\r\nBoyut	160 X 235\r\nBasım Yeri	Bursa", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8128), false, "TURKIYE CUMHURIYETI TARIHI", null, "Türkiye Cumhuriyeti Tarihi", null, 1 },
                    { 4, 1, "Ekonomiye Giriş Temel Kavramlar : Arz-Talep : Esneklik : Piyasa Dengesi ve Kaymalar : Piyasalar 1: Üretim ve Maliyetler : Piyasalar 2 : Kamu Ekonomisi : Makroekonomik Kavramlar ve Makro Denge : Harcamalar ve Denge Milli Gelir : Kamu Kesimi Genel Dengesi : Para ve Para : Teorisine Giriş : Merkez Bankacılığına Giriş : Merkez Bankası ve İşleyiş Mekanizması : Finansal Sistem İşleyişi : Uluslararası Ticaret, Ödemeler Dengesi ve Döviz Kuru", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8129), false, "EKONOMIYE GIRIS", null, "Ekonomiye Giris", null, 1 },
                    { 5, 1, "X86 Tabanlı Mikroişlemci ve Assembly Dili - Nurettin Topaloğlu - Seçkin Yayıncılık - İngilizce ve Türkçe Kitap, Nurettin Topaloğlu tarafından kaleme alınmıştır. Eser - editörlüğünde hazırlanmıştır. Kitap 2001 yılında Seçkin Yayıncılık tarafından [Ankara] yayınlanmıştır. Bu baskının çevirisi - tarafından yapılmıştır. 512 sayfadır. Sayfa bilgisi - olarak belirtilmiştir. X86 Tabanlı Mikroişlemci ve Assembly Dili - Nurettin Topaloğlu - Seçkin Yayıncılık - İngilizce ve Türkçe Kitap adlı eser İngilizce dilindedir. Eserin içeriğinde Türkçe dilinde bölümlere de yer verilmektedir.\r\n\r\nKitap, 19 cm genişliğinde 24 cm yüksekliğindedir.\r\n\r\nKitap KARTON KAPAKLI cilt bilgisi ile 26 gün önce eklenmiştir.\r\n\r\nX86 Tabanlı Mikroişlemci ve Assembly Dili - Nurettin Topaloğlu - Seçkin Yayıncılık - İngilizce ve Türkçe Kitap adlı eser, Kitap > Bilim, Teknik, Araştırma kategorisinde İkinci El olarak satıştadır.", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8129), false, "X86 TABANLI MIKROISLEMCI VE ASEMBLY DILI", null, "X86 Tabanlı Mikroişlemci ve Assembly Dili", null, 1 },
                    { 6, 1, "Dil pek çok bilim alanının incelediği bir olgudur. Ancak dil ile ilgili incelemelerin kalbi dilbilimdir. Bu kitap dilbilimin dünü ve bugününü ana hatlarıyla okuyucuya sunma amacıyla hazırlanmıştır. Dilbilim kuramları, dilbilimin ses bilgisi, biçim bilgisi, sözdizimi gibi alanlardaki uygulamaları, göstergebilim, edimbilim gibi dil ile ilgili pek çok alanın yaklaşım biçimleri isimler, kuramlar ve uygulamalar üzerinden değerlendirilmiştir. Kitabın yeniliklerinden birisi daha önceki yayınlarda toplu olarak ele alınmayan dilbilgisi kuramlarına ayrı bir başlık ayırmasıdır. Dilbilim İngilizce, Fransızca ve Almanca gibi Batı dillerinin akademik programında yer alan bir ders olarak da okutulmaktadır. Son yıllarda üniversitelerimizin Türkçeyle ilgili bölümlerinde de Genel Dilbilim dersi yer almaktadır. Bu nedenle kitapta açıklama ve uygulamalar Türkolojiyle ilişkilendirilerek verilmeye çalışılmıştır. Ayrıca sesbilgisi, biçimbilgisi ve sözdizimi bölümlerinde Türkolojideki bakış açıları da ayrı bir başlık açılarak tartışılmıştır.", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8130), false, "GENEL DILBILIMINE GIRIS", null, "Genel Dilbilime Giriş", null, 2 },
                    { 7, 1, "Fahrettin Erdinç, web tasarımına ve HTML'e yeni başlayanları hedef alarak yazdığı bu kitapta, fazla teoriye kaçmadan, konuya odaklanarak, kolay anlaşılacak örneklerle web tasarım mantığını anlatıyor, HTML 5 ve CSS 3'ün yeni olanaklarını örneklerle okura sunuyor.\r\n\r\nKitapta Web sayfalarının oluşturulması süreci anlatılırken, Steve Champeon’ın “Aşamalı Geliştirme” yaklaşımını kullanıldı. Bu yaklaşımda amaç, önce basit bir sayfa oluşturup zamanla eklemeler yaparak daha karmaşık sayfalar oluşturmaktır. Bu yöntemde, önce HTML kodları yazılıyor ve okurla birlikte doğru çalışıp çalışmadığı test ediliyor. Daha sonra CCS kodları eklenip sayfa daha görsel hale getiriliyor. Son olarak da Javascript ve ilgili kütüphaneleri kullanarak daha etkileşimli sayfalar oluşturuluyor.\r\n\r\nFahrettin Erdinç, web teknolojisinin en yeni araçlarını kullanarak, web sayfası tasarımının temel mantığını herkesin anlayabileceği bir şekilde adım adım anlatıyor. Bu da kitabı, hiç HTML ve CSS bilmeyip öğrenmek isteyen veya var olan HTML/CSS bilgisini geliştirmek isteyenler için ideal başvuru kaynağı haline getiriyor", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8130), false, "YENI BASLAYANLAR ICIN HTML5 - CSS3", null, "Yeni Başlayanlar İçin HTML5 - CSS3", null, 2 },
                    { 8, 1, "1) Bilgisayar ile ilişkili bir eğitim görüyorsanız, çok kullanıcılı işletim sistemleri içinde kararlılık ve güvenilirlik bakımından en popüleri olan UNIX işletim sistemini öğrenmek zorundasınız demektir. Ancak UNIX, PC'ler üzerine yüklenemez. Evde kullanabileceğiniz bir PC üzerine ancak Linux'u yükleyebilirsiniz ve Linux, komut ve özellikleri bakımından, grafik arayüzleri bakımından UNIX'in tam bir kopyasıdır. O halde evdeki UNIX laboratuvarınız, bir Linux makinasıdır.\r\n\r\n2) İşyerinizde UNIX kullanan bir profesyonelseniz evinizdeki PC'de de Linux kullanmak istemeniz son derecede anlaşılır bir istektir.\r\n\r\n3) Bir bilişim teknolojisi (Information technology-IT) uzmanı iseniz ve şu ana kadar Linux ile pek ilgilenmedi iseniz, bilmelisiniz ki uygun bir Linux dağıtımını seçerek (Red Hat, Mandrake vb), ticari bir ağ uygulamasını Linux ile mükemmel bir şekilde yürütebilirsiniz. Linux, güvenilirlik ve kararlılık açısından mükemmel bir işletim sistemidir.\r\n\r\nKitapta Yer Alan Konular\r\n\r\no Linux Nedir? Linux'un Tarihçesi Linux Dağıtımları\r\n\r\no Ubuntu Linux Sürümü Hakkında Kısa Bilgi\r\n\r\no Linux'a Giriş En Sık Kullanılan Komutlar\r\n\r\no KDE - K Desktop Environment (K Masaüstü Ortamı)\r\n\r\no Linux Komut Satırı ve Linux Komutları\r\n\r\no Linux'ta Süreç (Process) Yönetimi\r\n\r\no Önyükleme (Boot) ve Kapatma (Shut Down) İşlemleri\r\n\r\no Linux'ta Dosya (File) ve Dizin (Directory, Folder) Kavramları\r\n\r\no Paketlerin Kurulumu Rpm ile Yazılımın Yüklenmesi\r\n\r\no Linux Kernel\r\n\r\no Linux'ta Kabuk (Shell) Programlama\r\n\r\no Linux'ta Yazıcı (Printer) Kullanımı\r\n\r\no Linux Altında Kullanılabilen Programlama Dilleri\r\n\r\no Yedekleme (Backup) İşlemi\r\n\r\no Ağ Ortamında Linux - Linux ile Internet Hizmetleri\r\n\r\no Gnome ve KDE ile Web ve E-Mail", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8131), false, "LINUX ISLETIM SISTEMI", null, "linux isletim sistemi", null, 2 },
                    { 9, 1, "Muhteşem yazım tarzı ile Shakepeare Edebiyat Ödülü kazanmış bir bilim insanı olan Profesör Richard Dawkins, karmaşık bilimsel gerçekleri insanlara basit bir dille anlatmayı kendisine görev edinerek, yaşamın doğa üstü bir yaratıcı olmadan nasıl ortaya çıktığını ateşli bir şekilde anlatıyor. Çağımızın en çok okunan bilim insanları listesinde muhtemelen ilk sırayı alan Dawkins, Gen Bencildir ile sarstığı dünyayı bu kitapla bir kez daha canlandırıyor. Bilimi yanlış anlayan veya anlamak isteyen çeşitli kesimlere çekinmeden dağıttığı eleştirileriyle, uzun yıllar sonra yazacağı Tanrı Yanılgısı kitabının ilk sinyallerini veriyor.\r\n \r\n“Güzel ve mükemmel yazılmış. … Tamamen anlaşılır fakat derin duygularla dolu konuşmanın ritmine sahip. Her sayfa gerçeği çınlatıyor. Bu, şu ana kadar okuduğum en iyi bilim kitaplarından biri (en iyi kitaplardan biri).”\r\n—Lee Dembart, Los Angeles Times\r\n \r\n“Nefis bir kitap, orijinal ve hayat dolu, evrimin ayrıntılarını coşkun bir berraklıkla açıklıyor, her yerinde yaradılışçı mağara adamlarını cevaplıyor.”\r\n—Isaac Asimov\r\n \r\n“İyi bilim edebiyatının sırrı, kişinin fikirleri önce kendisinin anlamasının gerektiği: iyi yazmak net düşünmekle mümkün olur. … Kör Saatçi’yi okurken Dawkins’in problemlere bakışındaki berraklıkla tekrar tekrar hayrete düştüm. … Dawkins’in doğal dünya hakkında bilgisini arttırmışken ona karşı hayranlık duygusunu kaybetmemiş olduğu fazlasıyla açık. … Keşke ben de böyle yazabiliyor olsaydım.”\r\n—John Maynard Smith, New Scientist", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8131), false, "KOR SAATCI", null, "Kör Saatçi", null, 2 },
                    { 10, 1, "Başlangıcından günümüze insanoğluna\r\nyol gösteren düşünsel gelişmeler...\r\nDört bin yıllık düşün, sanat ve bilim tarihinin klasik yapıtları üstüne eleştirel inceleme olan kitabın 27. basımı...\r\nOrhan Hançerlioğlu, insanlığın var ettiği kimi kavramları, akımlar ve yapıtlar temelinde incelerken bilim, sanat ve evrensel düşünce tarihinin\r\ndönüm noktalarını oluşturan atılımları eleştirel ama nesnel bir gözle değerlendirmektedir.\r\nYoğun bir emek ürünü olan kitap, insanoğlunun dört bin yıllık düşünsel birikiminin yanı sıra dünyayı anlama, kavrama ve yorumlamada biricik rehber olma özelliğini koruyor.\r\nDüşünce Tarihi, çağdaş, yenilikçi ve kuşatıcı yaklaşımıyla günümüzün olduğu kadar gelecek kuşakların da düşünsel yolunu aydınlatıyor.", 3, new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8132), false, "DUSUNCE TARIHI", null, "Düşünce Tarihi", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "PostImage",
                columns: new[] { "Id", "BlobName", "ContainerName", "CreatedDate", "Extention", "Index", "IsRemoved", "PostId", "RemovedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "1_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8034), "jpg", 0, false, 1, null, null },
                    { 2, "1_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8038), "jpg", 1, false, 1, null, null },
                    { 3, "1_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8038), "jpg", 2, false, 1, null, null },
                    { 4, "2_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8039), "jpg", 0, false, 2, null, null },
                    { 5, "2_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8040), "jpg", 1, false, 2, null, null },
                    { 6, "2_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8040), "jpg", 2, false, 2, null, null },
                    { 7, "3_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8041), "jpg", 0, false, 3, null, null },
                    { 8, "3_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8041), "jpg", 1, false, 3, null, null },
                    { 9, "3_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8042), "jpg", 2, false, 3, null, null },
                    { 10, "4_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8043), "jpg", 0, false, 4, null, null },
                    { 11, "4_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8043), "jpg", 1, false, 4, null, null },
                    { 12, "4_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8044), "jpg", 2, false, 4, null, null },
                    { 13, "5_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8045), "jpg", 0, false, 5, null, null },
                    { 14, "5_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8046), "jpg", 1, false, 5, null, null },
                    { 15, "5_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8047), "jpg", 2, false, 5, null, null },
                    { 16, "6_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8047), "jpg", 0, false, 6, null, null },
                    { 17, "6_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8048), "jpg", 1, false, 6, null, null },
                    { 18, "6_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8048), "jpg", 2, false, 6, null, null },
                    { 19, "7_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8049), "jpg", 0, false, 7, null, null },
                    { 20, "7_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8050), "jpg", 1, false, 7, null, null },
                    { 21, "7_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8050), "jpg", 2, false, 7, null, null },
                    { 22, "8_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8051), "jpg", 0, false, 8, null, null },
                    { 23, "8_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8051), "jpg", 1, false, 8, null, null },
                    { 24, "8_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8052), "jpg", 2, false, 8, null, null },
                    { 25, "9_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8052), "jpg", 0, false, 9, null, null },
                    { 26, "9_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8053), "jpg", 1, false, 9, null, null },
                    { 27, "9_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8054), "jpg", 2, false, 9, null, null },
                    { 28, "10_0", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8054), "jpg", 0, false, 10, null, null },
                    { 29, "10_1", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8055), "jpg", 1, false, 10, null, null },
                    { 30, "10_2", "post-image", new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8055), "jpg", 2, false, 10, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(7022));
        }
    }
}
