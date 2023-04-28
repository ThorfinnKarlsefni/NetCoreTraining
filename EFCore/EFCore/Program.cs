
using EFCore;
using Microsoft.EntityFrameworkCore;

await using (MyDbContext ctx = new MyDbContext())
{
    // add data

    var b1 = new Book { AuthorName = "阿桑", Price = 1223, PubTime = new DateTime(2023, 11, 21), Titile = "给你的爱一直很安静" };
    ctx.Add(b1);
    await ctx.SaveChangesAsync();
    var b2 = new Book { AuthorName = "杨杨杨", Price = 1223, PubTime = new DateTime(2023, 11, 21), Titile = "给你的爱一直很安静" };
    ctx.Add(b2);
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

    var update = ctx.Books.Single(b => b.AuthorName.Contains("羊"));
    update.AuthorName = "羊绒111";
    await ctx.SaveChangesAsync();

    // remove

    var remove = ctx.Books.Single(b => b.AuthorName.EndsWith("111"));
    ctx.Remove(remove);
    await ctx.SaveChangesAsync();

    //test brids data annotation
    var brids = new Brid { CreateAt = new DateTime(2033, 11, 22) };
    ctx.Add(brids);
    await ctx.SaveChangesAsync();

    //test

    var test = new Test { Name = "weiwei" };
    ctx.Add(test);
    await ctx.SaveChangesAsync();

    var book = new Book { AuthorName = "Ferrair", mins = "40", PubTime = new DateTime(2022, 11, 23), Price = 12.30, lyric = "we all make mistakes", Titile = "清白之年" };
    Console.WriteLine(book.Id);
    ctx.Add(book);
    await ctx.SaveChangesAsync();
    Console.WriteLine(book.Id);

    //guid primary guid 算法是根据mac地址和时钟、网卡生成的全局唯一
    //缺点: 磁盘占用空间大
    //guid 不连续 使用guid做主键的时候 不能把主键设置为聚集索引
    //因为聚集索引是按照顺序的保存主键 因此用guid性能差
    //比如mysql的InnoDb主键是强制使用聚集索引的
    // 有的数据库支持部分连续的guid 比如sql server
    // 在sql server中 不要把guid主键设置为聚集索引
    // 在mysql中插入频繁不要使用guid做主键

    // add guid

    var rabbit = new Rabbit { Name = "jonb" };
    rabbit.Id = new Guid();
    Console.WriteLine(rabbit.Id);
    ctx.Add(rabbit);
    await ctx.SaveChangesAsync();

    // select only
    var str = ctx.Books.Where(b=>b.AuthorName == "清白之年");
    Console.WriteLine(str.ToQueryString());
    Console.ReadKey();

}
