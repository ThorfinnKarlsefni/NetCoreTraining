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

foreach (var user in ctx.Applies.Where(a => a.Requester == u))
{
    Console.WriteLine(user.Remark);
}

// insert data

User u1 = new User { Name = "Cheung" };
Apply apply = new Apply();
apply.Requester = u1;
apply.From = new DateTime(2021, 3, 23);
apply.To = new DateTime(2022, 2, 28);
apply.Remark = "你这点工资让我很难办啊";
apply.Status = 0;
ctx.Users.Add(u1);
ctx.Applies.Add(apply);
await ctx.SaveChangesAsync();



OrgUnit orgRoot = new OrgUnit { Name = "top Song" };
OrgUnit orgAsia = new OrgUnit { Name = "Asia" };
orgAsia.Parent = orgRoot;
orgRoot.Children.Add(orgAsia);
OrgUnit orgSong6 = new OrgUnit { Name = "Unknown" };
orgSong6.Parent = orgAsia;
orgAsia.Children.Add(orgSong6);

OrgUnit orgChina = new OrgUnit { Name = "China" };
orgChina.Parent = orgRoot;
orgRoot.Children.Add(orgChina);
OrgUnit orgSong3 = new OrgUnit { Name = "绵绵" };
OrgUnit orgSong4 = new OrgUnit { Name = "忘记时间" };
orgSong3.Parent = orgChina;
orgSong4.Parent = orgChina;
orgChina.Children.Add(orgSong3);
orgChina.Children.Add(orgSong4);

OrgUnit orgCan = new OrgUnit { Name = "Canada" };
orgCan.Parent = orgRoot;
OrgUnit orgSong5 = new OrgUnit { Name = "Unknown" };
orgSong5.Parent = orgCan;
orgRoot.Children.Add(orgCan);
orgCan.Children.Add(orgSong5);

OrgUnit orgUsa = new OrgUnit { Name = "United States" };
orgUsa.Parent = orgRoot;
orgRoot.Children.Add(orgUsa);
OrgUnit orgSong = new OrgUnit { Name = "see you agin" };
OrgUnit orgSong1 = new OrgUnit { Name = "i really like you" };
OrgUnit orgSong2 = new OrgUnit { Name = "Ferrari" };
orgSong.Parent = orgUsa;
orgSong1.Parent = orgUsa;
orgSong2.Parent = orgUsa;
orgUsa.Children.Add(orgSong);
orgUsa.Children.Add(orgSong1);
orgUsa.Children.Add(orgSong2);


ctx.OrgUnits.Add(orgRoot);
await ctx.SaveChangesAsync();

// 地址和订单其实是一对多的关系
// 这里是一对一 
Order order = new Order();
order.Name = "IPhone 13 pro";
Addresses address = new Addresses();
address.Address = "皇后大道东";
address.Order = order;
ctx.Addresses.Add(address);
await ctx.SaveChangesAsync();

Order order1 = await ctx.Orders.Include(a => a.Addresses)
    .FirstAsync(o => o.Name.Contains("IPhone 13 pro"));
Console.WriteLine($"名称:{order1.Name},地址:{order1.Addresses.Address}");

Console.WriteLine("i will cherish tomorrow without you");
Console.Read();