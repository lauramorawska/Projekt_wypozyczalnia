using System.Reflection;

namespace Projekt
{
    class Program
    {
        static void Main()
        {
            //testPracownik();
            //TestCarbioleta();
            //TestSportowe();
            //TestKlient();        
            //testPracownik();
            TestWypozyczenia();
            
        }
        static void TestWypozyczenia()
        {
            DateTime data = new DateTime(2023, 12, 20);
            DateTime data2 = new DateTime(2023, 12, 15);
            Wypozyczalnia wypozyczalnia1 = new Wypozyczalnia("Najlepsza wypozyczalnia w miescie");





            #region Pracownicy

            Pracownik pracownik1 = new Pracownik("Adam", "Nowak", "81023567498", true, "469825743", EnumRola.kierownik);
            Pracownik pracownik2 = new Pracownik("Ewa", "Kowalska", "25783694018", false, "324819765", EnumRola.obsluga_klienta);
            Pracownik pracownik3 = new Pracownik("Piotr", "Lis", "70846193520", true, "186935702", EnumRola.obsluga_techniczna);
            Pracownik pracownik4 = new Pracownik("Magdalena", "Kowalczyk", "50317849265", false, "905836170", EnumRola.obsluga_finansowa);
            Pracownik pracownik5 = new Pracownik("Tomasz", "Jankowski", "61520984783", true, "789415620", EnumRola.kierownik);
            Pracownik pracownik6 = new Pracownik("Anna", "Wojciechowska", "37058269143", false, "490583670", EnumRola.obsluga_klienta);
            Pracownik pracownik7 = new Pracownik("Krzysztof", "Mazur", "83519602478", true, "268470921", EnumRola.obsluga_techniczna);
            Pracownik pracownik8 = new Pracownik("Alicja", "Witkowska", "54189023756", false, "193846208", EnumRola.obsluga_finansowa);
            Pracownik pracownik9 = new Pracownik("Bartłomiej", "Kaczmarek", "65720318495", true, "019873654", EnumRola.kierownik);
            Pracownik pracownik10 = new Pracownik("Karolina", "Piotrowska", "97856024183", false, "139650872", EnumRola.obsluga_klienta);
            Pracownik pracownik11 = new Pracownik("Rafał", "Grabowski", "30657482901", true, "819342705", EnumRola.obsluga_techniczna);
            Pracownik pracownik12 = new Pracownik("Natalia", "Malinowska", "57201638490", false, "465720314", EnumRola.obsluga_finansowa);
            Pracownik pracownik13 = new Pracownik("Szymon", "Olszewski", "23487156089", true, "701536204", EnumRola.kierownik);
            Pracownik pracownik14 = new Pracownik("Michał", "Zawadzki", "81934265705", false, "571638490", EnumRola.obsluga_klienta);
            Pracownik pracownik15 = new Pracownik("Julia", "Jablonska", "99923456701", true, "111567892", EnumRola.obsluga_techniczna);
            Pracownik pracownik16 = new Pracownik("Mateusz", "Zawadzki", "11145678903", false, "222678904", EnumRola.obsluga_finansowa);
            Pracownik pracownik17 = new Pracownik("Marta", "Sikora", "22256789005", true, "333670106", EnumRola.kierownik);
            Pracownik pracownik18 = new Pracownik("Wojciech", "Wojcik", "33367890107", false, "444901208", EnumRola.obsluga_klienta);
            Pracownik pracownik19 = new Pracownik("Patrycja", "Wrobel", "44478901209", true, "589012310", EnumRola.obsluga_techniczna);
            Pracownik pracownik20 = new Pracownik("Kamil", "Dabrowski", "55589012311", false, "690123412", EnumRola.obsluga_finansowa);
            Pracownik pracownik21 = new Pracownik("Oliwia", "Witkowska", "66690123413", true, "701234514", EnumRola.kierownik);
            Pracownik pracownik22 = new Pracownik("Dominik", "Kaczmarek", "77701234515", false, "812345616", EnumRola.obsluga_klienta);
            Pracownik pracownik23 = new Pracownik("Kinga", "Piotrowska", "88812345617", true, "999236718", EnumRola.obsluga_techniczna);
            Pracownik pracownik24 = new Pracownik("Jan", "Grabowski", "99923456719", false, "111345678", EnumRola.obsluga_finansowa);
            Pracownik pracownik25 = new Pracownik("Zuzanna", "Malinowska", "11134567821", true, "222456722", EnumRola.kierownik);
            Pracownik pracownik26 = new Pracownik("Bartosz", "Olszewski", "22245678923", false, "333567890", EnumRola.obsluga_klienta);
            Pracownik pracownik27 = new Pracownik("Aleksandra", "Jablonska", "33356789025", true, "444678901", EnumRola.obsluga_techniczna);



            wypozyczalnia1.DodajPracownika(pracownik1);
            wypozyczalnia1.DodajPracownika(pracownik2);
            wypozyczalnia1.DodajPracownika(pracownik3);
            wypozyczalnia1.DodajPracownika(pracownik4);
            wypozyczalnia1.DodajPracownika(pracownik5);
            wypozyczalnia1.DodajPracownika(pracownik6);
            wypozyczalnia1.DodajPracownika(pracownik7);
            wypozyczalnia1.DodajPracownika(pracownik8);
            wypozyczalnia1.DodajPracownika(pracownik9);
            wypozyczalnia1.DodajPracownika(pracownik10);
            wypozyczalnia1.DodajPracownika(pracownik11);
            wypozyczalnia1.DodajPracownika(pracownik12);
            wypozyczalnia1.DodajPracownika(pracownik13);
            wypozyczalnia1.DodajPracownika(pracownik14);
            wypozyczalnia1.DodajPracownika(pracownik15);
            wypozyczalnia1.DodajPracownika(pracownik16);
            wypozyczalnia1.DodajPracownika(pracownik17);
            wypozyczalnia1.DodajPracownika(pracownik18);
            wypozyczalnia1.DodajPracownika(pracownik19);
            wypozyczalnia1.DodajPracownika(pracownik20);
            wypozyczalnia1.DodajPracownika(pracownik21);
            wypozyczalnia1.DodajPracownika(pracownik22);
            wypozyczalnia1.DodajPracownika(pracownik23);
            wypozyczalnia1.DodajPracownika(pracownik24);
            wypozyczalnia1.DodajPracownika(pracownik25);
            wypozyczalnia1.DodajPracownika(pracownik26);
            wypozyczalnia1.DodajPracownika(pracownik27);

            #endregion


            //Console.WriteLine(wypozyczalnia1.WypiszPracownikow());

            // Console.WriteLine(wypozyczalnia2.WypiszPracownikow());
            //Console.WriteLine(wypozyczalnia3.WypiszPracownikow());
            #region Auta

            SamochodSportowy auto1 = new SamochodSportowy("Ferrari", "488 GTB", "KTA P011", 2019, 300M, 670, true, 8000, EnumStan.dzialajacy);
            SamochodSportowy auto2 = new SamochodSportowy("Lamborghini", "Huracan", "KTA P012", 2020, 320M, 630, true, 8500, EnumStan.dzialajacy);
            SamochodSportowy auto3 = new SamochodSportowy("Porsche", "Cayman", "KTA P013", 2017, 280M, 450, false, 6000, EnumStan.dzialajacy);
            SamochodSportowy auto4 = new SamochodSportowy("McLaren", "570S", "KTA P014", 2018, 310M, 540, true, 7800, EnumStan.dzialajacy);
            SamochodSportowy auto5 = new SamochodSportowy("Aston Martin", "Vantage", "KTA P015", 2019, 320M, 600, true, 8200, EnumStan.dzialajacy);
            SamochodSportowy auto6 = new SamochodSportowy("Bugatti", "Chiron", "KTA P016", 2021, 420M, 1500, true, 15000, EnumStan.dzialajacy);
            SamochodSportowy auto7 = new SamochodSportowy("Nissan", "GT-R", "KTA P017", 2016, 290M, 565, false, 6500, EnumStan.dzialajacy);
            SamochodSportowy auto8 = new SamochodSportowy("Chevrolet", "Corvette", "KTA P018", 2015, 350M, 650, true, 7500, EnumStan.dzialajacy);
            SamochodSportowy auto9 = new SamochodSportowy("Ford", "Mustang", "KTA P019", 2018, 280M, 450, false, 6000, EnumStan.dzialajacy);
            SamochodSportowy auto10 = new SamochodSportowy("Toyota", "Supra", "KTA P020", 2020, 320M, 500, true, 7000, EnumStan.dzialajacy);

            wypozyczalnia1.DodajAuto(auto1);
            wypozyczalnia1.DodajAuto(auto2);
            wypozyczalnia1.DodajAuto(auto3);
            wypozyczalnia1.DodajAuto(auto4);
            wypozyczalnia1.DodajAuto(auto5);
            wypozyczalnia1.DodajAuto(auto6);
            wypozyczalnia1.DodajAuto(auto7);
            wypozyczalnia1.DodajAuto(auto8);
            wypozyczalnia1.DodajAuto(auto9);
            wypozyczalnia1.DodajAuto(auto10);


            
            SamochodCabriolet auto11 = new SamochodCabriolet("Mercedes", "Benz C300", "KTA P001", 2015, 200M, EnumDach.miekki, 5000, EnumStan.dzialajacy);
            SamochodCabriolet auto12 = new SamochodCabriolet("Audi", "A5", "KTA P002", 2016, 180M, EnumDach.sztywny, 4500, EnumStan.dzialajacy);
            SamochodCabriolet auto13 = new SamochodCabriolet("BMW", "Z4", "KTA P003", 2014, 220M, EnumDach.miekki, 5500, EnumStan.dzialajacy);
            SamochodCabriolet auto14 = new SamochodCabriolet("Lexus", "LC500", "KTA P004", 2018, 250M, EnumDach.sztywny, 6000, EnumStan.dzialajacy);
            SamochodCabriolet auto15 = new SamochodCabriolet("Porsche", "911", "KTA P005", 2017, 240M, EnumDach.miekki, 5800, EnumStan.dzialajacy);
            SamochodCabriolet auto16 = new SamochodCabriolet("Ferrari", "Portofino", "KTA P006", 2020, 300M, EnumDach.sztywny, 8000, EnumStan.dzialajacy);
            SamochodCabriolet auto17 = new SamochodCabriolet("Jaguar", "F-Type", "KTA P007", 2019, 270M, EnumDach.miekki, 7000, EnumStan.dzialajacy);
            SamochodCabriolet auto18 = new SamochodCabriolet("Maserati", "GranCabrio", "KTA P008", 2016, 190M, EnumDach.sztywny, 5000, EnumStan.dzialajacy);
            SamochodCabriolet auto19 = new SamochodCabriolet("Tesla", "Roadster", "KTA P009", 2022, 350M, EnumDach.sztywny, 9000, EnumStan.dzialajacy);
            SamochodCabriolet auto20 = new SamochodCabriolet("Chevrolet", "Camaro", "KTA P010", 2013, 200M, EnumDach.miekki, 4800, EnumStan.dzialajacy);

            wypozyczalnia1.DodajAuto(auto11);
            wypozyczalnia1.DodajAuto(auto12);
            wypozyczalnia1.DodajAuto(auto13);
            wypozyczalnia1.DodajAuto(auto14);
            wypozyczalnia1.DodajAuto(auto15);
            wypozyczalnia1.DodajAuto(auto16);
            wypozyczalnia1.DodajAuto(auto17);
            wypozyczalnia1.DodajAuto(auto18);
            wypozyczalnia1.DodajAuto(auto19);
            wypozyczalnia1.DodajAuto(auto20);

           
            SamochodKlasyczny auto21 = new SamochodKlasyczny("Volkswagen", "Beetle", "KTA P021", 1965, 50, 3000, EnumStan.dzialajacy);
            SamochodKlasyczny auto22 = new SamochodKlasyczny("Ford", "Model T", "KTA P022", 1923, 20, 2000, EnumStan.dzialajacy);
            SamochodKlasyczny auto23 = new SamochodKlasyczny("Chevrolet", "Bel Air", "KTA P023", 1957, 60, 4000, EnumStan.dzialajacy);
            SamochodKlasyczny auto24 = new SamochodKlasyczny("Cadillac", "Eldorado", "KTA P024", 1976, 70, 5000, EnumStan.dzialajacy);
            SamochodKlasyczny auto25 = new SamochodKlasyczny("Mercedes-Benz", "300SL", "KTA P025", 1954, 90, 7000, EnumStan.dzialajacy);
            SamochodKlasyczny auto26 = new SamochodKlasyczny("Jaguar", "E-Type", "KTA P026", 1961, 80, 6000, EnumStan.dzialajacy);
            SamochodKlasyczny auto27 = new SamochodKlasyczny("Mercedes-Benz", "300SL", "KTA P026", 1961, 90, 7000, EnumStan.dzialajacy);
            SamochodKlasyczny auto28 = new SamochodKlasyczny("Chevrolet", "Impala", "KTA P027", 1967, 60, 4500, EnumStan.dzialajacy);
            SamochodKlasyczny auto29 = new SamochodKlasyczny("Porsche", "356", "KTA P028", 1956, 80, 6000, EnumStan.dzialajacy);
            SamochodKlasyczny auto30 = new SamochodKlasyczny("Ford", "Thunderbird", "KTA P029", 1955, 70, 5500, EnumStan.dzialajacy);
            wypozyczalnia1.DodajAuto(auto21);
            wypozyczalnia1.DodajAuto(auto22);
            wypozyczalnia1.DodajAuto(auto23);
            wypozyczalnia1.DodajAuto(auto24);
            wypozyczalnia1.DodajAuto(auto25);
            wypozyczalnia1.DodajAuto(auto26);
            wypozyczalnia1.DodajAuto(auto27);
            wypozyczalnia1.DodajAuto(auto28);
            wypozyczalnia1.DodajAuto(auto29);
            wypozyczalnia1.DodajAuto(auto30);

            SamochodWieloosobowy auto31 = new SamochodWieloosobowy("Ford", "Explorer", "KTA P001", 2022, 150.0M, EnumMiejsca.Siedmioosobowe, 2000.0M, EnumStan.dzialajacy);
            SamochodWieloosobowy auto32 = new SamochodWieloosobowy("Toyota", "Highlander", "KTA P002", 2021, 140.0M, EnumMiejsca.Siedmioosobowe, 1800.0M, EnumStan.naprawiany);
            SamochodWieloosobowy auto33 = new SamochodWieloosobowy("Honda", "Pilot", "KTA P003", 2020, 130.0M, EnumMiejsca.Dziewiecioosobowe, 1600.0M, EnumStan.zepsuty);
            SamochodWieloosobowy auto34 = new SamochodWieloosobowy("Chevrolet", "Traverse", "KTA P004", 2022, 155.0M, EnumMiejsca.Siedmioosobowe, 2100.0M, EnumStan.dzialajacy);
            SamochodWieloosobowy auto35 = new SamochodWieloosobowy("Nissan", "Pathfinder", "KTA P005", 2021, 145.0M, EnumMiejsca.Siedmioosobowe, 1900.0M, EnumStan.dzialajacy);
            SamochodWieloosobowy auto36 = new SamochodWieloosobowy("Mazda", "CX-9", "KTA P006", 2020, 135.0M, EnumMiejsca.Dziewiecioosobowe, 1700.0M, EnumStan.dzialajacy);
            SamochodWieloosobowy auto37 = new SamochodWieloosobowy("Kia", "Telluride", "KTA P007", 2022, 160.0M, EnumMiejsca.Dziewiecioosobowe, 2200.0M, EnumStan.naprawiany);
            SamochodWieloosobowy auto38 = new SamochodWieloosobowy("Hyundai", "Palisade", "KTA P008", 2021, 150.0M, EnumMiejsca.Siedmioosobowe, 2000.0M, EnumStan.dzialajacy);
            SamochodWieloosobowy auto39 = new SamochodWieloosobowy("Subaru", "Ascent", "KTA P009", 2020, 140.0M, EnumMiejsca.Siedmioosobowe, 1800.0M, EnumStan.naprawiany);
            SamochodWieloosobowy auto40 = new SamochodWieloosobowy("Volkswagen", "Atlas", "KTA P010", 2022, 155.0M, EnumMiejsca.Dziewiecioosobowe, 2100.0M, EnumStan.zepsuty);

            wypozyczalnia1.DodajAuto(auto31);
            wypozyczalnia1.DodajAuto(auto32);
            wypozyczalnia1.DodajAuto(auto33);
            wypozyczalnia1.DodajAuto(auto34);
            wypozyczalnia1.DodajAuto(auto35);
            wypozyczalnia1.DodajAuto(auto36);
            wypozyczalnia1.DodajAuto(auto37);
            wypozyczalnia1.DodajAuto(auto38);
            wypozyczalnia1.DodajAuto(auto39);
            wypozyczalnia1.DodajAuto(auto40);

            #endregion
            #region Klienci

            Klient klient1 = new Klient("Aleksandra", "Nowak", "75102912345", "ABC123456");
            Klient klient2 = new Klient("Bartosz", "Kowalski", "80031567890", "CDA123456");
            Klient klient3 = new Klient("Catherine", "Lis", "92063098765", "EFG123456");
            Klient klient4 = new Klient("Dominik", "Wójcik", "65112254321", "HIJ123456");
            Klient klient5 = new Klient("Eliza", "Szymańska", "88041587654", "KLM123456");
            Klient klient6 = new Klient("Felix", "Jankowski", "70071023456", "NOP123456");
            Klient klient7 = new Klient("Gabriela", "Dąbrowska", "82082087654", "QRS123456");
            Klient klient8 = new Klient("Henryk", "Kaczmarek", "94092734567", "TUV123456");
            Klient klient9 = new Klient("Izabela", "Zając", "75060412345", "WXY123456");
            Klient klient10 = new Klient("Jerzy", "Kowalczyk", "89121367890", "ZAB123456");

    
            Klient klient11 = new Klient("Katarzyna", "Piotrowska", "73121898765", "CDE123456");
            Klient klient12 = new Klient("Łukasz", "Mazur", "90050254321", "FGH123456");
            Klient klient13 = new Klient("Magdalena", "Witkowska", "66110387654", "IJK123456");
            Klient klient14 = new Klient("Norbert", "Zawadzki", "81121923456", "LMN123456");
            Klient klient15 = new Klient("Oliwia", "Sikorska", "98032367890", "OPQ123456");
            Klient klient16 = new Klient("Paweł", "Olszewski", "71112454321", "RST123456");
            Klient klient17 = new Klient("Renata", "Jabłońska", "89042987654", "UVW123456");
            Klient klient18 = new Klient("Sebastian", "Kubiak", "67060512345", "XYZ123456");
            Klient klient19 = new Klient("Teresa", "Wójcik", "82021498765", "ABC987654");
            Klient klient20 = new Klient("Wojciech", "Nowakowski", "95051523456", "CDE987654");

            //Klient klient21 = new Klient("Zofia", "Jasińska", "76122067890", "FGH987654");
            //Klient klient22 = new Klient("Adam", "Duda", "94060454321", "IJK987654");
            //Klient klient23 = new Klient("Agnieszka", "Mazurek", "77102587654", "LMN987654");
            //Klient klient24 = new Klient("Bartłomiej", "Krawczyk", "90030512345", "OPQ987654");
            //Klient klient25 = new Klient("Celina", "Adamczyk", "65121023456", "RST987654");
            //Klient klient26 = new Klient("Dawid", "Jabłoński", "82031567890", "UVW987654");
            //Klient klient27 = new Klient("Ewa", "Wojciech", "94062198765", "XYZ987654");
            //Klient klient28 = new Klient("Filip", "Bąk", "71040212345", "ABC567890");
            //Klient klient29 = new Klient("Gabriel", "Rutkowski", "89102287654", "CDE567890");
            //Klient klient30 = new Klient("Hanna", "Szewczyk", "72110723456", "FGH567890");
            //Klient klient31 = new Klient("Igor", "Kowalczyk", "80031067890", "HIJ567890");
            //Klient klient32 = new Klient("Joanna", "Lis", "92062554321", "KLM567890");
            //Klient klient33 = new Klient("Krzysztof", "Wójcik", "65111898765", "NOP567890");
            //Klient klient34 = new Klient("Lidia", "Szymańska", "88041023456", "QRS567890");
            //Klient klient35 = new Klient("Mateusz", "Jankowski", "70070587654", "TUV567890");
            //Klient klient36 = new Klient("Natalia", "Dąbrowska", "82081512345", "WXY567890");
            //Klient klient37 = new Klient("Oskar", "Kaczmarek", "94092298765", "ZAB567890");
            //Klient klient38 = new Klient("Patrycja", "Zając", "75060123456", "ABC345678");
            //Klient klient39 = new Klient("Quentin", "Kowalczyk", "89121067890", "CDE345678");
            //Klient klient40 = new Klient("Renata", "Piotrowska", "73121554321", "FGH345678");

            //Klient klient41 = new Klient("Sebastian", "Mazur", "90050098765", "IJK345678");
            //Klient klient42 = new Klient("Teresa", "Witkowska", "66110123456", "LMN345678");
            //Klient klient43 = new Klient("Urszula", "Zawadzka", "81121787654", "OPQ345678");
            //Klient klient44 = new Klient("Viktor", "Sikorski", "98032112345", "RST345678");
            //Klient klient45 = new Klient("Weronika", "Olszewska", "71112298765", "UVW345678");
            //Klient klient46 = new Klient("Xavier", "Jabłoński", "89042723456", "XYZ345678");
            //Klient klient47 = new Klient("Yulia", "Kubiak", "67060367890", "ABC876543");
            //Klient klient48 = new Klient("Zygmunt", "Nowak", "82021254321", "CDE876543");
            //Klient klient49 = new Klient("Adrianna", "Nowakowska", "95051387654", "FGH876543");
            //Klient klient50 = new Klient("Bartosz", "Kowal", "80031112345", "IJK876543");

            //Klient klient51 = new Klient("Celina", "Adamczyk", "65121298765", "LMN876543");
            //Klient klient52 = new Klient("Daniel", "Jabłoński", "82031823456", "OPQ876543");
            //Klient klient54 = new Klient("Ewelina", "Jabłońska", "95060267890", "RST876543");
            //Klient klient55 = new Klient("Fryderyk", "Dąbrowski", "71071654321", "UVW876543");
            //Klient klient56 = new Klient("Gabriela", "Szulc", "86082387654", "XYZ876543");
            //Klient klient57 = new Klient("Henryk", "Kaczmarczyk", "98090712345", "ABC987654");
            //Klient klient58 = new Klient("Izabela", "Żukowska", "78102098765", "CDE987654");
            //Klient klient59 = new Klient("Janusz", "Nowacki", "90011623456", "FGH987654");
            //Klient klient60 = new Klient("Kamila", "Włodarczyk", "67022887654", "IJK987654");
            //Klient klient61 = new Klient("Łukasz", "Zieliński", "80033012345", "LMN987654");
            //Klient klient62 = new Klient("Monika", "Sadowska", "93121567890", "OPQ987654");
            //Klient klient63 = new Klient("Norbert", "Wójcik", "76041654321", "RST987654");

            
            //Klient klient64 = new Klient("Olga", "Kowal", "89053087654", "UVW987654");
            //Klient klient65 = new Klient("Piotr", "Gajewska", "71101812345", "XYZ987654");
            //Klient klient66 = new Klient("Queenie", "Malinowska", "84062398765", "ABC012345");
            //Klient klient67 = new Klient("Robert", "Michalski", "97100723456", "CDE012345");
            //Klient klient68 = new Klient("Sylwia", "Jabłońska", "79111987654", "FGH012345");
            //Klient klient69 = new Klient("Tomasz", "Nowak", "93033012345", "IJK012345");
            //Klient klient70 = new Klient("Urszula", "Zawadzka", "66060267890", "LMN012345");
            //Klient klient71 = new Klient("Viktor", "Szymański", "89071754321", "OPQ012345");
            //Klient klient72 = new Klient("Wiktoria", "Olszewska", "71102287654", "RST012345");
            //Klient klient73 = new Klient("Xawery", "Jabłoński", "82042812345", "UVW012345");

            
            //Klient klient74 = new Klient("Yulia", "Kubiak", "95060267890", "XYZ012345");
            //Klient klient75 = new Klient("Zygmunt", "Nowak", "71071654321", "ABC123456");
            //Klient klient76 = new Klient("Adrianna", "Nowakowska", "86082387654", "CDE123456");
            //Klient klient77 = new Klient("Bartosz", "Kowal", "98090712345", "FGH123456");
            //Klient klient78 = new Klient("Celina", "Adamczyk", "78102098765", "IJK123456");
            //Klient klient79 = new Klient("Daniel", "Jabłoński", "90011623456", "LMN123456");
            //Klient klient80 = new Klient("Ewelina", "Jabłońska", "67022887654", "OPQ123456");
            //Klient klient81 = new Klient("Fryderyk", "Dąbrowski", "80033012345", "RST123456");
            //Klient klient82 = new Klient("Gabriela", "Szulc", "93121567890", "UVW123456");
            //Klient klient83 = new Klient("Henryk", "Kaczmarczyk", "76041654321", "XYZ123456");

            wypozyczalnia1.DodajKlienta(klient1);
            wypozyczalnia1.DodajKlienta(klient2);
            wypozyczalnia1.DodajKlienta(klient3);
            wypozyczalnia1.DodajKlienta(klient4);
            wypozyczalnia1.DodajKlienta(klient5);
            wypozyczalnia1.DodajKlienta(klient6);
            wypozyczalnia1.DodajKlienta(klient7);
            wypozyczalnia1.DodajKlienta(klient8);
            wypozyczalnia1.DodajKlienta(klient9);
            wypozyczalnia1.DodajKlienta(klient10);
            wypozyczalnia1.DodajKlienta(klient11);
            wypozyczalnia1.DodajKlienta(klient12);
            wypozyczalnia1.DodajKlienta(klient13);
            wypozyczalnia1.DodajKlienta(klient14);
            wypozyczalnia1.DodajKlienta(klient15);
            wypozyczalnia1.DodajKlienta(klient16);
            wypozyczalnia1.DodajKlienta(klient17);
            wypozyczalnia1.DodajKlienta(klient18);
            wypozyczalnia1.DodajKlienta(klient19);
            wypozyczalnia1.DodajKlienta(klient20);


            #endregion
            //Console.WriteLine(wypozyczalnia1.WypiszSamochody());

            #region Wypozyczenia

            Wypozyczenie wypozyczenie1 = new Wypozyczenie(pracownik1, DateTime.Now, DateTime.Now.AddDays(5), auto1, klient1, 50.0M);
            Wypozyczenie wypozyczenie2 = new Wypozyczenie(pracownik2, DateTime.Now.AddDays(2), DateTime.Now.AddDays(8), auto2, klient2, 60.0M);
            Wypozyczenie wypozyczenie3 = new Wypozyczenie(pracownik3, DateTime.Now.AddDays(5), DateTime.Now.AddDays(10), auto3, klient3, 70.0M);
            Wypozyczenie wypozyczenie4 = new Wypozyczenie(pracownik4, DateTime.Now.AddDays(8), DateTime.Now.AddDays(15), auto4, klient4, 80.0M);
            Wypozyczenie wypozyczenie5 = new Wypozyczenie(pracownik5, DateTime.Now.AddDays(12), DateTime.Now.AddDays(18), auto5, klient5, 90.0M);
            Wypozyczenie wypozyczenie6 = new Wypozyczenie(pracownik6, DateTime.Now.AddDays(15), DateTime.Now.AddDays(20), auto6, klient6, 100.0M);
            Wypozyczenie wypozyczenie7 = new Wypozyczenie(pracownik7, DateTime.Now.AddDays(18), DateTime.Now.AddDays(25), auto7, klient7, 110.0M);
            Wypozyczenie wypozyczenie8 = new Wypozyczenie(pracownik8, DateTime.Now.AddDays(22), DateTime.Now.AddDays(28), auto8, klient8, 120.0M);
            Wypozyczenie wypozyczenie9 = new Wypozyczenie(pracownik9, DateTime.Now.AddDays(25), DateTime.Now.AddDays(30), auto9, klient9, 130.0M);
            Wypozyczenie wypozyczenie10 = new Wypozyczenie(pracownik10, DateTime.Now.AddDays(28), DateTime.Now.AddDays(35), auto10, klient10, 140.0M);
            Wypozyczenie wypozyczenie11 = new Wypozyczenie(pracownik11, DateTime.Now.AddDays(32), DateTime.Now.AddDays(38), auto11, klient11, 150.0M);
            Wypozyczenie wypozyczenie12 = new Wypozyczenie(pracownik12, DateTime.Now.AddDays(35), DateTime.Now.AddDays(40), auto12, klient12, 160.0M);
            Wypozyczenie wypozyczenie13 = new Wypozyczenie(pracownik13, DateTime.Now.AddDays(38), DateTime.Now.AddDays(45), auto13, klient13, 170.0M);
            Wypozyczenie wypozyczenie14 = new Wypozyczenie(pracownik14, DateTime.Now.AddDays(42), DateTime.Now.AddDays(48), auto14, klient14, 180.0M);
            Wypozyczenie wypozyczenie15 = new Wypozyczenie(pracownik15, DateTime.Now.AddDays(45), DateTime.Now.AddDays(50), auto15, klient15, 190.0M);
            Wypozyczenie wypozyczenie16 = new Wypozyczenie(pracownik16, DateTime.Now.AddDays(48), DateTime.Now.AddDays(55), auto16, klient16, 200.0M);
            Wypozyczenie wypozyczenie17 = new Wypozyczenie(pracownik17, DateTime.Now.AddDays(52), DateTime.Now.AddDays(58), auto17, klient17, 210.0M);
            Wypozyczenie wypozyczenie18 = new Wypozyczenie(pracownik18, DateTime.Now.AddDays(55), DateTime.Now.AddDays(60), auto18, klient18, 220.0M);
            Wypozyczenie wypozyczenie19 = new Wypozyczenie(pracownik19, DateTime.Now.AddDays(58), DateTime.Now.AddDays(65), auto19, klient19, 230.0M);
            Wypozyczenie wypozyczenie20 = new Wypozyczenie(pracownik20, DateTime.Now.AddDays(62), DateTime.Now.AddDays(68), auto20, klient20, 240.0M);

            wypozyczalnia1.NoweWypozyczenie(wypozyczenie1);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie2);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie3);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie4);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie5);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie6);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie7);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie8);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie9);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie10);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie11);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie12);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie13);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie14);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie15);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie16);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie17);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie18);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie19);
            wypozyczalnia1.NoweWypozyczenie(wypozyczenie20);





            #endregion

            Console.WriteLine(wypozyczalnia1.Wypozyczenia);


            //Console.WriteLine(wyp2.ToString());
            //Wypozyczenie wyp = new(pracownik9, DateTime.Now,DateTime.Now.AddDays(9), auto30, klient9, 30);
            //wypozyczalnia1.NoweWypozyczenie(wyp);
            //Console.WriteLine(wyp.ToString());
            Console.WriteLine("Przedluzone wypozyczenie o 20 dni");
            wypozyczenie1.PrzedluzWypozyczenie(20);
            Console.WriteLine(wypozyczenie1.ToString());
            
            Console.WriteLine("\n Sklonowane wypozyczenie");
            Wypozyczenie sklonowaneWypozyczenie = (Wypozyczenie)wypozyczenie2.Clone();
            sklonowaneWypozyczenie.PrzedluzWypozyczenie(1);
            Console.WriteLine(sklonowaneWypozyczenie.ToString());


            //Wypozyczalnia wypo = new();
            //    wypo.DodajSamochod(zabcia);
            //    wypo.DodajSamochod(S);
            // Console.WriteLine(wypo.ToString());
            //Wypozyczenie wypozyczenie, decimal kwota, DateTime dataPlatnosci, bool potwierdzona
            //Wypozyczenie wypozyczenie, decimal kwota, DateTime dataPlatnosci, bool potwierdzona
            //Platnosc platnosc = new(wyp, wyp.Kwota(), DateTime.Now, true);
            // Platnosc platnosc1 = new(wyp2, wyp2.Kwota(), null ,false);
            // nowa.DodajPlatnosc(platnosc);
            //nowa.DodajPlatnosc(platnosc1);
            // platnosc1.DokonajPlatnosci(wyp, wyp.Kwota());
            // platnosc.DokonajPlatnosci(wyp2, wyp.Kwota());
            //  Console.WriteLine(platnosc.ToString());
            //  Console.WriteLine(wypo.ToString());
            // Console.WriteLine(nowa.WypiszPlatnosci());
            //Console.WriteLine(WyszukajNieZaplacone());
            // ListaAut lista = new ListaAut();

            
            //Console.WriteLine(wypozyczalnia1.ToString());

            //Console.WriteLine(wypozyczalnia1.WypiszSamochody());
            //Console.WriteLine(wypozyczalnia1.WypiszStanKasy());
            //Console.WriteLine(wypozyczalnia1.ZnajdzAktualnieWypozyczoneAuta());
            Console.WriteLine("Przed posortowaniem");
            Console.WriteLine(wypozyczalnia1.ZnajdzAktualnieWypozyczenia());
            //wypozyczalnia1.SortujNazwiskoImie();
            //Console.WriteLine("Po posortowaniu wedlug nazwisk klientow");
            //Console.WriteLine(wypozyczalnia1.ToString());


            try // zostawiam w razie probelmow jakby nie działalo
            {
                wypozyczalnia1.ZapiszJSON("Wypozyczalnia.json");
                Wypozyczalnia odczytanaWypozyczalnia = Wypozyczalnia.OdczytJSON("Wypozyczalnia.json");

                if (odczytanaWypozyczalnia != null)
                {
                    Console.WriteLine(odczytanaWypozyczalnia.ToString());

                }
                else
                {
                    Console.WriteLine("Błąd");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            wypozyczalnia1.Zapisz("Wypozyczalnia.xml");
            Console.WriteLine("Wypozyczalnia odczytana z xml");
            Console.WriteLine(Wypozyczalnia.Odczytaj("Wypozyczalnia.xml"));


            /*    static void TestKlient()
                {
                    Klient Laura = new("Laura", "Morawska", "638174682", "ABC123456");
                    Klient Zuza = new("Zuzanna", "Bosak", "82394762", "CDA123456");
                    Console.WriteLine(Laura.ToString());
                }
                static void TestSportowe()
                {
                   // SamochodSportowy Sam = new("Volkswagen", "Bora", "KTA P783", 1999, 1000000M, 170, true, 5000);
                  //  Console.WriteLine(Sam.ToString());


                    //public SamochodSportowy(string marka, string model, string numerRejestracyjny,
                    //bool czyDostepny, int rokProdukcji, decimal cenaZaDzienWypozyczenia,
                    //int konieMechaniczne, bool podwojnyTlumik)
                }
                static void TestCarbioleta()
                {
                 //   SamochodCabriolet S = new("Mercedes", "Benz c 300", "KTA P783", 2015, 200M, EnumDach.miekki, 5000);
                //    Console.WriteLine(S.ToString());

                    //   public SamochodCabriolet(string marka, string model, string numerRejestracyjny, bool czyDostepny, int rokProdukcji, decimal cenaZaDzienWypozyczenia, EnumDach dach)
                    //  : base(marka, model, numerRejestracyjny, czyDostepny, rokProdukcji, cenaZaDzienWypozyczenia)
                }

                static void testPracownik()
                {
                    //string imie, string nazwisko, string pesel, bool dostepny, string nrTelefonu
                    Pracownik Damian = new("Damian", "Grochowiec", "12345678900", true, "786226758");
                    Pracownik Filip = new("Filip", "Głogowski", "123769367593", false, "019472547");
                    Console.WriteLine(Damian);
                    Console.WriteLine(Filip);
                }*/
            wypozyczalnia1.ZapiszDoBazy();
            wypozyczalnia1.OdczytBazyDanych();
        }
    }
}