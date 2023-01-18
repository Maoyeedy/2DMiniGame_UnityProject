using UnityEngine;

public class Virtual : MonoBehaviour
{
    //对于Virtual虚方法，如果在派生类没有override重写，则会调用基类的方法。
    public class Animal
    {
        public float Speed;
        public string Name;

        public virtual void PrintInfo()
        {
            print($"{Name} is moving at {Speed} km/h");
        }
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