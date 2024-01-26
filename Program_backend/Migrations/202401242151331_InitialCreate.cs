namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Klienci",
                c => new
                    {
                        KlientId = c.Int(nullable: false, identity: true),
                        NrDowoduOsobistego = c.String(),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        NumerTelefonu = c.String(),
                        WypozyczalniaId = c.Int(nullable: false),
                        Wypozyczalnia_WypozyczalniaId = c.Int(),
                        Wypozyczalnia_WypozyczalniaId1 = c.Int(),
                        Wypozyczalnia_WypozyczalniaId2 = c.Int(),
                    })
                .PrimaryKey(t => t.KlientId)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId1)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId2)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId1)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId2);
            
            CreateTable(
                "dbo.Wypozyczalnia",
                c => new
                    {
                        WypozyczalniaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Kasa = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.WypozyczalniaId);
            
            CreateTable(
                "dbo.Pracownicy",
                c => new
                    {
                        PracownikId = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Pesel = c.String(),
                        Dostepny = c.Boolean(nullable: false),
                        NrTelefonu = c.String(),
                        Rola = c.Int(nullable: false),
                        Wypozyczalnia_WypozyczalniaId = c.Int(),
                        Wypozyczalnia_WypozyczalniaId1 = c.Int(),
                    })
                .PrimaryKey(t => t.PracownikId)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId1)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId1);
            
            CreateTable(
                "dbo.Samochody",
                c => new
                    {
                        SamochodId = c.Int(nullable: false, identity: true),
                        Marka = c.String(),
                        Model = c.String(),
                        NumerRejestracyjny = c.String(),
                        CzyDostepny = c.Boolean(nullable: false),
                        RokProdukcji = c.Int(nullable: false),
                        Kaucja = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stan = c.Int(nullable: false),
                        WypozyczalniaId = c.Int(nullable: false),
                        Dach = c.Int(),
                        KonieMechaniczne = c.Int(),
                        PodwojnyTlumik = c.Boolean(),
                        Ilosc = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Samochod_SamochodId = c.Int(),
                        Samochod_SamochodId1 = c.Int(),
                        Samochod_SamochodId2 = c.Int(),
                        Samochod_SamochodId3 = c.Int(),
                        Wypozyczalnia_WypozyczalniaId = c.Int(),
                        Wypozyczalnia_WypozyczalniaId1 = c.Int(),
                        Wypozyczalnia_WypozyczalniaId2 = c.Int(),
                    })
                .PrimaryKey(t => t.SamochodId)
                .ForeignKey("dbo.Samochody", t => t.Samochod_SamochodId)
                .ForeignKey("dbo.Samochody", t => t.Samochod_SamochodId1)
                .ForeignKey("dbo.Samochody", t => t.Samochod_SamochodId2)
                .ForeignKey("dbo.Samochody", t => t.Samochod_SamochodId3)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId1)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId2)
                .Index(t => t.Samochod_SamochodId)
                .Index(t => t.Samochod_SamochodId1)
                .Index(t => t.Samochod_SamochodId2)
                .Index(t => t.Samochod_SamochodId3)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId1)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId2);
            
            CreateTable(
                "dbo.Wypozyczenia",
                c => new
                    {
                        WypozyczenieId = c.Int(nullable: false, identity: true),
                        CenaZaDzienWypozyczenia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AktualnyNumer = c.Int(nullable: false),
                        DataWypozyczenia = c.DateTime(nullable: false),
                        DataZwrotu = c.DateTime(nullable: false),
                        WypozyczalniaId = c.Int(nullable: false),
                        Kaucja = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Klient_KlientId = c.Int(),
                        Pracownik_PracownikId = c.Int(),
                        Samochod_SamochodId = c.Int(),
                        Wypozyczalnia_WypozyczalniaId = c.Int(),
                        Wypozyczalnia_WypozyczalniaId1 = c.Int(),
                        Wypozyczalnia_WypozyczalniaId2 = c.Int(),
                    })
                .PrimaryKey(t => t.WypozyczenieId)
                .ForeignKey("dbo.Klienci", t => t.Klient_KlientId)
                .ForeignKey("dbo.Pracownicy", t => t.Pracownik_PracownikId)
                .ForeignKey("dbo.Samochody", t => t.Samochod_SamochodId)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId1)
                .ForeignKey("dbo.Wypozyczalnia", t => t.Wypozyczalnia_WypozyczalniaId2)
                .Index(t => t.Klient_KlientId)
                .Index(t => t.Pracownik_PracownikId)
                .Index(t => t.Samochod_SamochodId)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId1)
                .Index(t => t.Wypozyczalnia_WypozyczalniaId2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Klienci", "Wypozyczalnia_WypozyczalniaId2", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Wypozyczenia", "Wypozyczalnia_WypozyczalniaId2", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Wypozyczenia", "Wypozyczalnia_WypozyczalniaId1", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Wypozyczenia", "Wypozyczalnia_WypozyczalniaId", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Wypozyczenia", "Samochod_SamochodId", "dbo.Samochody");
            DropForeignKey("dbo.Wypozyczenia", "Pracownik_PracownikId", "dbo.Pracownicy");
            DropForeignKey("dbo.Wypozyczenia", "Klient_KlientId", "dbo.Klienci");
            DropForeignKey("dbo.Samochody", "Wypozyczalnia_WypozyczalniaId2", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Samochody", "Wypozyczalnia_WypozyczalniaId1", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Samochody", "Wypozyczalnia_WypozyczalniaId", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Samochody", "Samochod_SamochodId3", "dbo.Samochody");
            DropForeignKey("dbo.Samochody", "Samochod_SamochodId2", "dbo.Samochody");
            DropForeignKey("dbo.Samochody", "Samochod_SamochodId1", "dbo.Samochody");
            DropForeignKey("dbo.Samochody", "Samochod_SamochodId", "dbo.Samochody");
            DropForeignKey("dbo.Pracownicy", "Wypozyczalnia_WypozyczalniaId1", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Pracownicy", "Wypozyczalnia_WypozyczalniaId", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Klienci", "Wypozyczalnia_WypozyczalniaId1", "dbo.Wypozyczalnia");
            DropForeignKey("dbo.Klienci", "Wypozyczalnia_WypozyczalniaId", "dbo.Wypozyczalnia");
            DropIndex("dbo.Wypozyczenia", new[] { "Wypozyczalnia_WypozyczalniaId2" });
            DropIndex("dbo.Wypozyczenia", new[] { "Wypozyczalnia_WypozyczalniaId1" });
            DropIndex("dbo.Wypozyczenia", new[] { "Wypozyczalnia_WypozyczalniaId" });
            DropIndex("dbo.Wypozyczenia", new[] { "Samochod_SamochodId" });
            DropIndex("dbo.Wypozyczenia", new[] { "Pracownik_PracownikId" });
            DropIndex("dbo.Wypozyczenia", new[] { "Klient_KlientId" });
            DropIndex("dbo.Samochody", new[] { "Wypozyczalnia_WypozyczalniaId2" });
            DropIndex("dbo.Samochody", new[] { "Wypozyczalnia_WypozyczalniaId1" });
            DropIndex("dbo.Samochody", new[] { "Wypozyczalnia_WypozyczalniaId" });
            DropIndex("dbo.Samochody", new[] { "Samochod_SamochodId3" });
            DropIndex("dbo.Samochody", new[] { "Samochod_SamochodId2" });
            DropIndex("dbo.Samochody", new[] { "Samochod_SamochodId1" });
            DropIndex("dbo.Samochody", new[] { "Samochod_SamochodId" });
            DropIndex("dbo.Pracownicy", new[] { "Wypozyczalnia_WypozyczalniaId1" });
            DropIndex("dbo.Pracownicy", new[] { "Wypozyczalnia_WypozyczalniaId" });
            DropIndex("dbo.Klienci", new[] { "Wypozyczalnia_WypozyczalniaId2" });
            DropIndex("dbo.Klienci", new[] { "Wypozyczalnia_WypozyczalniaId1" });
            DropIndex("dbo.Klienci", new[] { "Wypozyczalnia_WypozyczalniaId" });
            DropTable("dbo.Wypozyczenia");
            DropTable("dbo.Samochody");
            DropTable("dbo.Pracownicy");
            DropTable("dbo.Wypozyczalnia");
            DropTable("dbo.Klienci");
        }
    }
}
