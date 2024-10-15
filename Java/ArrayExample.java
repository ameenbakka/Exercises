// program of Array example
/* program of Array example */
public class ArrayExample{
public static void main(String[] args){
int[] numbers={10,20,30,40,50};
for(int i=0; i < numbers.length; i++)
System.out.println("Element at index"+ i +":"+ numbers[i]);

for(int n: numbers){
System.out.println(n);

}
}
}