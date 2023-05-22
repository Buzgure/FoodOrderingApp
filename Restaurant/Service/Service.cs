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
    }
}