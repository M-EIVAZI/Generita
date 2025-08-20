using Bogus;

using Generita.Application.Common.Interfaces;
using Generita.Domain.Common.Enums;
using Generita.Domain.Enums;
using Generita.Domain.Models;
using Generita.Domain.ValueObjects;
using Generita.Infrustructure.Persistance;

namespace Generita.Api
{
    public  static class FakeDataGenerator
    {
        public static void GenerateData(GeneritaDbContext dbContext,IPasswordHasher passwordHasher)
        {
            var categories = new[] { "Fiction", "Science", "History", "Philosophy", "Art", "Biography" };

            var bookCategoryFaker = new Faker<BookCategory>()
                .CustomInstantiator(f => new BookCategory(Guid.NewGuid()))
                .RuleFor(c => c.CategoryName, f => f.PickRandom(categories));
            var bookCategories = bookCategoryFaker.Generate(6); 
            var authorFaker = new Faker<Author>()
                .CustomInstantiator(f => new Author(Guid.NewGuid()))
                .RuleFor(a => a.Name, f => new Name(f.Person.FirstName, f.Person.LastName))
                .RuleFor(a => a.BirthDate, f => DateOnly.FromDateTime(f.Date.Past(80, DateTime.Now.AddYears(-18)))) 
                .RuleFor(a => a.age, (f, a) => DateTime.Now.Year - a.BirthDate.Year)
                .RuleFor(a => a.Nationality, f => f.Address.Country());
            var authors = authorFaker.Generate(10); 
            var bookAccessValues = Enum.GetValues(typeof(BookAccess)).Cast<BookAccess>().ToArray();

            var bookFaker = new Faker<Book>()
                .CustomInstantiator(f => new Book(Guid.NewGuid()))
                .RuleFor(b => b.Title, f => f.Commerce.ProductName())
                .RuleFor(b => b.PublishedDate, f => DateOnly.FromDateTime(f.Date.Past(50)))
                .RuleFor(b => b.AuthorId, f => f.PickRandom(authors).Id)       
                .RuleFor(b => b.CategoryId, f => f.PickRandom(bookCategories).Id)  
                .RuleFor(b => b.Synopsis, f => f.Lorem.Paragraph())
                .RuleFor(b => b.Cover, f => f.Image.PicsumUrl(200, 300))
                .RuleFor(b => b.Access, f => f.PickRandom(bookAccessValues))
                .RuleFor(b => b.FilePath, f => f.Internet.Url())
                .RuleFor(b => b.ImagePath, f => f.Internet.Url());
            var books = bookFaker.Generate(10);
            var planNames = new[] { "Basic", "Standard", "Premium", "Student", "Family" };

            var plansFaker = new Faker<Plans>()
                .CustomInstantiator(f => new Plans(Guid.NewGuid()))
                .RuleFor(p => p.Name, f => f.PickRandom(planNames))
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(5, 8))
                .RuleFor(p => p.Price, f => f.Random.Int(100000, 300000)) 
                .RuleFor(p => p.Duration, f => f.Random.Int(7, 365));
            var plans=plansFaker.Generate(4);
            var hashedPasswordResult = passwordHasher.HashPassword("M@hdi1382");

            if (hashedPasswordResult.IsError)
            {
                throw new Exception("Password hashing failed: " + hashedPasswordResult.FirstError.Description);
            }

            var hashedPassword = hashedPasswordResult.Value;
            var userFaker = new Faker<User>()
                .CustomInstantiator(f => new User(Guid.NewGuid()))
                .RuleFor(u => u.Name, f => f.Person.FullName)
                .RuleFor(u => u.CreateAt, f => f.Date.Past(2).ToUniversalTime())
                .RuleFor(u => u.UpdateAt, (f, u) => u.CreateAt.AddMinutes(f.Random.Int(1, 1000)).ToUniversalTime())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Password, f => hashedPassword);
            var users = userFaker.Generate(5);

            var transactionStates = Enum.GetValues(typeof(States)).Cast<States>().ToArray();

