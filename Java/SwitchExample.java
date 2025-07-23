import java.util.Scanner;
public class SwitchExample {
public static void main(String[] args) {
Scanner S = new Scanner(System.in);
System.out.println("enter a number");
int x=S.nextInt();
System.out.println(x);

switch(x)
{
case 1: if (x>5)
{ System.out.println("x is greater");}
break;
case 2 : if(x<5){
System.out.println("x is smaller");}
break;
default : System.out.println("Invalid input");
}
}
}
