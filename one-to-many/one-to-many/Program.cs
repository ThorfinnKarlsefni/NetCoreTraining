// See https://aka.ms/new-console-template for more information
using one_to_many;

Console.WriteLine("Hello, World!");

await using MyDbContext ctx = new MyDbContext();
//var a1 = new Article();
//a1.Content = "life's little bit messy.we all make mistake\",Title =\"忘记时间";
//a1.Title = "忘记时间";
//Comment c1 = new Comment() { Message = "我会好好珍惜没有你的明天" };
//Comment c2 = new Comment() { Message = "i will cherish tomorrow without you" };

var a1 = new Article
{
    Content = "大概你的体重 会抱我造梦",
    Title = "绵绵",
    Comments  = new List<Comment>
    {
        new Comment { Message = "从来未爱你" },
        new Comment { Message = "从来未爱你" },
    }
};

ctx.Articles.Add(a1);
await ctx.SaveChangesAsync();
Console.WriteLine("i will cherish tomorrow without you");