            var transactionsFaker = new Faker<Transactions>()
                .CustomInstantiator(f => new Transactions(Guid.NewGuid()))
                .RuleFor(t => t.UserId, f => f.PickRandom(users).Id)    
                .RuleFor(t => t.PlanId, f => f.PickRandom(plans).Id)
                .RuleFor(t => t.CreateAt, f => f.Date.Recent(90).ToUniversalTime())
                .RuleFor(t => t.Price, (f, t) => plans.First(p => p.Id == t.PlanId).Price)
                .RuleFor(t => t.States, f => f.PickRandom(transactionStates));
            var transactions = transactionsFaker.Generate(50);


            var userbookfaker = new Faker<UserBook>()
                .CustomInstantiator(f => new UserBook(Guid.NewGuid()))
                .RuleFor(x => x.AddedAt, f => f.Date.Recent().ToUniversalTime())
                .RuleFor(x => x.UserId, f => f.PickRandom(users).Id)
                .RuleFor(x => x.BookId, f => f.PickRandom(books).Id);
            var userbooks = userbookfaker.Generate(20);

            var ownerShipValues = Enum.GetValues(typeof(OwnerShip)).Cast<OwnerShip>().ToArray();

            var songFaker = new Faker<Songs>()
                .CustomInstantiator(f => new Songs(Guid.NewGuid()))
                .RuleFor(s => s.Name, f => f.Lorem.Sentence(2, 3)) 
                .RuleFor(s => s.Duration, f => TimeSpan.FromSeconds(f.Random.Int(120, 360)))
                .RuleFor(s => s.CreateAt, f => f.Date.Past(2).ToUniversalTime())
                .RuleFor(s => s.UpdateAt, (f, s) => s.CreateAt.AddDays(f.Random.Int(0, 200)).ToUniversalTime())
                .RuleFor(s => s.FilePath, f => f.Internet.UrlWithPath("https", "example.com", $"songs/{f.Random.Guid()}.mp3"))
                .RuleFor(s => s.Owner, f => f.PickRandom(ownerShipValues));
            var songs = songFaker.Generate(10);
            var ageClassesValues = Enum.GetValues(typeof(AgeClasses)).Cast<AgeClasses>().ToArray();
            var musicSenseValues = Enum.GetValues(typeof(MusicSense)).Cast<MusicSense>().ToArray();

            var paragraphFaker = new Faker<Paragraph>()
                .CustomInstantiator(f => new Paragraph(Guid.NewGuid()))
                .RuleFor(p => p.Text, f => f.Lorem.Paragraph(3))
                .RuleFor(p => p.AgeClass, f => f.PickRandom(ageClassesValues))
                .RuleFor(p => p.MusicSense, f => f.PickRandom(musicSenseValues))
                .RuleFor(p => p.BookId, f => f.PickRandom(books).Id)
                .RuleFor(p => p.SongId, f => f.PickRandom(songs).Id);

            var paragraphs= paragraphFaker.Generate(20);
            var entityTypes = new[] { "Character", "Place", "Event", "Object", "Symbol" };

            var entityFaker = new Faker<Entity>()
                .CustomInstantiator(f => new Entity(Guid.NewGuid()))
                .RuleFor(e => e.type, f => f.PickRandom(entityTypes))
                .RuleFor(e => e.sample, f => f.Lorem.Sentence(3))
                .RuleFor(e => e.Position, f => f.Random.Int(1, 100))
                .RuleFor(e => e.ParagraphId, f => f.PickRandom(paragraphs).Id) 
                .RuleFor(e => e.MusicId, f => f.PickRandom(songs).Id);
            var entities = entityFaker.Generate(10);
            dbContext.BookCategory.AddRange(bookCategories);
            dbContext.Author.AddRange(authors);
            dbContext.SaveChanges();

            dbContext.Book.AddRange(books);
            dbContext.SaveChanges();

            dbContext.Plans.AddRange(plans);
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();

            dbContext.Transactions.AddRange(transactions);
            dbContext.SaveChanges();

            dbContext.Songs.AddRange(songs);
            dbContext.SaveChanges();

            dbContext.Paragraph.AddRange(paragraphs);
            dbContext.SaveChanges();

            dbContext.Entity.AddRange(entities);
            dbContext.SaveChanges();

            dbContext.UsersBook.AddRange(userbooks);
            dbContext.SaveChanges();
            }






        }
    }

