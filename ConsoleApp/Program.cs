
//İş analizi => neyi nasıl yapacağımızı yazarak belirledim
//araç kiralama
//araç listemiz olsun -- tamam
//araç seç -- tamam
//tarih seç -- tamam
//ödeme yap -- tamam
//Aynı araç aynı tarih için kiralama yapılmasın -- tamam

//admin girişi olsun -- tamam
//admin menüsü olsun -- tamam
//admin kiralanan araç bilgilerini görebilsin -- tamam

List<string> vehicles = new()
{
    "Mercedes",
    "BMW",
    "Audi",
    "Fiat",
    "Renault",
    "Toyota",
    "Hyundai",
    "Ford",
    "Nissan",
    "Chevrolet"
};

List<Rent> rents = new();

while (true)
{
    Console.Clear();

    #region Araç listesini göster
    foreach (var vehicle in vehicles)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(vehicle);
    }
    #endregion

    #region Araç seçimi sorusu ve cevabı
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Lütfen kiralamak istediğiniz aracınızı seçin");

    Console.ForegroundColor = ConsoleColor.White;
    string? selectedVehicle = Console.ReadLine();

    if (string.IsNullOrEmpty(selectedVehicle))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Lütfen bir araç seçiniz");
        Console.ReadLine();
        continue;
    }

    #region Admin Login
    if (selectedVehicle == "admin login")
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Admin şifresini giriniz");
        string? password = Console.ReadLine();
        if (password == "1234")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Admin girişi başarılı");

            List<string> adminMenu = new()
            {
                "Kiralanan araçları listele",
                "Çıkış yap"
            };

            foreach (var item in adminMenu)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(item);
            }

            string? selectedAdminMenu = Console.ReadLine();
            if (selectedAdminMenu == "Kiralanan araçları listele" || selectedAdminMenu == "1")
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (rents.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Kiralanan araç bulunmamaktadır");
                    Console.ReadLine();
                    continue;
                }

                foreach (var val in rents)
                {
                    Console.WriteLine($"Araç: {val.Vehicle} - Tarih: {val.Date}");
                }
                Console.ReadLine();
                continue;
            }
            else if (selectedAdminMenu == "Çıkış yap")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Admin çıkışı yapıldı");
            }

            Console.ReadLine();
            continue;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Admin şifresi yanlış");
            Console.ReadLine();
            continue;
        }
    }
    #endregion

    if (!vehicles.Contains(selectedVehicle))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Seçtiğiniz araç listemizde bulunmamaktadır");
        Console.ReadLine();
        continue;
    }
    #endregion

    #region Kiralama tarihi seçimi ve cevabı
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Kiralama tarihi seçin");

    Console.ForegroundColor = ConsoleColor.White;
    string? selectedDateString = Console.ReadLine();

    if (string.IsNullOrEmpty(selectedDateString))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Lütfen bir tarih seçiniz");
        Console.ReadLine();
        continue;
    }

    if (!DateOnly.TryParse(selectedDateString, out DateOnly selectedDate))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Geçerli bir tarih giriniz");
        Console.ReadLine();
        continue;
    }


    if (rents.Any(x => x.Vehicle == selectedVehicle && x.Date == selectedDate))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Seçtiğiniz araç ve tarih için daha önce kiralama yapılmıştır");
        Console.ReadLine();
        continue;
    }
    #endregion

    #region Ödeme sorusu ve cevabı
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Ödeme yapmak için 'E' ya da 'e' tuşuna basınız");
    string? payment = Console.ReadLine();
    if (string.IsNullOrEmpty(payment) || payment.ToLower() != "e")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ödeme yapmadınız. İşlem iptal edildi");
        Console.ReadLine();
        continue;
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Araç kiralama işlemi yapılıyor");
    for (int i = 0; i < 45; i++)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("-");
        Task.Delay(50).Wait();
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine();
    #endregion

    #region Kiralama listesine kiralanan aracın eklenmesi
    Rent rent = new()
    {
        Vehicle = selectedVehicle,
        Date = selectedDate
    };
    rents.Add(rent);
    #endregion

    #region İşlem sonu
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Araç kiralama işlemi başarılı");
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("Çıkmak için bir tuşa basın...");
    Console.ReadLine();
    #endregion
}

internal class Rent
{
    public string Vehicle { get; set; } = default!;
    public DateOnly Date { get; set; }
}


// Önce iş analizi yapıyoruz
// Sonra taskları tamamlıyoruz
// Varsa görsel iyileştirme yapıyoruz
// Son olarak refactor ile kodlarımızda iyileştiremeler yapıyoruz





































//public class Fundamentals
//{
//    //değişken
//    private string name = "Taner Saydam";


//    //property
//    private string Name { get; set; } = "Taner Saydam";

//    //metot
//    private static void PrintName()
//    {
//        Console.WriteLine("Hello, world!");
//    }

//    private static int Calculate(int a, int b)
//    {
//        return a + b;
//    }

//    private static void Main(string[] args)
//    {
//        Console.WriteLine("Hello, World!");
//        PrintName();
//        int total = Calculate(5, 6);
//        Console.WriteLine(total);
//    }


//    //syntax yapısı => söz dizimi => kodun doğru yazılış şeklinin tarifidir.
//    //syntax hatası => class MyClass   mYClass class || clas myClass |
//}