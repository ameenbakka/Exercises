public class Duplicate{
public static void main(String args[]){
int myArray[]={1,2,2,3,4,4,5};
int length= myArray.length;
System.out.println("Duplicate Elements are :");
for(int i=0;i<length;i++)
{
for(int j=i+1;j<length;j++)
{
if(myArray[i]==myArray[j]){
System.out.println(myArray[i]);
break;}
}
}
}
}

