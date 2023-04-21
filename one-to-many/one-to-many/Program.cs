// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using one_to_many;

//Console.WriteLine("Hello, World!");

await using MyDbContext ctx = new MyDbContext();
var a1 = new Article();
a1.Content = "life's little bit messy.we all make mistake\",Title =\"忘记时间";
a1.Title = "忘记时间";
Comment c1 = new Comment() { Message = "我会好好珍惜没有你的明天" };
Comment c2 = new Comment() { Message = "i will cherish tomorrow without you" };

var a2 = new Article
{
    Content = "大概你的体重 会抱我造梦",
    Title = "绵绵",
    Comments = new List<Comment>
    {
        new Comment { Message = "从来未爱你" },
        new Comment { Message = "从来未爱你" },
    }
};

ctx.Articles.Add(a2);
await ctx.SaveChangesAsync();

var article = ctx.Articles.Single(a => a.Id == 2);
//left join
var a3 = ctx.Articles.Include(a => a.Comments).Single(a => a.Id == 2);
Console.WriteLine(a3.Content);
foreach (var cmt in article.Comments)
{
    Console.WriteLine(cmt.Id + "," + cmt.Message);
}

// inner join
var comment = ctx.Comments.Include(a => a.Article).Single(c => c.Id == 4);
Console.WriteLine(comment.Article.Title);

var a4 = ctx.Articles.Single(b => b.Id == 2);

// select Id,Title from table;
var a5 = ctx.Articles.Select(a => new { a.Id, a.Title }).First();
Console.WriteLine(a5.Title, "+", a5.Id);

/*    
SELECT TOP(2) [t].[Id], [t].[Name]
FROM [T_Users] AS [t]
WHERE [t].[Name] = N'绵 绵
*/

User u = await ctx.Users.SingleOrDefaultAsync(u => u.Name == "绵绵");

/*
SELECT[t].[Id], [t].[ApproverId], [t].[From], [t].[Remark], [t].[RequesterId], [t].[Status], [t].[To]
FROM[T_Applies] AS[t]
      INNER JOIN[T_Users] AS [t0] ON[t].[RequesterId] = [t0].[Id]
      WHERE 0 = 1
*/

foreach (var user in ctx.Applies.Where(a=>a.Requester == u))
{
    Console.WriteLine(user.Remark);
}

Console.WriteLine("i will cherish tomorrow without you");
Console.Read();