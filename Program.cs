using _17._06_ADO.Models;
//Culture (Production)
//ProductDescription (Production)

using (AdventureWorks2019Context context = new AdventureWorks2019Context())
{
    // add
    // 
    int cultIdForRemove = context.Cultures.Count() + 7;
    context.Cultures.Add(new Culture() { CultureId = cultIdForRemove.ToString(), ModifiedDate = DateTime.Now, Name = $"Ukrainian{cultIdForRemove}" });
    context.ProductDescriptions.Add(new ProductDescription() { Description ="123", ModifiedDate=DateTime.Now, Rowguid=new Guid()});
    context.SaveChanges();

    // remove
    
    string descForRemove = "123";
    string strIdForUpdate = "th";
    context.Cultures.Remove(context.Cultures.FirstOrDefault(x => x.CultureId.Equals(cultIdForRemove.ToString())));
    context.ProductDescriptions.Remove(context.ProductDescriptions.FirstOrDefault(x => x.Description.Equals(descForRemove)));
    context.SaveChanges();

    //          update
    int idForUpdate = 2022;
    var oldData = context.ProductDescriptions.FirstOrDefault(x => x.ProductDescriptionId.Equals(idForUpdate));
    oldData.Description = "Updated description";
    context.ProductDescriptions.Update(oldData);
    context.SaveChanges();

    var oldCultureData = context.Cultures.FirstOrDefault(x => x.CultureId.Equals(strIdForUpdate));
    oldCultureData.Name = "Updated name";
    context.Cultures.Update(oldCultureData);
    context.SaveChanges();

    foreach(Culture c in context.Cultures)
    {
        Console.WriteLine(c);
    }
    int i = 0;
    foreach(ProductDescription p in  context.ProductDescriptions)
    {
        Console.WriteLine(p);
        i++;
        if (i == 9) break;
    }
}