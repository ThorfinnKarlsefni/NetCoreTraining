
using EFCore;

await using (MyDbContext ctx = new MyDbContext())
{
    // add data

    var b1 = new Book { AuthorName = "阿桑", Price = 1223, PubTime = new DateTime(2023, 11, 21), Titile = "给你的爱一直很安静" };
    ctx.Add(b1);
    await ctx.SaveChangesAsync();
    var b2 = new Book { AuthorName = "杨杨杨", Price = 1223, PubTime = new DateTime(2023, 11, 21), Titile = "给你的爱一直很安静" };
    ctx.Add(b1);
    await ctx.SaveChangesAsync();

    // select query
    var books = ctx.Books.Where(b => b.AuthorName == "彭于晏");
    var items = ctx.Books.Where(b => b.Price > 10).GroupBy(b => b.AuthorName);
    var itemss = ctx.Books.GroupBy(b => b.PubTime).Select(g => new { PubTime = g.Key, BookCount = g.Count(), Price = g.Max(b => b.Price), Title = g.First().Titile });
    foreach (var item in items)
    {
        //Console.WriteLine(item.Key);
        Console.WriteLine(item);
    }

    // update

    var item = ctx.Books.Single(b => b.AuthorName.Contains("羊"));
    item.AuthorName = "羊绒111";
    await ctx.SaveChangesAsync();

    // remove

    var item = ctx.Books.Single(b => b.AuthorName.EndsWith("111"));
    ctx.Remove(item);
    await ctx.SaveChangesAsync();

    Console.ReadKey();

}
