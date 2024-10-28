public class ArrayExample2 {
public static void main (String args[]){
int ages[]={20,22,18,35,48,26,87,70};
int lowestage= ages[0];
for (int age: ages){
if (lowestage>age)
lowestage=age;
}
System.out.println("lowest age is "+lowestage);
}
}