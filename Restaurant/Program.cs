using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Repository;

namespace Restaurant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   /*
            Repository<User> userRepo = new UserRepository();
            Repository<Food> foodRepo = new FoodRepository();
            Repository<Restaurant> restaurantRepo = new RestaurantRepository();
            Repository<Orders> ordersRepo = new OrdersRepository();
            Service.Service service = new Service.Service(restaurantRepo, userRepo, foodRepo, ordersRepo);
            UserInterface.UserInterface ui = new UserInterface.UserInterface(service);
            ui.testMethod();*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}