using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Model
{
    public static class GetData
    {
        public static List<Author> GetAuthors() => new List<Author>()
            {
                new Author(){FirstName="Akhmadjon",LastName="Jurayev",Emailaddress="formyproject1999@gmail.com",PhoneNumber="+998946644275",DialyNews=true},
                new Author(){FirstName="Yakhyo",LastName="Abdualimov",Emailaddress="chunchakiadres@gmail.com",PhoneNumber="+998903239974"},
                new Author(){FirstName="Najmiddin",LastName="Najirov",Emailaddress="nazirov97@gmail.com",PhoneNumber="+998915479900"},
                new Author(){FirstName="Jurabek",LastName="Rahmonov",Emailaddress="rahmonov@gmail.com",PhoneNumber="+998945059989"},
                new Author(){FirstName="Akmal",LastName="Otaboboyev",Emailaddress="akmal.otaboboyev@gmail.com",PhoneNumber="+998903346467"}
            };
        public static List<Category> GetCategory() => new List<Category>()
        {
            new Category(){Type="critic"},
            new Category(){Type="politic"},
            new Category(){Type="comedy"},
            new Category(){Type="scientific"},
            new Category(){Type="current"},
            new Category(){Type="sport"},
            new Category(){Type="programming"}
        };
        public static List<Quote> GetQuotes() => new List<Quote>()
        {
            new Quote(){Author_id=2,Entered_Date=DateTime.Parse("12-02-2020"),Text="c# dasturlash tili .net esa framework hisoblanadi"},
            new Quote(){Author_id=2,Entered_Date=DateTime.Parse("12-01-2021"),Text="ingiliz tili hozirda yoshlar orasida keng tarqalmoqda"},
            new Quote(){Author_id=3,Entered_Date=DateTime.Parse("18-02-2021"),Text="barselona va real madrid kulublari oxirgi yillarda yulduzli oyinchilari kamaygani sababidan kuchi sezilarli ravishda kamaydi"},
            new Quote(){Author_id=3,Entered_Date=DateTime.Parse("13-04-2021"),Text="oxirgi 5 - 6 oy davomida bitcoinni narhi sezilarli ravishda o'smoqa"}
        };
        public static List<Category_Quote> GetCategory_Quotes() => new List<Category_Quote>()
        {
            new Category_Quote(){Quote_Id=20,Category_Id=13},
            new Category_Quote(){Quote_Id=20,Category_Id=16},
            new Category_Quote(){Quote_Id=21,Category_Id=13},
            new Category_Quote(){Quote_Id=22,Category_Id=10},
            new Category_Quote(){Quote_Id=22,Category_Id=15},
            new Category_Quote(){Quote_Id=23,Category_Id=10},
            new Category_Quote(){Quote_Id=23,Category_Id=14},
            new Category_Quote(){Quote_Id=23,Category_Id=14},
        };
    }
}
