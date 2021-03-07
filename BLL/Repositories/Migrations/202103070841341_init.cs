namespace BLL.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        InviteCode = c.String(),
                        HelpPoint = c.Int(),
                        HelpBean = c.Int(),
                        CreateTime = c.DateTime(nullable: false),
                        HelpMoney_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HelpMoneys", t => t.HelpMoney_Id)
                .Index(t => t.HelpMoney_Id);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateTime = c.DateTime(nullable: false),
                        PublishTime = c.DateTime(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                        Title1 = c.String(),
                        Body1 = c.String(),
                        Reward = c.Int(),
                        ProblemStatus = c.Int(),
                        Title2 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Category_Id = c.Int(),
                        Article_Id = c.Int(),
                        Problem_Id = c.Int(),
                        Summary_Id = c.Int(),
                        User_Id = c.Int(),
                        User_Id1 = c.Int(),
                        User_Id2 = c.Int(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Contents", t => t.Article_Id)
                .ForeignKey("dbo.Contents", t => t.Problem_Id)
                .ForeignKey("dbo.Summaries", t => t.Summary_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .ForeignKey("dbo.Users", t => t.User_Id2)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Article_Id)
                .Index(t => t.Problem_Id)
                .Index(t => t.Summary_Id)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1)
                .Index(t => t.User_Id2)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Appraises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Direction = c.Int(nullable: false),
                        vote_Id = c.Int(),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.vote_Id)
                .ForeignKey("dbo.Contents", t => t.Article_Id)
                .Index(t => t.vote_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author_Id = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Summaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HelpMoneys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surplus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateTime = c.DateTime(nullable: false),
                        Usable = c.Int(nullable: false),
                        Freeze = c.Int(nullable: false),
                        Variation = c.String(),
                        Remark = c.String(),
                        HelpMoney_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HelpMoneys", t => t.HelpMoney_Id)
                .Index(t => t.HelpMoney_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Content = c.String(),
                        HasRead = c.Boolean(nullable: false),
                        MessageStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KeywordArticles",
                c => new
                    {
                        Keyword_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Keyword_Id, t.Article_Id })
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contents", t => t.Article_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.ProblemKeywords",
                c => new
                    {
                        Problem_Id = c.Int(nullable: false),
                        Keyword_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Problem_Id, t.Keyword_Id })
                .ForeignKey("dbo.Contents", t => t.Problem_Id, cascadeDelete: true)
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .Index(t => t.Problem_Id)
                .Index(t => t.Keyword_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Contents", "User_Id2", "dbo.Users");
            DropForeignKey("dbo.Contents", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Users", "HelpMoney_Id", "dbo.HelpMoneys");
            DropForeignKey("dbo.Accounts", "HelpMoney_Id", "dbo.HelpMoneys");
            DropForeignKey("dbo.Contents", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Contents", "Summary_Id", "dbo.Summaries");
            DropForeignKey("dbo.ProblemKeywords", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.ProblemKeywords", "Problem_Id", "dbo.Contents");
            DropForeignKey("dbo.Contents", "Problem_Id", "dbo.Contents");
            DropForeignKey("dbo.KeywordArticles", "Article_Id", "dbo.Contents");
            DropForeignKey("dbo.KeywordArticles", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.Contents", "Article_Id", "dbo.Contents");
            DropForeignKey("dbo.Categories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Contents", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Appraises", "Article_Id", "dbo.Contents");
            DropForeignKey("dbo.Appraises", "vote_Id", "dbo.Users");
            DropIndex("dbo.ProblemKeywords", new[] { "Keyword_Id" });
            DropIndex("dbo.ProblemKeywords", new[] { "Problem_Id" });
            DropIndex("dbo.KeywordArticles", new[] { "Article_Id" });
            DropIndex("dbo.KeywordArticles", new[] { "Keyword_Id" });
            DropIndex("dbo.Accounts", new[] { "HelpMoney_Id" });
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "Author_Id" });
            DropIndex("dbo.Appraises", new[] { "Article_Id" });
            DropIndex("dbo.Appraises", new[] { "vote_Id" });
            DropIndex("dbo.Contents", new[] { "Author_Id" });
            DropIndex("dbo.Contents", new[] { "User_Id2" });
            DropIndex("dbo.Contents", new[] { "User_Id1" });
            DropIndex("dbo.Contents", new[] { "User_Id" });
            DropIndex("dbo.Contents", new[] { "Summary_Id" });
            DropIndex("dbo.Contents", new[] { "Problem_Id" });
            DropIndex("dbo.Contents", new[] { "Article_Id" });
            DropIndex("dbo.Contents", new[] { "Category_Id" });
            DropIndex("dbo.Users", new[] { "HelpMoney_Id" });
            DropTable("dbo.ProblemKeywords");
            DropTable("dbo.KeywordArticles");
            DropTable("dbo.Messages");
            DropTable("dbo.Accounts");
            DropTable("dbo.HelpMoneys");
            DropTable("dbo.Summaries");
            DropTable("dbo.Keywords");
            DropTable("dbo.Categories");
            DropTable("dbo.Appraises");
            DropTable("dbo.Contents");
            DropTable("dbo.Users");
        }
    }
}
