namespace MVC_Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelEmpDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "FK_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employee", "FK_DepartmentId");
            AddForeignKey("dbo.Employee", "FK_DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "FK_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employee", new[] { "FK_DepartmentId" });
            DropColumn("dbo.Employee", "FK_DepartmentId");
        }
    }
}
