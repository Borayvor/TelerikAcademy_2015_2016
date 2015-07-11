namespace E01_ClassChefInCSharp
{
    using System;

    public class Chef
    {
        private KitchenUtensils bowl;

        public void Cook(Vegetable currentVegetable)
        {            
            bowl = GetBowl();

            currentVegetable = Cut(currentVegetable);
            currentVegetable = Peel(currentVegetable);

            bowl.Add(currentVegetable);
        }
        
        private KitchenUtensils GetBowl()
        {
            return new KitchenUtensils("bowl");
        }

        private Vegetable Peel(Vegetable vegetableObject)
        {
            if (!vegetableObject.IsPeeled)
            {                
                vegetableObject.IsPeeled = true;
            }

            return new Vegetable(vegetableObject);
        }

        private Vegetable Cut(Vegetable vegetableObject)
        {
            if (vegetableObject.IsRotten)
            {
                vegetableObject.IsRotten = false;
            }

            return new Vegetable(vegetableObject);
        }
    }
}
