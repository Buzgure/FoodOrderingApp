using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Repository;

namespace Restaurant.Service
{
    public class Service
    {
        private Repository<Restaurant> restaurantRepo;
        private Repository<User> userRepo;
        private Repository<Food> foodRepo;
        private Repository<Orders> ordersRepo;


        public Service()
        {
        }

        public Service(Repository<Restaurant> restaurantRepo, Repository<User> userRepo, Repository<Food> foodRepo,
            Repository<Orders> ordersRepo)
        {
            this.restaurantRepo = restaurantRepo;// ?? throw new ArgumentNullException(nameof(restaurantRepo));
            this.userRepo = userRepo;
            this.foodRepo = foodRepo;// ?? throw new ArgumentNullException(nameof(foodRepo));
            this.ordersRepo = ordersRepo;// ?? throw new ArgumentNullException(nameof(ordersRepo));
        }
        
        


        public Repository<Restaurant> RestaurantRepo
        {
            get => restaurantRepo;
            set => restaurantRepo = value;
        }

        public Repository<User> UserRepo
        {
            get => userRepo;
            set => userRepo = value;
        }

        public Repository<Food> FoodRepo
        {
            get => foodRepo;
            set => foodRepo = value;
        }

        public Repository<Orders> OrdersRepo
        {
            get => ordersRepo;
            set => ordersRepo = value;
        }

        public void Deconstruct(out Repository<Restaurant> restaurantRepo, out Repository<User> userRepo, out Repository<Food> foodRepo, out Repository<Orders> ordersRepo)
        {
            restaurantRepo = this.restaurantRepo;
            userRepo = this.userRepo;
            foodRepo = this.foodRepo;
            ordersRepo = this.ordersRepo;
        }

        public User UserAdd(User user)
        {
            int maxID = getMaxID() + 1;
            user.UserId = maxID;
            try
            {
                return userRepo.save(user);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }


        }

        public User UserDelete(User user)
        {
            try
            {
                return userRepo.delete(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public User UserUpdate(User user)
        {
            try
            {
                return userRepo.update(user);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }

        public List<User> getAllUsers()
        {
            //userRepo.findAll();
            List<User> users = userRepo.findAll().ToList();
            try
            {
                return users;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }

        public int getMaxID()
        {
            List<User> users = userRepo.findAll().ToList();
            int maxID = 0;
            foreach (User u in users)
            {
                if (u.UserId > maxID)
                    maxID = u.UserId;
            }

            return maxID;


        }

        public List<Food> getFoodList()
        {
            List<Food> foodList = foodRepo.findAll().ToList();
            try
            {
                return foodList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Orders addOrder(Orders order)
        {
            try
            {
                return ordersRepo.save(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Orders deleteOrder(Orders order)
        {
            try
            {
                return ordersRepo.delete(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Orders updateOrder(Orders order)
        {
            try
            {
                return ordersRepo.update(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public List<Orders> getAllOrders()
        {
            try
            {
                return ordersRepo.findAll().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public int getMaxIDOrder()
        {
            List<Orders> orders = ordersRepo.findAll().ToList();
            int maxID = 0;
            foreach (Orders o in orders)
            {
                if (o.OrderId > maxID)
                    maxID = o.OrderId;
            }

            return maxID;

        }

        public List<Orders> findOrdersByUser(int userID)
        {
            List<Orders> allOrders = getAllOrders();
            List<Orders> desiredOrders = new List<Orders>();
            foreach (var o in allOrders)
            {
                if (o.UserId == userID)
                {
                    desiredOrders.Add(o);
                }
            }

            return desiredOrders;
        }
    }
}