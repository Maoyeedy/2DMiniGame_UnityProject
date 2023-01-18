using UnityEngine;

public class New : MonoBehaviour
{
    //new 隐藏基类的同名函数
    //myAnimal myBird 输出不同结果；
    //用base.PrintInfo()以在派生类调用基类函数
    public class Animal
    {
        public float Speed;
        public string Name;

        public void PrintInfo()
        {
            print($"{Name} is moving at {Speed} km/h");
        }
    }

    private class Bird : Animal
    {
        public new void PrintInfo()
        {
            print($"{Name} is flying at {Speed} km/h");
        }
    }

    private void Start()
    {
        var myBird = new Bird { Name = "Jesse", Speed = 80 };
        Animal myAnimal = myBird;
        myBird.PrintInfo();
        myAnimal.PrintInfo();
    }
}