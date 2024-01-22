using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class PostSeed : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder
				.HasData(
					new[]
					{
						new {
							Id = 1,
							UserId = 1,
							CategoryId = 1,
							Title = "Platon Bir Gün Kolunda Bir Ornitorenkle Bara Girer : Felsefeyi Mizah Yoluyla Anlamak",
							NormalizedTitle = "PLATON BIR GUN KOLUNDA BIR ORNITORENKLE BARA GIRER : FELSEFEYI MIZAH YOLUYLA ANLAMAK",
							Content = "Dikkat! İçerde Felsefespri var!\r\n\r\n“Yılın en matrak çoksatarı” –The Boston Globe\r\n\r\n“Çok güldüm, çok şey öğrendim, çok sevdim” –Roy Blount Jr.\r\n\r\nFelsefe mi? Felsefeyi anlamak için büyük bir dehanın zekâsına ve peygamber sabrına sahip olmak gerekir. Bu doğru değil! Bu komik, ele avuca sığmaz, çok yönlü ve zengin içerikli kitap bu efsaneyi yerle bir ediyor.\r\n\r\n“Platon Bir Gün Kolunda Bir Ornitorenkle Bara Girer…” ile birlikte kendinizi olağanüstü eğlenceli bir felsefe dersinin içinde bulacaksınız. Felsefi kavramların esprilerle nasıl aydınlatılabileceğini, mizahın da aslında büyüleyici bir felsefi içerik barındırdığını göreceksiniz. Ama bir dakika… Bu iki kavrayış yolu, yani felsefe ile espri aynı şey mi yoksa? Fıkra ve esprilerin kuruluşu ve etkisiyle felsefi kavramların kuruluşu ve etkisi aynı malzemelere dayanmaz mı? İkisi de aynı şekilde aklımızı gıdıklamaz mı? Şey, biraz düşünüp sonra söylesek?\r\n\r\nHarvard’lı iki felsefe profesöründen “güldürürken düşündüren” bir Stand-Up…",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
						new {
							Id = 2,
							UserId = 1,
							CategoryId = 1,
							Title = "OLASILIK ve İSTATİSTİĞE GİRİŞ -Mühendisler ve Fenciler için- / Introduction to Probability and Statistics for Engineers and Scientist",
							NormalizedTitle = "OLASILIK VE ISTATISTIGE GIRIS -MUHEMDISLER VE FENCILER ICIN- / INTRODUCTION TO PROBABILITY AND STATICTICS FOR ENGINEERS AND SCIENTIST",
							Content = "Bu klâsik ders kitabı, mühendislik, fen bilimleri veya bilgisayar bilimlerine uygulandığı kadarıyla olasılık ve istatistik dersleri alan üçüncü/dördiincü sınıf lisans öğrencileri için güncel konularla ilgili uygulamalara bağlayarak harekete getiren titiz bir temel olasılık teorisi ve istatistiksel kanıtlamaya giriş sunar. Kitap temel yüksek matematik bilgisini öngörür.\r\nÖnceki baskıları kullananlar olağanüstü anlatım ve yazım biçimine övgüye devam ediyor. Ross, olasılığın istatistik problemlerinin içyüzünü kavrama konusundaki rolünün altını çizerken, bu baskının yeni nesil mühendis ve fen bilimcilere cazip geleceğini de garanti ediyor. Kapalı CD-ROM alıştırmalar için gerekli hesaplamaları otomatikleştiren ve olasılık teorisini günlük istatistiksel problemlere ve durumlara uygulamada öğrencilere yardımcı olan kullanımı kolay yazılım içeriyor.",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
						new {
							Id = 3,
							UserId = 1,
							CategoryId = 1,
							Title = "Türkiye Cumhuriyeti Tarihi",
							NormalizedTitle = "TURKIYE CUMHURIYETI TARIHI",
							Content = "Yayıncı\tEkin Kitabevi Yayınları\r\nListe Fiyatı\t150.00 \r\nFormat\tKitap\r\nBarkod\t9786055335854\r\nYayın Tarihi\t2018-11-07\r\nBaskı Sayısı\t2012.Baskı\r\nSayfa Sayısı\t394\r\nBoyut\t160 X 235\r\nBasım Yeri\tBursa",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
						new {
							Id = 4,
							UserId = 1,
							CategoryId = 1,
							Title = "Ekonomiye Giris",
							NormalizedTitle = "EKONOMIYE GIRIS",
							Content = "Ekonomiye Giriş Temel Kavramlar : Arz-Talep : Esneklik : Piyasa Dengesi ve Kaymalar : Piyasalar 1: Üretim ve Maliyetler : Piyasalar 2 : Kamu Ekonomisi : Makroekonomik Kavramlar ve Makro Denge : Harcamalar ve Denge Milli Gelir : Kamu Kesimi Genel Dengesi : Para ve Para : Teorisine Giriş : Merkez Bankacılığına Giriş : Merkez Bankası ve İşleyiş Mekanizması : Finansal Sistem İşleyişi : Uluslararası Ticaret, Ödemeler Dengesi ve Döviz Kuru",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
						new {
							Id = 5,
							UserId = 1,
							CategoryId = 1,
							Title = "X86 Tabanlı Mikroişlemci ve Assembly Dili",
							NormalizedTitle = "X86 TABANLI MIKROISLEMCI VE ASEMBLY DILI",
							Content = "X86 Tabanlı Mikroişlemci ve Assembly Dili - Nurettin Topaloğlu - Seçkin Yayıncılık - İngilizce ve Türkçe Kitap, Nurettin Topaloğlu tarafından kaleme alınmıştır. Eser - editörlüğünde hazırlanmıştır. Kitap 2001 yılında Seçkin Yayıncılık tarafından [Ankara] yayınlanmıştır. Bu baskının çevirisi - tarafından yapılmıştır. 512 sayfadır. Sayfa bilgisi - olarak belirtilmiştir. X86 Tabanlı Mikroişlemci ve Assembly Dili - Nurettin Topaloğlu - Seçkin Yayıncılık - İngilizce ve Türkçe Kitap adlı eser İngilizce dilindedir. Eserin içeriğinde Türkçe dilinde bölümlere de yer verilmektedir.\r\n\r\nKitap, 19 cm genişliğinde 24 cm yüksekliğindedir.\r\n\r\nKitap KARTON KAPAKLI cilt bilgisi ile 26 gün önce eklenmiştir.\r\n\r\nX86 Tabanlı Mikroişlemci ve Assembly Dili - Nurettin Topaloğlu - Seçkin Yayıncılık - İngilizce ve Türkçe Kitap adlı eser, Kitap > Bilim, Teknik, Araştırma kategorisinde İkinci El olarak satıştadır.",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
						new {
							Id = 6,
							UserId = 2,
							CategoryId = 1,
							Title = "Genel Dilbilime Giriş",
							NormalizedTitle = "GENEL DILBILIMINE GIRIS",
							Content = "Dil pek çok bilim alanının incelediği bir olgudur. Ancak dil ile ilgili incelemelerin kalbi dilbilimdir. Bu kitap dilbilimin dünü ve bugününü ana hatlarıyla okuyucuya sunma amacıyla hazırlanmıştır. Dilbilim kuramları, dilbilimin ses bilgisi, biçim bilgisi, sözdizimi gibi alanlardaki uygulamaları, göstergebilim, edimbilim gibi dil ile ilgili pek çok alanın yaklaşım biçimleri isimler, kuramlar ve uygulamalar üzerinden değerlendirilmiştir. Kitabın yeniliklerinden birisi daha önceki yayınlarda toplu olarak ele alınmayan dilbilgisi kuramlarına ayrı bir başlık ayırmasıdır. Dilbilim İngilizce, Fransızca ve Almanca gibi Batı dillerinin akademik programında yer alan bir ders olarak da okutulmaktadır. Son yıllarda üniversitelerimizin Türkçeyle ilgili bölümlerinde de Genel Dilbilim dersi yer almaktadır. Bu nedenle kitapta açıklama ve uygulamalar Türkolojiyle ilişkilendirilerek verilmeye çalışılmıştır. Ayrıca sesbilgisi, biçimbilgisi ve sözdizimi bölümlerinde Türkolojideki bakış açıları da ayrı bir başlık açılarak tartışılmıştır.",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
						new {
							Id = 7,
							UserId = 2,
							CategoryId = 1,
							Title = "Yeni Başlayanlar İçin HTML5 - CSS3",
							NormalizedTitle = "YENI BASLAYANLAR ICIN HTML5 - CSS3",
							Content = "Fahrettin Erdinç, web tasarımına ve HTML'e yeni başlayanları hedef alarak yazdığı bu kitapta, fazla teoriye kaçmadan, konuya odaklanarak, kolay anlaşılacak örneklerle web tasarım mantığını anlatıyor, HTML 5 ve CSS 3'ün yeni olanaklarını örneklerle okura sunuyor.\r\n\r\nKitapta Web sayfalarının oluşturulması süreci anlatılırken, Steve Champeon’ın “Aşamalı Geliştirme” yaklaşımını kullanıldı. Bu yaklaşımda amaç, önce basit bir sayfa oluşturup zamanla eklemeler yaparak daha karmaşık sayfalar oluşturmaktır. Bu yöntemde, önce HTML kodları yazılıyor ve okurla birlikte doğru çalışıp çalışmadığı test ediliyor. Daha sonra CCS kodları eklenip sayfa daha görsel hale getiriliyor. Son olarak da Javascript ve ilgili kütüphaneleri kullanarak daha etkileşimli sayfalar oluşturuluyor.\r\n\r\nFahrettin Erdinç, web teknolojisinin en yeni araçlarını kullanarak, web sayfası tasarımının temel mantığını herkesin anlayabileceği bir şekilde adım adım anlatıyor. Bu da kitabı, hiç HTML ve CSS bilmeyip öğrenmek isteyen veya var olan HTML/CSS bilgisini geliştirmek isteyenler için ideal başvuru kaynağı haline getiriyor",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
						new {
							Id = 8,
							UserId = 2,
							CategoryId = 1,
							Title = "linux isletim sistemi",
							NormalizedTitle = "LINUX ISLETIM SISTEMI",
							Content = "1) Bilgisayar ile ilişkili bir eğitim görüyorsanız, çok kullanıcılı işletim sistemleri içinde kararlılık ve güvenilirlik bakımından en popüleri olan UNIX işletim sistemini öğrenmek zorundasınız demektir. Ancak UNIX, PC'ler üzerine yüklenemez. Evde kullanabileceğiniz bir PC üzerine ancak Linux'u yükleyebilirsiniz ve Linux, komut ve özellikleri bakımından, grafik arayüzleri bakımından UNIX'in tam bir kopyasıdır. O halde evdeki UNIX laboratuvarınız, bir Linux makinasıdır.\r\n\r\n2) İşyerinizde UNIX kullanan bir profesyonelseniz evinizdeki PC'de de Linux kullanmak istemeniz son derecede anlaşılır bir istektir.\r\n\r\n3) Bir bilişim teknolojisi (Information technology-IT) uzmanı iseniz ve şu ana kadar Linux ile pek ilgilenmedi iseniz, bilmelisiniz ki uygun bir Linux dağıtımını seçerek (Red Hat, Mandrake vb), ticari bir ağ uygulamasını Linux ile mükemmel bir şekilde yürütebilirsiniz. Linux, güvenilirlik ve kararlılık açısından mükemmel bir işletim sistemidir.\r\n\r\nKitapta Yer Alan Konular\r\n\r\no Linux Nedir? Linux'un Tarihçesi Linux Dağıtımları\r\n\r\no Ubuntu Linux Sürümü Hakkında Kısa Bilgi\r\n\r\no Linux'a Giriş En Sık Kullanılan Komutlar\r\n\r\no KDE - K Desktop Environment (K Masaüstü Ortamı)\r\n\r\no Linux Komut Satırı ve Linux Komutları\r\n\r\no Linux'ta Süreç (Process) Yönetimi\r\n\r\no Önyükleme (Boot) ve Kapatma (Shut Down) İşlemleri\r\n\r\no Linux'ta Dosya (File) ve Dizin (Directory, Folder) Kavramları\r\n\r\no Paketlerin Kurulumu Rpm ile Yazılımın Yüklenmesi\r\n\r\no Linux Kernel\r\n\r\no Linux'ta Kabuk (Shell) Programlama\r\n\r\no Linux'ta Yazıcı (Printer) Kullanımı\r\n\r\no Linux Altında Kullanılabilen Programlama Dilleri\r\n\r\no Yedekleme (Backup) İşlemi\r\n\r\no Ağ Ortamında Linux - Linux ile Internet Hizmetleri\r\n\r\no Gnome ve KDE ile Web ve E-Mail",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
						new {
							Id = 9,
							UserId = 2,
							CategoryId = 1,
							Title = "Kör Saatçi",
							NormalizedTitle = "KOR SAATCI",
							Content = "Muhteşem yazım tarzı ile Shakepeare Edebiyat Ödülü kazanmış bir bilim insanı olan Profesör Richard Dawkins, karmaşık bilimsel gerçekleri insanlara basit bir dille anlatmayı kendisine görev edinerek, yaşamın doğa üstü bir yaratıcı olmadan nasıl ortaya çıktığını ateşli bir şekilde anlatıyor. Çağımızın en çok okunan bilim insanları listesinde muhtemelen ilk sırayı alan Dawkins, Gen Bencildir ile sarstığı dünyayı bu kitapla bir kez daha canlandırıyor. Bilimi yanlış anlayan veya anlamak isteyen çeşitli kesimlere çekinmeden dağıttığı eleştirileriyle, uzun yıllar sonra yazacağı Tanrı Yanılgısı kitabının ilk sinyallerini veriyor.\r\n \r\n“Güzel ve mükemmel yazılmış. … Tamamen anlaşılır fakat derin duygularla dolu konuşmanın ritmine sahip. Her sayfa gerçeği çınlatıyor. Bu, şu ana kadar okuduğum en iyi bilim kitaplarından biri (en iyi kitaplardan biri).”\r\n—Lee Dembart, Los Angeles Times\r\n \r\n“Nefis bir kitap, orijinal ve hayat dolu, evrimin ayrıntılarını coşkun bir berraklıkla açıklıyor, her yerinde yaradılışçı mağara adamlarını cevaplıyor.”\r\n—Isaac Asimov\r\n \r\n“İyi bilim edebiyatının sırrı, kişinin fikirleri önce kendisinin anlamasının gerektiği: iyi yazmak net düşünmekle mümkün olur. … Kör Saatçi’yi okurken Dawkins’in problemlere bakışındaki berraklıkla tekrar tekrar hayrete düştüm. … Dawkins’in doğal dünya hakkında bilgisini arttırmışken ona karşı hayranlık duygusunu kaybetmemiş olduğu fazlasıyla açık. … Keşke ben de böyle yazabiliyor olsaydım.”\r\n—John Maynard Smith, New Scientist",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
						new {
							Id = 10,
							UserId = 2,
							CategoryId = 1,
							Title = "Düşünce Tarihi",
							NormalizedTitle = "DUSUNCE TARIHI",
							Content = "Başlangıcından günümüze insanoğluna\r\nyol gösteren düşünsel gelişmeler...\r\nDört bin yıllık düşün, sanat ve bilim tarihinin klasik yapıtları üstüne eleştirel inceleme olan kitabın 27. basımı...\r\nOrhan Hançerlioğlu, insanlığın var ettiği kimi kavramları, akımlar ve yapıtlar temelinde incelerken bilim, sanat ve evrensel düşünce tarihinin\r\ndönüm noktalarını oluşturan atılımları eleştirel ama nesnel bir gözle değerlendirmektedir.\r\nYoğun bir emek ürünü olan kitap, insanoğlunun dört bin yıllık düşünsel birikiminin yanı sıra dünyayı anlama, kavrama ve yorumlamada biricik rehber olma özelliğini koruyor.\r\nDüşünce Tarihi, çağdaş, yenilikçi ve kuşatıcı yaklaşımıyla günümüzün olduğu kadar gelecek kuşakların da düşünsel yolunu aydınlatıyor.",
							CountOfImages = 3,
							CreatedDate = DateTime.Now,
							IsRemoved = false,
						},
					}
				);
		}
	}
}
