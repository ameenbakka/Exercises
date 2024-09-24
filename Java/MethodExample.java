import java.util.Scanner;

public class MethodExample{
static void myMethod(){
System.out.println("I just got excuted");}
static void myMethod2(String fname){
System.out.println(fname+"Sahil");}
static int myMethod3(int x){
return x+5;}
public static void main(String args[]){
Scanner s= new Scanner(System.in);
System.out.println("Enter you choice :");
int d = s.nextInt();
switch(d){
case 1: myMethod();
break;
case 2: myMethod2("Ameen");
break;
case 3:System.out.println(myMethod3(3));
break;
default : System.out.println("Invalid input");
}
}
}