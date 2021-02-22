using System;

namespace oop_week2_carpark
{
    class Program
    {
        static double income;

        public class customer
        {
            public string Name { get; set; }
            public DateTime Entry { get; set;}
            public double Amount { get; set; }

            public override string ToString()
            {
                return $"Customer : {Name}, Date_of_entry : {Entry}, Amount_to_pay : {Amount} euros";
            }
        }

        public static double calculateCharges(customer customer)
        {
            DateTime now = DateTime.Now;
            int Hour = now.Hour;
            double money = 2;
            if(customer.Entry.Date == now.Date)
            {
                int r = now.Hour - customer.Entry.Hour;
                if(r < 3){income += money; return money;}
                for(;r > 3;r--){
                    money += 0.5;
                }
            }
            else
            {
                if(customer.Entry.Hour < now.Hour){income += 10;return 10;}
                int r = (24 - customer.Entry.Hour) + now.Hour;
                for(;r > 3;r--){
                    money += 0.5;
                }
            }
            if(money > 10){money = 10;}
            income += money;
            return money;
        }

        static void Main(string[] args)
        {
            Console.WriteLine();

            DateTime date1 = new DateTime(2021,2,21,15,0,0);
            customer customer1 = new customer(){Name = "Alexis", Entry = date1,Amount = 0};
            customer1.Amount = calculateCharges(customer1);

            DateTime date2 = new DateTime(2021,2,21,10,0,0);
            customer customer2 = new customer(){Name = "Henri", Entry = date2,Amount = 0};
            customer2.Amount = calculateCharges(customer2);

            DateTime date3 = new DateTime(2021,2,20,22,0,0);
            customer customer3 = new customer(){Name = "Lou", Entry = date3,Amount = 0};
            customer3.Amount = calculateCharges(customer3);
        }
    }
}
