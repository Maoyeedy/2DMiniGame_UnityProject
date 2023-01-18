using UnityEngine;

public class Abstract : MonoBehaviour
{
    public abstract class Animal
    {
        public float Speed;
        public string Name;

        public abstract void PrintInfo();
    }

    public class Bird : Animal
    {
        public override void PrintInfo()
        {
            print($"{Name} is flying at {Speed} km/h");
        }
    }


    private void Start()
    {
        Animal myAnimal = new Bird { Name = "Jesse", Speed = 80 };
        myAnimal.PrintInfo();
    }
}