namespace LsMapasNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mapas",
                c => new
                    {
                        id = c.Int(nullable: false),
                        desc_mapa = c.String(maxLength: 50, unicode: false),
                        obs = c.String(maxLength: 100, unicode: false),
                        centromapa_lat = c.String(maxLength: 15, unicode: false),
                        centromapa_long = c.String(maxLength: 15, unicode: false),
                        id_surdo = c.Int(nullable: false),
                        zoommapa = c.Decimal(nullable: false, precision: 7, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MapaSurdo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idMapa = c.Int(nullable: false),
                        idSurdo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Mapas", t => t.idMapa)
                .ForeignKey("dbo.Surdo", t => t.idMapa)
                .Index(t => t.idMapa);
            
            CreateTable(
                "dbo.Surdo",
                c => new
                    {
                        id = c.Int(nullable: false),
                        nome = c.String(maxLength: 100, unicode: false),
                        endereco = c.String(maxLength: 100, unicode: false),
                        perimetro = c.String(maxLength: 100, unicode: false),
                        classe = c.String(maxLength: 1, unicode: false),
                        latitude = c.String(maxLength: 15, unicode: false),
                        longitude = c.String(maxLength: 15, unicode: false),
                        bairro = c.String(maxLength: 30, unicode: false),
                        status = c.String(maxLength: 1, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapaSurdo", "idMapa", "dbo.Surdo");
            DropForeignKey("dbo.MapaSurdo", "idMapa", "dbo.Mapas");
            DropIndex("dbo.MapaSurdo", new[] { "idMapa" });
            DropTable("dbo.Surdo");
            DropTable("dbo.MapaSurdo");
            DropTable("dbo.Mapas");
        }
    }
}
