public class Car extends Vehicle {
int wheels = 4;
public static void main(String args[]){
Vehicle vehicle = new Vehicle();
Car car = new Car();
System.out.println(car.wheels);
vehicle.display();
}
}