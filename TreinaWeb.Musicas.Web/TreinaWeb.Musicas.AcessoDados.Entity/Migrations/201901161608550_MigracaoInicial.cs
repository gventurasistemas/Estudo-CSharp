namespace TreinaWeb.Musicas.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ALB_ALBUNS", name: "ALB_OBSERVACOES", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ALB_ALBUNS", name: "Ano", newName: "ALB_ANO");
            RenameColumn(table: "dbo.ALB_ALBUNS", name: "Observacoes", newName: "ALB_OBSERVACOES");
            RenameColumn(table: "dbo.ALB_ALBUNS", name: "__mig_tmp__0", newName: "ALB_NOME");
            AddColumn("dbo.ALB_ALBUNS", "ALB_EMAIL", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ALB_ALBUNS", "ALB_NOME", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ALB_ALBUNS", "ALB_OBSERVACOES", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ALB_ALBUNS", "ALB_OBSERVACOES", c => c.String());
            AlterColumn("dbo.ALB_ALBUNS", "ALB_NOME", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.ALB_ALBUNS", "ALB_EMAIL");
            RenameColumn(table: "dbo.ALB_ALBUNS", name: "ALB_NOME", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ALB_ALBUNS", name: "ALB_OBSERVACOES", newName: "Observacoes");
            RenameColumn(table: "dbo.ALB_ALBUNS", name: "ALB_ANO", newName: "Ano");
            RenameColumn(table: "dbo.ALB_ALBUNS", name: "__mig_tmp__0", newName: "ALB_OBSERVACOES");
        }
    }
}
