namespace CorgiFanSubBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BoxModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                        Item4 = c.String(),
                        Item5 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CombinedQAModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SurveyAnswers_ID = c.Int(),
                        SurveyQuestions_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SurveyAnswersModels", t => t.SurveyAnswers_ID)
                .ForeignKey("dbo.SurveyQuestionsModels", t => t.SurveyQuestions_ID)
                .Index(t => t.SurveyAnswers_ID)
                .Index(t => t.SurveyQuestions_ID);
            
            CreateTable(
                "dbo.SurveyAnswersModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Result = c.String(),
                        Item_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ItemModels", t => t.Item_ID)
                .Index(t => t.Item_ID);
            
            CreateTable(
                "dbo.ItemModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        Responses_ID = c.Int(),
                        Subscription_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResponsesModels", t => t.Responses_ID)
                .ForeignKey("dbo.SubscriptionModels", t => t.Subscription_ID)
                .Index(t => t.Responses_ID)
                .Index(t => t.Subscription_ID);
            
            CreateTable(
                "dbo.ResponsesModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Customer_ID = c.Int(),
                        SurveyAnswers_ID = c.Int(),
                        SurveyQuestions_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerModels", t => t.Customer_ID)
                .ForeignKey("dbo.SurveyAnswersModels", t => t.SurveyAnswers_ID)
                .ForeignKey("dbo.SurveyQuestionsModels", t => t.SurveyQuestions_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.SurveyAnswers_ID)
                .Index(t => t.SurveyQuestions_ID);
            
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address_ID = c.Int(),
                        Subscription_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AddressModels", t => t.Address_ID)
                .ForeignKey("dbo.SubscriptionModels", t => t.Subscription_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.Subscription_ID);
            
            CreateTable(
                "dbo.SubscriptionModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Premium = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SurveyQuestionsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Box_ID = c.Int(),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BoxModels", t => t.Box_ID)
                .ForeignKey("dbo.CustomerModels", t => t.Customer_ID)
                .Index(t => t.Box_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderModels", "Customer_ID", "dbo.CustomerModels");
            DropForeignKey("dbo.OrderModels", "Box_ID", "dbo.BoxModels");
            DropForeignKey("dbo.CombinedQAModels", "SurveyQuestions_ID", "dbo.SurveyQuestionsModels");
            DropForeignKey("dbo.CombinedQAModels", "SurveyAnswers_ID", "dbo.SurveyAnswersModels");
            DropForeignKey("dbo.SurveyAnswersModels", "Item_ID", "dbo.ItemModels");
            DropForeignKey("dbo.ItemModels", "Subscription_ID", "dbo.SubscriptionModels");
            DropForeignKey("dbo.ItemModels", "Responses_ID", "dbo.ResponsesModels");
            DropForeignKey("dbo.ResponsesModels", "SurveyQuestions_ID", "dbo.SurveyQuestionsModels");
            DropForeignKey("dbo.ResponsesModels", "SurveyAnswers_ID", "dbo.SurveyAnswersModels");
            DropForeignKey("dbo.ResponsesModels", "Customer_ID", "dbo.CustomerModels");
            DropForeignKey("dbo.CustomerModels", "Subscription_ID", "dbo.SubscriptionModels");
            DropForeignKey("dbo.CustomerModels", "Address_ID", "dbo.AddressModels");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderModels", new[] { "Customer_ID" });
            DropIndex("dbo.OrderModels", new[] { "Box_ID" });
            DropIndex("dbo.CustomerModels", new[] { "Subscription_ID" });
            DropIndex("dbo.CustomerModels", new[] { "Address_ID" });
            DropIndex("dbo.ResponsesModels", new[] { "SurveyQuestions_ID" });
            DropIndex("dbo.ResponsesModels", new[] { "SurveyAnswers_ID" });
            DropIndex("dbo.ResponsesModels", new[] { "Customer_ID" });
            DropIndex("dbo.ItemModels", new[] { "Subscription_ID" });
            DropIndex("dbo.ItemModels", new[] { "Responses_ID" });
            DropIndex("dbo.SurveyAnswersModels", new[] { "Item_ID" });
            DropIndex("dbo.CombinedQAModels", new[] { "SurveyQuestions_ID" });
            DropIndex("dbo.CombinedQAModels", new[] { "SurveyAnswers_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderModels");
            DropTable("dbo.SurveyQuestionsModels");
            DropTable("dbo.SubscriptionModels");
            DropTable("dbo.CustomerModels");
            DropTable("dbo.ResponsesModels");
            DropTable("dbo.ItemModels");
            DropTable("dbo.SurveyAnswersModels");
            DropTable("dbo.CombinedQAModels");
            DropTable("dbo.BoxModels");
            DropTable("dbo.AddressModels");
        }
    }
}
