namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateTime = c.DateTime(nullable: false),
                        PublishTime = c.DateTime(nullable: false),
                        Problem_Id = c.Int(),
                        Article_Id = c.Int(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Problems", t => t.Problem_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Problem_Id)
                .Index(t => t.Article_Id)
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
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.vote_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        HelpPoint = c.Int(),
                        HelpBean = c.Int(),
                        CreateTime = c.DateTime(nullable: false),
                        HelpMoney_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HelpMoneys", t => t.HelpMoney_Id)
                .Index(t => t.HelpMoney_Id);
            
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
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.KeywordProblems",
                c => new
                    {
                        Keyword_Id = c.Int(nullable: false),
                        Problem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Keyword_Id, t.Problem_Id })
                .ForeignKey("dbo.Keywords", t => t.Keyword_Id, cascadeDelete: true)
                .ForeignKey("dbo.Problems", t => t.Problem_Id, cascadeDelete: true)
                .Index(t => t.Keyword_Id)
                .Index(t => t.Problem_Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                        Category_Id = c.Int(),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contents", t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Id)
                .Index(t => t.User_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Summary_Id = c.Int(),
                        User_Id = c.Int(),
                        Title = c.String(),
                        Body = c.String(),
                        Reward = c.Int(nullable: false),
                        ProblemStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contents", t => t.Id)
                .ForeignKey("dbo.Summaries", t => t.Summary_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Id)
                .Index(t => t.Summary_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.suggests",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contents", t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.suggests", "User_Id", "dbo.Users");
            DropForeignKey("dbo.suggests", "Id", "dbo.Contents");
            DropForeignKey("dbo.Problems", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Problems", "Summary_Id", "dbo.Summaries");
            DropForeignKey("dbo.Problems", "Id", "dbo.Contents");
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Articles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Articles", "Id", "dbo.Contents");
            DropForeignKey("dbo.Contents", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Contents", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Appraises", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Appraises", "vote_Id", "dbo.Users");
            DropForeignKey("dbo.KeywordProblems", "Problem_Id", "dbo.Problems");
            DropForeignKey("dbo.KeywordProblems", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.KeywordArticles", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.KeywordArticles", "Keyword_Id", "dbo.Keywords");
            DropForeignKey("dbo.Contents", "Problem_Id", "dbo.Problems");
            DropForeignKey("dbo.Users", "HelpMoney_Id", "dbo.HelpMoneys");
            DropForeignKey("dbo.Accounts", "HelpMoney_Id", "dbo.HelpMoneys");
            DropForeignKey("dbo.Categories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Author_Id", "dbo.Users");
            DropIndex("dbo.suggests", new[] { "User_Id" });
            DropIndex("dbo.suggests", new[] { "Id" });
            DropIndex("dbo.Problems", new[] { "User_Id" });
            DropIndex("dbo.Problems", new[] { "Summary_Id" });
            DropIndex("dbo.Problems", new[] { "Id" });
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            DropIndex("dbo.Articles", new[] { "User_Id" });
            DropIndex("dbo.Articles", new[] { "Id" });
            DropIndex("dbo.KeywordProblems", new[] { "Problem_Id" });
            DropIndex("dbo.KeywordProblems", new[] { "Keyword_Id" });
            DropIndex("dbo.KeywordArticles", new[] { "Article_Id" });
            DropIndex("dbo.KeywordArticles", new[] { "Keyword_Id" });
            DropIndex("dbo.Accounts", new[] { "HelpMoney_Id" });
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "Author_Id" });
            DropIndex("dbo.Users", new[] { "HelpMoney_Id" });
            DropIndex("dbo.Appraises", new[] { "Article_Id" });
            DropIndex("dbo.Appraises", new[] { "vote_Id" });
            DropIndex("dbo.Contents", new[] { "Author_Id" });
            DropIndex("dbo.Contents", new[] { "Article_Id" });
            DropIndex("dbo.Contents", new[] { "Problem_Id" });
            DropTable("dbo.suggests");
            DropTable("dbo.Problems");
            DropTable("dbo.Articles");
            DropTable("dbo.KeywordProblems");
            DropTable("dbo.KeywordArticles");
            DropTable("dbo.Messages");
            DropTable("dbo.Summaries");
            DropTable("dbo.Keywords");
            DropTable("dbo.Accounts");
            DropTable("dbo.HelpMoneys");
            DropTable("dbo.Categories");
            DropTable("dbo.Users");
            DropTable("dbo.Appraises");
            DropTable("dbo.Contents");
        }
    }
}
