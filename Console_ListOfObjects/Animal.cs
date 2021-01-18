using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    class Animal
    {

        //Fields
        public enum AnimalDiet
        {
            none,
            carnivore,
            herbivore,
            omnivore
        }

        private AnimalDiet _diet;
        private string _animalName;
        private string _speciesName;
        private int _animalAge;
        private bool _isMammal;
        //private List<string> _favoriteZookeepers;


        //Properties
        public AnimalDiet Diet
        {
            get { return _diet; }
            set { _diet = value; }
        }

        public string AnimalName
        {
            get { return _animalName; }
            set { _animalName = value; }
        }

        public string SpeciesName
        {
            get { return _speciesName; }
            set { _speciesName = value; }
        }

        public int AnimalAge
        {
            get { return _animalAge; }
            set { _animalAge = value; }
        }

        public bool Mammal
        {
            get { return _isMammal; }
            set { _isMammal = value; }
        }
        //public List<string> Zookeepers
        //{
        //    get { return _favoriteZookeepers; }
        //    set { _favoriteZookeepers = value; }
        //}



        //Contructors
        //Default Constructor - lists, dictionaries 
        public Animal()
        {
            //instantiate 
            //_favoriteZookeepers = new List<string>();
        }

        //Constructor with parameters 
        public Animal(AnimalDiet diet, string animalname, string speciesname, int animalage, bool mammal)
        {
            //setting field values
            _diet = diet;
            _animalName = animalname;
            _speciesName = speciesname;
            _animalAge = animalage;
            _isMammal = mammal;

            //instantiate 
            //_favoriteZookeepers = new List<string>();
        }

        //Methods
        
    }
}
