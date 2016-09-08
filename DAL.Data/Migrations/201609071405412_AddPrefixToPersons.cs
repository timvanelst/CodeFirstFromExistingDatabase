namespace DAL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrefixToPersons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Prefix", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Prefix");
        }
    }
}
