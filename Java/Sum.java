public class Sum{
public static void main(String args[]){
int myArray[]={1,2,3,4,5};
int sum=0;
int length=myArray.length;
for (int i=0;i<length;i++) {
sum=sum+myArray[i]; }
System.out.println("Sum is "+ sum);
}
}