using PetAdoptionPortal.Models;

namespace PetAdoptionPortal.Data
{
    // Adds sample data the first time the app runs (only if the Pets table is empty)
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Pets.Any()) return;

            var today = DateTime.Today;

            var bruno = new Pet { Name = "Bruno", Species = "Dog", Breed = "Labrador", AgeInMonths = 18, Gender = "Male", Description = "Friendly and energetic. Loves fetch and long walks. Good with children.", DateAdded = today.AddDays(-10) };
            var luna = new Pet { Name = "Luna", Species = "Cat", Breed = "Persian", AgeInMonths = 8, Gender = "Female", Description = "Calm, fluffy and loves to cuddle on the sofa.", DateAdded = today.AddDays(-8) };
            var coco = new Pet { Name = "Coco", Species = "Rabbit", Breed = "Dutch", AgeInMonths = 6, Gender = "Female", Description = "Curious little bunny. Enjoys carrots and hopping around the garden.", DateAdded = today.AddDays(-6) };
            var mango = new Pet { Name = "Mango", Species = "Bird", Breed = "Budgerigar", AgeInMonths = 24, Gender = "Male", Description = "Cheerful and chatty. Can already whistle a few tunes.", DateAdded = today.AddDays(-5) };
            var max = new Pet { Name = "Max", Species = "Dog", Breed = "Indian Pariah", AgeInMonths = 36, Gender = "Male", Description = "Loyal, healthy and street-smart. A perfect guard and a loving companion.", DateAdded = today.AddDays(-4) };
            var whiskers = new Pet { Name = "Whiskers", Species = "Cat", Breed = "Indian Domestic Shorthair", AgeInMonths = 4, Gender = "Female", Description = "Playful kitten who chases anything that moves.", DateAdded = today.AddDays(-2) };
            var simba = new Pet { Name = "Simba", Species = "Cat", Breed = "Orange Tabby", AgeInMonths = 14, Gender = "Male", Description = "Found a loving home last month!", Status = PetStatus.Adopted, DateAdded = today.AddDays(-40) };

            db.Pets.AddRange(bruno, luna, coco, mango, max, whiskers, simba);
            db.SaveChanges();

            db.VaccinationRecords.AddRange(
                new VaccinationRecord { PetId = bruno.Id, VaccineName = "Rabies", DateGiven = today.AddDays(-60), NextDueDate = today.AddDays(305), Notes = "Annual booster" },
                new VaccinationRecord { PetId = bruno.Id, VaccineName = "DHPP", DateGiven = today.AddDays(-90), NextDueDate = today.AddDays(-5), Notes = "Booster is overdue" },
                new VaccinationRecord { PetId = luna.Id, VaccineName = "FVRCP", DateGiven = today.AddDays(-30), NextDueDate = today.AddDays(335) },
                new VaccinationRecord { PetId = max.Id, VaccineName = "Rabies", DateGiven = today.AddDays(-20), NextDueDate = today.AddDays(345) },
                new VaccinationRecord { PetId = max.Id, VaccineName = "Deworming", DateGiven = today.AddDays(-20), NextDueDate = today.AddDays(10), Notes = "Every 3 months" }
            );

            db.AdoptionApplications.Add(new AdoptionApplication
            {
                PetId = bruno.Id,
                ApplicantName = "Sneha Joshi",
                Email = "sneha@example.com",
                Phone = "9876501234",
                City = "Surat",
                Reason = "We have a big garden and a 10 year old who has wanted a dog for years.",
                HasOtherPets = false,
                AppliedOn = DateTime.Now.AddDays(-1)
            });

            db.SaveChanges();
        }
    }
}
